
Imports System.Text
Imports System.IO

''' <summary>
''' RPGツクールMV素材書き出し用のメイン画面
''' </summary>

Public Class mainForm


    ''' <summary>
    ''' レジストリーを参照するメソッド
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '対象プロジェクトにレジストリーの値セット
        ProjectPathBox.Text = Rseregistry.Read()

    End Sub


    ''' <summary>
    ''' 対象プロジェクトボタンをクリックしたときのイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub ProjectPathButton_Click(sender As Object, e As EventArgs) Handles ProjectPathButton.Click

        'フォルダ選択ダイアログ表示
        FolderBrowserDialog1.SelectedPath = ProjectPathBox.Text
        FolderBrowserDialog1.ShowDialog()

        '対象プロジェクトに選択したフォルダセット
        ProjectPathBox.Text = FolderBrowserDialog1.SelectedPath

        '書き出し先をセット
        ExportPathBox.Text = ProjectPathBox.Text & "\data\MV_Project.json"

    End Sub


    ''' <summary>
    ''' 対象プロジェクトのテキストボックスからフォーカスを外したときのイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub ProjectPathBox_Leave(sender As Object, e As EventArgs) Handles ProjectPathBox.Leave

        '書き出し先をセット
        FolderBrowserDialog2.SelectedPath = ProjectPathBox.Text & "\data"
        ExportPathBox.Text = ProjectPathBox.Text & "\data\MV_Project.json"

    End Sub


    ''' <summary>
    ''' 書き出し先ボタンをクリックしたときのイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub ExportPathButton_Click(sender As Object, e As EventArgs) Handles ExportPathButton.Click
        FolderBrowserDialog2.ShowDialog()
        ExportPathBox.Text = FolderBrowserDialog2.SelectedPath & "\MV_Project.json"
    End Sub


    ''' <summary>
    ''' JSON書き出しをクリックしたときのイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub WriteJSONButton_Click(sender As Object, e As EventArgs) Handles WriteJSONButton.Click

        'プロジェクトフォルダの存在チェック
        If Not Folder.Check(ProjectPathBox.Text) Then
            ProjectPathBox.Focus()
            Exit Sub
        End If

        '書き出し先フォルダの存在チェック
        Try
            If Not Folder.Check(System.IO.Path.GetDirectoryName(ExportPathBox.Text)) Then
                ExportPathBox.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("書き出し先を設定してください。",
            "エラー",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
            ExportPathBox.Focus()
            Exit Sub
        End Try

        'プロジェクト内各フォルダの存在チェック
        If ck_bgm.Checked And Not Folder.Check(ProjectPathBox.Text & "\audio\bgm") Then Exit Sub
        If ck_bgs.Checked And Not Folder.Check(ProjectPathBox.Text & "\audio\bgs") Then Exit Sub
        If ck_me.Checked And Not Folder.Check(ProjectPathBox.Text & "\audio\me") Then Exit Sub
        If ck_se.Checked And Not Folder.Check(ProjectPathBox.Text & "\audio\se") Then Exit Sub
        If ck_pictures.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\pictures") Then Exit Sub
        If ck_system.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\system") Then Exit Sub
        If ck_tilesets.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\tilesets") Then Exit Sub
        If ck_titles1.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\titles1") Then Exit Sub
        If ck_titles2.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\titles2") Then Exit Sub
        If ck_battlebacks1.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\battlebacks1") Then Exit Sub
        If ck_battlebacks2.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\battlebacks2") Then Exit Sub
        If ck_characters.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\characters") Then Exit Sub
        If ck_enemies.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\enemies") Then Exit Sub
        If ck_faces.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\faces") Then Exit Sub
        If ck_parallaxes.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\parallaxes") Then Exit Sub
        If ck_sv_actors.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\sv_actors") Then Exit Sub
        If ck_sv_enemies.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\sv_enemies") Then Exit Sub
        If ck_animations.Checked And Not Folder.Check(ProjectPathBox.Text & "\img\animations") Then Exit Sub
        If ck_movies.Checked And Not Folder.Check(ProjectPathBox.Text & "\movies") Then Exit Sub

        'JSONファイルの存在チェック
        If System.IO.File.Exists(ExportPathBox.Text) Then
            Dim result As DialogResult = MessageBox.Show("既にファイルが存在します。" & vbCrLf &
                                                         "ファイルを上書きしますか？", "確認",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Exclamation,
                                                         MessageBoxDefaultButton.Button2)
            If result = DialogResult.No Then Exit Sub
        End If

        Try
            System.IO.File.Delete(ExportPathBox.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message,
            "エラー",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
            Exit Sub
        End Try

        '拡張子の有無チェック
        Dim Extension As String

        If ExtensionBox.Checked Then
            Extension = True
        Else
            Extension = False
        End If

        'JSONの内容構成
        Dim strText As String = "{"
        If ck_bgm.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\audio\bgm", ExportPathBox.Text, Extension)
        If ck_bgs.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\audio\bgs", ExportPathBox.Text, Extension)
        If ck_me.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\audio\me", ExportPathBox.Text, Extension)
        If ck_se.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\audio\se", ExportPathBox.Text, Extension)
        If ck_pictures.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\pictures", ExportPathBox.Text, Extension)
        If ck_system.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\system", ExportPathBox.Text, Extension)
        If ck_tilesets.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\tilesets", ExportPathBox.Text, Extension)
        If ck_titles1.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\titles1", ExportPathBox.Text, Extension)
        If ck_titles2.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\titles2", ExportPathBox.Text, Extension)
        If ck_battlebacks1.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\battlebacks1", ExportPathBox.Text, Extension)
        If ck_battlebacks2.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\battlebacks2", ExportPathBox.Text, Extension)
        If ck_characters.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\characters", ExportPathBox.Text, Extension)
        If ck_enemies.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\enemies", ExportPathBox.Text, Extension)
        If ck_faces.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\faces", ExportPathBox.Text, Extension)
        If ck_parallaxes.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\parallaxes", ExportPathBox.Text, Extension)
        If ck_sv_actors.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\sv_actors", ExportPathBox.Text, Extension)
        If ck_sv_enemies.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\sv_enemies", ExportPathBox.Text, Extension)
        If ck_animations.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\animations", ExportPathBox.Text, Extension)
        If ck_movies.Checked Then strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\movies", ExportPathBox.Text, Extension)
        strText = strText.Substring(0, strText.Length - 1)
        strText = strText & "}"

        'JSON書き出し
        Dim utf8Enc As Encoding = Encoding.GetEncoding("UTF-8")
        Dim writer As New StreamWriter(ExportPathBox.Text, True, utf8Enc)
        writer.Write(strText)
        writer.Close()
        ShowJSONBox.Text = strText
        MessageBox.Show("MV_Project.jsonの作成が完了しました。", "作成完了", MessageBoxButtons.OK)
    End Sub

    Private Sub ExportPathBox_TextChanged(sender As Object, e As EventArgs) Handles ExportPathBox.TextChanged

    End Sub
End Class
