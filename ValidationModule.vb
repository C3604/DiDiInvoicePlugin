Imports System.IO
Imports Microsoft.Office.Interop.Outlook
Imports System.Windows.Forms

Module ValidationModule
    Public Sub ValidateConfig(data As String, mail As String)
        ' 校验当前日期是否大于 data
        Dim currentDate As DateTime = DateTime.Now
        Dim configDate As DateTime
        If DateTime.TryParse(data, configDate) AndAlso currentDate > configDate Then
            Throw New InvalidOperationException("当前日期已超过配置的日期，程序终止。")
        End If

        ' 暂时取消检查收件人信息
        ' ' 校验当前选中邮件收件人是否包含 mail
        ' Dim outlookApp As New Microsoft.Office.Interop.Outlook.Application()
        ' Dim explorer As Explorer = outlookApp.ActiveExplorer()
        ' Dim selection As Selection = explorer.Selection

        ' If selection.Count = 0 Then
        '     Throw New InvalidOperationException("未选中任何邮件。")
        ' End If

        ' Dim mailItem As MailItem = TryCast(selection.Item(1), MailItem)
        ' If mailItem Is Nothing OrElse Not mailItem.To.Contains(mail) Then
        '     Throw New InvalidOperationException("选中邮件的收件人不包含指定的邮箱地址，程序终止。")
        ' End If
    End Sub
End Module
