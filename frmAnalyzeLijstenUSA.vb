Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmAnalyzeLijstenUSA
    Private ds, ds1, ds_server, dslast As New DataSet
    Private KoersNum As Integer
    Private KoersDollar As Integer
    Private Started1, Started2 As Boolean
    Private MyResults As String
    Private Expanded As Boolean = False
    Private ListId As Integer
    Private MyWebbrowser As New WebBrowser
    Public ShowHits As Boolean = True


    Sub New(ByVal mypar As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        KoersNum = mypar

    End Sub

    Private Sub frmAnalyze_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ds1.ReadXml(CurDir() + "\xml\lijst.xml")
        Me.DataGrid1.DataSource = Me.ds1.Tables(0)
        Me.FormatColumnHeadersA()
        ds1.Tables(0).Rows.RemoveAt(0)
        Me.DataGrid1.ReadOnly = True

        ListId = 1
        ds.Reset()
        Me.LoadDataset(2)
        Started2 = True



    End Sub

    Private Sub LoadVertical()

        Dim srv, user, pwd, db, mysql, mysql2, type, nullstr, TheSong, TheArtist, TheName, TheSong2, TheArtist2, TheName2 As String
        Dim mystring, d1, d2, d3, d4 As String
        Dim da, dalast As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim dblNu, dblOrig, amount, dbl1, dbl2, EuroNu, EuroOrig As Double
        Dim dblHL, dblNH, dblNL As Double
        Dim index1, index2, st1, st2, start1, ind1, indlast1, i As Integer 'Substring
        Dim indlast2, indlast3 As Integer?


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
            mysql = "select Listid,nr01,nr02,nr03,nr04,nr05,nr06,nr07,nr08,nr09,nr10,nr11,nr12,nr13,nr14,nr15,nr16,nr17,nr18,nr19,nr20,nr21,nr22,nr23,nr24,nr25,nr26,nr27,nr28,nr29,nr30,nr31,nr32,nr33,nr34,nr35,nr36,nr37,nr38,nr39,nr40,nr41, nr42, nr43, nr44, nr45, nr46, nr47, nr48, nr49, nr50, nr51, nr52, nr53, nr54, nr55, nr56, nr57, nr58, nr59, nr60, nr61, nr62, nr63, nr64, nr65, nr66, nr67, nr68, nr69, nr70, nr71, nr72, nr73, nr74, nr75, nr76, nr77, nr78, nr79, nr80, nr81, nr82, nr83, nr84, nr85, nr86, nr87, nr88, nr89, nr90, nr91, nr92, nr93, nr94, nr95, nr96, nr97, nr98, nr99, nr100 from Top100ListItemsUSA where Listid = " + ListId.ToString()
            If ListId > 1 Then
                indlast1 = ListId - 1
            Else
                indlast1 = ListId
            End If
            mysql2 = "select Listid,nr01,nr02,nr03,nr04,nr05,nr06,nr07,nr08,nr09,nr10,nr11,nr12,nr13,nr14,nr15,nr16,nr17,nr18,nr19,nr20,nr21,nr22,nr23,nr24,nr25,nr26,nr27,nr28,nr29,nr30,nr31,nr32,nr33,nr34,nr35,nr36,nr37,nr38,nr39,nr40,nr41, nr42, nr43, nr44, nr45, nr46, nr47, nr48, nr49, nr50, nr51, nr52, nr53, nr54, nr55, nr56, nr57, nr58, nr59, nr60, nr61, nr62, nr63, nr64, nr65, nr66, nr67, nr68, nr69, nr70, nr71, nr72, nr73, nr74, nr75, nr76, nr77, nr78, nr79, nr80, nr81, nr82, nr83, nr84, nr85, nr86, nr87, nr88, nr89, nr90, nr91, nr92, nr93, nr94, nr95, nr96, nr97, nr98, nr99, nr100 from Top100ListItemsUSA where Listid = " + indlast1.ToString()

            Me.Text = "Top100 USA 1965 Week 1"

        End If
        da = New OleDbDataAdapter
        da.SelectCommand = New OleDbCommand(mysql, myconnection1)
        dalast = New OleDbDataAdapter
        dalast.SelectCommand = New OleDbCommand(mysql2, myconnection1)

        myconnection1.Open()
        da.Fill(ds, "Top100ListItemsUSA")
        DGAltcoins.DataSource = ds.Tables(0)

        dalast.Fill(dslast, "Top100ListItemsUSA")

        For i = 0 To 49 '19
            If IsDBNull(ds.Tables(0).Rows(0).Item(i + 1)) Then
                TheArtist = "-"
                TheName = "-"
                indlast2 = -1
                GoTo song2
            End If
            TheSong = ds.Tables(0).Rows(0).Item(i + 1)
            If TheSong = "-" Or TheSong = "" Or TheSong = " " Then
                TheArtist = "-"
                TheName = "-"
                indlast2 = -1
                GoTo song2
            End If
            ind1 = TheSong.IndexOf("-", start1)
            TheArtist = TheSong.Substring(0, ind1)
            TheName = TheSong.Substring(ind1 + 1, TheSong.Length - ind1 - 1)
            indlast2 = 0
            For j = 1 To 99
                If Not IsDBNull(dslast.Tables(0).Rows(0).Item(j)) Then
                    If TheSong = dslast.Tables(0).Rows(0).Item(j) Then
                        indlast2 = j
                        GoTo song2
                    End If
                End If
            Next


song2:

            If IsDBNull(ds.Tables(0).Rows(0).Item(i + 51)) Then
                TheArtist2 = "-"
                TheName2 = "-"
                indlast3 = -1
                GoTo song3
            End If
            TheSong2 = ds.Tables(0).Rows(0).Item(i + 51)  '19->21, 49-> 51
            If TheSong2 = "-" Or TheSong2 = "" Or TheSong = " " Then
                TheArtist2 = "-"
                TheName2 = "-"
                indlast3 = -1
                GoTo song3
            End If

            ind1 = TheSong2.IndexOf("-", start1)
            TheArtist2 = TheSong2.Substring(0, ind1)
            TheName2 = TheSong2.Substring(ind1 + 1, TheSong2.Length - ind1 - 1)

            indlast3 = 0

            For j = 1 To 99
                If Not IsDBNull(dslast.Tables(0).Rows(0).Item(j)) Then
                    If TheSong2 = dslast.Tables(0).Rows(0).Item(j) Then
                        indlast3 = j
                        GoTo song3
                    End If
                End If
            Next

song3:


            If cbxAll.Checked = True Then

                If indlast2 = -1 Then
                    indlast2 = 0
                End If
                If indlast3 = -1 Then
                    indlast3 = 0
                End If

                Dim myrow As DataRow = Me.ds1.Tables(0).NewRow()
                ds1.Tables(0).Rows.InsertAt(myrow, ds1.Tables(0).Rows.Count)
                myrow.Item(0) = i + 1
                myrow.Item(1) = indlast2
                myrow.Item(2) = TheArtist
                myrow.Item(3) = TheName
                myrow.Item(4) = i + 51
                myrow.Item(5) = indlast3
                myrow.Item(6) = TheArtist2
                myrow.Item(7) = TheName2

            Else

                If Not IsDBNull(ds.Tables(0).Rows(0).Item(i + 1)) Then
                    If ds.Tables(0).Rows(0).Item(i + 1) <> "-" Then
                        If indlast2 = 0 Then
                            Dim myrow As DataRow = Me.ds1.Tables(0).NewRow()
                            ds1.Tables(0).Rows.InsertAt(myrow, ds1.Tables(0).Rows.Count)
                            myrow.Item(0) = i + 1
                            myrow.Item(1) = indlast2
                            myrow.Item(2) = TheArtist
                            myrow.Item(3) = TheName
                            myrow.Item(4) = 0
                            myrow.Item(5) = 0
                            myrow.Item(6) = ""
                            myrow.Item(7) = ""
                        End If

                    End If
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item(i + 51)) Then
                    If ds.Tables(0).Rows(0).Item(i + 51) <> "-" Then
                        If indlast3 = 0 Then
                            Dim myrow As DataRow = Me.ds1.Tables(0).NewRow()
                            ds1.Tables(0).Rows.InsertAt(myrow, ds1.Tables(0).Rows.Count)
                            myrow.Item(0) = i + 21
                            myrow.Item(1) = indlast3
                            myrow.Item(2) = TheArtist2
                            myrow.Item(3) = TheName2
                            myrow.Item(4) = 0
                            myrow.Item(5) = 0
                            myrow.Item(6) = ""
                            myrow.Item(7) = ""
                        End If
                    End If
                End If
            End If
        Next

        myconnection1.Close()

    End Sub

    Private Sub LoadHorizontal()

        Dim srv, user, pwd, db, mysql, mysql2, type, nullstr, TheSong, TheArtist, TheName, TheSong2, TheArtist2, TheName2 As String
        Dim mystring, d1, d2, d3, d4 As String
        Dim da, dalast As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim dblNu, dblOrig, amount, dbl1, dbl2, EuroNu, EuroOrig As Double
        Dim dblHL, dblNH, dblNL As Double
        Dim index1, index2, st1, st2, start1, ind1, indlast1, i As Integer 'Substring
        Dim indlast2, indlast3 As Integer?


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
            mysql = "select Listid,nr01,nr02,nr03,nr04,nr05,nr06,nr07,nr08,nr09,nr10,nr11,nr12,nr13,nr14,nr15,nr16,nr17,nr18,nr19,nr20,nr21,nr22,nr23,nr24,nr25,nr26,nr27,nr28,nr29,nr30,nr31,nr32,nr33,nr34,nr35,nr36,nr37,nr38,nr39,nr40,nr41, nr42, nr43, nr44, nr45, nr46, nr47, nr48, nr49, nr50, nr51, nr52, nr53, nr54, nr55, nr56, nr57, nr58, nr59, nr60, nr61, nr62, nr63, nr64, nr65, nr66, nr67, nr68, nr69, nr70, nr71, nr72, nr73, nr74, nr75, nr76, nr77, nr78, nr79, nr80, nr81, nr82, nr83, nr84, nr85, nr86, nr87, nr88, nr89, nr90, nr91, nr92, nr93, nr94, nr95, nr96, nr97, nr98, nr99, nr100 from Top100ListItemsUSA where Listid = " + ListId.ToString()
            If ListId > 1 Then
                indlast1 = ListId - 1
            Else
                indlast1 = ListId
            End If
            mysql2 = "select Listid,nr01,nr02,nr03,nr04,nr05,nr06,nr07,nr08,nr09,nr10,nr11,nr12,nr13,nr14,nr15,nr16,nr17,nr18,nr19,nr20,nr21,nr22,nr23,nr24,nr25,nr26,nr27,nr28,nr29,nr30,nr31,nr32,nr33,nr34,nr35,nr36,nr37,nr38,nr39,nr40,nr41, nr42, nr43, nr44, nr45, nr46, nr47, nr48, nr49, nr50, nr51, nr52, nr53, nr54, nr55, nr56, nr57, nr58, nr59, nr60, nr61, nr62, nr63, nr64, nr65, nr66, nr67, nr68, nr69, nr70, nr71, nr72, nr73, nr74, nr75, nr76, nr77, nr78, nr79, nr80, nr81, nr82, nr83, nr84, nr85, nr86, nr87, nr88, nr89, nr90, nr91, nr92, nr93, nr94, nr95, nr96, nr97, nr98, nr99, nr100 from Top100ListItemsUSA where Listid = " + indlast1.ToString()

            Me.Text = "Top100 USA 1965 Week 1"

        End If
        da = New OleDbDataAdapter
        da.SelectCommand = New OleDbCommand(mysql, myconnection1)
        dalast = New OleDbDataAdapter
        dalast.SelectCommand = New OleDbCommand(mysql2, myconnection1)

        myconnection1.Open()
        da.Fill(ds, "Top100ListItemsUSA")
        DGAltcoins.DataSource = ds.Tables(0)

        dalast.Fill(dslast, "Top100ListItemsUSA")


        For j = 0 To 48
            i = j * 2
            If IsDBNull(ds.Tables(0).Rows(0).Item(i + 1)) Then
                TheArtist = "-"
                TheName = "-"
                indlast2 = -1
                GoTo song2
            End If
            TheSong = ds.Tables(0).Rows(0).Item(i + 1)

            If TheSong = "-" Or TheSong = "" Or TheSong = " " Then
                TheArtist = "-"
                TheName = "-"
                indlast2 = -1
                GoTo song2
            End If
            ind1 = TheSong.IndexOf("-", start1)
            TheArtist = TheSong.Substring(0, ind1)
            TheName = TheSong.Substring(ind1 + 1, TheSong.Length - ind1 - 1)
            indlast2 = 0

            For k = 1 To 99
                If Not IsDBNull(dslast.Tables(0).Rows(0).Item(k)) Then
                    If TheSong = dslast.Tables(0).Rows(0).Item(k) Then
                        indlast2 = i
                        GoTo song2
                    End If
                End If
            Next


