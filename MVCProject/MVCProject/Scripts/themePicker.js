function onReady(callback) {
    var intervalID = window.setInterval(checkReady, 1000);

    function checkReady() {
        if (document.getElementsByTagName('body')[0] !== undefined) {
            window.clearInterval(intervalID);
            callback.call(this);
        }
    }
}

function show(id, value) {
    document.getElementById(id).style.display = value ? 'block' : 'none';
}

onReady(function () {
    show('page', true);
    show('loading', false);
});

var themes = {
    "default": "/Content/bootstrap.css",
    "cerulean": "/Styles/cerulean.css",
    "cosmo": "/Styles/cosmo.css",
    "cyborg": "/Styles/cyborg.css",
    "flatly": "/Styles/flatly.css",
    "journal": "/Styles/journal.css",
    "readable": "/Styles/readable.css",
    "simplex": "/Styles/simplex.css",
    "slate": "/Styles/slate.css",
    "spacelab": "/Styles/spacelab.css",
    "united": "/Styles/united.css"
};

var themesheet = $('<link href="' + themes['default'] + '" rel="stylesheet" />');
themesheet.appendTo('head');

$(function () {

    $('.theme-link').click(function () {
        var themeurl = themes[$(this).attr('data-theme')];
        themesheet.attr('href', themeurl);

        var d = new Date();
        d.setTime(d.getTime() + (30 * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toGMTString();
        document.cookie = "theme =" + $(this).attr('data-theme') + "; " + expires;

    });
});

function getCookieTheme(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function checkCookieTheme() {
    var theme = getCookieTheme("theme");
    if (theme != "") {
        var themeurl = themes[theme];
        themesheet.attr('href', themeurl);
    } else {
        var d = new Date();
        d.setTime(d.getTime() + (30 * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toGMTString();
        document.cookie = "theme = default; " + expires;
    }
}