Imports Microsoft.Win32

''' <summary>
''' RPG用のレジストリーを扱うクラス
''' </summary>

Public Class Rseregistry


    ''' <summary>
    ''' RPG用のレジストリーを参照しプロジェクトファイルの
    ''' デフォルト書き出しパスを参照するメソッド
    ''' </summary>
    ''' <returns></returns>

    Public Shared Function Read()

        '操作するレジストリ・キーの名前
        Dim rKeyName As String = "Software\KADOKAWA\RPGMV"

        ' 取得処理を行う対象となるレジストリの値の名前
        Dim rGetValueName As String = "location"

        ' レジストリの取得
        Try
            ' レジストリ・キーのパスを指定してレジストリを開く
            Dim rKey As RegistryKey = Registry.CurrentUser.OpenSubKey(rKeyName)

            ' レジストリの値を取得
            Dim location As String = CStr(rKey.GetValue(rGetValueName))

            ' 開いたレジストリを閉じる
            rKey.Close()

            ' コンソールに取得したレジストリの値を表示
            Return location

            '例外が発生した場合は値取得無し
        Catch ex As Exception
            Return ""
        End Try

    End Function


End Class
