Imports System.Text
Imports System.IO


''' <summary>
''' RPGツクールMV素材管理用のJSONを扱うクラス
''' </summary>
Public Class JSON

    Public _extension As Boolean
    Public _mvfile As Boolean


    ''' <summary>
    ''' 初期化処理
    ''' </summary>

    Public Sub New(ByVal EX As Boolean, ByVal MV As Boolean)

        Me._extension = EX
        Me._mvfile = MV

    End Sub

    ''' <summary>
    ''' 素材管理用JSON生成用メソッド
    ''' </summary>
    ''' <param name="strPath">素材フォルダ</param>
    ''' <param name="nameJSON">JSONのファイル名</param>
    ''' <returns>JSONの内容</returns>

    Public Function Generate(ByVal strPath As String, ByVal nameJSON As String)

        'ファイル名一覧の取得
        Dim files() As String = {}
        Dim tmpfiles1() As String = {}
        Dim tmpfiles2() As String = {}

        If Not Me._mvfile Then
            files = System.IO.Directory.GetFiles(
                strPath, "*", System.IO.SearchOption.AllDirectories)
        Else

            If strPath.IndexOf("audio") <> -1 Then
                tmpfiles1 = System.IO.Directory.GetFiles(
                strPath, "*.ogg", System.IO.SearchOption.AllDirectories)
                tmpfiles2 = System.IO.Directory.GetFiles(
                strPath, "*.m4a", System.IO.SearchOption.AllDirectories)
                files = New String(tmpfiles1.Length + tmpfiles2.Length - 1) {}
                tmpfiles1.CopyTo(files, 0)
                tmpfiles2.CopyTo(files, tmpfiles1.Length)
            End If

            If strPath.IndexOf("img") <> -1 Then
                files = System.IO.Directory.GetFiles(
                strPath, "*.png", System.IO.SearchOption.AllDirectories)
            End If

        End If

        '拡張子無しの場合の処理
        If Not Me._extension Then
            tmpfiles1 = New String() {}
            tmpfiles1 = Array.RemoveExtension(files)
            files = New String() {}
            files = Array.RemoveDuplicate(tmpfiles1)
        End If

        'JSON生成
        Dim strText As String
        Dim kindFile As String = System.IO.Path.GetFileName(strPath)
        strText = """" & kindFile & """" & ": ["

        For Each strFileName As String In files
            strText = strText & """"
            strText = strText & System.IO.Path.GetFileName(strFileName)
            strText = strText & """"
            strText = strText & ","
        Next

        If Not files.Length = 0 Then strText = strText.Substring(0, strText.Length - 1)
        strText = strText & "],"

        'JSONの内容をリターン
        Return strText

    End Function


End Class
