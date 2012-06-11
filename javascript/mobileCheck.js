function checkMobile() {
    Browser = {};

    var ua = navigator.userAgent.toLowerCase();
    Browser.isWebkit = ua.indexOf('applewebkit/') > -1;

    try {
        document.createEvent("TouchEvent");
        Browser.supportsTouch = true;
    } catch (e) {
        Browser.supportsTouch = false;
    }

    Browser.isAndroid = (ua.search('android') > -1);
    var iphone = (ua.search('iphone') > -1);
    Browser.isIphone = iphone && !((ua.search('ipad') > -1) || (ua.search('ipod') > -1));
    Browser.isIpad = (ua.search('ipad') > -1);
    Browser.isIpod = (ua.search('ipod') > -1);
    Browser.isXoom = (ua.search('xoom') > -1);
    Browser.isIE8 = (ua.search(/msie 8/i) > -1) || (ua.search(/msie 7/i) > -1);

    if (Browser.isIphone) {
        document.write('<link rel="Stylesheet" type="text/css" href="css/mobile.css" />'); 
    }
}