song2:

            If IsDBNull(ds.Tables(0).Rows(0).Item(i + 2)) Then
                TheArtist2 = "-"
                TheName2 = "-"
                indlast3 = -1
                GoTo song3
            End If
            TheSong2 = ds.Tables(0).Rows(0).Item(i + 2)  '19->21, 49-> 51
            If TheSong2 = "-" Or TheSong2 = "" Or TheSong = " " Then
                TheArtist2 = "-"
                TheName2 = "-"
                indlast3 = -1
                GoTo song3
            End If

            ind1 = TheSong2.IndexOf("-", start1)
            TheArtist2 = TheSong2.Substring(0, ind1)
            TheName2 = TheSong2.Substring(ind1 + 1, TheSong2.Length - ind1 - 1)

            indlast3 = 0

            For k = 1 To 99
                If Not IsDBNull(dslast.Tables(0).Rows(0).Item(k)) Then
                    If TheSong2 = dslast.Tables(0).Rows(0).Item(k) Then
                        indlast3 = j
                        GoTo song3
                    End If
                End If
            Next

song3:


            If cbxAll.Checked = True Then

                If indlast2 = -1 Then
                    indlast2 = 0
                End If
                If indlast3 = -1 Then
                    indlast3 = 0
                End If

                Dim myrow As DataRow = Me.ds1.Tables(0).NewRow()
                ds1.Tables(0).Rows.InsertAt(myrow, ds1.Tables(0).Rows.Count)
                myrow.Item(0) = i + 1
                myrow.Item(1) = indlast2
                myrow.Item(2) = TheArtist
                myrow.Item(3) = TheName
                myrow.Item(4) = i + 2
                myrow.Item(5) = indlast3
                myrow.Item(6) = TheArtist2
                myrow.Item(7) = TheName2

            Else

                If Not IsDBNull(ds.Tables(0).Rows(0).Item(i + 1)) Then
                    If ds.Tables(0).Rows(0).Item(i + 1) <> "-" Then
                        If indlast2 = 0 Then
                            Dim myrow As DataRow = Me.ds1.Tables(0).NewRow()
                            ds1.Tables(0).Rows.InsertAt(myrow, ds1.Tables(0).Rows.Count)
                            myrow.Item(0) = i + 1
                            myrow.Item(1) = indlast2
                            myrow.Item(2) = TheArtist
                            myrow.Item(3) = TheName
                            myrow.Item(4) = 0
                            myrow.Item(5) = 0
                            myrow.Item(6) = ""
                            myrow.Item(7) = ""
                        End If

                    End If
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item(i + 2)) Then
                    If ds.Tables(0).Rows(0).Item(i + 2) <> "-" Then
                        If indlast3 = 0 Then
                            Dim myrow As DataRow = Me.ds1.Tables(0).NewRow()
                            ds1.Tables(0).Rows.InsertAt(myrow, ds1.Tables(0).Rows.Count)
                            myrow.Item(0) = i + 21
                            myrow.Item(1) = indlast3
                            myrow.Item(2) = TheArtist2
                            myrow.Item(3) = TheName2
                            myrow.Item(4) = 0
                            myrow.Item(5) = 0
                            myrow.Item(6) = ""
                            myrow.Item(7) = ""
                        End If
                    End If
                End If
            End If
        Next

        myconnection1.Close()


    End Sub

    Private Sub LoadAltcoins(ByVal num As Integer)

        Dim srv, user, pwd, db, mysql, mysql2, type, nullstr, TheSong, TheArtist, TheName, TheSong2, TheArtist2, TheName2 As String
        Dim mystring, d1, d2, d3, d4 As String
        Dim da, dalast As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim dblNu, dblOrig, amount, dbl1, dbl2, EuroNu, EuroOrig As Double
        Dim dblHL, dblNH, dblNL As Double
        Dim index1, index2, st1, st2, start1, ind1, indlast1, i As Integer 'Substring
        Dim indlast2, indlast3 As Integer?


        If cbxHor.Checked = True Then
            Me.LoadHorizontal()
        Else
            Me.LoadVertical()
        End If


    End Sub


    Private Sub LoadDataset(ByVal num As Integer)

        Me.LoadAltcoins(num)

    End Sub

    Private Sub FormatColumnHeadersA()

        Dim ts As New DataGridTableStyle
        Dim cs0, cs1, cs1a, cs1b, cs2, cs3, cs4, cs4a, cs5, cs5a, cs5b, cs5c, cs5d, cs6, cs7, cs8, cs9, cs10, cs11 As DataGridTextBoxColumn

        ts.MappingName = "LIJST"

        cs1 = New DataGridTextBoxColumn
        cs1.MappingName = "nr1"
        cs1.HeaderText = "NR:"
        cs1.Width = 40
        ts.GridColumnStyles.Add(cs1)

        cs1a = New DataGridTextBoxColumn
        cs1a.MappingName = "lw1"
        cs1a.HeaderText = "LW:"
        cs1a.Width = 40
        ts.GridColumnStyles.Add(cs1a)

        cs2 = New DataGridTextBoxColumn
        cs2.MappingName = "artist1"
        cs2.HeaderText = "Artist:"
        cs2.Width = 150
        ts.GridColumnStyles.Add(cs2)

        cs3 = New DataGridTextBoxColumn
        cs3.MappingName = "song1"
        cs3.HeaderText = "Album:"
        cs3.Width = 250
        ts.GridColumnStyles.Add(cs3)

        cs9 = New DataGridTextBoxColumn
        cs9.MappingName = "nr2"
        cs9.HeaderText = "NR:"
        cs9.Width = 40
        ts.GridColumnStyles.Add(cs9)

        cs1b = New DataGridTextBoxColumn
        cs1b.MappingName = "lw2"
        cs1b.HeaderText = "LW:"
        cs1b.Width = 40
        ts.GridColumnStyles.Add(cs1b)

        cs4 = New DataGridTextBoxColumn
        cs4.MappingName = "artist2"
        cs4.HeaderText = "Artist:"
        cs4.Width = 150
        ts.GridColumnStyles.Add(cs4)

        cs5 = New DataGridTextBoxColumn
        cs5.MappingName = "song2"
        cs5.HeaderText = "Album:"
        cs5.Width = 250
        ts.GridColumnStyles.Add(cs5)

        DataGrid1.TableStyles.Add(ts)


    End Sub


    Private Sub FormatColumnHeaders2()

        Dim ts2 As New DataGridTableStyle
        Dim cs1, cs2, cs3, cs4, cs4a, cs4b, cs4c, cs4d, cs5, cs5a, cs5b, cs5c, cs5d, cs6, cs7, cs8, cs9, cs9a, cs10, cs11, cs12, cs13, cs15, cs16, cs17 As DataGridTextBoxColumn

        ts2.MappingName = "Top100ListItemsUSA"

        cs2 = New DataGridTextBoxColumn
        cs2.MappingName = "Listid"
        cs2.HeaderText = "Nr List"
        cs2.Width = 60
        ts2.GridColumnStyles.Add(cs2)

        cs3 = New DataGridTextBoxColumn
        cs3.MappingName = "nr01"
        cs3.HeaderText = "Nr 1:"
        cs3.Width = 150
        ts2.GridColumnStyles.Add(cs3)

        cs4 = New DataGridTextBoxColumn
        cs4.MappingName = "nr02"
        cs4.HeaderText = "Nr 2:"
        cs4.Width = 150
        ts2.GridColumnStyles.Add(cs4)

        cs5 = New DataGridTextBoxColumn
        cs5.MappingName = "nr03"
        cs5.HeaderText = "Nr 3:"
        cs5.Width = 150
        ts2.GridColumnStyles.Add(cs5)

        DGAltcoins.TableStyles.Add(ts2)

    End Sub






    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Function GetLastIndex(ByVal mysong As String) As Integer
        Dim week, year, myret As Integer
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim srv, user, pwd, db, mysql, type, nullstr, test_sql, mystring As String

        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)


        week = CInt(tbWEEK.Text)
        year = CInt(tbYEAR.Text)

        myconnection1.Open()
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1

        test_sql = "Select id from Top100ListUSA where listyear = '" + tbYEAR.Text + "' and week = '" + tbWEEK.Text + "' and "
        mycommand.CommandText = test_sql
        myret = mycommand.ExecuteScalar()
        ListId = myret

        test_sql = "Select id from Top100ListUSA where listyear = '" + tbYEAR.Text + "' and week = '" + tbWEEK.Text + "' and "
        mycommand.CommandText = test_sql
        myret = mycommand.ExecuteScalar()


        If myret > 0 Then GoTo Endstatement





