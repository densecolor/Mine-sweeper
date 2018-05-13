<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDemineur
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlJeu = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbls = New System.Windows.Forms.Label()
        Me.Lblnbrr = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lblnbr = New System.Windows.Forms.Label()
        Me.btnrestart = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MeunuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeginnerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IntermediateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlJeu
        '
        Me.pnlJeu.BackColor = System.Drawing.SystemColors.Control
        Me.pnlJeu.Font = New System.Drawing.Font("幼圆", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.pnlJeu.Location = New System.Drawing.Point(26, 89)
        Me.pnlJeu.Name = "pnlJeu"
        Me.pnlJeu.Size = New System.Drawing.Size(377, 385)
        Me.pnlJeu.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'lbls
        '
        Me.lbls.AutoSize = True
        Me.lbls.Font = New System.Drawing.Font("宋体", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbls.Location = New System.Drawing.Point(33, 44)
        Me.lbls.Name = "lbls"
        Me.lbls.Size = New System.Drawing.Size(34, 35)
        Me.lbls.TabIndex = 3
        Me.lbls.Text = "0"
        '
        'Lblnbrr
        '
        Me.Lblnbrr.AutoSize = True
        Me.Lblnbrr.Font = New System.Drawing.Font("宋体", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lblnbrr.Location = New System.Drawing.Point(184, 44)
        Me.Lblnbrr.Name = "Lblnbrr"
        Me.Lblnbrr.Size = New System.Drawing.Size(34, 35)
        Me.Lblnbrr.TabIndex = 5
        Me.Lblnbrr.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 60.0!)
        Me.Label1.Image = Global.Demineur.My.Resources.Resources.time_small
        Me.Label1.Location = New System.Drawing.Point(12, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 80)
        Me.Label1.TabIndex = 7
        '
        'Lblnbr
        '
        Me.Lblnbr.AutoSize = True
        Me.Lblnbr.Font = New System.Drawing.Font("宋体", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lblnbr.Image = Global.Demineur.My.Resources.Resources.lei
        Me.Lblnbr.Location = New System.Drawing.Point(363, 39)
        Me.Lblnbr.Name = "Lblnbr"
        Me.Lblnbr.Size = New System.Drawing.Size(0, 27)
        Me.Lblnbr.TabIndex = 4
        '
        'btnrestart
        '
        Me.btnrestart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrestart.FlatAppearance.BorderColor = System.Drawing.SystemColors.Menu
        Me.btnrestart.FlatAppearance.BorderSize = 0
        Me.btnrestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrestart.ForeColor = System.Drawing.SystemColors.Menu
        Me.btnrestart.Image = Global.Demineur.My.Resources.Resources.xiao
        Me.btnrestart.Location = New System.Drawing.Point(92, 55)
        Me.btnrestart.Name = "btnrestart"
        Me.btnrestart.Size = New System.Drawing.Size(75, 23)
        Me.btnrestart.TabIndex = 2
        Me.btnrestart.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MeunuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(444, 30)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MeunuToolStripMenuItem
        '
        Me.MeunuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeginnerToolStripMenuItem, Me.IntermediateToolStripMenuItem, Me.ExpertToolStripMenuItem, Me.PersonalToolStripMenuItem})
        Me.MeunuToolStripMenuItem.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MeunuToolStripMenuItem.Name = "MeunuToolStripMenuItem"
        Me.MeunuToolStripMenuItem.Size = New System.Drawing.Size(67, 26)
        Me.MeunuToolStripMenuItem.Text = "Menu"
        '
        'BeginnerToolStripMenuItem
        '
        Me.BeginnerToolStripMenuItem.Name = "BeginnerToolStripMenuItem"
        Me.BeginnerToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.BeginnerToolStripMenuItem.Text = "Beginner"
        '
        'IntermediateToolStripMenuItem
        '
        Me.IntermediateToolStripMenuItem.Name = "IntermediateToolStripMenuItem"
        Me.IntermediateToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.IntermediateToolStripMenuItem.Text = "Intermediate"
        '
        'ExpertToolStripMenuItem
        '
        Me.ExpertToolStripMenuItem.Name = "ExpertToolStripMenuItem"
        Me.ExpertToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.ExpertToolStripMenuItem.Text = "Expert"
        '
        'PersonalToolStripMenuItem
        '
        Me.PersonalToolStripMenuItem.Name = "PersonalToolStripMenuItem"
        Me.PersonalToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.PersonalToolStripMenuItem.Text = "Personal"
        '
        'FormDemineur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(444, 415)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Lblnbrr)
        Me.Controls.Add(Me.Lblnbr)
        Me.Controls.Add(Me.lbls)
        Me.Controls.Add(Me.btnrestart)
        Me.Controls.Add(Me.pnlJeu)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormDemineur"
        Me.Text = "Démineur"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlJeu As System.Windows.Forms.Panel
    Friend WithEvents btnrestart As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbls As System.Windows.Forms.Label
    Friend WithEvents Lblnbr As System.Windows.Forms.Label
    Friend WithEvents Lblnbrr As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MeunuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeginnerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IntermediateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExpertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
