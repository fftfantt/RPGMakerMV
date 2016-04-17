<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ProjectPathButton = New System.Windows.Forms.Button()
        Me.ProjectPathBox = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ck_bgm = New System.Windows.Forms.CheckBox()
        Me.ck_bgs = New System.Windows.Forms.CheckBox()
        Me.ck_me = New System.Windows.Forms.CheckBox()
        Me.ck_se = New System.Windows.Forms.CheckBox()
        Me.ck_pictures = New System.Windows.Forms.CheckBox()
        Me.ExportPathButton = New System.Windows.Forms.Button()
        Me.WriteJSONButton = New System.Windows.Forms.Button()
        Me.ExportPathBox = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ShowJSONBox = New System.Windows.Forms.TextBox()
        Me.ExtensionBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ck_animations = New System.Windows.Forms.CheckBox()
        Me.ck_sv_enemies = New System.Windows.Forms.CheckBox()
        Me.ck_sv_actors = New System.Windows.Forms.CheckBox()
        Me.ck_parallaxes = New System.Windows.Forms.CheckBox()
        Me.ck_faces = New System.Windows.Forms.CheckBox()
        Me.ck_enemies = New System.Windows.Forms.CheckBox()
        Me.ck_characters = New System.Windows.Forms.CheckBox()
        Me.ck_battlebacks2 = New System.Windows.Forms.CheckBox()
        Me.ck_battlebacks1 = New System.Windows.Forms.CheckBox()
        Me.ck_titles2 = New System.Windows.Forms.CheckBox()
        Me.ck_titles1 = New System.Windows.Forms.CheckBox()
        Me.ck_tilesets = New System.Windows.Forms.CheckBox()
        Me.ck_system = New System.Windows.Forms.CheckBox()
        Me.ck_movies = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProjectPathButton
        '
        Me.ProjectPathButton.Location = New System.Drawing.Point(38, 224)
        Me.ProjectPathButton.Name = "ProjectPathButton"
        Me.ProjectPathButton.Size = New System.Drawing.Size(153, 55)
        Me.ProjectPathButton.TabIndex = 0
        Me.ProjectPathButton.Text = "対象プロジェクト"
        Me.ProjectPathButton.UseVisualStyleBackColor = True
        '
        'ProjectPathBox
        '
        Me.ProjectPathBox.Location = New System.Drawing.Point(223, 239)
        Me.ProjectPathBox.Name = "ProjectPathBox"
        Me.ProjectPathBox.Size = New System.Drawing.Size(712, 25)
        Me.ProjectPathBox.TabIndex = 1
        Me.ProjectPathBox.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'ck_bgm
        '
        Me.ck_bgm.AutoSize = True
        Me.ck_bgm.Checked = True
        Me.ck_bgm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_bgm.Location = New System.Drawing.Point(25, 24)
        Me.ck_bgm.Name = "ck_bgm"
        Me.ck_bgm.Size = New System.Drawing.Size(64, 22)
        Me.ck_bgm.TabIndex = 3
        Me.ck_bgm.Text = "bgm"
        Me.ck_bgm.UseVisualStyleBackColor = True
        '
        'ck_bgs
        '
        Me.ck_bgs.AutoSize = True
        Me.ck_bgs.Checked = True
        Me.ck_bgs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_bgs.Location = New System.Drawing.Point(151, 24)
        Me.ck_bgs.Name = "ck_bgs"
        Me.ck_bgs.Size = New System.Drawing.Size(59, 22)
        Me.ck_bgs.TabIndex = 4
        Me.ck_bgs.Text = "bgs"
        Me.ck_bgs.UseVisualStyleBackColor = True
        '
        'ck_me
        '
        Me.ck_me.AutoSize = True
        Me.ck_me.Checked = True
        Me.ck_me.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_me.Location = New System.Drawing.Point(260, 24)
        Me.ck_me.Name = "ck_me"
        Me.ck_me.Size = New System.Drawing.Size(56, 22)
        Me.ck_me.TabIndex = 5
        Me.ck_me.Text = "me"
        Me.ck_me.UseVisualStyleBackColor = True
        '
        'ck_se
        '
        Me.ck_se.AutoSize = True
        Me.ck_se.Checked = True
        Me.ck_se.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_se.Location = New System.Drawing.Point(360, 24)
        Me.ck_se.Name = "ck_se"
        Me.ck_se.Size = New System.Drawing.Size(51, 22)
        Me.ck_se.TabIndex = 6
        Me.ck_se.Text = "se"
        Me.ck_se.UseVisualStyleBackColor = True
        '
        'ck_pictures
        '
        Me.ck_pictures.AutoSize = True
        Me.ck_pictures.Checked = True
        Me.ck_pictures.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_pictures.Location = New System.Drawing.Point(38, 117)
        Me.ck_pictures.Name = "ck_pictures"
        Me.ck_pictures.Size = New System.Drawing.Size(94, 22)
        Me.ck_pictures.TabIndex = 10
        Me.ck_pictures.Text = "pictures"
        Me.ck_pictures.UseVisualStyleBackColor = False
        '
        'ExportPathButton
        '
        Me.ExportPathButton.Location = New System.Drawing.Point(38, 326)
        Me.ExportPathButton.Name = "ExportPathButton"
        Me.ExportPathButton.Size = New System.Drawing.Size(153, 55)
        Me.ExportPathButton.TabIndex = 11
        Me.ExportPathButton.Text = "書き出し先"
        Me.ExportPathButton.UseVisualStyleBackColor = True
        '
        'WriteJSONButton
        '
        Me.WriteJSONButton.Location = New System.Drawing.Point(38, 422)
        Me.WriteJSONButton.Name = "WriteJSONButton"
        Me.WriteJSONButton.Size = New System.Drawing.Size(153, 55)
        Me.WriteJSONButton.TabIndex = 12
        Me.WriteJSONButton.Text = "JSON書出"
        Me.WriteJSONButton.UseVisualStyleBackColor = True
        '
        'ExportPathBox
        '
        Me.ExportPathBox.Location = New System.Drawing.Point(223, 341)
        Me.ExportPathBox.Name = "ExportPathBox"
        Me.ExportPathBox.Size = New System.Drawing.Size(712, 25)
        Me.ExportPathBox.TabIndex = 13
        '
        'ShowJSONBox
        '
        Me.ShowJSONBox.Location = New System.Drawing.Point(223, 422)
        Me.ShowJSONBox.Multiline = True
        Me.ShowJSONBox.Name = "ShowJSONBox"
        Me.ShowJSONBox.ReadOnly = True
        Me.ShowJSONBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ShowJSONBox.Size = New System.Drawing.Size(712, 166)
        Me.ShowJSONBox.TabIndex = 14
        '
        'ExtensionBox
        '
        Me.ExtensionBox.AutoSize = True
        Me.ExtensionBox.Location = New System.Drawing.Point(766, 40)
        Me.ExtensionBox.Name = "ExtensionBox"
        Me.ExtensionBox.Size = New System.Drawing.Size(145, 22)
        Me.ExtensionBox.TabIndex = 15
        Me.ExtensionBox.Text = "拡張子をつける"
        Me.ExtensionBox.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ck_se)
        Me.GroupBox1.Controls.Add(Me.ck_me)
        Me.GroupBox1.Controls.Add(Me.ck_bgs)
        Me.GroupBox1.Controls.Add(Me.ck_bgm)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(469, 65)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "audio"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ck_animations)
        Me.GroupBox2.Controls.Add(Me.ck_sv_enemies)
        Me.GroupBox2.Controls.Add(Me.ck_sv_actors)
        Me.GroupBox2.Controls.Add(Me.ck_parallaxes)
        Me.GroupBox2.Controls.Add(Me.ck_faces)
        Me.GroupBox2.Controls.Add(Me.ck_enemies)
        Me.GroupBox2.Controls.Add(Me.ck_characters)
        Me.GroupBox2.Controls.Add(Me.ck_battlebacks2)
        Me.GroupBox2.Controls.Add(Me.ck_battlebacks1)
        Me.GroupBox2.Controls.Add(Me.ck_titles2)
        Me.GroupBox2.Controls.Add(Me.ck_titles1)
        Me.GroupBox2.Controls.Add(Me.ck_tilesets)
        Me.GroupBox2.Controls.Add(Me.ck_system)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 87)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(922, 115)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "img"
        '
        'ck_animations
        '
        Me.ck_animations.AutoSize = True
        Me.ck_animations.Checked = True
        Me.ck_animations.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_animations.Location = New System.Drawing.Point(754, 77)
        Me.ck_animations.Name = "ck_animations"
        Me.ck_animations.Size = New System.Drawing.Size(114, 22)
        Me.ck_animations.TabIndex = 23
        Me.ck_animations.Text = "animations"
        Me.ck_animations.UseVisualStyleBackColor = False
        Me.ck_animations.UseWaitCursor = True
        '
        'ck_sv_enemies
        '
        Me.ck_sv_enemies.AutoSize = True
        Me.ck_sv_enemies.Checked = True
        Me.ck_sv_enemies.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_sv_enemies.Location = New System.Drawing.Point(607, 77)
        Me.ck_sv_enemies.Name = "ck_sv_enemies"
        Me.ck_sv_enemies.Size = New System.Drawing.Size(117, 22)
        Me.ck_sv_enemies.TabIndex = 22
        Me.ck_sv_enemies.Text = "sv_enemies"
        Me.ck_sv_enemies.UseVisualStyleBackColor = False
        Me.ck_sv_enemies.UseWaitCursor = True
        '
        'ck_sv_actors
        '
        Me.ck_sv_actors.AutoSize = True
        Me.ck_sv_actors.Checked = True
        Me.ck_sv_actors.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_sv_actors.Location = New System.Drawing.Point(489, 77)
        Me.ck_sv_actors.Name = "ck_sv_actors"
        Me.ck_sv_actors.Size = New System.Drawing.Size(103, 22)
        Me.ck_sv_actors.TabIndex = 21
        Me.ck_sv_actors.Text = "sv_actors"
        Me.ck_sv_actors.UseVisualStyleBackColor = False
        Me.ck_sv_actors.UseWaitCursor = True
        '
        'ck_parallaxes
        '
        Me.ck_parallaxes.AutoSize = True
        Me.ck_parallaxes.Checked = True
        Me.ck_parallaxes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_parallaxes.Location = New System.Drawing.Point(360, 77)
        Me.ck_parallaxes.Name = "ck_parallaxes"
        Me.ck_parallaxes.Size = New System.Drawing.Size(109, 22)
        Me.ck_parallaxes.TabIndex = 20
        Me.ck_parallaxes.Text = "parallaxes"
        Me.ck_parallaxes.UseVisualStyleBackColor = False
        '
        'ck_faces
        '
        Me.ck_faces.AutoSize = True
        Me.ck_faces.Checked = True
        Me.ck_faces.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_faces.Location = New System.Drawing.Point(260, 77)
        Me.ck_faces.Name = "ck_faces"
        Me.ck_faces.Size = New System.Drawing.Size(74, 22)
        Me.ck_faces.TabIndex = 19
        Me.ck_faces.Text = "faces"
        Me.ck_faces.UseVisualStyleBackColor = False
        '
        'ck_enemies
        '
        Me.ck_enemies.AutoSize = True
        Me.ck_enemies.Checked = True
        Me.ck_enemies.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_enemies.Location = New System.Drawing.Point(151, 77)
        Me.ck_enemies.Name = "ck_enemies"
        Me.ck_enemies.Size = New System.Drawing.Size(95, 22)
        Me.ck_enemies.TabIndex = 18
        Me.ck_enemies.Text = "enemies"
        Me.ck_enemies.UseVisualStyleBackColor = False
        '
        'ck_characters
        '
        Me.ck_characters.AutoSize = True
        Me.ck_characters.Checked = True
        Me.ck_characters.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_characters.Location = New System.Drawing.Point(25, 77)
        Me.ck_characters.Name = "ck_characters"
        Me.ck_characters.Size = New System.Drawing.Size(114, 22)
        Me.ck_characters.TabIndex = 17
        Me.ck_characters.Text = "characters"
        Me.ck_characters.UseVisualStyleBackColor = False
        '
        'ck_battlebacks2
        '
        Me.ck_battlebacks2.AutoSize = True
        Me.ck_battlebacks2.Checked = True
        Me.ck_battlebacks2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_battlebacks2.Location = New System.Drawing.Point(754, 30)
        Me.ck_battlebacks2.Name = "ck_battlebacks2"
        Me.ck_battlebacks2.Size = New System.Drawing.Size(129, 22)
        Me.ck_battlebacks2.TabIndex = 16
        Me.ck_battlebacks2.Text = "battlebacks2"
        Me.ck_battlebacks2.UseVisualStyleBackColor = False
        Me.ck_battlebacks2.UseWaitCursor = True
        '
        'ck_battlebacks1
        '
        Me.ck_battlebacks1.AutoSize = True
        Me.ck_battlebacks1.Checked = True
        Me.ck_battlebacks1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_battlebacks1.Location = New System.Drawing.Point(607, 30)
        Me.ck_battlebacks1.Name = "ck_battlebacks1"
        Me.ck_battlebacks1.Size = New System.Drawing.Size(129, 22)
        Me.ck_battlebacks1.TabIndex = 15
        Me.ck_battlebacks1.Text = "battlebacks1"
        Me.ck_battlebacks1.UseVisualStyleBackColor = False
        Me.ck_battlebacks1.UseWaitCursor = True
        '
        'ck_titles2
        '
        Me.ck_titles2.AutoSize = True
        Me.ck_titles2.Checked = True
        Me.ck_titles2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_titles2.Location = New System.Drawing.Point(489, 30)
        Me.ck_titles2.Name = "ck_titles2"
        Me.ck_titles2.Size = New System.Drawing.Size(80, 22)
        Me.ck_titles2.TabIndex = 14
        Me.ck_titles2.Text = "titles2"
        Me.ck_titles2.UseVisualStyleBackColor = False
        Me.ck_titles2.UseWaitCursor = True
        '
        'ck_titles1
        '
        Me.ck_titles1.AutoSize = True
        Me.ck_titles1.Checked = True
        Me.ck_titles1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_titles1.Location = New System.Drawing.Point(360, 30)
        Me.ck_titles1.Name = "ck_titles1"
        Me.ck_titles1.Size = New System.Drawing.Size(80, 22)
        Me.ck_titles1.TabIndex = 13
        Me.ck_titles1.Text = "titles1"
        Me.ck_titles1.UseVisualStyleBackColor = False
        '
        'ck_tilesets
        '
        Me.ck_tilesets.AutoSize = True
        Me.ck_tilesets.Checked = True
        Me.ck_tilesets.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_tilesets.Location = New System.Drawing.Point(260, 30)
        Me.ck_tilesets.Name = "ck_tilesets"
        Me.ck_tilesets.Size = New System.Drawing.Size(88, 22)
        Me.ck_tilesets.TabIndex = 12
        Me.ck_tilesets.Text = "tilesets"
        Me.ck_tilesets.UseVisualStyleBackColor = False
        '
        'ck_system
        '
        Me.ck_system.AutoSize = True
        Me.ck_system.Checked = True
        Me.ck_system.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_system.Location = New System.Drawing.Point(151, 30)
        Me.ck_system.Name = "ck_system"
        Me.ck_system.Size = New System.Drawing.Size(87, 22)
        Me.ck_system.TabIndex = 11
        Me.ck_system.Text = "system"
        Me.ck_system.UseVisualStyleBackColor = False
        '
        'ck_movies
        '
        Me.ck_movies.AutoSize = True
        Me.ck_movies.Checked = True
        Me.ck_movies.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_movies.Location = New System.Drawing.Point(502, 40)
        Me.ck_movies.Name = "ck_movies"
        Me.ck_movies.Size = New System.Drawing.Size(86, 22)
        Me.ck_movies.TabIndex = 18
        Me.ck_movies.Text = "movies"
        Me.ck_movies.UseVisualStyleBackColor = True
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 616)
        Me.Controls.Add(Me.ck_movies)
        Me.Controls.Add(Me.ck_pictures)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ExtensionBox)
        Me.Controls.Add(Me.ShowJSONBox)
        Me.Controls.Add(Me.ExportPathBox)
        Me.Controls.Add(Me.WriteJSONButton)
        Me.Controls.Add(Me.ExportPathButton)
        Me.Controls.Add(Me.ProjectPathBox)
        Me.Controls.Add(Me.ProjectPathButton)
        Me.Name = "mainForm"
        Me.Text = "RPGツクールMV素材用JSON生成"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProjectPathButton As Button
    Friend WithEvents ProjectPathBox As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ck_bgm As CheckBox
    Friend WithEvents ck_bgs As CheckBox
    Friend WithEvents ck_me As CheckBox
    Friend WithEvents ck_se As CheckBox
    Friend WithEvents ck_pictures As CheckBox
    Friend WithEvents ExportPathButton As Button
    Friend WithEvents WriteJSONButton As Button
    Friend WithEvents ExportPathBox As TextBox
    Friend WithEvents FolderBrowserDialog2 As FolderBrowserDialog
    Friend WithEvents ShowJSONBox As TextBox
    Friend WithEvents ExtensionBox As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ck_titles1 As CheckBox
    Friend WithEvents ck_tilesets As CheckBox
    Friend WithEvents ck_system As CheckBox
    Friend WithEvents ck_animations As CheckBox
    Friend WithEvents ck_sv_enemies As CheckBox
    Friend WithEvents ck_sv_actors As CheckBox
    Friend WithEvents ck_parallaxes As CheckBox
    Friend WithEvents ck_faces As CheckBox
    Friend WithEvents ck_enemies As CheckBox
    Friend WithEvents ck_characters As CheckBox
    Friend WithEvents ck_battlebacks2 As CheckBox
    Friend WithEvents ck_battlebacks1 As CheckBox
    Friend WithEvents ck_titles2 As CheckBox
    Friend WithEvents ck_movies As CheckBox
End Class
