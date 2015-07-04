<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CheckoutHeader.ascx.cs" Inherits="sfloor_pages_CheckoutHeader" %>
 
     <script type="text/javascript">
         var staticPath = '<%=ConfigUtil.StaticPath() %>';
         var path = '<%=ConfigUtil.hostURL() %>';
         var serverPath = '<%=ConfigUtil.getServerPath() %>';
    </script>
    <script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/lib/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/lib/angular.js'></script>
    <script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/menu.js'></script>
    <script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/common1.js"></script>
    <link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/checkoutpage_n.css" />
    <link type="text/css" rel="stylesheet" href='<%=ConfigUtil.StaticPath() %>new-css/login-forms.css' />
    <script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/lib/jquery-ui.min.js"></script>
	<link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/jquery-ui.css?v=10002"/>
    
<link rel="icon" href="http://admin.shoppersfloor.com/FnF/new-images/menulogo.png" type="image/x-icon"/>
    <style type="text/css">
		ul li:hover
		{
		    background-color:#ef6910;
		}
	</style>
<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-63595322-1', 'auto');
    ga('send', 'pageview');

</script>
        <header><div class="ckeckoutmain_sec" id="header">
        <div class="logo">
        <a href="<%=ConfigUtil.hostURL() %>Home"><img src="<%=ConfigUtil.StaticPath() %>new-images/newlogo.png"></a></diV>
        <a href='<%=ConfigUtil.hostURL() %>Home' class="btn_shipinfo bck_to_shp">Back to shop</a>

        <div>
    </div>
    </div>
 </header>