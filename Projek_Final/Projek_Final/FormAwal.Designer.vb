<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAwal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblJmlPemain = New System.Windows.Forms.Label()
        Me.cbJmlPemain = New System.Windows.Forms.ComboBox()
        Me.gbPemain1 = New System.Windows.Forms.GroupBox()
        Me.tbPemain1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbPemain2 = New System.Windows.Forms.GroupBox()
        Me.tbPemain2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbPemain3 = New System.Windows.Forms.GroupBox()
        Me.tbPemain3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbPemain4 = New System.Windows.Forms.GroupBox()
        Me.tbPemain4 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnNewGame = New System.Windows.Forms.Button()
        Me.btnResume = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gbPemain1.SuspendLayout()
        Me.gbPemain2.SuspendLayout()
        Me.gbPemain3.SuspendLayout()
        Me.gbPemain4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblJmlPemain
        '
        Me.lblJmlPemain.AutoSize = True
        Me.lblJmlPemain.BackColor = System.Drawing.Color.Transparent
        Me.lblJmlPemain.Font = New System.Drawing.Font("Milker", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJmlPemain.Location = New System.Drawing.Point(710, 68)
        Me.lblJmlPemain.Name = "lblJmlPemain"
        Me.lblJmlPemain.Size = New System.Drawing.Size(245, 30)
        Me.lblJmlPemain.TabIndex = 0
        Me.lblJmlPemain.Text = "Jumlah Pemain:"
        '
        'cbJmlPemain
        '
        Me.cbJmlPemain.FormattingEnabled = True
        Me.cbJmlPemain.Items.AddRange(New Object() {"2", "3", "4"})
        Me.cbJmlPemain.Location = New System.Drawing.Point(211, 121)
        Me.cbJmlPemain.Name = "cbJmlPemain"
        Me.cbJmlPemain.Size = New System.Drawing.Size(121, 28)
        Me.cbJmlPemain.TabIndex = 1
        '
        'gbPemain1
        '
        Me.gbPemain1.BackColor = System.Drawing.Color.Blue
        Me.gbPemain1.Controls.Add(Me.tbPemain1)
        Me.gbPemain1.Controls.Add(Me.Label1)
        Me.gbPemain1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPemain1.Location = New System.Drawing.Point(29, 166)
        Me.gbPemain1.Name = "gbPemain1"
        Me.gbPemain1.Size = New System.Drawing.Size(322, 100)
        Me.gbPemain1.TabIndex = 2
        Me.gbPemain1.TabStop = False
        Me.gbPemain1.Text = "Pemain 1"
        '
        'tbPemain1
        '
        Me.tbPemain1.Location = New System.Drawing.Point(96, 41)
        Me.tbPemain1.Name = "tbPemain1"
        Me.tbPemain1.Size = New System.Drawing.Size(211, 30)
        Me.tbPemain1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nama"
        '
        'gbPemain2
        '
        Me.gbPemain2.BackColor = System.Drawing.Color.Red
        Me.gbPemain2.Controls.Add(Me.tbPemain2)
        Me.gbPemain2.Controls.Add(Me.Label2)
        Me.gbPemain2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPemain2.Location = New System.Drawing.Point(379, 166)
        Me.gbPemain2.Name = "gbPemain2"
        Me.gbPemain2.Size = New System.Drawing.Size(320, 100)
        Me.gbPemain2.TabIndex = 3
        Me.gbPemain2.TabStop = False
        Me.gbPemain2.Text = "Pemain2"
        '
        'tbPemain2
        '
        Me.tbPemain2.Location = New System.Drawing.Point(96, 47)
        Me.tbPemain2.Name = "tbPemain2"
        Me.tbPemain2.Size = New System.Drawing.Size(218, 30)
        Me.tbPemain2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama"
        '
        'gbPemain3
        '
        Me.gbPemain3.BackColor = System.Drawing.Color.Green
        Me.gbPemain3.Controls.Add(Me.tbPemain3)
        Me.gbPemain3.Controls.Add(Me.Label3)
        Me.gbPemain3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPemain3.Location = New System.Drawing.Point(29, 283)
        Me.gbPemain3.Name = "gbPemain3"
        Me.gbPemain3.Size = New System.Drawing.Size(322, 100)
        Me.gbPemain3.TabIndex = 3
        Me.gbPemain3.TabStop = False
        Me.gbPemain3.Text = "Pemain3"
        '
        'tbPemain3
        '
        Me.tbPemain3.Location = New System.Drawing.Point(96, 48)
        Me.tbPemain3.Name = "tbPemain3"
        Me.tbPemain3.Size = New System.Drawing.Size(211, 30)
        Me.tbPemain3.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nama"
        '
        'gbPemain4
        '
        Me.gbPemain4.BackColor = System.Drawing.Color.Yellow
        Me.gbPemain4.Controls.Add(Me.tbPemain4)
        Me.gbPemain4.Controls.Add(Me.Label4)
        Me.gbPemain4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPemain4.Location = New System.Drawing.Point(379, 283)
        Me.gbPemain4.Name = "gbPemain4"
        Me.gbPemain4.Size = New System.Drawing.Size(320, 100)
        Me.gbPemain4.TabIndex = 4
        Me.gbPemain4.TabStop = False
        Me.gbPemain4.Text = "Pemain4"
        '
        'tbPemain4
        '
        Me.tbPemain4.Location = New System.Drawing.Point(96, 51)
        Me.tbPemain4.Name = "tbPemain4"
        Me.tbPemain4.Size = New System.Drawing.Size(218, 30)
        Me.tbPemain4.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Nama"
        '
        'btnNewGame
        '
        Me.btnNewGame.Location = New System.Drawing.Point(438, 404)
        Me.btnNewGame.Name = "btnNewGame"
        Me.btnNewGame.Size = New System.Drawing.Size(143, 41)
        Me.btnNewGame.TabIndex = 1
        Me.btnNewGame.Text = "Normal Mode"
        Me.btnNewGame.UseVisualStyleBackColor = True
        '
        'btnResume
        '
        Me.btnResume.Location = New System.Drawing.Point(298, 404)
        Me.btnResume.Name = "btnResume"
        Me.btnResume.Size = New System.Drawing.Size(134, 41)
        Me.btnResume.TabIndex = 1
        Me.btnResume.Text = "Resume Game"
        Me.btnResume.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(155, 404)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 41)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Battle Mode"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormAwal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = Global.Projek_Final.My.Resources.Resources.WhatsApp_Image_2025_04_22_at_09_18_25_48109588
        Me.ClientSize = New System.Drawing.Size(711, 453)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnResume)
        Me.Controls.Add(Me.btnNewGame)
        Me.Controls.Add(Me.gbPemain4)
        Me.Controls.Add(Me.gbPemain3)
        Me.Controls.Add(Me.gbPemain2)
        Me.Controls.Add(Me.gbPemain1)
        Me.Controls.Add(Me.cbJmlPemain)
        Me.Controls.Add(Me.lblJmlPemain)
        Me.Name = "FormAwal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormAwal"
        Me.gbPemain1.ResumeLayout(False)
        Me.gbPemain1.PerformLayout()
        Me.gbPemain2.ResumeLayout(False)
        Me.gbPemain2.PerformLayout()
        Me.gbPemain3.ResumeLayout(False)
        Me.gbPemain3.PerformLayout()
        Me.gbPemain4.ResumeLayout(False)
        Me.gbPemain4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblJmlPemain As Label
    Friend WithEvents cbJmlPemain As ComboBox
    Friend WithEvents gbPemain1 As GroupBox
    Friend WithEvents gbPemain2 As GroupBox
    Friend WithEvents gbPemain3 As GroupBox
    Friend WithEvents tbPemain1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbPemain2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbPemain3 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents gbPemain4 As GroupBox
    Friend WithEvents tbPemain4 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnNewGame As Button
    Friend WithEvents btnResume As Button
    Friend WithEvents Button1 As Button
End Class
