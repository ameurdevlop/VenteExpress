Module Startup
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Dim loginForm As New Auth()
        loginForm.Show()
        Application.Run()
    End Sub
End Module
