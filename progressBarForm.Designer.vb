<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class progressBarForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.logLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(16, 21)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(565, 38)
        Me.progressBar.TabIndex = 0
        '
        'logLabel
        '
        Me.logLabel.AutoSize = True
        Me.logLabel.Location = New System.Drawing.Point(13, 76)
        Me.logLabel.Name = "logLabel"
        Me.logLabel.Size = New System.Drawing.Size(37, 15)
        Me.logLabel.TabIndex = 1
        Me.logLabel.Text = "……"
        '
        'progressBarForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 105)
        Me.ControlBox = False
        Me.Controls.Add(Me.logLabel)
        Me.Controls.Add(Me.progressBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "progressBarForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "存档进度"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents progressBar As Windows.Forms.ProgressBar
    Friend WithEvents logLabel As Windows.Forms.Label

    Private Sub progressBarForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub UpdateProgress(value As Integer)
        If value < 0 OrElse value > 100 Then
            Throw New ArgumentOutOfRangeException(NameOf(value), "进度值必须在0到100之间。")
        End If
        Me.progressBar.Value = value
    End Sub

End Class
