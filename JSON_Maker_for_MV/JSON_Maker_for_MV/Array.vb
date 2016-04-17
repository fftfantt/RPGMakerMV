''' <summary>
''' 配列を扱うクラス
''' </summary>

Public Class Array


    ''' <summary>
    ''' ファイル一覧の拡張子を除外するメソッド
    ''' </summary>
    ''' <param name="Array1">ファイル一覧の配列</param>
    ''' <returns>拡張子を除外したファイル一覧の配列</returns>

    Public Shared Function RemoveExtension(ByVal Array1() As String)

        Dim Array2 = New String(Array1.Count - 1) {}
        Dim i As Integer = 0
        For Each strFileName As String In Array1
            Array2(i) = IO.Path.GetFileNameWithoutExtension(strFileName)
            i = i + 1
        Next

        Return Array2

    End Function


    ''' <summary>
    ''' 除外した配列を排除して圧縮するメソッド
    ''' </summary>
    ''' <param name="Array1"></param>
    ''' <returns></returns>

    Public Shared Function RemoveDuplicate(ByVal Array1())

        Dim HashSet1 As New System.Collections.Generic.HashSet(Of String)(Array1)
        Dim Array2 = New String(HashSet1.Count - 1) {}
        HashSet1.CopyTo(Array2, 0)
        Return Array2

    End Function


End Class
