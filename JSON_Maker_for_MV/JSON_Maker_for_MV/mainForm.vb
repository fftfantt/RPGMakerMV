
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

        Dim strPath As String = ProjectPathBox.Text
        Dim sctPath As String = FolderDialog.Show("プロジェクトフォルダ選択", strPath)
        If Not sctPath = "" Then ProjectPathBox.Text = sctPath


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
        ExportPathBox.Text = ProjectPathBox.Text & "\data\MV_Project.json"

    End Sub


    ''' <summary>
    ''' 書き出し先ボタンをクリックしたときのイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub ExportPathButton_Click(sender As Object, e As EventArgs) Handles ExportPathButton.Click

        Dim strPath As String = ProjectPathBox.Text
        Dim sctPath As String = FolderDialog.Show("書き出し先選択", strPath)
        If Not sctPath = "" Then ExportPathBox.Text = sctPath & "\MV_Project.json"

    End Sub


    ''' <summary>
    ''' JSON書き出しをクリックしたときのイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub WriteJSONButton_Click(sender As Object, e As EventArgs) Handles WriteJSONButton.Click

        'プロジェクトフォルダの存在チェック
        If Not Folder.Check(ProjectPathBox.Text) Then
            MessageBox.Show("プロジェクトフォルダ：「 " & ProjectPathBox.Text & " 」が存在しません。" & vbCrLf & "正しい値を入れてください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            ProjectPathBox.Focus()
            Exit Sub
        End If

        '書き出し先フォルダの存在チェック
        Try
            If Not Folder.Check(System.IO.Path.GetDirectoryName(ExportPathBox.Text)) Then
                MessageBox.Show("書き出し先：「 " & System.IO.Path.GetDirectoryName(ExportPathBox.Text) & " 」が存在しません。" & vbCrLf & "正しい値を入れてください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
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
        Dim errMsg As String = ""

        If ck_bgm.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\audio\bgm") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\audio\bgm", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & "\audio\bgm"
            End If
        End If

        If ck_bgs.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\audio\bgs") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\audio\bgs", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\audio\bgs"
            End If
        End If

        If ck_me.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\audio\me") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\audio\me", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\audio\me"
            End If
        End If

        If ck_se.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\audio\se") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\audio\se", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\audio\se"
            End If
        End If

        If ck_pictures.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\pictures") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\pictures", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\pictures"
            End If
        End If

        If ck_system.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\system") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\system", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\system"
            End If
        End If

        If ck_tilesets.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\tilesets") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\tilesets", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\tilesets"
            End If
        End If

        If ck_titles1.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\titles1") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\titles1", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\titles1"
            End If
        End If

        If ck_titles2.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\titles2") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\titles2", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\titles2"
            End If
        End If

        If ck_battlebacks1.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\battlebacks1") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\battlebacks1", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\battlebacks1"
            End If
        End If

        If ck_battlebacks2.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\battlebacks2") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\battlebacks2", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\battlebacks2"
            End If
        End If

        If ck_characters.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\characters") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\characters", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\characters"
            End If
        End If

        If ck_enemies.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\enemies") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\enemies", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\enemies"
            End If
        End If

        If ck_faces.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\faces") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\faces", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\faces"
            End If
        End If

        If ck_parallaxes.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\parallaxes") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\parallaxes", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\parallaxes"
            End If
        End If

        If ck_sv_actors.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\sv_actors") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\sv_actors", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\sv_actors"
            End If
        End If

        If ck_sv_enemies.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\sv_enemies") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\sv_enemies", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\sv_enemies"
            End If
        End If

        If ck_animations.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\img\animations") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\img\animations", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\img\animations"
            End If
        End If

        If ck_movies.Checked Then
            If Folder.Check(ProjectPathBox.Text & "\movies") Then
                strText = strText & JSON_Maker_for_MV.JSON.Generate(ProjectPathBox.Text & "\movies", ExportPathBox.Text, Extension)
            Else
                errMsg = errMsg & vbCrLf & "\movies"
            End If
        End If

        strText = strText.Substring(0, strText.Length - 1)
        strText = strText & "}"

        'JSON書き出し
        Dim utf8Enc As Encoding = Encoding.GetEncoding("UTF-8")
        Dim writer As New StreamWriter(ExportPathBox.Text, True, utf8Enc)
        writer.Write(strText)
        writer.Close()
        ShowJSONBox.Text = strText

        If Not errMsg = "" Then
            MessageBox.Show("以下の存在しない素材フォルダの一覧は作成されておりません。" &
                            vbCrLf & errMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        MessageBox.Show("MV_Project.jsonの作成が完了しました。", "作成完了", MessageBoxButtons.OK)
    End Sub

    Private Sub ExportPathBox_TextChanged(sender As Object, e As EventArgs) Handles ExportPathBox.TextChanged

    End Sub
End Class
