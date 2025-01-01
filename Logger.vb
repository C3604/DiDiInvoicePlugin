Imports System.IO
Imports System.Text

Module Logger
    Private logFilePath As String

    Public Sub InitializeLogger(tempFolderPath As String, debugMode As Boolean)
        If debugMode Then
            logFilePath = Path.Combine(tempFolderPath, "log.txt")
        Else
            logFilePath = Nothing
        End If
    End Sub

    Public Sub Log(moduleName As String, message As String, Optional isSuccess As Boolean = True, Optional exception As System.Exception = Nothing)
        If String.IsNullOrEmpty(logFilePath) Then
            Return
        End If

        Dim logMessage As New StringBuilder()
        logMessage.AppendLine($"操作时间: {DateTime.Now}")
        logMessage.AppendLine($"调用模块名称: {moduleName}")
        logMessage.AppendLine($"关键信息: {message}")
        logMessage.AppendLine($"结果: {(If(isSuccess, "成功", "失败"))}")

        If exception IsNot Nothing Then
            logMessage.AppendLine($"报错信息: {exception.Message}")
            logMessage.AppendLine($"堆栈信息: {exception.StackTrace}")
        End If

        logMessage.AppendLine(New String("-"c, 50))

        Try
            File.AppendAllText(logFilePath, logMessage.ToString())
        Catch ex As System.Exception
            ' 如果日志写入失败，可以选择忽略或处理
        End Try
    End Sub
End Module
