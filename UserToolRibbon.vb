Imports System.Windows.Forms
Imports Microsoft.Office.Tools.Ribbon

Public Class XYToolsRibbon

    Private Sub UserToolRibbon_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonOpenSettings_Click(sender As Object, e As RibbonControlEventArgs) Handles ButtonOpenSettings.Click
        Dim settingsForm As New SettingsForm()
        settingsForm.ShowDialog()
    End Sub

    Private Async Sub ButtonStartArchiving_Click(sender As Object, e As RibbonControlEventArgs) Handles ButtonStartArchiving.Click
        Try
            ProcessArchive.LoadConfig()
            Await ProcessArchive.ArchiveInvoices()
        Catch ex As Exception
            MessageBox.Show($"归档出错: {ex.Message}")
        End Try
    End Sub
End Class
