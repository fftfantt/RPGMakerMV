//=============================================================================
// Asset_JSON_Maker_for_MV
// ----------------------------------------------------------------------------
// Copyright (c) 2016 fftfantt
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php
// ----------------------------------------------------------------------------
// Version
// 1.0.0 2016/8/12 初版
// ----------------------------------------------------------------------------
// [HomePage]: https://googledrive.com/host/0BxiSZT-B8lvFOUFhVTF6VjNnUGc/index.html 
// [Twitter] : https://twitter.com/fftfantt/
// [GitHub]  : https://github.com/fftfantt/
//=============================================================================
/*:
 * @plugindesc 使用素材一覧JSON作成
 * @author fftfantt
 * 
 * @param jsonName
 * @desc 書き出すJSONのファイル名
 * @default MV_Project.json
 * 
 * @param addExtension
 * @desc 素材名に拡張子を付ける ON or OFF
 * @default OFF
 * 
 * @param bgm
 * @desc bgmフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param bgs
 * @desc bgsフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param me
 * @desc meフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param se
 * @desc seフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param animations
 * @desc animationsフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param battlebacks1
 * @desc battlebacks1フォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param battlebacks2
 * @desc battlebacks2フォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param characters
 * @desc  charactersフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param enemies
 * @desc enemiesフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param faces
 * @desc facesフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param parallaxes
 * @desc parallaxesフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param pictures
 * @desc picturesフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param sv_actors
 * @desc sv_actorsフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param sv_enemies
 * @desc sv_enemiesフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param system
 * @desc systemフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param tilesets
 * @desc tilesetsフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param titles1
 * @desc titles1フォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param titles2
 * @desc titles2フォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param movies
 * @desc moviesフォルダの素材名を書き出す ON or OFF
 * @default ON
 * 
 * @param others
 * @desc その他ツクールMV標準以外のフォルダの素材名を書き出す ON or OFF
 * @default OFF
 * 
 * @help
 * 
 * ■注意
 *  このプラグインはローカルファイルの削除および上書き(作成)を行います。
 *  使用前にファイルのバックアップを取ることを強く推奨します。
 *  MITライセンスの記載どおり、当プラグインにより必要なファイルが削除
 *  されてしまっても責任は負いかねますので、あらかじめご了承ください。
 *  ローカルモードのみ動作します。
 *  ファイルを書き換えるため、テストモード時のみの導入を強く推奨します。
 *
 * ■説明
 *  このプラグインは使用素材一覧のJSON素材を生成します。
 *  対象フォルダは「audio」「img」「movies」配下になります。
 *  プラグインコマンド「MakeAssetJSON」を実行すると現行のプロジェクト
 *  フォルダを解析して素材一覧のJSONファイルを作成します。
 *  プラグインコマンド「DeleteAssetJSON」を実行すると素材一覧のJSON
 *  ファイルを削除します。
 *  JSONの内容を解析して不要ファイルを削除するようなプラグインとの連携
 *  を行う場合、「DeleteAssetJSON」で素材一覧のJSONがあらかじめ削除して、
 *  削除プラグイン実行後に「MakeAssetJSON」でJSONを再作成してください。
 * 
 * ■利用規約
 *  当プラグインはMITライセンスのもとで公開されています。
 *  https://osdn.jp/projects/opensource/wiki/licenses%2FMIT_license
 *  ヘッダーのライセンス表記のみ残してください。
 *  商用利用、年齢制限のあるゲームへの使用や改変が可能です。
 *  クレジットは不要です。
 *  当プラグインによる損害の責任についても、MITライセンスの表記どおりです。 
*/

