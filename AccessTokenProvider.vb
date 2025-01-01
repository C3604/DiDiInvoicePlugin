Imports System.Net.Http
Imports System.Text.Json
Imports System.Threading.Tasks

Module AccessTokenProvider
    Private ReadOnly tokenUrl As String = "https://aip.baidubce.com/oauth/2.0/token"

    Public Async Function GetAccessToken(clientId As String, clientSecret As String) As Task(Of String)
        Try
            If String.IsNullOrEmpty(clientId) OrElse String.IsNullOrEmpty(clientSecret) Then
                Throw New InvalidOperationException("API Key 或 Secret Key 未配置。")
            End If

            ' 构建请求 URL
            Dim requestUrl As String = $"{tokenUrl}?grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}"

            ' 发送请求获取 Access_token
            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.PostAsync(requestUrl, Nothing)
                response.EnsureSuccessStatusCode()
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                Dim json As JsonDocument = JsonDocument.Parse(responseBody)
                Dim accessToken As String = json.RootElement.GetProperty("access_token").GetString()

                ' 记录日志
                Logger.Log("AccessTokenProvider", "成功获取 Access_token。")

                Return accessToken
            End Using
        Catch ex As Exception
            Logger.Log("AccessTokenProvider", "获取 Access_token 时出错。", False, ex)
            Return String.Empty
        End Try
    End Function
End Module
