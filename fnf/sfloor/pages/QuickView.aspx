<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quickview.aspx.cs" Inherits="sfloor_pages_quickview" %>
<%@ Import Namespace="MFO.Utils" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    

    <script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/lib/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/cloudzoom.js'></script>
    <link rel="stylesheet" type="text/css" href='<%=ConfigUtil.StaticPath() %>new-css/etalage.css'/>
        <link rel="stylesheet" type="text/css" href='<%=ConfigUtil.StaticPath() %>new-css/style.css'/>
    
    <script type="text/javascript">
        var staticPath = '<%=ConfigUtil.StaticPath() %>';
        var path = '<%=ConfigUtil.hostURL() %>';
        var serverPath = '<%=ConfigUtil.getServerPath() %>';
    </script>
    <script type="text/javascript">
        function reloadWL() {
            jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/ReloadWL.aspx' })
			.success(function (msg) {
			    window.top.jQuery("[name='WLContainer']").html(jQuery(msg).filter('#mini_cart_block').html());
			});
        }
        jQuery(document).ready(function () {
            jQuery("#size").val('');
            //maintain the popup at center of the page when browser resized
            jQuery("a[name='saveLater']").live('click', function () {
                var href = this;
                var sku1 = jQuery(this).attr('sku');
                var inner = jQuery(this).attr('inner')
                jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx?action=addFav', data: { sku: sku1} })
			        .success(function (msg) {
			            reloadWL();
			            jQuery("#wlNotificationInfo").show('slow');
                        if($(href).text()=="Add to wishlist")
                            $(href).text("Remove From Wishlist");
                        else
                            $(href).text("Add to wishlist");


			        });
            });
            jQuery("#viewWLLink").live("click", function () {
                window.top.location = '<%=ConfigUtil.hostURL()%>fav-items';
            });
            jQuery("[prev_item]").live("click", function () {
                var currentSeq = window.top.jQuery("ul[sku='" + jQuery(this).attr('prev_item') + "'] ").parents("[sequence]").attr('sequence');
                currentSeq = parseInt(currentSeq) - 1;
                var sku = window.top.jQuery("[sequence='" + currentSeq + "']").attr('sku');
                if (!sku)
                    sku = window.top.jQuery("[sequence]:last").attr('sku');
                window.location = path + "sfloor/pages/QuickView.aspx?sku=" + sku+"?quickview=true";


            });
            jQuery("[next_item]").live("click", function () {
                var currentSeq = window.top.jQuery("ul[sku='" + jQuery(this).attr('next_item') + "'] ").parents("[sequence]").attr('sequence');
                currentSeq = parseInt(currentSeq) + 1;
                var sku = window.top.jQuery("[sequence='" + currentSeq + "']").attr('sku');
                if (!sku)
                    sku = window.top.jQuery("[sequence]:first").attr('sku');
                window.location = path + "sfloor/pages/QuickView.aspx?sku=" + sku;

            });
        });
        CloudZoom.quickStart();
        function selectSize(txt) {
            var size = jQuery(txt).attr("size");
            jQuery.ajax({
                type: "get",
                url: "<%=ConfigUtil.hostURL()%>sfloor/pages/QuickView.aspx?sku="+ jQuery(txt).attr("sku"),
                success: function (data) {
                    jQuery("#quick-details-content").html(jQuery(data).find("#quick-details-content").html());
                    jQuery("li[namespace='sizeBtn']").css({ 'background-color': '#EBEBEB', 'color': 'black' })
                    jQuery("li[namespace = 'sizeBtn'][size='" + size + "']").css({ 'background-color': '#464646', 'color': 'white' });
                    jQuery("#size").val(jQuery(txt).attr("size"));
                },
                error: function (result) {
                    alert("Error......");
                }
            });
             
        }
        function addtoCart() {
            if (jQuery('#isSize').val() == 'true' && jQuery('#size').val().trim().length == 0) {
                jQuery('#errorSize').css('display', 'block').text('Please select the varient');
                jQuery("#sizeDIV").css("border", "2px solid red");
            } else {
                var data = {
                    sku: jQuery('#style').val(),
                    qty: jQuery("#dd_quantity option:selected").val(),
                    color: "",
                    size: jQuery("#size").val(),
                    isColor: false,
                    isSize: jQuery("#isSize").val(),
                    isSku: jQuery("#isSku").val()
                }
                jQuery.ajax({
                    type: "get",
                    contentType: "application/json; charset=utf-8",
                    url: "<%=ConfigUtil.hostURL()%>sfloor/pages/AjaxService.aspx?action=addToCart",
                    data:data,
                    success: function (msg) {
                        if (msg.error != null) { 
                            jQuery('#errorSize').css('display', 'block').text(msg.error);
                        } else {
                            window.top.location = '<%=ConfigUtil.hostURL()%>Add-To-Cart'
                           // window.location = '<%=ConfigUtil.hostURL()%>Add-To-Cart?type=quickview'

                        }
                    },
                    error: function (result) {
                        alert("Error......");
                    }
                });
            }
        }
    </script>
 
		</head>
	<body>
    
