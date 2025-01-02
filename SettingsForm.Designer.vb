<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.ButtonBrowse = New System.Windows.Forms.Button()
        Me.TextBoxDestinationFolder = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxtempmodel = New System.Windows.Forms.CheckBox()
        Me.CheckBoxShowToken = New System.Windows.Forms.CheckBox()
        Me.TextBoxClientSecret = New System.Windows.Forms.TextBox()
        Me.LabelClientSecret = New System.Windows.Forms.Label()
        Me.TextBoxClientId = New System.Windows.Forms.TextBox()
        Me.LabelClientId = New System.Windows.Forms.Label()
        Me.ButtonConfirm = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.CheckBoxDebug = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonBrowse
        '
        Me.ButtonBrowse.Location = New System.Drawing.Point(259, 59)
        Me.ButtonBrowse.Name = "ButtonBrowse"
        Me.ButtonBrowse.Size = New System.Drawing.Size(74, 25)
        Me.ButtonBrowse.TabIndex = 0
        Me.ButtonBrowse.Text = "浏览"
        Me.ButtonBrowse.UseVisualStyleBackColor = True
        '
        'TextBoxDestinationFolder
        '
        Me.TextBoxDestinationFolder.Location = New System.Drawing.Point(37, 59)
        Me.TextBoxDestinationFolder.Name = "TextBoxDestinationFolder"
        Me.TextBoxDestinationFolder.Size = New System.Drawing.Size(201, 25)
        Me.TextBoxDestinationFolder.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "归档路径"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBoxtempmodel)
        Me.GroupBox1.Controls.Add(Me.CheckBoxShowToken)
        Me.GroupBox1.Controls.Add(Me.TextBoxClientSecret)
        Me.GroupBox1.Controls.Add(Me.LabelClientSecret)
        Me.GroupBox1.Controls.Add(Me.TextBoxClientId)
        Me.GroupBox1.Controls.Add(Me.LabelClientId)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 127)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 260)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "OCR配置"
        '
        'CheckBoxtempmodel
        '
        Me.CheckBoxtempmodel.AccessibleDescription = ""
        Me.CheckBoxtempmodel.AutoSize = True
        Me.CheckBoxtempmodel.Location = New System.Drawing.Point(215, 215)
        Me.CheckBoxtempmodel.Name = "CheckBoxtempmodel"
        Me.CheckBoxtempmodel.Size = New System.Drawing.Size(89, 19)
        Me.CheckBoxtempmodel.TabIndex = 3
        Me.CheckBoxtempmodel.Text = "临时模式"
        Me.CheckBoxtempmodel.UseVisualStyleBackColor = True
        '
        'CheckBoxShowToken
        '
        Me.CheckBoxShowToken.AutoSize = True
        Me.CheckBoxShowToken.Location = New System.Drawing.Point(16, 215)
        Me.CheckBoxShowToken.Name = "CheckBoxShowToken"
        Me.CheckBoxShowToken.Size = New System.Drawing.Size(89, 19)
        Me.CheckBoxShowToken.TabIndex = 3
        Me.CheckBoxShowToken.Text = "明文显示"
        Me.CheckBoxShowToken.UseVisualStyleBackColor = True
        '
        'TextBoxClientSecret
        '
        Me.TextBoxClientSecret.Location = New System.Drawing.Point(8, 169)
        Me.TextBoxClientSecret.Name = "TextBoxClientSecret"
        Me.TextBoxClientSecret.Size = New System.Drawing.Size(296, 25)
        Me.TextBoxClientSecret.TabIndex = 1
        '
        'LabelClientSecret
        '
        Me.LabelClientSecret.AutoSize = True
        Me.LabelClientSecret.Location = New System.Drawing.Point(5, 139)
        Me.LabelClientSecret.Name = "LabelClientSecret"
        Me.LabelClientSecret.Size = New System.Drawing.Size(199, 15)
        Me.LabelClientSecret.TabIndex = 2
        Me.LabelClientSecret.Text = "ClientSecret(Secret Key)"
        '
        'TextBoxClientId
        '
        Me.TextBoxClientId.Location = New System.Drawing.Point(8, 84)
        Me.TextBoxClientId.Name = "TextBoxClientId"
        Me.TextBoxClientId.Size = New System.Drawing.Size(296, 25)
        Me.TextBoxClientId.TabIndex = 1
        '
        'LabelClientId
        '
        Me.LabelClientId.AutoSize = True
        Me.LabelClientId.Location = New System.Drawing.Point(5, 48)
        Me.LabelClientId.Name = "LabelClientId"
        Me.LabelClientId.Size = New System.Drawing.Size(143, 15)
        Me.LabelClientId.TabIndex = 2
        Me.LabelClientId.Text = "ClientId(API Key)"
        '
        'ButtonConfirm
        '
        Me.ButtonConfirm.Location = New System.Drawing.Point(37, 437)
        Me.ButtonConfirm.Name = "ButtonConfirm"
        Me.ButtonConfirm.Size = New System.Drawing.Size(74, 34)
        Me.ButtonConfirm.TabIndex = 0
        Me.ButtonConfirm.Text = "确认"
        Me.ButtonConfirm.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(259, 437)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(74, 34)
        Me.ButtonCancel.TabIndex = 0
        Me.ButtonCancel.Text = "取消"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'CheckBoxDebug
        '
        Me.CheckBoxDebug.AutoSize = True
        Me.CheckBoxDebug.Location = New System.Drawing.Point(45, 403)
        Me.CheckBoxDebug.Name = "CheckBoxDebug"
        Me.CheckBoxDebug.Size = New System.Drawing.Size(89, 19)
        Me.CheckBoxDebug.TabIndex = 3
        Me.CheckBoxDebug.Text = "调试模式"
        Me.CheckBoxDebug.UseVisualStyleBackColor = True
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 494)
        Me.Controls.Add(Me.CheckBoxDebug)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxDestinationFolder)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonConfirm)
        Me.Controls.Add(Me.ButtonBrowse)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsForm"
        Me.Text = "配置"
        AddHandler Load, AddressOf Me.SettingsForm_Load_1
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonBrowse As Windows.Forms.Button
    Friend WithEvents TextBoxDestinationFolder As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents TextBoxClientSecret As Windows.Forms.TextBox
    Friend WithEvents LabelClientSecret As Windows.Forms.Label
    Friend WithEvents TextBoxClientId As Windows.Forms.TextBox
    Friend WithEvents LabelClientId As Windows.Forms.Label

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, LabelClientSecret.Click, LabelClientId.Click

    End Sub

    Friend WithEvents CheckBoxShowToken As Windows.Forms.CheckBox
    Friend WithEvents ButtonConfirm As Windows.Forms.Button
    Friend WithEvents ButtonCancel As Windows.Forms.Button

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Friend WithEvents CheckBoxDebug As Windows.Forms.CheckBox
    Friend WithEvents CheckBoxtempmodel As Windows.Forms.CheckBox
End Class
