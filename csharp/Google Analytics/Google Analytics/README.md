*** Google Analytics - from the server side!

**** Queue up events anywhere in your asp.net code like this:
GoogleAnalytics.PushEvent("Login","Facebook");

**** Then in your view you ouput calls like so:
@GoogleAnalytics.OutputEvents()
