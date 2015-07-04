<%@ Page Language="C#" CodeFile="AddToCart.aspx.cs"
   Inherits="sfloor_pages_AddToCart"%>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
   <head>
      <%=Head %>
      <meta http-equiv="Expires" content="0"/>
      <meta http-equiv="Cache-Control" content="no-cache"/>
      <meta http-equiv="Pragma" content="no-cache"/>


      <script type="text/javascript">
         
          jQuery(document).ready(function () {
              jQuery.each(jQuery('select[qty]'), function () {
                  var selct = this;
                  jQuery(this).find("option[value='" + jQuery(selct).attr('qty') + "']").attr('selected', 'selected');
              });
              jQuery("select").on('change', function () {
                  var sku = jQuery(this).attr('sku');
                  var qty = jQuery(this).find('option:selected').val();
                  jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx?action=updateQty', data: { sku: sku, qty: qty } })
         .success(function (msg) {
             var json = msg; //JSON.parse(msg);
             if (json.error != null) {
                 jQuery("span[name='error'][sku='" + sku + "']").text(json.error);
             } else {
                 jQuery("[name='subTotal'][sku='" + sku + "']").text(json.subTotal);
                 jQuery("[name='gTotal']").text(json.total);
                 reloadCart();
             }
         });
              });
              jQuery("[removefromWL]").on("click", function () {
                  var sku = jQuery(this).attr('removefromWL')
                  jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx?action=removeFromCart', data: { sku: sku } })
                    .success(function (msg) {
                        if (jQuery('.cartitem').length == 1) {
                            jQuery('.addtocartmain').html("<center><p style='color:red'>Your Cart Is Empty!!!<p></center>")
                        } else {
                            jQuery('div[sku="' + sku + '"]').remove();
                        }
                        jQuery("[name='cartContainer']").html(jQuery(msg).filter('#mini_cart_block').html());;
                    });
              });
              jQuery("[type='checkout']").on("click", function () {
                  jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx?action=checkInventory' })
         .success(function (json) {
             if (json.length > 0) {
                 for (i = 0; i < json.length; i++)
                     jQuery("span[name='error'][sku='" + json[i].sku + "']").text(json[i].error);
             } else {
                 window.location = path + 'check-out';
             }
         });
              });
          });
      </script>
   </head>
   <body>
   <%if (Request.Params["type"] != "quickview")
     {%>
            <%=Header%> <!-- start end-->
            
          <%}
     else
     {%>
          <link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/style.css" />
        <link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/megamenu.css" />

        <link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/etalage.css" />
        <link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/bootstrap.css" />


        <script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/lib/jquery-ui.min.js"></script>
        <script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/jquery.etalage.min.js"></script>
        <script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/jquery.jscrollpane.min.js"></script>
        <script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/megamenu.js"></script>
        <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>

        <script type="text/javascript">    jQuery(document).ready(function () { jQuery(".megamenu").megamenu(); });</script>
        <a href="javascript:void(0)" onclick="window.history.back()">Back</a>

<%} %> 
             
