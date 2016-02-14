//=============================================================================
// OriginalTimer.js
// ----------------------------------------------------------------------------
// Copyright (c) 2016 fftfantt
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php
// ----------------------------------------------------------------------------
// Version
// 0.1.0 2016/2/15 β版
// ----------------------------------------------------------------------------
// [HomePage]: https://googledrive.com/host/0BxiSZT-B8lvFOUFhVTF6VjNnUGc/index.html 
// [Twitter] : https://twitter.com/fftfantt/
// [GitHub]  : https://github.com/fftfantt/
//=============================================================================
/*:
 * @plugindesc オリジナルタイマー
 * @author fftfantt
 *
 * @help
 * 
 * ■説明
 * このプラグインは1日から1/100秒単位でカウントできるオリジナルタイマーを実装します。
 * カウントダウンのほか、カウントアップにも対応しています。
 * 動的テキスト表示部分のロジックについては、トリアコンタン様の「DTextPicture.js」
 * を参考にさせていただいております。この場をお借りして感謝申し上げます。
 *
 * ■利用規約
 * 当プラグインはMITライセンスのもとで公開されています。
 * https://osdn.jp/projects/opensource/wiki/licenses%2FMIT_license
 * ヘッダーのライセンス表記のみ残してください。
 * 商用利用、年齢制限のあるゲームへの使用、改変が可能です。
 * クレジットは不要です。
 * 当プラグインの不具合に損害の責任についても、MITライセンスの表記どおりです。
 *
 * ■使い方の概要
 * イベントのコマンド追加からプラグインコマンドを選択し、以下のようなプラグイン
 * コマンドでタイマーを設定後開始してください。
 *  
 * ■タイマーの設定
 * 　◆パラメータ
 * 　　引数1：タイマーの設定を行う場合の引数 [設定 or SET]
 * 　　引数2：タイマーの種類[アップ or ダウン or UP or DOWN] 
 * 　　引数3：設定時間 (1d1h1m1s1x1c のように記載)[日 or d  時間 or h  分 or m  秒 or s x(1/10秒) c(1/100秒)]
 * 　　引数4：ピクチャ番号[1～100]
 * 　　引数5：フォントサイズ
 * 　　引数6：画面Ｘ
 * 　　引数7：画面Ｙ
 * 　　引数8：表示モード[表示 or 非表示 or DISPLAY or HIDE]
 * 　　引数9：表示形式[D日 HH時MM分SS.XC秒 や HH:MM:SS:XC で自由に]
 * 　◆コマンド例
 * 　　オリジナルタイマー 設定 ダウン 2d1h30m 99 24 10 10 表示 D日 HH時MM分SS.XC秒
 * 　　ORIGINALTIMER SET DOWN 1h30m 99 24 10 10 DISPLAY HH:MM:SS:XC
 * 　　オリジナルタイマー 設定 アップ 1h30m 10 24 630 10 非表示 HH:MM:SS.XC
 * 　　ORIGINALTIMER SET UP 1h30m 10 24 630 10 HIDE HH:MM:SS.XC
 * 
 * ■タイマーの開始
 * 　◆パラメータ
 * 　　引数1：タイマーを開始もしくは再開する場合の引数 [開始 or 再開 or START]
 * 　◆コマンド例
 * 　　オリジナルタイマー 開始
 * 　　ORIGINALTIMER START
 * 
 * ■タイマーの停止
 * 　◆パラメータ
 * 　　引数1：タイマーを停止する場合の引数 [停止 or STOP]
 * 　◆コマンド例
 * 　　オリジナルタイマー 停止
 * 　　ORIGINALTIMER STOP
 * 
 * ■タイマーの表示
 * 　◆パラメータ
 * 　　引数1：タイマーを表示する場合の引数 [表示 or DISPLAY]
 * 　◆コマンド例
 * 　　オリジナルタイマー 表示
 * 　　ORIGINALTIMER DISPLAY
 * 
 * ■タイマーの非表示
 * 　◆パラメータ
 * 　　引数1：タイマーを非表示にする場合の引数 [非表示 or HIDE]
 * 　◆コマンド例
 * 　　オリジナルタイマー 非表示
 * 　　ORIGINALTIMER HIDE
 * 
 * ■タイマーの初期化
 * 　　引数1：タイマーを初期化する場合の引数 [初期化 or INITIALIZE]
 * 　◆コマンド例
 * 　　オリジナルタイマー 初期化
 * 　　ORIGINALTIMER INITIALIZE
 * 
 * ■タイマー値の取得
 * 　　引数1：タイマーに関する値を取得する場合の引数 [取得 or GET]
 * 　　引数2：取得する値の種類 [状態 or STATE or 値 or VALUE etc]
 * 　　引数3：値を格納する変数
 * 　◆コマンド例
 * 　　オリジナルタイマー 取得 状態 1
 * 　　ORIGINALTIMER GET STATE 1
 * 　　オリジナルタイマー 取得 値 1
 * 　　ORIGINALTIMER GET VALUE 1
 * 　　オリジナルタイマー 取得 日 1
 * 　　ORIGINALTIMER GET DAY 1
 * 　　オリジナルタイマー 取得 時 1
 * 　　ORIGINALTIMER GET HR 1
 * 　　オリジナルタイマー 取得 分 1
 * 　　ORIGINALTIMER GET MIN 1
 * 　　オリジナルタイマー 取得 秒 1
 * 　　ORIGINALTIMER GET SEC 1
 * 　　オリジナルタイマー 取得 コンマ秒 1
 * 　　ORIGINALTIMER GET HSEC 1
 */

