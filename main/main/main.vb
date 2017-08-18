Imports System.Data.SQLite

Public Class main
    Dim datapath As String = "" 'Database location
    Dim industryList As New List(Of String)
    Dim targetTable As String = "SC"

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        industryList.Add("Sporting")
        industryList.Add("Community")
        industryList.Add("Primary School")
        industryList.Add("Secondary School")
        industryList.Add("Corporate")
        industryList.Add("Tertiary School")
        industryList.Add("Government Agency")
        industryList.Add("Other")
    End Sub

    Private Sub btnAutomate_Click(sender As Object, e As EventArgs) Handles btnAutomate.Click
        Dim period As New List(Of month)
        Dim header As New month With
            {
            .year = "Year",
            .name = "Month",
            .count = "Count",
            .value = "Value",
            .nightpeople = "Night People"
            }
        header.industryCount = industryList
        period.Add(header)
        automate(period) 'Iterate through desired sources and pages
        writeToFile(period)
        MsgBox("Query complete.")
    End Sub

    Private Sub writeToFile(period As List(Of month))
        MsgBox("Select a directory to save the output file.") 'Save output
        While sfdHitCount.ShowDialog() <> System.Windows.Forms.DialogResult.OK
            MsgBox("You must save an output file.")
        End While
        For Each month As month In period
            Dim import As String = month.year & vbTab & month.name & vbTab & month.count & vbTab & month.value & vbTab & month.nightpeople & vbTab
            For Each industry As String In month.industryCount
                import += industry & vbTab
            Next
            generateFile(import, sfdHitCount.FileName)
        Next
    End Sub

    Private Function automate(period As List(Of month))
        Dim month As String
        Using conn As New SQLiteConnection("Data Source=" + datapath)
            conn.Open()
            For y = 2014 To 2017
                For m = 1 To 12
                    month = m.ToString.PadLeft(2, "0")
                    Dim current As New month With
                        {
                        .year = y,
                        .name = m
                        }
                    Using cmd As New SQLiteCommand("SELECT COUNT(ref_num), SUM(total_value), SUM(night_people) FROM " & targetTable & " WHERE arrival_date LIKE '" & y & "-" & month & "%'", conn)
                        Using dr = cmd.ExecuteReader()
                            If dr.HasRows Then
                                Do While dr.Read()
                                    Try
                                        current.count = dr("COUNT(ref_num)")
                                        current.value = dr("SUM(total_value)")
                                        current.nightpeople = dr("SUM(night_people)")
                                    Catch ex As Exception

                                    End Try

                                Loop
                            End If
                        End Using
                    End Using
                    For Each industry As String In industryList
                        'MsgBox("SELECT COUNT('industry_sector') FROM " & targetTable & " WHERE arrival_date LIKE '" & y & "-" & month & "%' AND 'industry_sector'= '" & industry & "'")
                        Using cmd As New SQLiteCommand("SELECT COUNT(industry_sector) FROM " & targetTable & " WHERE arrival_date LIKE '" & y & "-" & month & "%' AND industry_sector= '" & industry & "'", conn)
                            Using dr = cmd.ExecuteReader()
                                If dr.HasRows Then
                                    Do While dr.Read()
                                        current.industryCount.Add(dr("COUNT(industry_sector)"))
                                    Loop
                                End If
                            End Using
                        End Using
                    Next
                    period.Add(current)
                Next
            Next
        End Using
        Return period
    End Function

    Private Sub btnSelectDb_Click(sender As Object, e As EventArgs) Handles btnSelectDb.Click
        If ofdSelectDb.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            btnAutomate.Enabled = True
            datapath = ofdSelectDb.FileName
            lblSelectedDb.Text = "Selected database: " + ofdSelectDb.FileName
        End If
    End Sub

    Private Sub generateFile(ByVal x As String, path As String)
        Dim FILE_NAME As String = path
        If System.IO.File.Exists(FILE_NAME) = False Then
            System.IO.File.Create(FILE_NAME).Dispose()
        End If
        Try
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            objWriter.WriteLine(x)
            objWriter.Close()
        Catch ex As Exception
            MsgBox("Please close the file first before pressing 'Generate'")
        End Try
    End Sub


End Class
