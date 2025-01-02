Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class SettingsForm
    Private configFilePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OutlookPlugin\DiDiInvoice\DiDiInvoice.ini")
    Private config As New Dictionary(Of String, String)

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists(configFilePath) Then
            Directory.CreateDirectory(Path.GetDirectoryName(configFilePath))
            File.WriteAllText(configFilePath, String.Empty)
        End If

        For Each line As String In File.ReadAllLines(configFilePath)
            Dim parts As String() = line.Split("="c)
            If parts.Length = 2 Then
                config(parts(0).Trim()) = parts(1).Trim()
            End If
        Next

        TextBoxDestinationFolder.Text = If(config.ContainsKey("DestinationFolder"), config("DestinationFolder"), String.Empty)
        TextBoxClientId.Text = If(config.ContainsKey("ClientId"), config("ClientId"), String.Empty)
        TextBoxClientSecret.Text = If(config.ContainsKey("ClientSecret"), config("ClientSecret"), String.Empty)
        CheckBoxDebug.Checked = If(config.ContainsKey("debug") AndAlso config("debug") = "1", True, False)
        CheckBoxtempmodel.Checked = If(config.ContainsKey("Tempmodel") AndAlso config("Tempmodel") = "1", True, False)

        ' 默认以*显示
        TextBoxClientId.UseSystemPasswordChar = True
        TextBoxClientSecret.UseSystemPasswordChar = True

        ' 根据Tempmodel的值禁用控件
        If CheckBoxtempmodel.Checked Then
            TextBoxClientId.Enabled = False
            TextBoxClientSecret.Enabled = False
            CheckBoxShowToken.Enabled = False
        End If
    End Sub

    Private Sub ButtonBrowse_Click(sender As Object, e As EventArgs) Handles ButtonBrowse.Click
        Using folderBrowser As New FolderBrowserDialog()
            If folderBrowser.ShowDialog() = DialogResult.OK Then
                TextBoxDestinationFolder.Text = folderBrowser.SelectedPath
            End If
        End Using
    End Sub

    Private Sub CheckBoxShowToken_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowToken.CheckedChanged
        If CheckBoxShowToken.Checked Then
            TextBoxClientId.UseSystemPasswordChar = False
            TextBoxClientSecret.UseSystemPasswordChar = False
        Else
            TextBoxClientId.UseSystemPasswordChar = True
            TextBoxClientSecret.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub CheckBoxtempmodel_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxtempmodel.CheckedChanged
        If CheckBoxtempmodel.Checked Then
            TextBoxClientId.Enabled = False
            TextBoxClientSecret.Enabled = False
            CheckBoxShowToken.Enabled = False

            ' 只有在勾选时才弹窗提示用户输入临时密钥
            If Not config.ContainsKey("Tempmodel") OrElse config("Tempmodel") <> "1" Then
                Dim tempKey As String = InputBox("请输入临时密钥（Base64编码）：", "临时密钥")
                If Not String.IsNullOrEmpty(tempKey) Then
                    Try
                        Dim decodedKey As String = Encoding.UTF8.GetString(Convert.FromBase64String(tempKey))
                        Dim keyParts As String() = decodedKey.Split("_"c)
                        Dim tempConfig As New Dictionary(Of String, String)
                        For Each part As String In keyParts
                            Dim kv As String() = part.Split(":"c)
                            If kv.Length = 2 Then
                                tempConfig(kv(0).Trim()) = kv(1).Trim()
                            End If
                        Next

                        ' 更新配置文件
                        If tempConfig.ContainsKey("mail") Then config("mail") = tempConfig("mail")
                        If tempConfig.ContainsKey("ClientId") Then
                            config("ClientId") = tempConfig("ClientId")
                            TextBoxClientId.Text = tempConfig("ClientId")
                        End If
                        If tempConfig.ContainsKey("ClientSecret") Then
                            config("ClientSecret") = tempConfig("ClientSecret")
                            TextBoxClientSecret.Text = tempConfig("ClientSecret")
                        End If
                        If tempConfig.ContainsKey("info") Then config("info") = tempConfig("info")
                        If tempConfig.ContainsKey("data") Then config("data") = tempConfig("data")

                        SaveConfig()
                    Catch ex As Exception
                        MessageBox.Show("临时密钥无效，请重新输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        Else
            TextBoxClientId.Enabled = True
            TextBoxClientSecret.Enabled = True
            CheckBoxShowToken.Enabled = True

            ' 删除配置文件中的相关参数和值
            config.Remove("mail")
            config.Remove("ClientId")
            config.Remove("ClientSecret")
            config.Remove("info")
            config.Remove("data")

            ' 清空文本框
            TextBoxClientId.Text = String.Empty
            TextBoxClientSecret.Text = String.Empty

            ' 新增 Tempmodel = 0 变量赋值
            config("Tempmodel") = "0"

            SaveConfig()
        End If
    End Sub

    Private Sub ButtonConfirm_Click(sender As Object, e As EventArgs) Handles ButtonConfirm.Click
        SaveConfig()
        Me.Close()
    End Sub

    Private Sub SaveConfig()
        Dim configContent As New StringBuilder()
        configContent.AppendLine($"DestinationFolder={TextBoxDestinationFolder.Text}")
        configContent.AppendLine($"ClientId={TextBoxClientId.Text}")
        configContent.AppendLine($"ClientSecret={TextBoxClientSecret.Text}")
        configContent.AppendLine($"debug={(If(CheckBoxDebug.Checked, "1", "0"))}")
        configContent.AppendLine($"Tempmodel={(If(CheckBoxtempmodel.Checked, "1", "0"))}")

        If config.ContainsKey("mail") Then configContent.AppendLine($"mail={config("mail")}")
        If config.ContainsKey("info") Then configContent.AppendLine($"info={config("info")}")
        If config.ContainsKey("data") Then configContent.AppendLine($"data={config("data")}")

        File.WriteAllText(configFilePath, configContent.ToString())
    End Sub

    Private Sub SettingsForm_Load_1(sender As Object, e As EventArgs)

    End Sub
End Class