<div class="quickview-content">
	<div id="quick-details-image">

	         <%if (!MFO.Utils.StringUtil.isNullOrEmpty((dt.Rows[0]["PathInternaldetailsZoomImage"] + "")))
              { %>
                <img class='cloudzoom-quick' src='<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathInternaldetailsZoomImage"] %>' data-cloudzoom="zoomImage: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathInternaldetailsZoomImage"] %>'" /> <br />
                <img class='cloudzoom-gallery ' src='<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathInternaldetailsZoomImage"] %>' data-cloudzoom="useZoom: '.cloudzoom-quick', image: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathInternaldetailsZoomImage"] %>', zoomImage: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathInternaldetailsZoomImage"] %>' ">
            <%} %>

            <%if (!StringUtil.isNullOrEmpty(dt.Rows[0]["PathUpperInternaldetailsSmallImage"] + "")){ %>
                <img class='cloudzoom-gallery ' src='<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathUpperInternaldetailsSmallImage"] %>' data-cloudzoom="useZoom: '.cloudzoom-quick', image: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathUpperInternaldetailsZoomImage"] %>', zoomImage: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathUpperInternaldetailsZoomImage"] %>' ">
            <%} %>

            <%if (!StringUtil.isNullOrEmpty(dt.Rows[0]["PathLowerInternaldetailsSmallImage"] + "")) {%>
                <img class='cloudzoom-gallery' src='<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathLowerInternaldetailsSmallImage"] %>' data-cloudzoom="useZoom: '.cloudzoom-quick', image: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathLowerInternaldetailsZoomImage"] %>', zoomImage: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathLowerInternaldetailsZoomImage"] %>' ">
            <%} %>

            <%if (!StringUtil.isNullOrEmpty(dt.Rows[0]["PathBackInternaldetailsSmallImage"] + "")) {%>
                <img class='cloudzoom-gallery' src='<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathBackInternaldetailsSmallImage"] %>' data-cloudzoom="useZoom: '.cloudzoom-quick', image: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathBackInternaldetailsZoomImage"] %>', zoomImage: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathBackInternaldetailsZoomImage"] %>' ">
            <%} %>
            </div>
   
            <div id="quick-details-content"> <div id="description">
	        <div class="prevnext">
                       <a href="#" class="previous" title="Previous Product" prev_item='<%=dt.Rows[0]["SKUCode"] %>'> <i class="prev-i"></i><span>Previous</span></a>
                        <a href="#" class="next" title="Next Product" next_item='<%=dt.Rows[0]["SKUCode"] %>'><span>Next</span><i class="next-i"></i></a>
            </div>	    
             <h1><%=(string)dt.Rows[0]["SKUName"] %></h1>
			<div class="quick-priceqty">
			<div class="quick-price">
			<div  class="discount">
                <%float disc = StringUtil.getDiscount(dt.Rows[0]["MRP"] + "", dt.Rows[0]["SpecialPrice"] + "");
                         if (disc>0){%>
                        <div class="discount">
                           <span>Discount: </span><span>Rs. <%=disc%></span>
                        </div>
                        <%} %>
            </div>
			<div  class="oldprice"><span>Rs. </span><span class="cut"><%=dt.Rows[0]["MRP"]+"" %></span></div>
			<div  class="rs"><span>Rs. </span><span><%=dt.Rows[0]["SpecialPrice"]+""%></span></div>
			<div  class="avl"> <span>Availability:</span><span class="instock"><%=avalibilty%> &nbsp;&nbsp;
                       
            </span></div>
            <div  class="avl"><span>SKU:</span><span class="instock"><%=(string)dt.Rows[0]["SKUCode"]%></span></div>

            </div>
			
            <%if (inventory != null && inventory > 0)
               {%>
			<div class="addtocart_qty-quick">
			<label for="qty">Quantity :</label>
        <div class="qty-container">
           <select id='dd_quantity'>
                <%for (int i = 1; i <= inventory; i++){ %>
                    <option value='<%=i %>'> <%=i %> </option>
                <%} %>
            </select>
        </div>
		
		<div><input type="button" onclick="addtoCart()" title="Add  to cart" value="BUY NOW" class="addtocartbtn">
		</div>
			</div>
			</div>
			<%}%>
                
            <%if ("true".Equals(isSize))
              { %>
			<div class="quick-size" id="sizeDIV">Also Avaliavel in these varient:
			<span id='errorSize' style='color:red;display:none'>Please select the varient</span>
             <ul>
                <%for (int i = 0; i < sizeDT.Rows.Count; i++)
                  { %>
                    <li namespace='sizeBtn' onclick="selectSize(this)" sku="<%=sizeDT.Rows[i]["SKUCode"] %>" size='<%=sizeDT.Rows[i]["Size"] %>'><%=sizeDT.Rows[i]["Size"] %><%=sizeDT.Rows[i]["SizeDataType"]%> </li>
                 <%} %>   
                </ul>
			</div>
            <%} %>  
         <%--   <%if ("true".Equals(isColor)) {%> 
			<div class="quick-color">
            <div class="avl">
               <span>Color:</span><span class="avlcolor"><%=(string)colorDT.Rows[0]["Color"]%></span></div>
                Also available in these colors:
              <ul>
                   <%for (int i = 0; i < colorDT.Rows.Count; i++)
                  { %>
                    <li>
                        <a href='<%=ConfigUtil.hostURL()%>sfloor/pages/QuickView.aspx?sku=<%=colorDT.Rows[i]["SKUCode"] %>'>  
                            <img style='height:60px;width:50px;' src='<%=ConfigUtil.getServerPath()%><%=colorDT.Rows[i]["PathInternaldetailsSmallImage"] %>'/>
                        </a>
                    </li>
                 <%} %>   
                </ul>
            </div>
            <%} %>
		--%>	    <div class="wishlist" style="clear:both">

                     <%if (SFloor.DAO.FavDAO.isItemExist(Session.SessionID, dt.Rows[0]["SKUCode"] + ""))
                       {%>
                         <a href="javascript:void(0);" class="removewishlist-cat" title="remove from wishlist" name='saveLater' sku="<%=dt.Rows[0]["SKUCode"] %>">remove from wishlist</a>
                    <%}
                       else
                       { %>
                          <a href="javascript:void(0);" class="addwishlist-cat" title="add to wishlist" name='saveLater' sku="<%=dt.Rows[0]["SKUCode"] %>">add to wishlist</a>
                    <%} %>

                  </div>
            
                <div>
                    <p id="wlNotificationInfo" style="color: Green; display: none;">
                        <small> <a href="#" id="viewWLLink">click here to view
                            WishList</a></small></p>
                </div>
        <input type="hidden" id='style' value='<%=style%>' />
        <input type="hidden" id='color' value='<%=color%>' />
        <input type="hidden" id='isColor' value='<%=isColor%>' />
        <input type="hidden" id='size' value='' />
        <input type="hidden" id='isSku' value='<%=isSku%>' />
        <input type="hidden" id='isSize' value='<%=isSize%>' />
        	
  </div></div>

  </div>
        
    </body>
</html>
