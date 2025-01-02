Imports System.IO
Imports Microsoft.Office.Interop.Outlook
Imports System.Windows.Forms

Module ValidationModule
    Public Sub ValidateConfig(data As String, mail As String)
        ' 校验当前日期是否大于 data
        Dim currentDate As DateTime = DateTime.Now
        Dim configDate As DateTime
        If DateTime.TryParse(data, configDate) AndAlso currentDate > configDate Then
            Throw New InvalidOperationException("当前日期已超过配置的日期")
        End If

        ' 获取当前选中的邮件
        Dim outlookApp As New Microsoft.Office.Interop.Outlook.Application()
        Dim explorer As Explorer = outlookApp.ActiveExplorer()
        If explorer.Selection.Count > 0 Then
            Dim selectedMail As MailItem = TryCast(explorer.Selection(1), MailItem)
            If selectedMail IsNot Nothing Then
                ' 判断收件人邮箱是否包含与 mail 相匹配的地址
                Dim recipients As Recipients = selectedMail.Recipients
                Dim authorized As Boolean = False
                For Each recipient As Recipient In recipients
                    Dim emailAddress As String = recipient.AddressEntry.GetExchangeUser().PrimarySmtpAddress
                    ' 显示当前收件人的邮箱和 mail
                    'MessageBox.Show($"当前收件人邮箱: {emailAddress}, mail: {mail}", "收件人信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If emailAddress.Contains(mail) Then
                        authorized = True
                        Exit For
                    End If
                Next

                If Not authorized Then
                    Throw New InvalidOperationException("非授权用户")
                End If
            End If
        End If
    End Sub
End Module
