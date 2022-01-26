Imports System.Web.Script.Serialization
Imports Excel = Microsoft.Office.Interop.Excel
Imports FireSharp.Config
Imports FireSharp.Response
Imports FireSharp.Interfaces
Public Class DataLog
    Private fcon As New FirebaseConfig() With
        {
        .AuthSecret = "AtGr1OHRlHJaE1j34hCMdSiVr7IiJIpZBRXbEEwW",
        .BasePath = "https://sara-yasaman-project-default-rtdb.firebaseio.com/"
        }

    Private client As IFirebaseClient
    Private Sub DataLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            client = New FireSharp.FirebaseClient(fcon)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        DoubleBuffer.DoubleBuffered(DataGridViewDataLog, True)
        ShowDataLog()
    End Sub


    Sub ShowDataLog()
        Try
            Me.Text = "Data Log (Get All Data From Firebase)"

            Dim GetData = client.Get("DHT11Database/")

            Dim myJsonTool As New JavaScriptSerializer
            Dim myDeserializedItems = myJsonTool.Deserialize(Of Dictionary(Of String, DHT11LEDDataLog))(GetData.Body)

            Dim dtTable As New DataTable
            dtTable.Columns.Add("No")
            dtTable.Columns.Add("Date")
            dtTable.Columns.Add("Time")
            dtTable.Columns.Add("Temperature")
            dtTable.Columns.Add("Humidity")

            For Each dictItem As KeyValuePair(Of String, DHT11LEDDataLog) In myDeserializedItems
                dtTable.Rows.Add(dtTable.Rows.Count + 1, dictItem.Value._Date, dictItem.Value._Time, dictItem.Value._Temperature, dictItem.Value._Humidity)
            Next

            DataGridViewDataLog.DataSource = dtTable
            Me.Text = "Data Log"
        Catch ex As Exception
            Me.Text = "Data Log"
            If ex.Message = "One or more errors occurred." Then
                MessageBox.Show("Cannot connect to firebase, check your network !", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf ex.Message = "Object reference not set to an instance of an object." Then
                MessageBox.Show("Data not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub


    Private Sub SaveToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToExcelToolStripMenuItem.Click
        Try
            If DataGridViewDataLog.Rows.Count > 0 Then
                Dim filename As String = ""
                Dim SV As SaveFileDialog = New SaveFileDialog()
                SV.Filter = "EXCEL FILES|*.xlsx;*.xls"
                Dim result As DialogResult = SV.ShowDialog()

                If result = DialogResult.OK Then
                    Me.Text = "Data Log (Saving to Excel. Please wait...)"
                    ProgressBarSave.Visible = True
                    ProgressBarSave.Value = 2
                    filename = SV.FileName
                    Dim multiselect As Boolean = DataGridViewDataLog.MultiSelect
                    DataGridViewDataLog.MultiSelect = True
                    DataGridViewDataLog.SelectAll()
                    DataGridViewDataLog.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
                    Clipboard.SetDataObject(DataGridViewDataLog.GetClipboardContent())
                    Dim results = System.Convert.ToString(Clipboard.GetData(DataFormats.Text))
                    DataGridViewDataLog.ClearSelection()
                    DataGridViewDataLog.MultiSelect = multiselect
                    Dim XCELAPP As Microsoft.Office.Interop.Excel.Application = Nothing
                    Dim XWORKBOOK As Microsoft.Office.Interop.Excel.Workbook = Nothing
                    Dim XSHEET As Microsoft.Office.Interop.Excel.Worksheet = Nothing
                    Dim misValue As Object = System.Reflection.Missing.Value
                    ProgressBarSave.Value = 4
                    XCELAPP = New Excel.Application()
                    XWORKBOOK = XCELAPP.Workbooks.Add(misValue)
                    XCELAPP.DisplayAlerts = False
                    XCELAPP.Visible = False
                    XSHEET = XWORKBOOK.ActiveSheet
                    ProgressBarSave.Value = 6
                    XSHEET.Paste()
                    XWORKBOOK.SaveAs(filename, Excel.XlFileFormat.xlOpenXMLWorkbook)
                    XWORKBOOK.Close(False)
                    XCELAPP.Quit()
                    ProgressBarSave.Value = 8
                    Try
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(XSHEET)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(XWORKBOOK)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(XCELAPP)
                    Catch
                    End Try
                    Me.Text = "Data Log"
                    ProgressBarSave.Value = 10
                    ProgressBarSave.Visible = False
                    MessageBox.Show("Save Succesfully")
                End If
            End If
        Catch ex As Exception
            Me.Text = "Data Log"
            MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        ShowDataLog()
    End Sub
End Class
