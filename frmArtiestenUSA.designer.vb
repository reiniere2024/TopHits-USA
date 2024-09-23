<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArtiestenUSA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArtiestenUSA))
        Me.DGAltcoins = New System.Windows.Forms.DataGrid
        Me.Button3 = New System.Windows.Forms.Button
        Me.cbArtists = New System.Windows.Forms.ComboBox
        Me.txtArtist = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtYear2 = New System.Windows.Forms.TextBox
        Me.web1 = New System.Windows.Forms.Button
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        CType(Me.DGAltcoins, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGAltcoins
        '
        Me.DGAltcoins.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DGAltcoins.CaptionVisible = False
        Me.DGAltcoins.DataMember = ""
        Me.DGAltcoins.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DGAltcoins.Location = New System.Drawing.Point(8, 34)
        Me.DGAltcoins.Name = "DGAltcoins"
        Me.DGAltcoins.PreferredColumnWidth = 50
        Me.DGAltcoins.Size = New System.Drawing.Size(617, 425)
        Me.DGAltcoins.TabIndex = 50
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(623, 467)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(41, 39)
        Me.Button3.TabIndex = 59
        Me.Button3.Tag = "sluiten"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cbArtists
        '
        Me.cbArtists.FormattingEnabled = True
        Me.cbArtists.Location = New System.Drawing.Point(12, 7)
        Me.cbArtists.Name = "cbArtists"
        Me.cbArtists.Size = New System.Drawing.Size(241, 21)
        Me.cbArtists.TabIndex = 80
        '
        'txtArtist
        '
        Me.txtArtist.Location = New System.Drawing.Point(267, 8)
        Me.txtArtist.Name = "txtArtist"
        Me.txtArtist.Size = New System.Drawing.Size(117, 20)
        Me.txtArtist.TabIndex = 81
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(576, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 23)
        Me.Button1.TabIndex = 82
        Me.Button1.Text = "search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(430, 7)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(35, 20)
        Me.txtYear.TabIndex = 83
        Me.txtYear.Text = "1965"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(394, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "van:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(483, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "tot:"
        '
        'txtYear2
        '
        Me.txtYear2.Location = New System.Drawing.Point(509, 7)
        Me.txtYear2.Name = "txtYear2"
        Me.txtYear2.Size = New System.Drawing.Size(35, 20)
        Me.txtYear2.TabIndex = 85
        Me.txtYear2.Text = "2018"
        '
        'web1
        '
        Me.web1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.web1.Location = New System.Drawing.Point(12, 472)
        Me.web1.Name = "web1"
        Me.web1.Size = New System.Drawing.Size(91, 28)
        Me.web1.TabIndex = 88
        Me.web1.Tag = "nieuw"
        Me.web1.Text = "&Music Videos"
        Me.web1.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(8, 34)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(617, 425)
        Me.WebBrowser1.TabIndex = 89
        Me.WebBrowser1.Visible = False
        '
        'frmArtiestenUSA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 516)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.web1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtYear2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtArtist)
        Me.Controls.Add(Me.cbArtists)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DGAltcoins)
        Me.Name = "frmArtiestenUSA"
        Me.Text = "CryptocoinsApp Import Coins"
        CType(Me.DGAltcoins, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGAltcoins As System.Windows.Forms.DataGrid
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cbArtists As System.Windows.Forms.ComboBox
    Friend WithEvents txtArtist As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtYear2 As System.Windows.Forms.TextBox
    Friend WithEvents web1 As System.Windows.Forms.Button
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
End Class
