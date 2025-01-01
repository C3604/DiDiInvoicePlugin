Imports System.IO
Imports Microsoft.Office.Interop.Outlook
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Threading.Tasks
Imports System.Runtime.InteropServices

Module ProcessArchive
    Private configFilePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OutlookPlugin\DiDiInvoice\DiDiInvoice.ini")
    Public DestinationFolder As String
    Public ClientId As String
    Public ClientSecret As String
    Public DebugMode As Boolean
    Public TempFolderPath As String

    <DllImport("user32.dll", SetLastError:=True)>
    Private Function FindWindow(lpClassName As String, lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Function SetForegroundWindow(hWnd As IntPtr) As Boolean
    End Function

    Private Sub ActivateOrOpenFolder(folderPath As String)
        Dim folderName As String = Path.GetFileName(folderPath.TrimEnd(Path.DirectorySeparatorChar))
        Dim hWnd As IntPtr = FindWindow("CabinetWClass", folderName)
        If hWnd <> IntPtr.Zero Then
            SetForegroundWindow(hWnd)
        Else
            Process.Start("explorer.exe", folderPath)
        End If
    End Sub

    Public Sub CheckMailAttachments()
        ' 读取选中邮件的“EntryID”属性
        Dim outlookApp As New Microsoft.Office.Interop.Outlook.Application()
        Dim explorer As Explorer = outlookApp.ActiveExplorer()
        Dim selection As Selection = explorer.Selection

        If selection.Count = 0 Then
            Throw New InvalidOperationException("未选中任何邮件。")
        End If

        Dim mailItem As MailItem = TryCast(selection.Item(1), MailItem)
        If mailItem Is Nothing Then
            Throw New InvalidOperationException("选中的项目不是邮件。")
        End If

        ' 检查附件是否包含“滴滴出行行程报销单.pdf”
        Dim attachmentFound As Boolean = False
        For Each attachment As Attachment In mailItem.Attachments
            If attachment.FileName.Contains("滴滴出行行程报销单.pdf") Then
                attachmentFound = True
                Exit For
            End If
        Next

        If Not attachmentFound Then
            Throw New InvalidOperationException("请选择邮件*滴滴出行电子发票及行程报销单*")
        End If

        Dim entryID As String = mailItem.EntryID
        If String.IsNullOrEmpty(entryID) Then
            Throw New InvalidOperationException("无法读取邮件唯一ID")
        End If

        TempFolderPath = Path.Combine(Path.GetTempPath(), entryID)
        If Directory.Exists(TempFolderPath) Then
            Directory.Delete(TempFolderPath, True)
        End If
        Directory.CreateDirectory(TempFolderPath)

        ' 初始化日志模块
        Logger.InitializeLogger(TempFolderPath, DebugMode)
    End Sub

    Public Sub LoadConfig()
        If Not File.Exists(configFilePath) Then
            ' 配置文件不存在，跳转到SettingsForm
            Dim settingsForm As New SettingsForm()
            settingsForm.ShowDialog()
            Return
        End If

        Dim config As New Dictionary(Of String, String)
        For Each line As String In File.ReadAllLines(configFilePath)
            Dim parts As String() = line.Split("="c)
            If parts.Length = 2 Then
                config(parts(0).Trim()) = parts(1).Trim()
            End If
        Next

        DestinationFolder = If(config.ContainsKey("DestinationFolder"), config("DestinationFolder"), String.Empty)
        ClientId = If(config.ContainsKey("ClientId"), config("ClientId"), String.Empty)
        ClientSecret = If(config.ContainsKey("ClientSecret"), config("ClientSecret"), String.Empty)
        DebugMode = If(config.ContainsKey("debug") AndAlso config("debug") = "1", True, False)
        Dim Tempmodel As Boolean = If(config.ContainsKey("Tempmodel") AndAlso config("Tempmodel") = "1", True, False)
        Dim data As String = If(config.ContainsKey("data"), config("data"), String.Empty)
        Dim info As String = If(config.ContainsKey("info"), config("info"), String.Empty)
        Dim mail As String = If(config.ContainsKey("mail"), config("mail"), String.Empty)

        ' 检查配置文件是否完整
        If String.IsNullOrEmpty(DestinationFolder) OrElse String.IsNullOrEmpty(ClientId) OrElse String.IsNullOrEmpty(ClientSecret) Then
            MessageBox.Show("配置文件不完整，请设置必要的参数。", "配置错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim settingsForm As New SettingsForm()
            settingsForm.ShowDialog()
            Return
        End If

        ' 如果 Tempmodel 为 1，进行额外校验
        If Tempmodel Then
            ValidationModule.ValidateConfig(data, mail)
        End If
    End Sub

    Public Async Function ArchiveInvoices() As Task
        Dim progressBarForm As New progressBarForm()
        Try
            ' 检查邮件附件
            CheckMailAttachments()

            ' 加载配置
            LoadConfig()
            progressBarForm.Show()
            progressBarForm.logLabel.Text = "正在加载配置……"
            Logger.Log("ProcessArchive", "发票归档流程已启动。")

            ' 更新进度条
            progressBarForm.UpdateProgress(10)

            ' 处理选中的邮件
            progressBarForm.logLabel.Text = "正在保存附件……"
            EmailProcessor.ProcessSelectedEmail()

            ' 更新进度条
            progressBarForm.UpdateProgress(30)

            ' 调用 OCR 处理模块
            progressBarForm.logLabel.Text = "正在OCR识别，此过程受网络限制可能需要30s左右"
            Await OcrProcessor.RecognizeText(ClientId, ClientSecret, TempFolderPath, DebugMode)

            ' 更新进度条
            progressBarForm.UpdateProgress(60)

            ' 处理 OCR 结果并重命名文件
            progressBarForm.logLabel.Text = "OCR识别成功，正在归档……"
            OcrResultProcessor.ProcessOcrResults(TempFolderPath, DestinationFolder)

            ' 更新进度条
            progressBarForm.UpdateProgress(80)

            ' 打开或激活目标文件夹
            progressBarForm.logLabel.Text = "归档完成"
            ActivateOrOpenFolder(DestinationFolder)
            Logger.Log("ProcessArchive", "已打开或激活目标文件夹。")

            ' 将邮件的“后续标记”改为“标记完成”
            Dim outlookApp As New Microsoft.Office.Interop.Outlook.Application()
            Dim explorer As Explorer = outlookApp.ActiveExplorer()
            Dim selection As Selection = explorer.Selection

            If selection.Count > 0 Then
                Dim mailItem As MailItem = TryCast(selection.Item(1), MailItem)
                If mailItem IsNot Nothing Then
                    mailItem.MarkAsTask(OlMarkInterval.olMarkComplete)
                    mailItem.Save()
                    Logger.Log("ProcessArchive", "邮件已标记为完成。")
                End If
            End If

            ' 更新进度条
            progressBarForm.UpdateProgress(100)

            ' 如果 debug 模式关闭，删除临时文件夹
            If Not DebugMode Then
                Directory.Delete(TempFolderPath, True)
            End If
        Catch ex As InvalidOperationException
            Logger.Log("ProcessArchive", "发票归档流程出错。", False, ex)
            MessageBox.Show($"发票归档出错: {ex.Message}")
            Return
        Catch ex As System.Exception
            Logger.Log("ProcessArchive", "发票归档流程出错。", False, ex)
            MessageBox.Show($"发票归档出错: {ex.Message}")
        Finally
            progressBarForm.Close()
        End Try
    End Function
End Module
