Imports System.Text
Imports System.IO

''' <summary>
''' フォルダーを扱うクラス
''' </summary>

Public Class Folder


    ''' <summary>
    ''' フォルダの存在チェックを行うメソッド
    ''' </summary>
    ''' <param name="strPath"></param>
    ''' <returns>True/False</returns>

    Public Shared Function Check(ByVal strPath As String)

        If Not System.IO.Directory.Exists(strPath) Then
            Return False
        End If

        Return True

    End Function


End Class
