<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportLijstenUSA
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportLijstenUSA))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DGAltcoins = New System.Windows.Forms.DataGrid
        Me.tbNR = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbYEAR = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbWEEK = New System.Windows.Forms.TextBox
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbDATE = New System.Windows.Forms.TextBox
        Me.tbURL = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGAltcoins, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(741, 237)
        Me.TextBox1.MaxLength = 0
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(366, 204)
        Me.TextBox1.TabIndex = 52
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(742, 8)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.PreferredColumnWidth = 50
        Me.DataGrid1.Size = New System.Drawing.Size(372, 221)
        Me.DataGrid1.TabIndex = 51
        '
        'DGAltcoins
        '
        Me.DGAltcoins.CaptionVisible = False
        Me.DGAltcoins.DataMember = ""
        Me.DGAltcoins.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DGAltcoins.Location = New System.Drawing.Point(8, 33)
        Me.DGAltcoins.Name = "DGAltcoins"
        Me.DGAltcoins.PreferredColumnWidth = 50
        Me.DGAltcoins.Size = New System.Drawing.Size(717, 198)
        Me.DGAltcoins.TabIndex = 50
        '
        'tbNR
        '
        Me.tbNR.Location = New System.Drawing.Point(45, 7)
        Me.tbNR.Name = "tbNR"
        Me.tbNR.Size = New System.Drawing.Size(55, 20)
        Me.tbNR.TabIndex = 67
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 15)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Nr:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(116, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 15)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Year:"
        '
        'tbYEAR
        '
        Me.tbYEAR.Location = New System.Drawing.Point(171, 7)
        Me.tbYEAR.Name = "tbYEAR"
        Me.tbYEAR.Size = New System.Drawing.Size(55, 20)
        Me.tbYEAR.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(243, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Week:"
        '
        'tbWEEK
        '
        Me.tbWEEK.Location = New System.Drawing.Point(303, 7)
        Me.tbWEEK.Name = "tbWEEK"
        Me.tbWEEK.Size = New System.Drawing.Size(55, 20)
        Me.tbWEEK.TabIndex = 72
        Me.tbWEEK.Text = "01"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(8, 240)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(715, 201)
        Me.WebBrowser1.TabIndex = 73
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(15, 452)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(52, 39)
        Me.Button6.TabIndex = 74
        Me.Button6.Tag = "nieuw"
        Me.Button6.Text = "web"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(375, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Date:"
        '
        'tbDATE
        '
        Me.tbDATE.Location = New System.Drawing.Point(436, 6)
        Me.tbDATE.Name = "tbDATE"
        Me.tbDATE.Size = New System.Drawing.Size(55, 20)
        Me.tbDATE.TabIndex = 77
        '
        'tbURL
        '
        Me.tbURL.Location = New System.Drawing.Point(180, 462)
        Me.tbURL.Name = "tbURL"
        Me.tbURL.Size = New System.Drawing.Size(340, 20)
        Me.tbURL.TabIndex = 78
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(684, 455)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(41, 39)
        Me.Button3.TabIndex = 59
        Me.Button3.Tag = "sluiten"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(596, 471)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(52, 23)
        Me.Button9.TabIndex = 82
        Me.Button9.Tag = "nieuw"
        Me.Button9.Text = "stop"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(538, 471)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(52, 23)
        Me.Button10.TabIndex = 81
        Me.Button10.Tag = "nieuw"
        Me.Button10.Text = "batch"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(586, 447)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(28, 20)
        Me.TextBox3.TabIndex = 84
        Me.TextBox3.Text = "01"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(538, 448)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "week"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(620, 447)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(28, 20)
        Me.TextBox4.TabIndex = 85
        Me.TextBox4.Text = "52"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(583, 5)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(48, 20)
        Me.txtAmount.TabIndex = 87
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(513, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 15)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Amount:"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(80, 507)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(52, 39)
        Me.Button7.TabIndex = 91
        Me.Button7.Tag = "nieuw"
        Me.Button7.Text = "copy"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(18, 507)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(52, 39)
        Me.Button1.TabIndex = 90
        Me.Button1.Tag = "nieuw"
        Me.Button1.Text = "manual"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(739, 507)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 39)
        Me.Button5.TabIndex = 89
        Me.Button5.Tag = "nieuw"
        Me.Button5.Text = "convert"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(820, 507)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 39)
        Me.Button2.TabIndex = 88
        Me.Button2.Tag = "nieuw"
        Me.Button2.Text = "load songs"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(651, 508)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 37)
        Me.Button4.TabIndex = 92
        Me.Button4.Tag = "nieuw"
        Me.Button4.Text = "hit info"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(201, 506)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(52, 39)
        Me.Button8.TabIndex = 93
        Me.Button8.Tag = "nieuw"
        Me.Button8.Text = "weeks"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(742, 459)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(52, 23)
        Me.Button11.TabIndex = 94
        Me.Button11.Tag = "nieuw"
        Me.Button11.Text = "import"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(816, 459)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(52, 23)
        Me.Button12.TabIndex = 95
        Me.Button12.Tag = "nieuw"
        Me.Button12.Text = "update"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'frmImportLijstenUSA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 506)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.tbURL)
        Me.Controls.Add(Me.tbDATE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.tbWEEK)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbYEAR)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbNR)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.DGAltcoins)
        Me.Name = "frmImportLijstenUSA"
        Me.Text = "Import HitCharts"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGAltcoins, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DGAltcoins As System.Windows.Forms.DataGrid
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents tbNR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbYEAR As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbWEEK As System.Windows.Forms.TextBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbDATE As System.Windows.Forms.TextBox
    Friend WithEvents tbURL As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
End Class
