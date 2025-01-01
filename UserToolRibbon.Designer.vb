Partial Class XYToolsRibbon
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Windows.Forms 类撰写设计器支持所必需的
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        '组件设计器需要此调用。
        InitializeComponent()

    End Sub

    '组件重写释放以清理组件列表。
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

    '组件设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是组件设计器所必需的
    '可使用组件设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.XYTools = Me.Factory.CreateRibbonTab
        Me.Group1 = Me.Factory.CreateRibbonGroup
        Me.ButtonStartArchiving = Me.Factory.CreateRibbonButton
        Me.ButtonOpenSettings = Me.Factory.CreateRibbonButton
        Me.XYTools.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XYTools
        '
        Me.XYTools.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office
        Me.XYTools.Groups.Add(Me.Group1)
        Me.XYTools.Label = "个人工具"
        Me.XYTools.Name = "XYTools"
        Me.XYTools.Position = Me.Factory.RibbonPosition.AfterOfficeId("InsertAfterMso")
        '
        'Group1
        '
        Me.Group1.Items.Add(Me.ButtonStartArchiving)
        Me.Group1.Items.Add(Me.ButtonOpenSettings)
        Me.Group1.Label = "滴滴发票"
        Me.Group1.Name = "Group1"
        '
        'ButtonStartArchiving
        '
        Me.ButtonStartArchiving.Image = Global.DiDiInvoicePlugin.My.Resources.Resources.Archive
        Me.ButtonStartArchiving.Label = "发票归档"
        Me.ButtonStartArchiving.Name = "ButtonStartArchiving"
        Me.ButtonStartArchiving.ShowImage = True
        '
        'ButtonOpenSettings
        '
        Me.ButtonOpenSettings.Image = Global.DiDiInvoicePlugin.My.Resources.Resources.Settings
        Me.ButtonOpenSettings.Label = "配置"
        Me.ButtonOpenSettings.Name = "ButtonOpenSettings"
        Me.ButtonOpenSettings.ShowImage = True
        '
        'XYToolsRibbon
        '
        Me.Name = "XYToolsRibbon"
        Me.RibbonType = "Microsoft.Outlook.Explorer, Microsoft.Outlook.Mail.Read"
        Me.Tabs.Add(Me.XYTools)
        Me.XYTools.ResumeLayout(False)
        Me.XYTools.PerformLayout()
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Group1 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents ButtonStartArchiving As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents ButtonOpenSettings As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents XYTools As Microsoft.Office.Tools.Ribbon.RibbonTab
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property UserToolRibbon() As XYToolsRibbon
        Get
            Return Me.GetRibbon(Of XYToolsRibbon)()
        End Get
    End Property
End Class