Endstatement:




        ListId = myret


    End Function

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myweek As String
        Dim week, year, myret As Integer
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim srv, user, pwd, db, mysql, type, nullstr, test_sql, mystring As String

        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        week = CInt(tbWEEK.Text)
        year = CInt(tbYEAR.Text)
        If year = 2018 And week > 25 Then
            Return
        End If

        If week < 52 Then
            week = week + 1
            tbWEEK.Text = week.ToString()
        Else
            year = year + 1
            week = 1
            tbWEEK.Text = week.ToString()
            tbYEAR.Text = year.ToString()
        End If

        myconnection1.Open()
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1

        test_sql = "Select id from Top100ListUSA where listyear = '" + tbYEAR.Text + "' and week = '" + tbWEEK.Text + "'"
        mycommand.CommandText = test_sql
        myret = mycommand.ExecuteScalar()
        ListId = myret

        For i = 0 To ds1.Tables(0).Rows.Count - 1
            ds1.Tables(0).Rows.RemoveAt(0)
        Next

        ds.Reset()
        dslast.Reset()

        Me.LoadDataset(2)
        Me.Refresh()


    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim myweek As String
        Dim week, year, myret As Integer
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim srv, user, pwd, db, mysql, type, nullstr, test_sql, mystring As String

        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)


        week = CInt(tbWEEK.Text)
        year = CInt(tbYEAR.Text)
        If year > 2017 Then
            Return
        End If
        year = year + 1
        tbYEAR.Text = year.ToString()

        myconnection1.Open()
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1

        test_sql = "Select id from Top100ListUSA where listyear = '" + tbYEAR.Text + "' and week = '" + tbWEEK.Text + "'"
        mycommand.CommandText = test_sql
        myret = mycommand.ExecuteScalar()
        ListId = myret

        For i = 0 To ds1.Tables(0).Rows.Count - 1
            ds1.Tables(0).Rows.RemoveAt(0)
        Next

        ds.Reset()
        dslast.Reset()

        Me.LoadDataset(2)
        Me.Refresh()



    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim myweek As String
        Dim week, year, myret As Integer
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim srv, user, pwd, db, mysql, type, nullstr, test_sql, mystring As String

        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)


        week = CInt(tbWEEK.Text)
        year = CInt(tbYEAR.Text)
        If week > 1 Then
            week = week - 1
            tbWEEK.Text = week.ToString()
        Else
            year = year - 1
            week = 52
            tbWEEK.Text = week.ToString()
            tbYEAR.Text = year.ToString()
        End If

        myconnection1.Open()
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1

        test_sql = "Select id from Top100ListUSA where listyear = '" + tbYEAR.Text + "' and week = '" + tbWEEK.Text + "'"
        mycommand.CommandText = test_sql
        myret = mycommand.ExecuteScalar()
        ListId = myret

        For i = 0 To ds1.Tables(0).Rows.Count - 1
            ds1.Tables(0).Rows.RemoveAt(0)
        Next

        ds.Reset()
        dslast.Reset()

        Me.LoadDataset(2)
        Me.Refresh()


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim myweek As String
        Dim week, year, myret As Integer
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim srv, user, pwd, db, mysql, type, nullstr, test_sql, mystring As String

        ds_server.ReadXml(CurDir() + "\xml\server.xml")
        type = ds_server.Tables(0).Rows(0).Item(0)
        srv = ds_server.Tables(0).Rows(0).Item(1)
        user = ds_server.Tables(0).Rows(0).Item(2)
        pwd = ds_server.Tables(0).Rows(0).Item(3)
        db = ds_server.Tables(0).Rows(0).Item(4)
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + db + "';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        week = CInt(tbWEEK.Text)
        year = CInt(tbYEAR.Text)
        If year < 1966 Then
            Return
        End If
        year = year - 1
        tbYEAR.Text = year.ToString()

        myconnection1.Open()
        mycommand = New OleDbCommand
        mycommand.Connection = myconnection1

        test_sql = "Select id from Top100ListUSA where listyear = '" + tbYEAR.Text + "' and week = '" + tbWEEK.Text + "'"
        mycommand.CommandText = test_sql
        myret = mycommand.ExecuteScalar()
        ListId = myret

        For i = 0 To ds1.Tables(0).Rows.Count - 1
            ds1.Tables(0).Rows.RemoveAt(0)
        Next

        ds.Reset()
        dslast.Reset()

        Me.LoadDataset(2)
        Me.Refresh()


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles web1.Click
        Dim myurl, myurl2, text, myartist, mytitle As String
        Dim myrow As Integer

        Try

            myrow = DataGrid1.CurrentRowIndex
            If cbxFirst.Checked = True Then
                myartist = ds1.Tables(0).Rows(myrow).Item(2)
                mytitle = ds1.Tables(0).Rows(myrow).Item(3)
            Else
                myartist = ds1.Tables(0).Rows(myrow).Item(6)
                mytitle = ds1.Tables(0).Rows(myrow).Item(7)
            End If
            'myurl = "https://www.youtube.com/results?search_query=" + myartist + "+" + mytitle
            myurl = "https://www.y2mate.com/search/" + myartist + "+" + mytitle

            If ShowHits = True Then

                WebBrowser1.ScriptErrorsSuppressed = True
                WebBrowser1.Url = New System.Uri(myurl)
                WebBrowser1.Visible = True
                web1.Text = "&Hit Chart's"

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

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        WebBrowser1.Visible = False
        WebBrowser1.Url = New System.Uri("https://www.erdtsieck.info")

    End Sub

    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click

    End Sub

    Private Sub DataGrid1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseClick




    End Sub

    Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles web2.Click

        Dim myurl, text, myartist, mytitle As String
        Dim myrow As Integer

        Try

            myrow = DataGrid1.CurrentRowIndex
            If cbxFirst.Checked = True Then
                myartist = ds1.Tables(0).Rows(myrow).Item(2)
                mytitle = ds1.Tables(0).Rows(myrow).Item(3)
            Else
                myartist = ds1.Tables(0).Rows(myrow).Item(6)
                mytitle = ds1.Tables(0).Rows(myrow).Item(7)
            End If

            text = myartist + " " + mytitle
            Clipboard.SetText(text)
            WebBrowser1.Visible = True


        Catch ex As Exception
            MsgBox(ex.Message)


        End Try


    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        WebBrowser1.Visible = False
        WebBrowser2.Visible = False

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        WebBrowser2.Visible = True

    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myurl, myurl2, text, myartist, mytitle As String
        Dim myrow As Integer

        Try

            myrow = DataGrid1.CurrentRowIndex
            If cbxFirst.Checked = True Then
                myartist = ds1.Tables(0).Rows(myrow).Item(2)
                mytitle = ds1.Tables(0).Rows(myrow).Item(3)
            Else
                myartist = ds1.Tables(0).Rows(myrow).Item(6)
                mytitle = ds1.Tables(0).Rows(myrow).Item(7)
            End If
            myurl = "https://www.youtube.com/results?search_query=" + myartist + "+" + mytitle

            MyWebbrowser.ScriptErrorsSuppressed = True
            MyWebbrowser.Navigate(New System.Uri(myurl))

            WebBrowser1.Url = MyWebbrowser.Url


            'web1.Visible = False
            WebBrowser1.Visible = True
            web2.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)


        End Try

    End Sub

    Private Sub cbxFirst_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxFirst.CheckedChanged

    End Sub

    Private Sub cbxHor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxHor.CheckedChanged

    End Sub
End Class