Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmImportLijstenUSA
    Private ds, ds1, ds_server As New DataSet
    Private KoersNum As Integer
    Private KoersEuro, KoersDollar As Integer
    Private Started1, Started2 As Boolean
    Private MyResults As String
    Private Expanded As Boolean = False
    Private BaseURLTop40 As String = "https://www.billboard.com/charts/hot-100/"

    Private NrOfAlbums As Integer

    Private TheList, TheYear, TheWeek As Integer
    Private TheBatch As Boolean = False
    Private StopBatch As Boolean = False
    Private BatchCount As Integer = 0
    Private CurIndex As Integer


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Expanded = False Then
            Me.Width = Me.Width + TextBox1.Width + 20
            Expanded = True
        End If

        TextBox1.SelectionStart = 0
        TextBox1.SelectionLength = TextBox1.Text.Length
        TextBox1.Focus()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub RemoveCMCoins()
        Dim srv, user, pwd, db, mysql, type, nullstr, Coin As String
        Dim mystring, my_sql, test_sql, valorig, valnu As String
        Dim nrofinserts, myret, dblPerc, amount As Integer
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim dblOrig, dblNu, dbl1, dbl2

        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1
        myconnection1.Open()



        myconnection1.Close()

    End Sub


    Private Sub frmImportCoins_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KoersNum = 0

        ds.Reset()
        Me.LoadDataset(2)
        Started2 = True

        ds1.ReadXml(CurDir() + "\xml\altcoin.xml")
        Me.DataGrid1.DataSource = Me.ds1.Tables(0)
        Me.FormatColumnHeadersA()
        ds1.Tables(0).Rows.RemoveAt(0)

        NrOfAlbums = 100

    End Sub

    Private Sub LoadAltcoins(ByVal num As Integer)

        Dim srv, user, pwd, db, mysql, type, nullstr, test_sql, myhitdate As String
        Dim myret, Weeknr As Integer
        Dim mystring, d1, d2 As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim dblNu, dblOrig, amount, dbl1, dbl2, EuroNu, EuroOrig As Double
        Dim mycommand As DbCommand

        ds_server.ReadXml(CurDir() + "\xml\server.xml")

        If Started2 = False Then
            Me.FormatColumnHeaders2()
        End If

        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        Me.Location = New Point(0, 0)
        If KoersNum = 0 Then
            mysql = "select Listid,nr01,nr02,nr03 from Top100ListItemsUSA order by Listid"
            Me.Text = "Import USA Hot 100 Lists"
        End If
        da = New OleDbDataAdapter
        da.SelectCommand = New OleDbCommand(mysql, myconnection1)

        Try
            myconnection1.Open()
            da.Fill(ds, "Top100ListItemsUSA")
            DGAltcoins.DataSource = ds.Tables(0)

            mycommand = New OleDbCommand
            mycommand.Connection = myconnection1

            'get listnumber
            test_sql = "Select max(Listid) from Top100ListItemsUSA"
            mycommand.CommandText = test_sql
            myret = mycommand.ExecuteScalar()
            TheList = myret

            tbNR.Text = CInt(myret + 1)

            'get year 
            test_sql = "Select listyear from Top100ListUSA where id = " + TheList.ToString()
            mycommand.CommandText = test_sql
            myret = mycommand.ExecuteScalar()
            TheYear = myret


            'get week
            test_sql = "Select week from Top100ListUSA where id = " + TheList.ToString()
            mycommand.CommandText = test_sql
            myret = mycommand.ExecuteScalar()
            TheWeek = myret

            test_sql = "Select hitdate from USAWeeks where hityear = " + TheYear.ToString() + " and hitweek = " + TheWeek.ToString()
            mycommand.CommandText = test_sql
            myhitdate = mycommand.ExecuteScalar()


            If TheWeek < 52 Then
                TheWeek = TheWeek + 1
                tbWEEK.Text = TheWeek.ToString()
                tbYEAR.Text = TheYear.ToString()
                tbDATE.Text = myhitdate
            Else
                TheYear = TheYear + 1
                TheWeek = 1
                tbWEEK.Text = TheWeek.ToString()
                tbYEAR.Text = TheYear.ToString()
                tbDATE.Text = myhitdate
            End If


        Catch ex As Exception

            MsgBox(ex.Message)


        Finally
            myconnection1.Close()

        End Try

    End Sub


    Private Sub LoadDataset(ByVal num As Integer)

        Me.LoadAltcoins(num)

    End Sub

    Private Sub FormatColumnHeadersA()

        Dim ts As New DataGridTableStyle
        Dim cs0, cs1, cs2, cs3, cs4, cs4a, cs5, cs5a, cs5b, cs5c, cs5d, cs6, cs7, cs8, cs9, cs10, cs11 As DataGridTextBoxColumn

        ts.MappingName = "ALTCOIN"

        cs1 = New DataGridTextBoxColumn
        cs1.MappingName = "code"
        cs1.HeaderText = "code"
        cs1.Width = 180
        ts.GridColumnStyles.Add(cs1)

        cs0 = New DataGridTextBoxColumn
        cs0.MappingName = "importdatum"
        cs0.HeaderText = "date"
        cs0.Width = 0
        ts.GridColumnStyles.Add(cs0)

        cs2 = New DataGridTextBoxColumn
        cs2.MappingName = "name"
        cs2.HeaderText = "naam"
        cs2.Width = 100
        ts.GridColumnStyles.Add(cs2)

        cs3 = New DataGridTextBoxColumn
        cs3.MappingName = "website"
        cs3.HeaderText = "website"
        cs3.Width = 0
        ts.GridColumnStyles.Add(cs3)

        cs4 = New DataGridTextBoxColumn
        cs4.MappingName = "valueBTC"
        cs4.HeaderText = "PriceBTC"
        cs4.Width = 0
        ts.GridColumnStyles.Add(cs4)

        cs5 = New DataGridTextBoxColumn
        cs5.MappingName = "volumeBTC"
        cs5.HeaderText = "volumeBTC"
        cs5.Width = 0
        ts.GridColumnStyles.Add(cs5)

        DataGrid1.TableStyles.Add(ts)


    End Sub


    Private Sub FormatColumnHeaders2()

        Dim ts2 As New DataGridTableStyle
        Dim cs1, cs2, cs3, cs4, cs4a, cs4b, cs4c, cs4d, cs5, cs5a, cs5b, cs5c, cs5d, cs6, cs7, cs8, cs9, cs10, cs11 As DataGridTextBoxColumn

        ts2.MappingName = "Top100ListItemsUSA"

        cs2 = New DataGridTextBoxColumn
        cs2.MappingName = "Listid"
        cs2.HeaderText = "Nr List"
        cs2.Width = 60
        ts2.GridColumnStyles.Add(cs2)

        cs3 = New DataGridTextBoxColumn
        cs3.MappingName = "nr01"
        cs3.HeaderText = "Nr 1:"
        cs3.Width = 200
        ts2.GridColumnStyles.Add(cs3)

        cs4 = New DataGridTextBoxColumn
        cs4.MappingName = "nr02"
        cs4.HeaderText = "Nr 2:"
        cs4.Width = 200
        ts2.GridColumnStyles.Add(cs4)

        cs5 = New DataGridTextBoxColumn
        cs5.MappingName = "nr03"
        cs5.HeaderText = "Nr 3:"
        cs5.Width = 200
        ts2.GridColumnStyles.Add(cs5)

        DGAltcoins.TableStyles.Add(ts2)

    End Sub



    Private Sub InsertDatagrid(ByVal MySong As String, ByVal MyDate As String, ByVal MyName As String)
        Dim myrow As DataRow
        Dim filnam, filnamnew As String
        Dim st1 As Integer
        Dim index1 As Integer

        filnam = MySong
        st1 = 0
        index1 = filnam.IndexOf("'", st1)
        filnamnew = ""
        While index1 > -1
            filnamnew = filnamnew + filnam.Substring(st1, index1 - st1)

            st1 = index1 + 1
            index1 = filnam.IndexOf("'", st1)
        End While
        If filnamnew = "" Then
            'check 1st pos
            index1 = filnam.IndexOf("'", 0)
            If index1 > -1 Then
                filnamnew = filnam.Substring(1, filnam.Length - 1)
            Else
                filnamnew = filnam
            End If
        Else 'copy end of string
            filnamnew = filnamnew + filnam.Substring(st1, filnam.Length - st1)
        End If
        MySong = filnamnew

        filnam = MyName
        st1 = 0
        index1 = filnam.IndexOf("'", st1)
        filnamnew = ""
        While index1 > -1
            filnamnew = filnamnew + filnam.Substring(st1, index1 - st1)

            st1 = index1 + 1
            index1 = filnam.IndexOf("'", st1)
        End While
        If filnamnew = "" Then
            'check 1st pos
            index1 = filnam.IndexOf("'", 0)
            If index1 > -1 Then
                filnamnew = filnam.Substring(1, filnam.Length - 1)
            Else
                filnamnew = filnam
            End If
        Else 'copy end of string
            filnamnew = filnamnew + filnam.Substring(st1, filnam.Length - st1)
        End If
        MyName = filnamnew


        myrow = Me.ds1.Tables(0).NewRow()
        ds1.Tables(0).Rows.InsertAt(myrow, ds1.Tables(0).Rows.Count)
        myrow.Item(0) = MySong
        myrow.Item(1) = MyDate
        myrow.Item(2) = MyName
        myrow.Item(3) = " "
        myrow.Item(4) = " "
        myrow.Item(5) = " "

    End Sub

    Private Function CM1SongToDatagrid(ByVal MyResults As String, ByVal MyIndex As Integer, ByVal SongNum As Integer) As Integer

        Dim ind1, ind2, start1, start2, rownr, lenStr As Integer ' Hoofdstring
        Dim index1, index2, st1, st2 As Integer 'Substring
        Dim newCoin As Boolean
        Dim AltcoinStr, LastChar As String
        Dim MyDateStr, Song, Name, Website, ValueBTC, VolumeBTC, Temp1, Temp2 As String
        Dim str_in, str_out As String
        Dim i As Integer
        Dim myrow As DataRow

        Dim MyDate As DateTime = Now()
        MyDateStr = MyDate.ToString("yyyy-MM-dd hh:mm")

        Dim LastSongNum As Integer

        If SongNum > 1 Then
            LastSongNum = SongNum - 1
        End If

        If SongNum < 99 Then
            Temp1 = SongNum.ToString + "  "
        Else
            Temp1 = SongNum.ToString + " "
        End If
        ind1 = MyIndex
        start1 = ind1
        ind2 = MyResults.IndexOf(Temp1, start1)
        If ((ind2 = -1)) Then 'next 1 not found
            Temp1 = LastSongNum.ToString + "  "
            ind1 = MyIndex
            start1 = ind1
            ind2 = MyResults.IndexOf(Temp1, start1)
            'If ((ind2 = -1) Or (ind2 - ind1 > 100)) Then 'same 1 not found
            '    Temp1 = (SongNum + 1).ToString + " "
            '    ind1 = MyIndex
            '    start1 = ind1
            '    ind2 = MyResults.IndexOf(Temp1, start1)
            '    If ((ind2 = -1) Or (ind2 - ind1 > 100)) Then 'same 1 not found
            '        MsgBox("not found")
            '        Return -1
            '    Else
            '        Status = 1
            '    End If

            'End If

        End If




        ind1 = ind2
        start1 = ind1
        ind2 = MyResults.IndexOf(vbCrLf, start1)
        AltcoinStr = MyResults.Substring(ind1, ind2 - ind1)
        ind1 = ind2 + 12

        start1 = ind1
        ind2 = MyResults.IndexOf(vbCrLf, start1)
        AltcoinStr = MyResults.Substring(ind1, ind2 - ind1)

        Song = AltcoinStr
        ind1 = ind2 + 3
        start1 = ind1
        ind2 = MyResults.IndexOf(vbCrLf, start1)
        AltcoinStr = MyResults.Substring(ind1, ind2 - ind1 - 2)
        Name = AltcoinStr

        'Correct the last lines until 

        Me.InsertDatagrid(Song, MyDateStr, Name)

        ind1 = ind2 + 1
        Return ind1


    End Function





    Private Function CMSongstoDatagrid() As Integer

        Dim ind1, ind2, start1, start2, rownr, lenStr, MyStatus As Integer ' Hoofdstring
        Dim index1, index2, st1, st2 As Integer 'Substring
        Dim newCoin As Boolean
        Dim AltcoinStr, LastChar, MyAmount As String
        Dim MyDateStr, Song, Name, Website, ValueBTC, VolumeBTC, Temp1, Temp2 As String
        Dim str_in, str_out As String
        Dim i As Integer
        Dim myrow As DataRow



        Dim MyDate As DateTime = Now()
        MyDateStr = MyDate.ToString("yyyy-MM-dd hh:mm")

        rownr = 0
        start1 = 0
        MyResults = TextBox1.Text
        lenStr = MyResults.Length

        ind2 = MyResults.IndexOf("Sadly, our database holds no chart for the date you have requested", 0)
        If ind2 > -1 Then
            Timer1.Stop()
            MsgBox("The database holds no chart for the date you have requested !!!")
            Return -1
        End If


        newCoin = True
        ind1 = 0
        start1 = CurIndex
        ind2 = MyResults.IndexOf("Search the Chart Archives", start1)
        ind1 = ind2 + 1
        start1 = ind1

        For i = 1 To NrOfAlbums
            ind1 = Me.CM1SongToDatagrid(MyResults, ind1, i)

        Next

        Return 0


    End Function

    Private Sub InsertCMCoins()

        Dim srv, user, pwd, db, mysql, type, nullstr, Coin, MyDateStr, TheSong, TheArtist, TheName, TheYear, TheWeek As String
        Dim mystring, my_sql, test_sql, valorig, valnu, dblPerc, myurl, hityear As String
        Dim nrofinserts, myret, amount, lijstnr, MySongId As Integer
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim dblOrig, dblNu, dbl1, dbl2 As Double
        Dim week, year As Integer


        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        ' Open connection
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1
        myconnection1.Open()

        Dim MyDate As DateTime = Now()
        MyDateStr = MyDate.ToString("yyyy-MM-dd hh:mm")

        If tbNR.Text = "" Then
            MsgBox("lijstnummer niet gevuld")
            Return
        End If
        ' invoeren lijstnummer vooraf
        lijstnr = CInt(tbNR.Text)

        If tbYEAR.Text = "" Then
            MsgBox("jaar niet gevuld")
            Return
        End If
        TheYear = tbYEAR.Text
        TheWeek = tbWEEK.Text

        'Insert all 40-100 songs
        my_sql = "insert into Top100ListItemsUSA values ("
        my_sql = my_sql + lijstnr.ToString() + ",'"
        TheSong = ds1.Tables(0).Rows(0).Item(2) + "-" + ds1.Tables(0).Rows(0).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 1
        TheSong = ds1.Tables(0).Rows(1).Item(2) + "-" + ds1.Tables(0).Rows(1).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 2
        TheSong = ds1.Tables(0).Rows(2).Item(2) + "-" + ds1.Tables(0).Rows(2).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 3
        TheSong = ds1.Tables(0).Rows(3).Item(2) + "-" + ds1.Tables(0).Rows(3).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 4
        TheSong = ds1.Tables(0).Rows(4).Item(2) + "-" + ds1.Tables(0).Rows(4).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 5
        TheSong = ds1.Tables(0).Rows(5).Item(2) + "-" + ds1.Tables(0).Rows(5).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 6
        TheSong = ds1.Tables(0).Rows(6).Item(2) + "-" + ds1.Tables(0).Rows(6).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 7
        TheSong = ds1.Tables(0).Rows(7).Item(2) + "-" + ds1.Tables(0).Rows(7).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 8
        TheSong = ds1.Tables(0).Rows(8).Item(2) + "-" + ds1.Tables(0).Rows(8).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 9
        TheSong = ds1.Tables(0).Rows(9).Item(2) + "-" + ds1.Tables(0).Rows(9).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 10
        TheSong = ds1.Tables(0).Rows(10).Item(2) + "-" + ds1.Tables(0).Rows(10).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 11
        TheSong = ds1.Tables(0).Rows(11).Item(2) + "-" + ds1.Tables(0).Rows(11).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 12
        TheSong = ds1.Tables(0).Rows(12).Item(2) + "-" + ds1.Tables(0).Rows(12).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 13
        TheSong = ds1.Tables(0).Rows(13).Item(2) + "-" + ds1.Tables(0).Rows(13).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 14
        TheSong = ds1.Tables(0).Rows(14).Item(2) + "-" + ds1.Tables(0).Rows(14).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 15
        TheSong = ds1.Tables(0).Rows(15).Item(2) + "-" + ds1.Tables(0).Rows(15).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 16
        TheSong = ds1.Tables(0).Rows(16).Item(2) + "-" + ds1.Tables(0).Rows(16).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 17
        TheSong = ds1.Tables(0).Rows(17).Item(2) + "-" + ds1.Tables(0).Rows(17).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 18
        TheSong = ds1.Tables(0).Rows(18).Item(2) + "-" + ds1.Tables(0).Rows(18).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 19
        TheSong = ds1.Tables(0).Rows(19).Item(2) + "-" + ds1.Tables(0).Rows(19).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 20

        TheSong = ds1.Tables(0).Rows(20).Item(2) + "-" + ds1.Tables(0).Rows(20).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 21
        TheSong = ds1.Tables(0).Rows(21).Item(2) + "-" + ds1.Tables(0).Rows(21).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 22
        TheSong = ds1.Tables(0).Rows(22).Item(2) + "-" + ds1.Tables(0).Rows(22).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 23
        TheSong = ds1.Tables(0).Rows(23).Item(2) + "-" + ds1.Tables(0).Rows(23).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 24
        TheSong = ds1.Tables(0).Rows(24).Item(2) + "-" + ds1.Tables(0).Rows(24).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 25
        TheSong = ds1.Tables(0).Rows(25).Item(2) + "-" + ds1.Tables(0).Rows(25).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 26
        TheSong = ds1.Tables(0).Rows(26).Item(2) + "-" + ds1.Tables(0).Rows(26).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 27
        TheSong = ds1.Tables(0).Rows(27).Item(2) + "-" + ds1.Tables(0).Rows(27).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 28
        TheSong = ds1.Tables(0).Rows(28).Item(2) + "-" + ds1.Tables(0).Rows(28).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 29
        TheSong = ds1.Tables(0).Rows(29).Item(2) + "-" + ds1.Tables(0).Rows(29).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 29

        TheSong = ds1.Tables(0).Rows(30).Item(2) + "-" + ds1.Tables(0).Rows(30).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 31
        TheSong = ds1.Tables(0).Rows(31).Item(2) + "-" + ds1.Tables(0).Rows(31).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 32
        TheSong = ds1.Tables(0).Rows(32).Item(2) + "-" + ds1.Tables(0).Rows(32).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 33
        TheSong = ds1.Tables(0).Rows(33).Item(2) + "-" + ds1.Tables(0).Rows(33).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 34
        TheSong = ds1.Tables(0).Rows(34).Item(2) + "-" + ds1.Tables(0).Rows(34).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 35
        TheSong = ds1.Tables(0).Rows(35).Item(2) + "-" + ds1.Tables(0).Rows(35).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 36
        TheSong = ds1.Tables(0).Rows(36).Item(2) + "-" + ds1.Tables(0).Rows(36).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 37
        TheSong = ds1.Tables(0).Rows(37).Item(2) + "-" + ds1.Tables(0).Rows(37).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 38
        TheSong = ds1.Tables(0).Rows(38).Item(2) + "-" + ds1.Tables(0).Rows(38).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 39
        TheSong = ds1.Tables(0).Rows(39).Item(2) + "-" + ds1.Tables(0).Rows(39).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 40
        TheSong = ds1.Tables(0).Rows(40).Item(2) + "-" + ds1.Tables(0).Rows(40).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 41
        TheSong = ds1.Tables(0).Rows(41).Item(2) + "-" + ds1.Tables(0).Rows(41).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 42
        TheSong = ds1.Tables(0).Rows(42).Item(2) + "-" + ds1.Tables(0).Rows(42).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 43
        TheSong = ds1.Tables(0).Rows(43).Item(2) + "-" + ds1.Tables(0).Rows(43).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 44
        TheSong = ds1.Tables(0).Rows(44).Item(2) + "-" + ds1.Tables(0).Rows(44).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 45
        TheSong = ds1.Tables(0).Rows(45).Item(2) + "-" + ds1.Tables(0).Rows(45).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 46
        TheSong = ds1.Tables(0).Rows(46).Item(2) + "-" + ds1.Tables(0).Rows(46).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 47
        TheSong = ds1.Tables(0).Rows(47).Item(2) + "-" + ds1.Tables(0).Rows(47).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 48
        TheSong = ds1.Tables(0).Rows(48).Item(2) + "-" + ds1.Tables(0).Rows(48).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 49
        TheSong = ds1.Tables(0).Rows(49).Item(2) + "-" + ds1.Tables(0).Rows(49).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 50
        TheSong = ds1.Tables(0).Rows(50).Item(2) + "-" + ds1.Tables(0).Rows(50).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 51
        TheSong = ds1.Tables(0).Rows(51).Item(2) + "-" + ds1.Tables(0).Rows(51).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 51
        TheSong = ds1.Tables(0).Rows(52).Item(2) + "-" + ds1.Tables(0).Rows(52).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 51
        TheSong = ds1.Tables(0).Rows(53).Item(2) + "-" + ds1.Tables(0).Rows(53).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 51
        TheSong = ds1.Tables(0).Rows(54).Item(2) + "-" + ds1.Tables(0).Rows(54).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 51
        TheSong = ds1.Tables(0).Rows(55).Item(2) + "-" + ds1.Tables(0).Rows(55).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 51
        TheSong = ds1.Tables(0).Rows(56).Item(2) + "-" + ds1.Tables(0).Rows(56).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 51
        TheSong = ds1.Tables(0).Rows(57).Item(2) + "-" + ds1.Tables(0).Rows(57).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 51
        TheSong = ds1.Tables(0).Rows(58).Item(2) + "-" + ds1.Tables(0).Rows(58).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 51
        TheSong = ds1.Tables(0).Rows(59).Item(2) + "-" + ds1.Tables(0).Rows(59).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 51
        TheSong = ds1.Tables(0).Rows(60).Item(2) + "-" + ds1.Tables(0).Rows(60).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(61).Item(2) + "-" + ds1.Tables(0).Rows(61).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(62).Item(2) + "-" + ds1.Tables(0).Rows(62).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(63).Item(2) + "-" + ds1.Tables(0).Rows(63).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(64).Item(2) + "-" + ds1.Tables(0).Rows(64).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(65).Item(2) + "-" + ds1.Tables(0).Rows(65).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(66).Item(2) + "-" + ds1.Tables(0).Rows(66).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(67).Item(2) + "-" + ds1.Tables(0).Rows(67).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(68).Item(2) + "-" + ds1.Tables(0).Rows(68).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(69).Item(2) + "-" + ds1.Tables(0).Rows(69).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(70).Item(2) + "-" + ds1.Tables(0).Rows(70).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 70
        TheSong = ds1.Tables(0).Rows(71).Item(2) + "-" + ds1.Tables(0).Rows(71).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(72).Item(2) + "-" + ds1.Tables(0).Rows(72).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(73).Item(2) + "-" + ds1.Tables(0).Rows(73).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(74).Item(2) + "-" + ds1.Tables(0).Rows(74).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(75).Item(2) + "-" + ds1.Tables(0).Rows(75).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(76).Item(2) + "-" + ds1.Tables(0).Rows(76).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(77).Item(2) + "-" + ds1.Tables(0).Rows(77).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(78).Item(2) + "-" + ds1.Tables(0).Rows(78).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(79).Item(2) + "-" + ds1.Tables(0).Rows(79).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(80).Item(2) + "-" + ds1.Tables(0).Rows(80).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(81).Item(2) + "-" + ds1.Tables(0).Rows(81).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(82).Item(2) + "-" + ds1.Tables(0).Rows(82).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(83).Item(2) + "-" + ds1.Tables(0).Rows(83).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(84).Item(2) + "-" + ds1.Tables(0).Rows(84).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(85).Item(2) + "-" + ds1.Tables(0).Rows(85).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(86).Item(2) + "-" + ds1.Tables(0).Rows(86).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(87).Item(2) + "-" + ds1.Tables(0).Rows(87).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(88).Item(2) + "-" + ds1.Tables(0).Rows(88).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(89).Item(2) + "-" + ds1.Tables(0).Rows(89).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 60
        TheSong = ds1.Tables(0).Rows(90).Item(2) + "-" + ds1.Tables(0).Rows(90).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 90
        TheSong = ds1.Tables(0).Rows(91).Item(2) + "-" + ds1.Tables(0).Rows(91).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 90
        TheSong = ds1.Tables(0).Rows(92).Item(2) + "-" + ds1.Tables(0).Rows(92).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 90
        TheSong = ds1.Tables(0).Rows(93).Item(2) + "-" + ds1.Tables(0).Rows(93).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 90
        TheSong = ds1.Tables(0).Rows(94).Item(2) + "-" + ds1.Tables(0).Rows(94).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 90
        TheSong = ds1.Tables(0).Rows(95).Item(2) + "-" + ds1.Tables(0).Rows(95).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 90
        TheSong = ds1.Tables(0).Rows(96).Item(2) + "-" + ds1.Tables(0).Rows(96).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 90
        TheSong = ds1.Tables(0).Rows(97).Item(2) + "-" + ds1.Tables(0).Rows(97).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 90
        TheSong = ds1.Tables(0).Rows(98).Item(2) + "-" + ds1.Tables(0).Rows(98).Item(0)
        my_sql = my_sql + TheSong + "','"  ' pos 90
        TheSong = ds1.Tables(0).Rows(99).Item(2) + "-" + ds1.Tables(0).Rows(99).Item(0)
        my_sql = my_sql + TheSong + "')"  ' pos 100

        mycommand.CommandText = my_sql
        mycommand.ExecuteNonQuery()


        'Insert lijst
        TheArtist = ds1.Tables(0).Rows(0).Item(2)
        TheName = ds1.Tables(0).Rows(0).Item(0)
        TheSong = ds1.Tables(0).Rows(0).Item(2) + "-" + ds1.Tables(0).Rows(0).Item(0)

        my_sql = "insert into Top100ListUSA values (" + lijstnr.ToString() + ",'" + TheYear + "','" + TheWeek + "','" + TheArtist + "','" + TheName + "','" + TheSong + "')"
        mycommand.CommandText = my_sql
        mycommand.ExecuteNonQuery()

        test_sql = "Select max(songid) from SongUSA"
        mycommand.CommandText = test_sql
        myret = mycommand.ExecuteScalar()
        MySongId = myret + 1

        For i = 0 To NrOfAlbums - 1
            TheArtist = ds1.Tables(0).Rows(i).Item(2)
            TheName = ds1.Tables(0).Rows(i).Item(0)

            TheSong = ds1.Tables(0).Rows(i).Item(2) + "-" + ds1.Tables(0).Rows(i).Item(0)

            test_sql = "Select count(*) from ArtistUSA where ArtistName = '" + TheArtist + "'"
            mycommand.CommandText = test_sql
            myret = mycommand.ExecuteScalar()

            If myret > 0 Then  ' Artist exist already
                'do nothing
            Else
                'insert the new artist
                my_sql = "insert into ArtistUSA(ArtistName) values ('" + TheArtist + "')"  ' artist name
                mycommand.CommandText = my_sql
                mycommand.ExecuteNonQuery()
            End If

            test_sql = "Select count(*) from SongUSA where Artist = '" + TheArtist + "' AND SongName = '" + TheName + "'"
            mycommand.CommandText = test_sql
            myret = mycommand.ExecuteScalar()

            If myret > 0 Then  ' Song exist already
                'do nothing
            Else
                'insert the new artist
                my_sql = "insert into SongUSA(SongId,SongName,Artist,Hitname,SongYear) values (" + MySongId.ToString() + ",'" + TheName + "','" + TheArtist + "','" + TheSong + "','" + TheYear + "')"
                mycommand.CommandText = my_sql
                mycommand.ExecuteNonQuery()
                MySongId = MySongId + 1

            End If
        Next
        ' adjust the week

        week = CInt(tbWEEK.Text)
        Year = CInt(tbYEAR.Text)
        If week < 52 Then
            week = week + 1
            tbWEEK.Text = week.ToString()
        Else
            year = year + 1
            week = 1
            tbWEEK.Text = week.ToString()
            tbYEAR.Text = Year.ToString()
        End If

        tbURL.Text = " "
        WebBrowser1.Url = New System.Uri("https://www.google.com")

    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Width = Me.Width - TextBox1.Width - 20
        Expanded = False


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Place in Datagrid
        Me.CMSongstoDatagrid()
        Me.Refresh()

    End Sub

    Private Sub CopyWebpage()

        Dim myurl, text As String
        Dim myyear, myweek, myhitdate As String
        Dim srv, user, pwd, db, mysql, type, nullstr, Coin As String
        Dim mystring, my_sql, test_sql, valorig, valnu As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        Try

            ds_server.ReadXml(CurDir() + "\xml\server.xml")
            type = ds_server.Tables(0).Rows(0).Item(0)
            srv = ds_server.Tables(0).Rows(0).Item(1)
            user = ds_server.Tables(0).Rows(0).Item(2)
            pwd = ds_server.Tables(0).Rows(0).Item(3)
            db = ds_server.Tables(0).Rows(0).Item(4)

            mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
            myconnection1 = New OleDbConnection(mystring)
            mycommand = New OleDbCommand
            mycommand.Connection = myconnection1
            myconnection1.Open()

            myyear = tbYEAR.Text
            myweek = tbWEEK.Text
            test_sql = "Select hitdate from USAWeeks where hityear = " + myyear + " and hitweek = " + myweek
            mycommand.CommandText = test_sql
            myhitdate = mycommand.ExecuteScalar()
            myconnection1.Close()


            myurl = BaseURLTop40 + myyear + myhitdate
            tbURL.Text = myurl

            WebBrowser1.ScriptErrorsSuppressed = True
            WebBrowser1.Url = New System.Uri(myurl)
            'ParentForm.Enabled = False

            Timer1.Start()


        Catch ex As Exception
            MsgBox("error")


        End Try


    End Sub



    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        TheBatch = False
        Me.CopyWebpage()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim text As String


        WebBrowser1.Document.ExecCommand("SelectAll", False, Nothing)
        WebBrowser1.Document.ExecCommand("Copy", False, Nothing)
        text = Clipboard.GetText()
        'MessageBox.Show(text, "Text")

        TextBox1.Text = text
        'TextBox1.SelectionStart = 0
        'TextBox1.SelectionLength = TextBox1.Text.Length
        TextBox1.Focus()





        'Clipboard.SetText(WebBrowser1.Document.Body.InnerText)
        'text = Clipboard.GetText()
        'MessageBox.Show(text, "Text")

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.SelectionStart = 0
        TextBox1.SelectionLength = TextBox1.Text.Length
        TextBox1.Focus()


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim text As String


        'If WebBrowser1.IsAccessible = True Then
        If WebBrowser1.IsBusy = True Then 'navigation not ready yet. wait some more
            Timer1.Start()
        Else
            If BatchCount Mod 2 = 1 Then
                'ParentForm.Enabled = True
                Timer1.Start()

            Else 'activate 
                'copy contents from webpage
                WebBrowser1.Document.ExecCommand("SelectAll", False, Nothing)
                WebBrowser1.Document.ExecCommand("Copy", False, Nothing)
                text = Clipboard.GetText()
                TextBox1.Text = text

                'Place in Datagrid
                If Me.CMSongstoDatagrid() = 0 Then
                    'Update Lijsten
                    Me.InsertCMCoins()

                    ds.Reset()
                    Me.LoadDataset(2)
                    For i = 0 To 99
                        ds1.Tables(0).Rows.RemoveAt(0)
                    Next
                    TextBox1.Text = ""

                    If TheBatch = False Then
                        Timer1.Stop()
                        'ParentForm.Enabled = True
                        Me.Refresh()
                    Else
                        If StopBatch = False Then
                            Me.CopyWebpage()
                            'ParentForm.Enabled = False
                            Timer1.Start()
                        Else
                            Timer1.Stop()
                            'ParentForm.Enabled = True
                            'Me.Refresh()
                        End If

                    End If
                Else
                    Timer1.Stop()
                    Me.Refresh()

                End If


            End If

        End If
        BatchCount = BatchCount + 1


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim week, year As Integer
        Dim mystr As String

        Dim srv, user, pwd, db, mysql, type, nullstr, Coin As String
        Dim mystring, my_sql, test_sql, valorig, valnu As String
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
        mycommand.Connection = myconnection1
        myconnection1.Open()

        week = 1
        Dim mydate As New Date(2018, 1, 5)
        year = 2018
        mystr = "0105"

        For i = 1 To 52

            test_sql = "insert into UKWeeks values (" + year.ToString() + "," + week.ToString() + ",'" + mystr + "')"
            mycommand.CommandText = test_sql
            mycommand.ExecuteNonQuery()

            mydate = mydate.AddDays(7)
            mystr = mydate.ToString("MMdd")
            week = week + 1

        Next
        myconnection1.Close()

    End Sub

    Private Sub tbWEEK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbWEEK.TextChanged

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        TheBatch = True
        Me.CopyWebpage()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        StopBatch = True

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myurl, text As String
        Dim myyear, myweek, myhitdate As String
        Dim srv, user, pwd, db, mysql, type, nullstr, Coin As String
        Dim mystring, my_sql, test_sql, valorig, valnu As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        Try
            ds_server.ReadXml(CurDir() + "\xml\server.xml")
            type = ds_server.Tables(0).Rows(0).Item(0)
            srv = ds_server.Tables(0).Rows(0).Item(1)
            user = ds_server.Tables(0).Rows(0).Item(2)
            pwd = ds_server.Tables(0).Rows(0).Item(3)
            db = ds_server.Tables(0).Rows(0).Item(4)

            mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
            myconnection1 = New OleDbConnection(mystring)
            mycommand = New OleDbCommand
            mycommand.Connection = myconnection1
            myconnection1.Open()

            myyear = tbYEAR.Text
            myweek = tbWEEK.Text
            test_sql = "Select hitdate from USAWeeks where hityear = " + myyear + " and hitweek = " + myweek
            mycommand.CommandText = test_sql
            myhitdate = mycommand.ExecuteScalar()

            myconnection1.Close()


            myurl = BaseURLTop40 + myyear + myhitdate
            tbURL.Text = myurl

            WebBrowser1.ScriptErrorsSuppressed = True
            WebBrowser1.Url = New System.Uri(myurl)

        Catch ex As Exception
            MsgBox("error")


        End Try

    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim text As String


        WebBrowser1.Document.ExecCommand("SelectAll", False, Nothing)
        WebBrowser1.Document.ExecCommand("Copy", False, Nothing)
        text = Clipboard.GetText()
        'MessageBox.Show(text, "Text")

        TextBox1.Text = text
        'TextBox1.SelectionStart = 0
        'TextBox1.SelectionLength = TextBox1.Text.Length
        TextBox1.Focus()


    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        'Place in Datagrid
        Me.CMSongstoDatagrid()
        Me.Refresh()

    End Sub

    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim rc As Integer


        'Update Koersen
        Me.InsertCMCoins()
        ds.Reset()
        Me.LoadDataset(2)

        For i = 0 To 99
            ds1.Tables(0).Rows.RemoveAt(0)
        Next
        TextBox1.Text = ""

        Me.Refresh()

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.SelectionStart = 0
        TextBox1.SelectionLength = TextBox1.Text.Length
        TextBox1.Focus()

    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click


        Dim week, year As Integer
        Dim mystr As String

        Dim srv, user, pwd, db, mysql, type, nullstr, Coin As String
        Dim mystring, my_sql, test_sql, valorig, valnu As String
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
        mycommand.Connection = myconnection1
        myconnection1.Open()

        week = 1
        Dim mydate As New Date(2018, 1, 3)
        year = 2018
        mystr = "-01-03"

        For i = 1 To 52

            test_sql = "insert into USAWeeks values (" + year.ToString() + "," + week.ToString() + ",'" + mystr + "')"
            mycommand.CommandText = test_sql
            mycommand.ExecuteNonQuery()

            mydate = mydate.AddDays(7)
            mystr = mydate.ToString("-MM-dd")
            week = week + 1

        Next
        myconnection1.Close()


    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        Me.CMSongstoDatagrid()

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

        Me.InsertCMCoins()

        ds.Reset()
        Me.LoadDataset(2)
        For i = 0 To 99
            ds1.Tables(0).Rows.RemoveAt(0)
        Next

        Me.Refresh()

    End Sub
End Class