(function () {
  var count;
  var count_unit;
  var count_time;
  var commnd_type;
  var timer_type;
  var timer_limit;
  var day;
  var hr;
  var min;
  var sec;
  var Hsec;
  var timer_text;
  var show_text;
 
  var pictureId;
  var fontsize; 
  var name = "";
  var origin = 0;
  var x;
  var y;
  var scaleX = 100;
  var scaleY = 100;
  var opacity;
  var blendMode = 0;
  var display_mode;
  var OriginalTimer;
  
  var _Game_Interpreter_pluginCommand = Game_Interpreter.prototype.pluginCommand;
  Game_Interpreter.prototype.pluginCommand = function(command, args) {
    _Game_Interpreter_pluginCommand.call(this, command, args);
   
    if (command === "オリジナルタイマー" || command.toUpperCase() === "ORIGINALTIMER" ) {
      if ($gameTimer !== null){
        if (!Object.prototype.hasOwnProperty.call($gameTimer, '_fftfantt_OriginalTimer_Run')){
          Game_Timer.prototype.fftfantt_OriginalTimer_initialize();
        }
      }
      commnd_type = args[0];
      
      if (commnd_type == '設定' || commnd_type.toUpperCase() == 'SET'){
        if ($gameTimer._fftfantt_OriginalTimer_Run){
          console.log('オリジナルタイマーは実行中です');
          return;
        }
      Game_Timer.prototype.fftfantt_OriginalTimer_initialize();
      $gameTimer._fftfantt_OriginalTimer_Set = true;
      timer_set(args);
      }

      if (commnd_type == '開始' || commnd_type == '再開' || commnd_type.toUpperCase() == 'START'){
        if ($gameTimer._fftfantt_OriginalTimer_Run){
          if ($gameTemp.isPlaytest()) console.log('オリジナルタイマーは実行中です');
          return;
        }
        if ($gameTimer._fftfantt_OriginalTimer_Run){
          if (!$gameTemp.isPlaytest()) console.log('タイマーが設定されていません');
          return;
        }
        $gameTimer._fftfantt_OriginalTimer_Run = true;
        timer_run();
        OriginalTimer = setInterval(timer_run,count_unit);
      }
      
      if (commnd_type == '停止' || commnd_type.toUpperCase() == 'STOP'){
        clearInterval(OriginalTimer);
        $gameTimer._fftfantt_OriginalTimer_Run = false;
      }
      
      if (commnd_type == '表示' || commnd_type.toUpperCase() == 'DISPLAY'){
        $gameTimer._fftfantt_OriginalTimer_Display = true;
        opacity = 255;
        return;
      }
      
      if (commnd_type == '非表示' || commnd_type.toUpperCase() == 'HIDE'){
        $gameTimer._fftfantt_OriginalTimer_Display = false;
        opacity = 0;
        return;
      }
      
      if (commnd_type == '初期化' || commnd_type.toUpperCase() == 'INITIALIZE'){
        Game_Timer.prototype.fftfantt_OriginalTimer_initialize();
        return;
      }

      if (commnd_type == '取得' || commnd_type.toUpperCase() == 'GET'){
        timer_get(args);
      }
      
    }
  };
  
  function timer_set(args){
    timer_type = args[1];
    var timer_tmp_array = args[2].match(/((\d+)(d|日))?((\d+)(h|時間))?((\d+)(m|分間?))?((\d+)(s|秒間?))?((\d+)(x))?((\d+)(c))?/);
    timer_limit = 0;
    if (timer_tmp_array[2])  timer_limit = timer_limit + parseInt(timer_tmp_array[2],10) * 8640000;
    if (timer_tmp_array[5])  timer_limit = timer_limit + parseInt(timer_tmp_array[5],10) * 360000;
    if (timer_tmp_array[8])  timer_limit = timer_limit + parseInt(timer_tmp_array[8],10) * 6000;
    if (timer_tmp_array[11]) timer_limit = timer_limit + parseInt(timer_tmp_array[11],10) * 100;
    if (timer_tmp_array[14]) timer_limit = timer_limit + parseInt(timer_tmp_array[14],10) * 10;
    if (timer_tmp_array[17]) timer_limit = timer_limit + parseInt(timer_tmp_array[17],10);
    pictureId = parseInt(args[3],10);
    fontsize = parseInt(args[4],10);
    x = parseInt(args[5],10);
    y = parseInt(args[6],10);
    display_mode = args[7];
    if (display_mode == '非表示' || display_mode.toUpperCase() == 'HIDE'){
      $gameTimer._fftfantt_OriginalTimer_Display = false;
      opacity = 0;
    }else{
      $gameTimer._fftfantt_OriginalTimer_Display = true;
      opacity = 255;
    }
    timer_text = args[8];
    if (args.length > 8){
      for (var i=9;i<args.length; i++) {
        timer_text = timer_text + ' ' + args[i];
      }
    }
    timer_text = timer_text.toUpperCase();
    count_unit = 1000;
    if (~timer_text.indexOf('X')) count_unit = 100;
    if (~timer_text.indexOf('C')) count_unit = 10;
    $gameTimer._fftfantt_OriginalTimer_Timer_Type = timer_type;
    $gameTimer._fftfantt_OriginalTimer_Timer_Limit = args[2];
    $gameTimer._fftfantt_OriginalTimer_Timer_Text = timer_text;
    $gameTimer._fftfantt_OriginalTimer_PctureId = pictureId;
    $gameTimer._fftfantt_OriginalTimer_FontSize = fontsize;
    $gameTimer._fftfantt_OriginalTimer_X = x;
    $gameTimer._fftfantt_OriginalTimer_Y = y;
    $gameTimer._fftfantt_OriginalTimer_Display_Mode = display_mode;
    $gameTimer._fftfantt_OriginalTimer_Timer_Text = timer_text;
  
    $gameTimer._fftfantt_OriginalTimer_Set = true;
    count = $gameTimer._fftfantt_OriginalTimer_Count;
  }
  
  function timer_run(){
    if (count >= timer_limit) $gameTimer._fftfantt_OriginalTimer_Run = false;
    if (!$gameTimer._fftfantt_OriginalTimer_Run){
      clearInterval(OriginalTimer);
      return;
    }
    count = count + count_unit / 10;
    if (timer_type == 'アップ' || timer_type.toUpperCase() == 'UP'){
      count_time = count;
    }else{
      count_time = timer_limit - count;
    }
    day = parseInt(count_time / 8640000,10);
    hr = parseInt((count_time % 8640000) / 360000,10);
    min = parseInt((count_time % 360000) / 6000,10);
    sec = parseInt((count_time % 6000)/100,10);
    Hsec = count_time % 100;
    show_text = timer_text;
    show_text = show_text.replace("D",day);
    show_text = show_text.replace("HH",("0"+hr).slice(-2));
    show_text = show_text.replace("H",hr);
    show_text = show_text.replace("MM",("0"+min).slice(-2));
    show_text = show_text.replace("M",min);
    show_text = show_text.replace("SS",("0"+sec).slice(-2));
    show_text = show_text.replace("S",sec);
    show_text = show_text.replace("X",("0"+Hsec).slice(-2).substr(0,1));
    show_text = show_text.replace("C",("0"+Hsec).slice(-2).substr(1,1));
    $gameScreen.fftfantt_SetOriginalTimerText(show_text,fontsize);
    $gameScreen.showPicture(pictureId, name, origin, x, y, scaleX, scaleY, opacity, blendMode);
    $gameTimer._fftfantt_OriginalTimer_Count = count;
  };

  function timer_get(args){
    if (args[1] == '表示値' || args[1].toUpperCase() == 'DISPLAYVALUE'){
      $gameVariables._data[parseInt(args[2],10)] = show_text;
      return;
    }
    if (args[1] == '値' || args[1].toUpperCase() == 'VALUE'){
      $gameVariables._data[parseInt(args[2],10)] = parseInt(count_time,10);
      return;
    }
    if (args[1] == 'セット値' || args[1].toUpperCase() == 'SETVALUE'){
      $gameVariables._data[parseInt(args[2],10)] = parseInt(count_time,10);
      return;
    }
    if (args[1] == '日' || args[1].toUpperCase() == 'DAY' || args[1].toUpperCase() == 'D'){
      $gameVariables._data[parseInt(args[2],10)] = parseInt(day,10);
      return;
    }
    if (args[1] == '時' || args[1].toUpperCase() == 'HR' || args[1].toUpperCase() == 'H'){
      $gameVariables._data[parseInt(args[2],10)] = parseInt(hr,10);
      return;
    }
    if (args[1]== '分' || args[1].toUpperCase() == 'MIN' || args[1].toUpperCase() == 'M'){
      $gameVariables._data[parseInt(args[2],10)] = parseInt(min,10);
      return;
    }
    if (args[1] == '秒' || args[1].toUpperCase() == 'SEC' || args[1].toUpperCase() == 'S'){
      $gameVariables._data[parseInt(args[2],10)] = parseInt(sec,10);
      return;
    }
    if (args[1] == 'コンマ秒' || args[1].toUpperCase() == 'HSEC' || args[1].toUpperCase() == 'XC'){
      $gameVariables._data[parseInt(args[2],10)] = parseInt(Hsec,10);
      return;
    }
    if (args[1] == '状態'){
      if ($gameTimer._fftfantt_OriginalTimer_Run) {
        $gameVariables._data[parseInt(args[2],10)] = '実行中';
      } else {
        $gameVariables._data[parseInt(args[2],10)] = '停止中'
      }
      return;
    }
    if (args[1].toUpperCase() == 'STATE'){
      if ($gameTimer._fftfantt_OriginalTimer_Run) {
        $gameVariables._data[parseInt(args[2],10)] = 'RUN';
      } else {
        $gameVariables._data[parseInt(args[2],10)] = 'STOP';
      }
      return;
    }
  }

  //=============================================================================
  // Game_Screen
  //  オリジナルタイマー表示用の動的ピクチャプロパティを追加定義します。
  //=============================================================================
  var _Game_Screen_clear = Game_Screen.prototype.clear;
  Game_Screen.prototype.clear = function() {
    _Game_Screen_clear.call(this);
    this.fftfantt_ClearOriginalTimerText();
  };

  Game_Screen.prototype.fftfantt_ClearOriginalTimerText = function() {
    this._fftfantt_TimerTextFlag = false;
    this._fftfantt_TimerTextValue = "";
    this._fftfantt_TimerTextSize = 0;
  };

    Game_Screen.prototype.fftfantt_SetOriginalTimerText = function(value, size) {
      this._fftfantt_TimerTextFlag = true;
      this._fftfantt_TimerTextValue = value;
      this._fftfantt_TimerTextSize = size;
    };

    //=============================================================================
    // Game_Picture
    //  動的ピクチャ用のプロパティを追加定義し、表示処理を動的ピクチャ対応に変更します。
    //=============================================================================
    var _Game_Picture_initBasic = Game_Picture.prototype.initBasic;
    Game_Picture.prototype.initBasic = function() {
      _Game_Picture_initBasic.call(this);
      this._fftfantt_TimerTextFlag     = false;
      this._fftfantt_TimerTextValue    = "";
      this._fftfantt_TimerTextSize    = 0;
    };

    var _Game_Picture_show = Game_Picture.prototype.show;
    Game_Picture.prototype.show = function(name, origin, x, y, scaleX,
                                           scaleY, opacity, blendMode) {
      if ($gameScreen._fftfantt_TimerTextFlag) {
        var window = SceneManager._scene._fftfantt_TimerTextHiddenWindow; // 制御文字の使用とサイズ計算のための隠しウィンドウ
        arguments[0] = Date.now().toString(); // 参照されません
        this._fftfantt_TimerTextFlag    = true;
        this._fftfantt_TimerTextValue   = $gameScreen._fftfantt_TimerTextValue;
        this._fftfantt_TimerTextSize    = $gameScreen._fftfantt_TimerTextSize;
            $gameScreen.fftfantt_ClearOriginalTimerText();
        } else {
            this._fftfantt_TimerTextFlag   = false;
            this._fftfantt_TimerTextValue  = "";
            this._fftfantt_TimerTextSize   = 0;
        }
        _Game_Picture_show.apply(this, arguments);
    };

    //=============================================================================
    // Sprite_Picture
    //  画像の動的生成を追加定義します。
    //=============================================================================

    var _Sprite_Picture_loadBitmap = Sprite_Picture.prototype.loadBitmap;
    Sprite_Picture.prototype.loadBitmap = function() {
        if (this.picture()._fftfantt_TimerTextFlag ) {
            this.fftfantt_TimerDynamicBitmap();
        } else {
            _Sprite_Picture_loadBitmap.call(this);
        }
    };

    Sprite_Picture.prototype.fftfantt_TimerDynamicBitmap = function() {
        var window = SceneManager._scene._fftfantt_TimerTextHiddenWindow; // 制御文字の使用とサイズ計算のための隠しウィンドウ
        if (this.picture()._fftfantt_TimerTextSize > 0) window.contents.fontSize = this.picture()._fftfantt_TimerTextSize;
        var textState = {index: 0, x: 0, y: 0, text: this.picture()._fftfantt_TimerTextValue};
        var bitmap = new Bitmap(window.textWidth(textState.text) * 1.5, window.calcTextHeight(textState, false));
        while (textState.text[textState.index]) {
            this.processCharacter(textState, bitmap);
        }
        this.bitmap = bitmap;
    };
    
    Sprite_Picture.prototype.processCharacter = function(textState, bitmap) {
        var window = SceneManager._scene._fftfantt_TimerTextHiddenWindow;
        var c = textState.text[textState.index++];
        var w = window.textWidth(c);

        bitmap.fontSize = window.contents.fontSize;
        bitmap.drawText(c, textState.x, textState.y, w * 2, bitmap.height, "left");
        textState.x += w;
    };

    //=============================================================================
    // Scene_Map
    //  動的ピクチャ作成用の隠しウィンドウを追加定義します。
    //=============================================================================
    var _Scene_Map_createDisplayObjects = Scene_Map.prototype.createDisplayObjects;
    
    Scene_Map.prototype.createDisplayObjects = function() {
        this._fftfantt_TimerTextHiddenWindow = new Window_Base(1,1,1,1);
        this._fftfantt_TimerTextHiddenWindow.hide();
        this._fftfantt_TimerTextHiddenWindow.deactivate();
        _Scene_Map_createDisplayObjects.call(this);
        this.addChild(this._fftfantt_TimerTextHiddenWindow);
    };

    //=============================================================================
    // Scene_Battle
    //  動的ピクチャ作成用の隠しウィンドウを追加定義します。
    //=============================================================================
    var _Scene_Battle_createDisplayObjects = Scene_Battle.prototype.createDisplayObjects;
    Scene_Battle.prototype.createDisplayObjects = function() {
        this._fftfantt_TimerTextHiddenWindow = new Window_Base(1,1,1,1);
        this._fftfantt_TimerTextHiddenWindow.hide();
        this._fftfantt_TimerTextHiddenWindow.deactivate();
        _Scene_Battle_createDisplayObjects.call(this);
        this.addChild(this._fftfantt_TimerTextHiddenWindow);
    };
    
  //=============================================================================
  // Game_Timer
  //  オリジナルタイマー用プロパティを追加定義します
  //=============================================================================
  Game_Timer.prototype.fftfantt_OriginalTimer_initialize = function() {
    this._fftfantt_OriginalTimer_Count = 0;
    this._fftfantt_OriginalTimer_Set = false;
    this._fftfantt_OriginalTimer_Run = false;
    this._fftfantt_OriginalTimer_Display = false;
    this._fftfantt_OriginalTimer_Timer_Type = '';
    this._fftfantt_OriginalTimer_Timer_Limit = 0;
    this._fftfantt_OriginalTimer_PctureId = 0;
    this._fftfantt_OriginalTimer_FontSize = 0;
    this._fftfantt_OriginalTimer_X = 0;
    this._fftfantt_OriginalTimer_Y = 0;
    this._fftfantt_OriginalTimer_Display_Mode = '';
    this._fftfantt_OriginalTimer_Timer_Text = '';
  };
  
  Game_Timer.prototype.fftfantt_OriginalTimer_updateBitmap = function() {
    if ($gameTimer !== null){
        if (!$gameTimer._fftfantt_OriginalTimer_Set) return;
    }

    var args = [];
    args[0] = '設定';
    args[1] = $gameTimer._fftfantt_OriginalTimer_Timer_Type;
    args[2] = $gameTimer._fftfantt_OriginalTimer_Timer_Limit;
    args[3] = $gameTimer._fftfantt_OriginalTimer_PctureId;
    args[4] = $gameTimer._fftfantt_OriginalTimer_FontSize;
    args[5] = $gameTimer._fftfantt_OriginalTimer_X;
    args[6] = $gameTimer._fftfantt_OriginalTimer_Y;
    args[7] = $gameTimer._fftfantt_OriginalTimer_Display_Mode;
    args[8] = $gameTimer._fftfantt_OriginalTimer_Timer_Text;
    timer_set(args);
    if (!$gameTimer._fftfantt_OriginalTimer_Run) return;
    clearInterval(OriginalTimer);
    OriginalTimer = setInterval(timer_run,count_unit);
  }
  
  var _Scene_Load_onLoadSuccess = Scene_Load.prototype.onLoadSuccess;
    Scene_Load.prototype.onLoadSuccess = function() {
    _Scene_Load_onLoadSuccess.call(this);
    Game_Timer.prototype.fftfantt_OriginalTimer_updateBitmap();
  };
  
})();