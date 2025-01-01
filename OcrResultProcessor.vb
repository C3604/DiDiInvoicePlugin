Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Diagnostics

Module OcrResultProcessor
    Public Sub ProcessOcrResults(tempFolderPath As String, destinationFolder As String)
        Dim ocrResultFilePath As String = Path.Combine(tempFolderPath, "ocr_result.json")
        If Not File.Exists(ocrResultFilePath) Then
            Throw New FileNotFoundException("OCR结果文件未找到。")
        End If

        Dim ocrContent As String = File.ReadAllText(ocrResultFilePath)
        Dim datePattern As String = "行程起止日期：(\d{4}-\d{2}-\d{2})"
        Dim amountPattern As String = "合计(\d+\.\d{2})元"

        Dim dateMatch As Match = Regex.Match(ocrContent, datePattern)
        Dim amountMatch As Match = Regex.Match(ocrContent, amountPattern)

        If Not dateMatch.Success OrElse Not amountMatch.Success Then
            Throw New InvalidOperationException("无法从OCR结果中提取关键信息。")
        End If

        Dim dateStr As String = dateMatch.Groups(1).Value
        Dim amountStr As String = amountMatch.Groups(1).Value

        Dim filesToRename As String() = Directory.GetFiles(tempFolderPath, "*.pdf")
        For Each filePath As String In filesToRename
            Dim fileName As String = Path.GetFileName(filePath)
            Dim newFileName As String = $"{dateStr}_{amountStr}_{fileName}"
            Dim newFilePath As String = Path.Combine(destinationFolder, newFileName)

            If File.Exists(newFilePath) Then
                File.Delete(newFilePath)
            End If

            File.Move(filePath, newFilePath)
            Logger.Log("OcrResultProcessor", $"文件重命名并移动: {filePath} -> {newFilePath}")
        Next
    End Sub
End Module
