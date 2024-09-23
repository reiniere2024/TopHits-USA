Public Class frmShowYoutube

    Private myurl, myurl2 As String
    Private TheArtist, TheSong As String


    Sub New(ByVal TheURL As String, ByVal artist As String, ByVal title As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        myurl = TheURL

        Me.Text = "Youtube Artist: " + artist + " , Song: " + title


    End Sub

    Private Sub frmShowYoutube_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New Point(0, 0)
        Dim myurl2, myurl3 As String

        Try

            WebBrowser1.Visible = True
            WebBrowser1.ScriptErrorsSuppressed = True
            WebBrowser1.Url = New System.Uri(myurl)

            WebBrowser2.Visible = False
            myurl2 = "https://2conv.com/nl/"
            WebBrowser2.ScriptErrorsSuppressed = True
            WebBrowser2.Url = New System.Uri(myurl2)

            WebBrowser3.Visible = False
            myurl3 = "https://y2mate.com/"
            WebBrowser3.ScriptErrorsSuppressed = True
            WebBrowser3.Url = New System.Uri(myurl3)

        Catch ex As Exception
            MsgBox(ex.Message)


        End Try



    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        WebBrowser1.Visible = False
        WebBrowser2.Visible = True
        WebBrowser3.Visible = False

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        WebBrowser1.Visible = True
        WebBrowser2.Visible = False
        WebBrowser3.Visible = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        WebBrowser1.Visible = False
        WebBrowser2.Visible = False
        WebBrowser3.Visible = True

    End Sub
End Class