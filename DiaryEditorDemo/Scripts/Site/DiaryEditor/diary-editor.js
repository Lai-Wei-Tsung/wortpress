/**
 * 注意事項：
 * 1. config中的inline有編輯器的BUG，必須同時設成 'inline:false' 或是一個true一個false，才能夠正確載入自訂插件'cover'
 */
 tinymce.PluginManager.add('cover', function (editor, currentUrl) {
    
    editor.on('init', function () {
        tinymce.activeEditor.formatter.register('cover', {
            inline: 'cover'
        });
    });

    editor.ui.registry.addToggleButton('cover', {
        // text: '機敏文字',
        icon: 'lock',
        tooltip: '選取字段，將其設定為機敏文字',
        onAction: function (_) {
            editor.execCommand('mceToggleFormat', false, 'cover');
        },
        onSetup: function (api) {
            editor.formatter.formatChanged('cover', function (state) {
                api.setActive(state);
            });
        },
    });
});

var baseConfig = {
    language: 'zh_TW',
    menubar: false,
    plugins: [
        'code', //debug用
        'autoresize',
        'paste',
        'cover',
    ],
    autoresize_bottom_margin: 0,
    toolbar: ['cover code'],/*'code' debug用*/
    paste_as_text: true, // 純文字貼上
    entity_encoding: 'raw', // 禁用 &nbsp;
    invalid_elements: "p,span,div,br,strong,b,i,u,em,table,tr,td,th,thead,tfoot,tbody,h1,h2,h3,h4,h5,img", // 禁用所有 hteml tag
    forced_root_block: false, // 禁用外層自動套用 p span
    force_br_newlines: false,
    custom_elements: "~cover", // 註冊自定義 tag
    branding: false, // 隱藏底欄的商標
    elementpath: false, // 隱藏底欄的元素路徑
    content_style: 'cover{border-style: dotted; border-width: 2px; border-color: red;}', // 編輯器自訂 css
}

var eventConfig = {
    ...baseConfig,
    selector: '#diaryEvent',
    // inline: true,
    setup: function (editor) {
        editor.on('keyDown', function (event) {
            // 改寫 Enter、Tab 事件：不允許換行及縮排
            if (event.keyCode == 13 || event.keyCode == 9) {
                tinymce.dom.Event.cancel(event);
                return;
            }
        });
        editor.on('keyUp change', function (event) {
            // 即時預覽
            changeDisplayEvent();
        });
    },
}

var contentConfig = {
    ...baseConfig,
    selector: '#diaryContent',
    // inline: false,
    setup: function (editor) {
        editor.on('keyDown', function (event) {
            // 改寫 Enter、Tab 事件：不允許換行及縮排
            if (event.keyCode == 13 || event.keyCode == 9) {
                tinymce.dom.Event.cancel(event);
                return;
            }
        });
        editor.on('keyUp change', function (event) {
            // 即時預覽
            changeDisplayContent();
        });
    },
}

tinymce.init(eventConfig);
tinymce.init(contentConfig);