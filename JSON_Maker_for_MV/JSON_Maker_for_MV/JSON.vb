Imports System.Text
Imports System.IO

''' <summary>
''' RPGツクールMV素材管理用のJSONを扱うクラス
''' </summary>

Public Class JSON


    ''' <summary>
    ''' 素材管理用JSON生成用メソッド
    ''' </summary>
    ''' <param name="strPath">プロジェクトフォルダ</param>
    ''' <param name="nameJSON">JSONのファイル名</param>
    ''' <param name="Extension">拡張子書き出しの有無</param>
    ''' <returns>JSONの内容</returns>

    Public Shared Function Generate(ByVal strPath As String, ByVal nameJSON As String, ByVal Extension As Boolean)

        'ファイル名一覧の取得
        Dim files As String() = System.IO.Directory.GetFiles(
            strPath, "*", System.IO.SearchOption.AllDirectories)

            '拡張子無しの場合の処理
            If Not Extension Then
                Dim tmpfiles = Array.RemoveExtension(files)
                files = New String() {}
                files = Array.RemoveDuplicate(tmpfiles)
            End If

            'JSON生成
            Dim strText As String
        Dim kindFile As String = System.IO.Path.GetFileName(strPath)
        strText = """" & kindFile & """" & ": [" & """" & """" & ","

            For Each strFileName As String In files
                strText = strText & """"
            strText = strText & System.IO.Path.GetFileName(strFileName)
            strText = strText & """"
                strText = strText & ","
            Next

            strText = strText.Substring(0, strText.Length - 1)
            strText = strText & "],"

        'JSONの内容をリターン
        Return strText

    End Function


End Class