<div class="container">
<div class="main addtocartmain">

         <%if (!MFO.Commom.CommonUtil.DT.isEmptyOrNull(cartDT))
           {%> <!--start loop--> <%for (int i = 0; i < cartDT.Rows.Count; i++)
                                   { %>
	
    <div class="shoping_bag1 cartitem"  sku='<%=cartDT.Rows[i]["SKU"]%>'>
		<div class="shoping_left">
			<div class="shoping1_of_1">
				<img  src="<%=ConfigUtil.getServerPath() %><%=cartDT.Rows[i]["PathInternaldetailsSmallImage"] %>" class="img-responsive" alt="" />
			</div>
			<div class="shoping1_of_2" >
                <h5><%=cartDT.Rows[i]["SKUBrand"]%></h5>
				<h4><a href="#"><%=cartDT.Rows[i]["SKUName"]%></a> </h4>
                
                <h4>Rs. : <%=cartDT.Rows[i]["UNIT_PRICE"]%>/Unit</h4>
                <h6> <%if (!MFO.Utils.StringUtil.isNullOrEmpty(cartDT.Rows[i]["Color"] + ""))
                       {%> <span>Color:</span><em><%=cartDT.Rows[i]["Color"]%></em>
                              <%} %> <%if (!MFO.Utils.StringUtil.isNullOrEmpty(cartDT.Rows[i]["Size"] + ""))
                                 {%> <span>Size:</span><em><%=cartDT.Rows[i]["Size"]%></em>
                              <%} %> <% string status = MFO.Utils.StringUtil.checkInventrory(cartDT.Rows[i]["Inventory"] + "", cartDT.Rows[i]["QTY"] + ""); %>
                              <% if (status == "available")
                                 {%> <span>Quantity:</span>
                              <em>
                                 <select
                                    qty='<%=cartDT.Rows[i]["QTY"]%>' sku='<%=cartDT.Rows[i]["SKU"]%>'>
                                    <%for (int j = 1; j <= float.Parse(cartDT.Rows[i]["Inventory"] + ""); j++)
                                       {%>
                                    <option value='<%=j %>'><%=j%></option>
                                    <%} %>
                                 </select>
                                 <span name='error' sku='<%=cartDT.Rows[i]["SKU"]%>'></span> 
                              </em>
                              <%}
                                 else if (status == "Sold Out")
                                 {%> <span style='color: red'> Oops!!
                              Sorry, this items is sold out<//span> <em> <span style='color: Green'>
                              We will notifiy you as soon as this item will available. </span> <span
                                 style='color: red'> You need to remove this item from cart if
                              wish to checkout</span> </em> <%}
                                 else
                                 { %> <span>Quantity:</span>
                              <em>
                                 <select ng-change='changeQty()' sku='<%=cartDT.Rows[i]["SKU"]%>'>
                                    <option value='' selected>--Select--</option>
                                    <%for (int j = 1; j <= float.Parse(cartDT.Rows[i]["Inventory"] + ""); j++)
                                      {%>
                                    <option value='<%=j %>'><%=j%></option>
                                    <%} %>
                                 </select>
                                 <span name='error' sku='<%=cartDT.Rows[i]["SKU"]%>'></span> 
                              </em>
                              <% }%>
                    </h6>   
                <span>SKU : <b><%=cartDT.Rows[i]["SKU"]%></b></span><br />
			<%--	<span>size <b>xl</b>&nbsp;&nbsp; qty <b>1</b> | code :1175</span>--%>
                <span>Return Policy : <%=cartDT.Rows[0]["ShippingReturns"]%></span>
				<ul class="s_icons">
					<%--<li><a href="#"><img src="<%=ConfigUtil.StaticPath() %>images/s_icon1.png" alt=""></a></li>--%>
					<li><a class="cartwishlist" href="#" name='saveLater' sku="<%=cartDT.Rows[i]["SKU"] %>"><img src="<%=ConfigUtil.StaticPath() %>new-images/icon-addtowishlist.png" alt=""></a></li>
					<li><a href="#" removefromWL='<%=cartDT.Rows[i]["SKU"]%>'><img src="<%=ConfigUtil.StaticPath() %>new-images/s_icon3.png" alt=""></a></li>
				</ul>
			</div>
			<div class="clearfix"></div>
		</div>
		<div class="shoping_right">
			<p class="tot">Sub Total Rs.&nbsp;<span name='subTotal'  sku='<%=cartDT.Rows[i]["SKU"]%>'><%=cartDT.Rows[i]["TOTAL"]%></span>
              </p>
		</div>
		<div class="clearfix"></div>
	</div>
    
      <%} %> <!--end loop-->

<%--	<div class="shoping_bag1">
		<div class="shoping_left">
			<h2><a href="#"><img src="images/gift.jpg">gift wrap </a> <span> for rs. 25</span></h2>
		</div>
		<div class="shoping_right">
			<p>sub total &nbsp;<span> Rs. 1,899</span></p>
			<p>vat collected &nbsp;<span> Rs. 91</span></p>
			<p>delivery &nbsp;<a href="#">free</a>&nbsp;<span> Rs. 0</span></p>
		</div>
		<div class="clearfix"></div>
	</div>--%>
<%--	<div class="shoping_bag1">
		<div class="shoping_left">
			<h2><a href="#"><img src="<%=ConfigUtil.StaticPath() %>images/login.jpg">login </a> <span> to apply coupons</span></h2>
		</div>
		<div class="shoping_right">
			<p>coupon discount &nbsp;<span class="color"> Rs. 0</span></p>
		</div>
		<div class="clearfix"></div>
	</div>--%>
	<div class="shoping_bag2">
		<div class="shoping_left">
            <a class="btn1" name="cnt_toshop"  href="<%=ConfigUtil.hostURL() %>">CONTINUE SHOPPING</a>
			 <a class="btn1" name="pcd_tochk" type='checkout' href="javascript:void(0)">ORDER NOW</a>
            
		</div>
		<div class="shoping_right">
             	<p class="tot">total rs.&nbsp;<span name='gTotal' class="grandtot"><%=total%></span></p>
		</div>
		<div class="clearfix"></div>
	</div>
                <%}
           else
           { %>
                     <p style='color: red'>Your Cart is Empty!!</p>
                  <%} %>
</div>
</div>
     
     <%if (Request.Params["type"] != "quickview")
     {%>
                      <%=Footer %> 
<!-- start end-->
            
          <%} %> 
   </body>
</html>