(function () {
    'use strict';

    //コンストラクタ
    function Asset_JSON_Maker_for_MV() { this.initialize() };

    //初期化
    Asset_JSON_Maker_for_MV.prototype.initialize = function () {
        var parameters = PluginManager.parameters('Asset_JSON_Maker_for_MV');
        this._name = parameters['jsonName'];
        this._addExtension = (parameters['addExtension'] === 'ON') ? true : false;
        this._folderHash = parameters;
        this._data = {};
    };

    //プロジェクトディレクトリ
    Asset_JSON_Maker_for_MV.prototype.projectDirectory = function () {
        var path = require('path');
        var dir = path.dirname(window.location.pathname);
        if (dir.match(/^\/([A-Z]\:)/)) {
            dir = dir.slice(1);
        }
        return decodeURIComponent(dir);
    };

    //DevTool起動
    Asset_JSON_Maker_for_MV.prototype.showDevTool = function () {
        if (!StorageManager.isLocalMode()) return;
        var devTool = require('nw.gui');
        devTool.Window.get().moveTo(0, 0);
        devTool.Window.get().resizeTo(window.screenX + window.outerWidth,
            window.screenY + window.outerHeight);
        devTool.Window.get().showDevTools();
    };

    //拡張子除外
    Asset_JSON_Maker_for_MV.prototype.excludExtension = function (file) {
        if (!this._addExtension) file = file.match(/(.*)(?:\.([^.]+$))/)[1];
        return file;
    };

    //重複除外
    Asset_JSON_Maker_for_MV.prototype.deDuplication = function (files) {
        files = files.filter(function (x, i, self) {
            return self.indexOf(x) === i;
        });
        return files;
    };

    //フォルダ書き出し判定
    Asset_JSON_Maker_for_MV.prototype.isWriteFolder = function (dir) {
        var hash = this._folderHash;
        var key = '' + dir;
        if (key in hash) {
            if (hash[key] === 'ON') return true;
        } else {
            if (hash['others'] === 'ON') return true;
        }
        return false;
    };

    //ファイルリスト作成
    Asset_JSON_Maker_for_MV.prototype.makeFileList = function (dir) {
        try {
            var fs = require('fs');
            var path = require('path');
            var files = [];
            var list = fs.readdirSync(dir);
            if (list == null) return;
            list.forEach(function (etc) {
                if (fs.statSync(dir + '/' + etc + '/').isDirectory()) this.makeFileList(dir + '/' + etc + '/');
                if (fs.statSync(dir + '/' + etc + '/').isFile()) files.push(this.excludExtension(etc));
            }, this);
            if (files.length !== 0 && this.isWriteFolder(path.basename(dir)))
                this._data[path.basename(dir)] = this.deDuplication(files);
        } catch (e) {
            if (e.errno === -4058 && e.code === 'ENOENT' && e.syscall === 'scandir') {
                var msg = dir + 'が存在しないため読み飛ばします。';
                console.log(msg);
                this.showDevTool();
            } else { throw e }
        };
    };

    //素材用JSON作成
    Asset_JSON_Maker_for_MV.prototype.makeJSON = function () {
        try {
            var fs = require('fs');
            var dir = this.projectDirectory() + '/data/';
            fs.writeFileSync(dir + this._name, JSON.stringify(this._data, null));
            return true;
        } catch (e) {
            if (e.errno === -4058 && e.code === 'ENOENT' && e.syscall === 'open') {
                var msg = 'JSONファイルが作成できません。';
                msg = msg + '\n' + '作成するフォルダが存在するか、';
                msg = msg + 'またはファイルがOPENされていないか確認してください。';
                msg = msg + '\n';
                console.log(msg);
                this.showDevTool();
                return false;
            } else { throw e }
        };
    };

    //素材用JSON削除
    Asset_JSON_Maker_for_MV.prototype.deleteJSON = function () {
        try {
            var fs = require('fs');
            var dir = this.projectDirectory() + '/data/';
            fs.unlinkSync(dir + this._name);
            return true;
        } catch (e) {
            if (e.errno === -4058 && e.code === 'ENOENT' && e.syscall === 'unlink') {
                var msg = '削除するJSONファイルが見つかりません';
                msg = msg + '\n';
                console.log(msg);
                this.showDevTool();
                return false;
            } else { throw e }
        };
    };

    //JSON作成メイン処理
    var makeAssetJSON = function () {
        if (!StorageManager.isLocalMode()) return;
        var jsonMaker = new Asset_JSON_Maker_for_MV();
        var dir = jsonMaker.projectDirectory();
        jsonMaker.makeFileList(dir + '/audio/');
        jsonMaker.makeFileList(dir + '/img/');
        jsonMaker.makeFileList(dir + '/movies/');
        var makeJSON = jsonMaker.makeJSON();
        if (makeJSON) console.log('JSON maked');
    };

    //JSON削除メイン処理
    var deleteAssetJSON = function () {
        if (!StorageManager.isLocalMode()) return;
        var jsonMaker = new Asset_JSON_Maker_for_MV();
        var deleteJSON = jsonMaker.deleteJSON();
        if (deleteJSON) console.log('JSON deleted');
    };

    //=============================================================================
    // Game_Interpreter_pluginCommand
    //  プラグインコマンドが実行されたときに処理されます
    //=============================================================================
    var _Game_Interpreter_pluginCommand = Game_Interpreter.prototype.pluginCommand;
    Game_Interpreter.prototype.pluginCommand = function (command, args) {
        _Game_Interpreter_pluginCommand.call(this, command, args);
        if (command === 'MakeAssetJSON') { makeAssetJSON() }
        else if (command === 'DeleteAssetJSON') { deleteAssetJSON() }
    };
})();
