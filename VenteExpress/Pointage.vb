Imports System.Data.SqlClient
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing
Imports ZXing.Common
Imports ZXing.Windows.Compatibility
Imports System.IO
Public Class Pointage
    Dim videoDevices As FilterInfoCollection
    Dim videoSource As VideoCaptureDevice
    Dim scannerTimer As New Timer()

    Dim barcodeReader As BarcodeReader

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        ComboBoxWebcams.Enabled = False
        barcodeReader = New BarcodeReader()
        barcodeReader.Options = New DecodingOptions() With {
            .TryHarder = True,
            .PossibleFormats = New List(Of BarcodeFormat) From {
                BarcodeFormat.AZTEC,
                BarcodeFormat.CODABAR,
                BarcodeFormat.CODE_39,
                BarcodeFormat.CODE_93,
                BarcodeFormat.CODE_128,
                BarcodeFormat.DATA_MATRIX,
                BarcodeFormat.EAN_8,
                BarcodeFormat.EAN_13,
                BarcodeFormat.ITF,
                BarcodeFormat.MAXICODE,
                BarcodeFormat.PDF_417,
                BarcodeFormat.QR_CODE,
                BarcodeFormat.RSS_14,
                BarcodeFormat.RSS_EXPANDED,
                BarcodeFormat.UPC_A,
                BarcodeFormat.UPC_E,
                BarcodeFormat.UPC_EAN_EXTENSION
            }
        }


        videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        For Each device As FilterInfo In videoDevices
            ComboBoxWebcams.Items.Add(device.Name)
        Next
        If ComboBoxWebcams.Items.Count > 0 Then ComboBoxWebcams.SelectedIndex = 0


        AddHandler scannerTimer.Tick, AddressOf ScannerTimer_Tick
        scannerTimer.Interval = 1000
    End Sub

    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        If videoDevices.Count = 0 Then
            MessageBox.Show("Aucune webcam détectée. Veuillez connecter une webcam.")
            Return
        End If

        If ComboBoxWebcams.SelectedIndex >= 0 Then
            videoSource = New VideoCaptureDevice(videoDevices(ComboBoxWebcams.SelectedIndex).MonikerString)
            AddHandler videoSource.NewFrame, AddressOf VideoSource_NewFrame
            videoSource.Start()
            scannerTimer.Start()
        Else
            MessageBox.Show("Aucune webcam sélectionnée.")
        End If
    End Sub

    Private Sub VideoSource_NewFrame(sender As Object, eventArgs As NewFrameEventArgs)
        Dim bitmap As Bitmap = CType(eventArgs.Frame.Clone(), Bitmap)
        PictureBoxWebcam.Image = bitmap
    End Sub

    Private Sub ScannerTimer_Tick(sender As Object, e As EventArgs)
        If PictureBoxWebcam.Image IsNot Nothing Then
            Try

                Using img As New Bitmap(PictureBoxWebcam.Image)
                    Dim luminanceSource = New BitmapLuminanceSource(img)
                    Dim binaryBitmap = New BinaryBitmap(New HybridBinarizer(luminanceSource))
                    Dim result = barcodeReader.Decode(img)

                    If result IsNot Nothing Then
                        TextBox1.Text = result.Text
                        MessageBox.Show("Bon journé : " & result.Text)
                        '  StopCamera()
                        scannerTimer.Stop()
                    Else
                        UpdateStatus("Aucun code détecté. Veuillez ajuster la position de la carte.")
                    End If
                End Using
            Catch ex As Exception
                LogError("Erreur de scan : " & ex.Message)
                UpdateStatus("Une erreur est survenue lors du scan.")
            End Try
        Else
            UpdateStatus("Aucune image capturée par la webcam.")
        End If
    End Sub

    Private Sub ButtonStop_Click(sender As Object, e As EventArgs) Handles ButtonStop.Click
        StopCamera()
    End Sub

    Private Sub StopCamera()
        If videoSource IsNot Nothing AndAlso videoSource.IsRunning Then
            videoSource.SignalToStop()
            videoSource.WaitForStop()
            PictureBoxWebcam.Image = Nothing
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StopCamera()
        scannerTimer.Stop()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub UpdateStatus(message As String)
        LabelStatus.Text = message
    End Sub

    Private Sub LogError(message As String)
        Dim logFilePath As String = "error_log.txt"
        Using writer As New StreamWriter(logFilePath, True)
            writer.WriteLine($"{DateTime.Now}: {message}")
        End Using
    End Sub
End Class