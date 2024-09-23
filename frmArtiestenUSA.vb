Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmArtiestenUSA
    Private ds, ds1, ds_server As New DataSet
    Private KoersNum As Integer
    Private KoersEuro, KoersDollar As Integer
    Private Started1, Started2 As Boolean
    Private MyResults As String
    Private Expanded As Boolean = False
    Private TheExchange, TableName As String
    Private curCode, curName, curExch, curExch2 As String
    Private EN1, EN2 As String
    Public ShowHits As Boolean = True

    Private MyArtist, MyChoice, MyYear, MyYear2 As String


    Sub New(ByVal exch As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        TableName = "SongUSA"
        MyArtist = ""

    End Sub

    Private Sub frmImportCoins_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KoersNum = 0

        ds.Reset()
        Me.LoadDataset(2)
        Started2 = True
        Me.LoadArtists()


    End Sub

    Private Sub LoadArtists()
        Dim srv, user, pwd, db, mysql, s1, type, mysqlcat, mysqlcat2 As String
        Dim mystring As String
        Dim datemp As DbDataAdapter
        Dim dstemp As New DataSet
        Dim da, da_categorie, da_opbrengsten As DbDataAdapter
        Dim myconnection1 As DbConnection

        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        myconnection1.Open()

        mysql = "select ArtistName from ArtistUSA order by ArtistName"
        datemp = New OleDbDataAdapter
        datemp.SelectCommand = New OleDbCommand(mysql, myconnection1)
        datemp.Fill(dstemp, "ArtistUSA")
        For i = 0 To dstemp.Tables(0).Rows.Count - 1
            s1 = dstemp.Tables(0).Rows(i).Item(0)
            cbArtists.Items.Add(s1)
        Next


    End Sub


    Private Sub LoadAltcoins(ByVal num As Integer)

        Dim srv, user, pwd, db, mysql, type, nullstr As String
        Dim mystring, d1, d2 As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim dblNu, dblOrig, amount, dbl1, dbl2, EuroNu, EuroOrig As Double

        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        DGAltcoins.TableStyles.Clear()
        Me.FormatColumnHeaders2()

        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)
        'KoersEuro = CInt(ds_server.Tables(0).Rows(0).Item(6))
        'KoersDollar = CInt(ds_server.Tables(0).Rows(0).Item(7))

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        Me.Location = New Point(0, 0)

        If MyArtist = "" And MyChoice = "" Then
            mysql = "select SongName,Artist,SongYear from " + TableName
        Else
            If MyArtist <> "" Then
                mysql = "select SongName,Artist,SongYear  from " + TableName + " where Artist like '%" + MyArtist + "%'"
            Else 'MyChoice !
                mysql = "select SongName,Artist,SongYear  from " + TableName + " where Artist = '" + MyChoice + "'"
            End If

        End If

        If MyYear <> "" Then
            mysql = mysql + " and SongYear >= '" + MyYear + "' and SongYear <= '" + MyYear2 + "'"
        End If
        mysql = mysql + " order by SongYear,SongName"

        Me.Text = "USA POP Artists and Hits Search Artists"

        da = New OleDbDataAdapter
        da.SelectCommand = New OleDbCommand(mysql, myconnection1)

        Try
            myconnection1.Open()
            da.Fill(ds, TableName)
            DGAltcoins.DataSource = ds.Tables(0)

        Catch ex As Exception

            MsgBox(ex.Message)


        Finally
            myconnection1.Close()

        End Try

    End Sub


    Private Sub LoadDataset(ByVal num As Integer)

        Me.LoadAltcoins(num)

    End Sub


    Private Sub FormatColumnHeaders2()

        Dim ts2 As New DataGridTableStyle
        Dim cs1, cs2, cs3, cs4, cs4a, cs4b, cs4c, cs4d, cs5, cs5a, cs5b, cs5c, cs5d, cs6, cs7, cs8, cs9, cs10, cs11 As DataGridTextBoxColumn

        ts2.MappingName = TableName

        cs2 = New DataGridTextBoxColumn
        cs2.MappingName = "SongName"
        cs2.HeaderText = "SongName"
        cs2.Width = 300
        ts2.GridColumnStyles.Add(cs2)

        cs3 = New DataGridTextBoxColumn
        cs3.MappingName = "Artist"
        cs3.HeaderText = "Artist"
        cs3.Width = 200
        ts2.GridColumnStyles.Add(cs3)

        cs4 = New DataGridTextBoxColumn
        ' cs4.Format = "#########"
        cs4.MappingName = "SongYear"
        cs4.HeaderText = "Year"
        cs4.Width = 60
        ts2.GridColumnStyles.Add(cs4)

        DGAltcoins.TableStyles.Add(ts2)

    End Sub




    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If txtYear.Text <> "" Then
            MyYear = txtYear.Text
            If txtYear2.Text <> "" Then
                MyYear2 = txtYear2.Text
            Else
                MyYear2 = MyYear
            End If
        Else
            MyYear = ""
            MyYear2 = ""
        End If

        If txtArtist.Text <> "" Then
            MyChoice = ""
            MyArtist = txtArtist.Text
        Else
            If cbArtists.Text <> "" Then
                MyArtist = ""
                MyChoice = cbArtists.Text
            End If
        End If

        ds.Reset()
        Me.LoadDataset(2)
        Me.Refresh()

    End Sub

    Private Sub cbArtists_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArtists.SelectedIndexChanged

        txtArtist.Text = ""

    End Sub

    Private Sub web1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles web1.Click
        Dim myurl, myurl2, text, myartist, mytitle As String
        Dim myrow As Integer

        Try

            myrow = DGAltcoins.CurrentRowIndex
            myartist = ds.Tables(0).Rows(myrow).Item(0)
            mytitle = ds.Tables(0).Rows(myrow).Item(1)
            'myurl = "https://www.youtube.com/results?search_query=" + myartist + "+" + mytitle
            myurl = "https://www.y2mate.com/search/" + myartist + "+" + mytitle

            If ShowHits = True Then
                WebBrowser1.ScriptErrorsSuppressed = True
                WebBrowser1.Url = New System.Uri(myurl)
                WebBrowser1.Visible = True
                web1.Text = "&Search Artists"

                ShowHits = False
            Else
                WebBrowser1.Visible = False
                web1.Text = "&Music Video's"

                ShowHits = True

            End If

            'Dim myform As New frmShowYoutube(myurl, myartist, mytitle)
            'myform.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
End Class