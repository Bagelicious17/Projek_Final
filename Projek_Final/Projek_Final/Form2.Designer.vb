<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LudoGame
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
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pbBoard = New System.Windows.Forms.PictureBox()
        Me.btnAcak = New System.Windows.Forms.Button()
        Me.pbDadu = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbDadu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Projek_Final.My.Resources.Resources.Merah
        Me.PictureBox2.Location = New System.Drawing.Point(478, 222)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(30, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'pbBoard
        '
        Me.pbBoard.Image = Global.Projek_Final.My.Resources.Resources._360_F_94642486_eISVocQwYVqM7cZJ3QTlTCxUJ6K0You2
        Me.pbBoard.Location = New System.Drawing.Point(284, 12)
        Me.pbBoard.Name = "pbBoard"
        Me.pbBoard.Size = New System.Drawing.Size(450, 450)
        Me.pbBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBoard.TabIndex = 6
        Me.pbBoard.TabStop = False
        '
        'btnAcak
        '
        Me.btnAcak.Location = New System.Drawing.Point(53, 428)
        Me.btnAcak.Name = "btnAcak"
        Me.btnAcak.Size = New System.Drawing.Size(194, 44)
        Me.btnAcak.TabIndex = 5
        Me.btnAcak.Text = "Acak Dadu"
        Me.btnAcak.UseVisualStyleBackColor = True
        '
        'pbDadu
        '
        Me.pbDadu.BackColor = System.Drawing.Color.White
        Me.pbDadu.Location = New System.Drawing.Point(98, 294)
        Me.pbDadu.Name = "pbDadu"
        Me.pbDadu.Size = New System.Drawing.Size(100, 100)
        Me.pbDadu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbDadu.TabIndex = 4
        Me.pbDadu.TabStop = False
        '
        'LudoGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 542)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.pbBoard)
        Me.Controls.Add(Me.btnAcak)
        Me.Controls.Add(Me.pbDadu)
        Me.Name = "LudoGame"
        Me.Text = "Form2"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBoard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbDadu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents pbBoard As PictureBox
    Friend WithEvents btnAcak As Button
    Friend WithEvents pbDadu As PictureBox
End Class
