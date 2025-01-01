Imports System.IO
Imports Microsoft.Office.Interop.Outlook
Imports System.Windows.Forms

Module EmailProcessor
    Public Sub ProcessSelectedEmail()
        Try
            Dim outlookApp As New Microsoft.Office.Interop.Outlook.Application()
            Dim explorer As Explorer = outlookApp.ActiveExplorer()
            Dim selection As Selection = explorer.Selection

            If selection.Count = 0 Then
                Logger.Log("EmailProcessor", "未选中任何邮件。", False)
                MessageBox.Show("未选中任何邮件。")
                Return
            End If

            Dim mailItem As MailItem = TryCast(selection.Item(1), MailItem)
            If mailItem Is Nothing Then
                Logger.Log("EmailProcessor", "选中的项目不是邮件。", False)
                MessageBox.Show("选中的项目不是邮件。")
                Return
            End If

            ' 检查是否包含“滴滴出行行程报销单.pdf”附件
            Dim containsInvoice As Boolean = False
            For Each attachment As Attachment In mailItem.Attachments
                If attachment.FileName.Contains("滴滴出行行程报销单.pdf") Then
                    containsInvoice = True
                    Exit For
                End If
            Next

            If Not containsInvoice Then
                Logger.Log("EmailProcessor", "选中的邮件不包含滴滴出行行程报销单.pdf附件。", False)
                MessageBox.Show("选中的邮件不包含滴滴出行行程报销单.pdf附件。")
                Return
            End If

            ' 下载附件到临时目录
            For Each attachment As Attachment In mailItem.Attachments
                Dim filePath As String = Path.Combine(ProcessArchive.TempFolderPath, attachment.FileName)
                attachment.SaveAsFile(filePath)
            Next

            Logger.Log("EmailProcessor", "附件已下载到临时目录。")
        Catch ex As System.Exception
            Logger.Log("EmailProcessor", "处理选中邮件时出错。", False, ex)
            MessageBox.Show($"处理选中邮件时出错: {ex.Message}")
        End Try
    End Sub
End Module
