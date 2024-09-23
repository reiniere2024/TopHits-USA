Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class Main
    Inherits System.Windows.Forms.Form

    Private ds_server As New DataSet
    Friend WithEvents InsertHitsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private ds As New DataSet
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents butCoins As System.Windows.Forms.ToolBarButton
    Friend WithEvents butBalances As System.Windows.Forms.ToolBarButton
    Friend WithEvents butTrades As System.Windows.Forms.ToolBarButton
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butAbout As System.Windows.Forms.ToolBarButton
    Friend WithEvents butHelp As System.Windows.Forms.ToolBarButton
    Friend WithEvents DailyPricesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.DailyPricesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.InsertHitsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = -1
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem4, Me.MenuItem14, Me.MenuItem5})
        Me.MenuItem1.Text = "DB Transfer"
        '
        'MenuItem4
        '
        Me.MenuItem4.Checked = True
        Me.MenuItem4.Index = 0
        Me.MenuItem4.Text = "Settings"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 1
        Me.MenuItem14.Text = "Comparison Tables"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 2
        Me.MenuItem5.Text = "Transfer Tables"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = -1
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem12})
        Me.MenuItem6.Text = "DB Browser"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 0
        Me.MenuItem12.Text = "Browse Database"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = -1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem9, Me.MenuItem10, Me.MenuItem7, Me.MenuItem8})
        Me.MenuItem2.Text = "Vensters"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 0
        Me.MenuItem9.Text = "&Cascade"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 1
        Me.MenuItem10.Text = "&Layered"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 2
        Me.MenuItem7.Text = "Vertical"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 3
        Me.MenuItem8.Text = "&Horizontal"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = -1
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem11})
        Me.MenuItem3.Text = "Help"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 0
        Me.MenuItem11.Text = "About"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Button001-coins.bmp")
        Me.ImageList1.Images.SetKeyName(1, "Button002-balance.bmp")
        Me.ImageList1.Images.SetKeyName(2, "Button002-balanceB.bmp")
        Me.ImageList1.Images.SetKeyName(3, "Button003-tradeA.bmp")
        Me.ImageList1.Images.SetKeyName(4, "Button003-tradeB.bmp")
        Me.ImageList1.Images.SetKeyName(5, "Button003-tradeC.bmp")
        Me.ImageList1.Images.SetKeyName(6, "Button004-pricesA.bmp")
        Me.ImageList1.Images.SetKeyName(7, "Button004-pricesB.bmp")
        Me.ImageList1.Images.SetKeyName(8, "Button005-exit.bmp")
        Me.ImageList1.Images.SetKeyName(9, "coinfo001.bmp")
        Me.ImageList1.Images.SetKeyName(10, "Lookup.jpg")
        Me.ImageList1.Images.SetKeyName(11, "help001.bmp")
        Me.ImageList1.Images.SetKeyName(12, "help002.bmp")
        Me.ImageList1.Images.SetKeyName(13, "cryptocoin001.bmp")
        Me.ImageList1.Images.SetKeyName(14, "cryptocoin002.bmp")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DailyPricesToolStripMenuItem, Me.ExitToolStripMenuItem, Me.ExitToolStripMenuItem1, Me.InsertHitsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(732, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DailyPricesToolStripMenuItem
        '
        Me.DailyPricesToolStripMenuItem.Name = "DailyPricesToolStripMenuItem"
        Me.DailyPricesToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.DailyPricesToolStripMenuItem.Text = "&Artists"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ExitToolStripMenuItem.Text = "The Hits"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(38, 20)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'InsertHitsToolStripMenuItem
        '
        Me.InsertHitsToolStripMenuItem.Name = "InsertHitsToolStripMenuItem"
        Me.InsertHitsToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.InsertHitsToolStripMenuItem.Text = "InsertHits"
        Me.InsertHitsToolStripMenuItem.Visible = False
        '
        'Main
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(732, 425)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.Text = "USA POP Artists and Hits Archive"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade)

    End Sub

    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade)

    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical)

    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal)

    End Sub



    Private Sub DailyPricesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UpdateLicense()
        Dim srv, user, pwd, db, mysql, type, myact, CurDate As String
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand

        Try
            myconnection1.Open()

            'update tabel productinfo
            mysql = "update productinfo set license = 'DJY5RHGKIEWSX56GJHJKK23HH'"
            mycommand.Connection = myconnection1
            mycommand.CommandText = mysql
            mycommand.ExecuteNonQuery()

        Catch ex As Exception

        Finally
            myconnection1.Close()

        End Try

    End Sub

    Private Function ReadLicense() As String
        Dim srv, user, pwd, db, mysql, type, mylic, myact As String
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mysql = "select IIf(license Is Not NULL, license, '') from productinfo"
        mycommand = New OleDbCommand

        Try
            myconnection1.Open()
            mycommand.Connection = myconnection1
            mycommand.CommandText = mysql
            mylic = mycommand.ExecuteScalar()
            Return mylic

        Catch ex As Exception

            MsgBox("License Data are corrupt ! Please contact supplier for activation data ! ")
            MsgBox(ex.Message)
            Me.Close()

        Finally
            myconnection1.Close()

        End Try

    End Function

    Private Sub EnterInstallDate()
        Dim srv, user, pwd, db, mysql, type, myact, CurDate As String

        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand

        Try
            myconnection1.Open()
            CurDate = Today.ToString()

            'update tabel licenseinfo
            mysql = "update productinfo set installation = '" + CurDate + "'"
            mycommand.Connection = myconnection1
            mycommand.CommandText = mysql
            mycommand.ExecuteNonQuery()

        Catch ex As Exception

        Finally
            myconnection1.Close()

        End Try

    End Sub

    Private Function GetInstallDate() As String
        Dim srv, user, pwd, db, mysql, type, myact As String

        Dim mystring, mydir As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mydir = CurDir()

        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mysql = "select IIf(installation Is Not NULL, installation, '') from productinfo"
        mycommand = New OleDbCommand

        Try
            myconnection1.Open()
            mycommand.Connection = myconnection1
            mycommand.CommandText = mysql
            myact = mycommand.ExecuteScalar()

        Catch ex As Exception
            MsgBox("Database Data are corrupt ! Please contact supplier for repair !  !")
            MsgBox(ex.Message)
            Me.Close()

        Finally
            myconnection1.Close()
        End Try

        Return myact


    End Function




    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Dim myform As New frmAnalyzeLijstenUSA(0)
        myform.MdiParent = Me
        myform.Show()


    End Sub


    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub



    Private Sub ArtistsNLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim myform As New frmArtiestenUSA(0)
        myform.MdiParent = Me
        myform.Show()

    End Sub



    Private Sub NLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim myform As New frmAnalyzeLijstenUSA(0)
        myform.MdiParent = Me
        myform.Show()

    End Sub




    Private Sub ImportNLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myform As New frmImportLijstenUSA
        myform.MdiParent = Me
        myform.Show()

    End Sub


    Private Sub DailyPricesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyPricesToolStripMenuItem.Click

        Dim myform As New frmArtiestenUSA(0)
        myform.MdiParent = Me
        myform.Show()


    End Sub

    Private Sub InsertHitsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertHitsToolStripMenuItem.Click

        Dim myform As New frmImportLijstenUSA
        myform.MdiParent = Me
        myform.Show()

    End Sub
End Class
