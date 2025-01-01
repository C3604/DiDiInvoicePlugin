Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports System.Web
Imports System.Windows.Forms

Module OcrProcessor
    Private ReadOnly OcrUrl As String = "https://aip.baidubce.com/rest/2.0/ocr/v1/accurate_basic"

    Public Async Function RecognizeText(clientId As String, clientSecret As String, tempFolderPath As String, debugMode As Boolean) As Task
        Try
            ' 获取 Access_token
            Dim accessToken As String = Await AccessTokenProvider.GetAccessToken(clientId, clientSecret)
            If String.IsNullOrEmpty(accessToken) Then Throw New InvalidOperationException("无法获取 Access_token。")

            ' 获取文件路径和内容
            Dim pdfFilePath = Path.Combine(tempFolderPath, "滴滴出行行程报销单.pdf")
            If Not File.Exists(pdfFilePath) Then Throw New FileNotFoundException("未找到滴滴出行行程报销单文件。")

            Dim pdfBytes = File.ReadAllBytes(pdfFilePath)
            Dim pdfBase64 = Convert.ToBase64String(pdfBytes)
            Dim encodedBase64 = HttpUtility.UrlEncode(pdfBase64)

            ' 构建请求
            Dim requestUrl = $"{OcrUrl}?access_token={accessToken}"
            Dim content = New StringContent($"pdf_file={encodedBase64}", Encoding.UTF8, "application/x-www-form-urlencoded")

            ' 发送请求并处理响应
            Using client As New HttpClient()
                client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

                Dim response = Await client.PostAsync(requestUrl, content)
                response.EnsureSuccessStatusCode()

                Dim responseBody = Await response.Content.ReadAsStringAsync()
                Dim jsonFilePath = Path.Combine(tempFolderPath, "ocr_result.json")
                File.WriteAllText(jsonFilePath, responseBody)

                Logger.Log("OcrProcessor", "成功识别文字并保存结果。")
            End Using
        Catch ex As Exception
            Logger.Log("OcrProcessor", "文字识别时出错。", False, ex)
            If debugMode Then MessageBox.Show($"文字识别时出错: {ex.Message}")
        End Try
    End Function
End Module