Public Class makeJSON
    Dim files As String() = System.IO.Directory.GetFiles(
        TextBox1.Text & "\audio\bgm", "*", System.IO.SearchOption.AllDirectories)


    Dim strText As String


        strText = "{" & """" & "bgm" & """" & ": [" & """" & """" & ","
        For Each test As String In files
            strText = strText & """"

            strText = strText & IO.Path.GetFileName(test)
            strText = strText & """"
            strText = strText & ","

        Next
        strText = strText.Substring(0, strText.Length - 1)
        strText = strText & "]}"


        Dim strText2 As String
        strText2 = "{" & """" & "enemies" & """" & ": [" & """" & """" & ","
        For Each test2 As String In files2
            strText2 = strText2 & """"

            strText2 = strText2 & IO.Path.GetFileName(test2)
            strText2 = strText2 & """"
            strText2 = strText2 & ","
        Next


        strText2 = strText2.Substring(0, strText2.Length - 1)
        strText2 = strText2 & "]}"


        Dim utf8Enc As Encoding = Encoding.GetEncoding("UTF-8")
    Dim writer As New StreamWriter(TextBox1.Text & "\TEST.JSON", True, utf8Enc)
        writer.WriteLine("[")
        writer.WriteLine(strText)
        writer.WriteLine(",")
        writer.WriteLine(strText2)
        writer.Close()
        'ListBox1に結果を表示する
        JSON内容.Items.AddRange(files)

End Class
