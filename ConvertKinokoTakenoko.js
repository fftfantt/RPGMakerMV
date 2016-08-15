//=============================================================================
// ConvertKinokoTakenoko
// ----------------------------------------------------------------------------
// Copyright (c) 2016 fftfantt
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php
// ----------------------------------------------------------------------------
// Version
// 1.0.0 2016/8/15 初版
// ----------------------------------------------------------------------------
// [HomePage]: https://googledrive.com/host/0BxiSZT-B8lvFOUFhVTF6VjNnUGc/index.html 
// [Twitter] : https://twitter.com/fftfantt/
// [GitHub]  : https://github.com/fftfantt/
//=============================================================================
/*:
 *
 * @plugindesc 文章中の「きのこ」を「たけのこ」に変換します。
 * @help
 *
 * ■説明
 *  このプラグインは、文章の表示やシステムメッセージなどあらゆる場面での「きのこ」
 *  を「たけのこ」に「きのこの山」を「たけのこの里」に変換します。
 * 
 * ■使い方
 *  プラグインを適用するだけでご使用できます。
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

    //=============================================================================
    // Game_Message
    // きのこからたけのこへの変換を追加定義します。
    //=============================================================================
    var _Game_Message_prototype_add = Game_Message.prototype.add
    Game_Message.prototype.add = function (text) {
        text = convertKinokoTakenoko(text);
        _Game_Message_prototype_add.call(this, text);
    };

    //=============================================================================
    // ConvertKinokoTakenoko
    // きのこからたけのこへの変換の実装部分です。
    //=============================================================================
    var convertKinokoTakenoko = function (text) {

        var dm = '';

        text = text.replace(/きのこの山/ig, 'たけのこの里');
        text = text.replace(/キノコの山/i, 'タケノコの里');
        text = text.replace(/ｷﾉｺの山/i, 'ﾀｹﾉｺの里');
        text = text.replace(/きのこ/i, 'たけのこ');
        text = text.replace(/キノコ/i, 'タケノコ');
        text = text.replace(/ｷﾉｺ/i, 'ﾀｹﾉｺ');
        text = text.replace(/kinoko/i, 'Takenoko');

        dm = sarchKinoko(text.match(/(き)(.)(の)(.)(こ)(.)(の)(.)(山)/i));
        text = (dm !== null) ?
            text.replace('き' + dm + 'の' + dm + 'こ' + dm + 'の' + dm + '山',
                'た' + dm + 'け' + dm + 'の' + dm + 'こ' + dm + 'の' + dm + '里') : text;

        dm = sarchKinoko(text.match(/(キ)(.)(ノ)(.)(コ)(.)(の)(.)(山)/i));
        text = (dm !== null) ?
            text.replace('キ' + dm + 'ノ' + dm + 'コ' + dm + 'の' + dm + '山',
                'タ' + dm + 'ケ' + dm + 'ノ' + dm + 'コ' + dm + 'の' + dm + '里') : text;

        dm = sarchKinoko(text.match(/(ｷ)(.)(ﾉ)(.)(ｺ)(.)(の)(.)(山)/i));
        text = (dm !== null) ?
            text.replace('ｷ' + dm + 'ﾉ' + dm + 'ｺ' + dm + 'の' + dm + '山',
                'ﾀ' + dm + 'ｹ' + dm + 'ﾉ' + dm + 'ｺ' + dm + 'の' + dm + '里') : text;

        dm = sarchKinoko(text.match(/(き)(.)(の)(.)(こ)/i))
        text = (dm !== null) ?
            text.replace('き' + dm + 'の' + dm + 'こ',
                'た' + dm + 'け' + dm + 'の' + dm + 'こ') : text;

        dm = sarchKinoko(text.match(/(キ)(.)(ノ)(.)(コ)/i));
        text = (dm !== null) ?
            text.replace('キ' + dm + 'ノ' + dm + 'コ',
                'タ' + dm + 'ケ' + dm + 'ノ' + dm + 'コ') : text;

        dm = sarchKinoko(text.match(/(ｷ)(.)(ﾉ)(.)(ｺ)/i));
        text = (dm !== null) ?
            text.replace('ｷ' + dm + 'ﾉ' + dm + 'ｺ',
                'ﾀ' + dm + 'ｹ' + dm + 'ﾉ' + dm + 'ｺ') : text;

        dm = sarchKinoko(text.match(/(k)(.)(i)(.)(n)(.)(o)(.)(k)(.)(o)/i));
        text = (dm !== null) ?
            text.replace('k' + dm + 'i' + dm + 'n' + dm + 'o' + dm + 'k' + dm + 'o',
                'T' + dm + 'a' + dm + 'k' + dm + 'e' + dm + 'n' + dm + 'o' + dm + 'k' + dm + 'o') : text;

        return text;

    }

    var sarchKinoko = function (text) {
        if (text == null) return null;
        var delimiterKinoko = text[2];
        for (var i = 1; i < text.length; i++) {
            if ((i % 2) !== 0 && text[i] === null) return null;
            if ((i % 2) === 0 && delimiterKinoko !== text[i]) return null;
        }
        return delimiterKinoko;
    };

})();