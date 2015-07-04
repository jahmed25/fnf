<%@ Page Language="C#"  CodeFile="CatDetails.aspx.cs" Inherits="sfloor_CatDetails" %>
<%@ Import Namespace="MFO.Utils" %>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
   <head>
      <%=Head %>
	  <style>
		#recent-product .owl-stage{height:20%}
	  </style>
      <!-- start end-->
      <link rel="stylesheet" type="text/css" href='<%=ConfigUtil.StaticPath() %>new-css/etalage.css'>
      <link href='<%=ConfigUtil.StaticPath() %>new-css/internalpage.css' rel="stylesheet" type="text/css" />
      <script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/cloudzoom.js'></script>
       <script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/lib/easing.js'></script>
 <%--     <script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/lib/olive-horizontal-slider.js'></script>
 --%>
     
      <script type="text/javascript">
          CloudZoom.quickStart();
          function selectSize(txt) {
              var size = jQuery(txt).attr("size");
              jQuery.ajax({
                  type: "get",
                  url: "<%=ConfigUtil.hostURL()%>?htm=" + jQuery(txt).attr("sku"),
                  success: function (data) {
                     // alert(jQuery(data).find("#description").html());
                      jQuery("#description").html(jQuery(data).find("#description").html());
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
                  return;
              }
              var data = {
                  sku: jQuery('#style').val(),
                  qty: jQuery("#dd_quantity option:selected").val(),
                  color: jQuery("#color").val(),
                  size: jQuery("#size").val(),
                  isColor: jQuery("#isColor").val(),
                  isSize: jQuery("#isSize").val(),
                  isSku: jQuery("#isSku").val()
              }
              jQuery.ajax({
                  type: "get",
                  contentType: "application/json; charset=utf-8",
                  url: "<%=ConfigUtil.hostURL()%>sfloor/pages/AjaxService.aspx?action=addToCart",
                  data: data,
                  success: function (data) {
                      if (data.error != null) {
                          jQuery('#errorSize').css('display', 'block').text(data.error);
                      } else {
                          window.location = '<%=ConfigUtil.hostURL()%>Add-To-Cart'
                      }
                  },
                  error: function (result) {
                      alert("Error......");
                  }
              });
          }
    
          jQuery(document).ready(function () {

              if (jQuery('#crumb4').text().trim().length == 0) {
                  jQuery('#crumb4').css('display', 'none');
              }
              else {
                  jQuery('#crumb4').css('display', 'block');
              }
          });

          jQuery(document).ready(function () { initTabs(); });
          function initTabs() {
              jQuery('#tabMenu a').bind('click', function (e) {
                  e.preventDefault();
                  var thref = jQuery(this).attr("href").replace(/#/, '');
                  jQuery('#tabMenu a').removeClass('active');
                  jQuery(this).addClass('active');
                  jQuery('#tabContent div.content').removeClass('active');
                  jQuery('#' + thref).addClass('active');
              });
          }
          var $kk = jQuery.noConflict();
          $kk(document).ready(function () {
              $kk('#recent-product').owlCarousel({
                  loop: true,
                  margin: 15,
                  responsive: {
                      0: {
                          items: 1
                      },
                      600: {
                          items: 3
                      },
                      1000: {
                          items: 7
                      }
                  }
              });
              $kk('#related-product').owlCarousel({
                  loop: true,
                  margin: 15,
                  responsive: {
                      0: {
                          items: 1
                      },
                      600: {
                          items: 3
                      },
                      1000: {
                          items: 7
                      }
                  }
              });
              jQuery('.aboutproduct > .single-bottom1 h6').click(function () {
                  jQuery('.aboutproduct > .single-bottom1 .prod-desc').slideUp();
                  jQuery(this).next().slideToggle();
              });
              jQuery('.fb_like').hide();
              jQuery('.share').click(function (e) {
                  jQuery('.fb_like').slideToggle();
                  e.stopPropagation();
              });
              jQuery('body,html').click(function () {
                  jQuery('.fb_like').slideUp();
              });
              
          });
          </script>
   </head>
   <body>
   
            <%=Header %>

       <div class="container">
           
               <div class="right_inner_categorydetailssortby">
                  <div class="bradcrumbs-contain">
                     <div class="breadcrumbs" id="crumbs">
                        <ul>
                           <li id="crumb1"><a  href='<%=ConfigUtil.hostURL() %>Home'> Home </a></li>
                           <li id="crumb2"><span></span><a id='catNav' href='<%=ConfigUtil.hostURL() + StringUtil.urlEncode(dt.Rows[0]["SKUCategory"]+"")%>'> <%=dt.Rows[0]["SKUCategory"]%> </a></li>
                           <li id="crumb3"><span></span><a id='subCatNav' href='<%=ConfigUtil.hostURL() + StringUtil.urlEncode(dt.Rows[0]["SKUCategory"]+"")%>/<%=StringUtil.urlEncode(dt.Rows[0]["SKUCategoryType"]+"")%>'> <%=dt.Rows[0]["SKUCategoryType"]%>  </a></li>
                           <li id="crumb4"><span></span><a id='pTypeNav' href='<%=ConfigUtil.hostURL() + StringUtil.urlEncode(dt.Rows[0]["SKUCategory"]+"")%>/<%=StringUtil.urlEncode(dt.Rows[0]["SKUCategoryType"]+"")%>/<%=StringUtil.urlEncode(dt.Rows[0]["SKUProductType"]+"")%>'> <%=dt.Rows[0]["SKUProductType"]%> </a></li>
                        </ul>
                     </div>
                  </div>
               </div>
<div class="women_main">

	<!-- start content -->
			<div class="row single">
				<div class="col-md-12">
				  <div class="single_left">
					<div class="grid images_3_of_2">
				
                           <div id="details-image">
                  <%if (!StringUtil.isNullOrEmpty((dt.Rows[0]["PathInternaldetailsZoomImage"] + "")))
                    { %>
                  <img class="cloudzoom" src='<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathInternaldetailsHoverImage"] %>' data-cloudzoom="zoomImage: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathInternaldetailsZoomImage"] %>'" /> <br />
                  <img class='cloudzoom-gallery' src='<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathInternaldetailsHoverImage"] %>' data-cloudzoom="useZoom: '.cloudzoom', image: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathInternaldetailsZoomImage"] %>', zoomImage: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathInternaldetailsZoomImage"] %>' ">
                  <%} %>
                  <%if (!StringUtil.isNullOrEmpty(dt.Rows[0]["PathUpperInternaldetailsSmallImage"] + ""))
                    { %>
                  <img class='cloudzoom-gallery' src='<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathUpperInternaldetailsHoverImage"] %>' data-cloudzoom="useZoom: '.cloudzoom', image: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathUpperInternaldetailsZoomImage"] %>', zoomImage: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathUpperInternaldetailsZoomImage"] %>' ">
                  <%} %>
                  <%if (!StringUtil.isNullOrEmpty(dt.Rows[0]["PathLowerInternaldetailsSmallImage"] + ""))
                    {%>
                  <img class='cloudzoom-gallery' src='<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathLowerInternaldetailsHoverImage"] %>' data-cloudzoom="useZoom: '.cloudzoom', image: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathLowerInternaldetailsZoomImage"] %>', zoomImage: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathLowerInternaldetailsZoomImage"] %>' ">
                  <%} %>
                  <%if (!StringUtil.isNullOrEmpty(dt.Rows[0]["PathBackInternaldetailsSmallImage"] + ""))
                    {%>
                  <img class='cloudzoom-gallery' src='<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathBackInternaldetailsHoverImage"] %>' data-cloudzoom="useZoom: '.cloudzoom', image: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathBackInternaldetailsZoomImage"] %>', zoomImage: '<%=ConfigUtil.getServerPath() %><%=(string)dt.Rows[0]["PathBackInternaldetailsZoomImage"] %>' ">
                  <%} %>
               </div>
						 <div class="clearfix"></div>		
				  </div>
				  <div class="desc1 span_3_of_2">
			    <div id="description">
                    <div class="prevnext">
                       <a class="previous" title="Previous Product" href='<%=ConfigUtil.hostURL() %><%=StringUtil.urlEncode(dt.Rows[0]["SKUName"]+"") %>?htm=<%=Request.Params["htm"]%>&action=prev&index=<%=index-1%>'> <i class="prev-i"></i><span>Previous</span></a>
                        <a class="next" title="Next Product" href='<%=ConfigUtil.hostURL() %><%=StringUtil.urlEncode(dt.Rows[0]["SKUName"]+"") %>?htm=<%=Request.Params["htm"]%>&action=next&index=<%=index%>'><span>Next</span><i class="next-i"></i></a>
                    </div>	 
                  <h5><%=(string)dt.Rows[0]["SKUBrand"] %></h5>
                  <h3><%=(string)dt.Rows[0]["SKUName"] %></h3>
                  <div class="priceqty">
                     <div class="price">
                     <%float disc = StringUtil.getDiscount(dt.Rows[0]["MRP"] + "", dt.Rows[0]["SpecialPrice"] + "");
                         if (disc>0){%>
                        <div class="discount">
                           <span>Discount: </span><span>Rs. <%=disc%></span>
                        </div>
                        <%} %>
                        <div class="oldprice">
                           <span>Rs. </span><span class="cut"><%=dt.Rows[0]["MRP"]+"" %></span>
                        </div>
                        <div class="rs">
                           <span>Rs. </span><span><%=dt.Rows[0]["SpecialPrice"]+""%></span>
                        </div>
                        <div class="avl">
                           <span>Availability:</span><span class="instock"><%=avalibilty%></span>
                        </div>
                        <div class="avl">
                           <span>SKU:</span><span class="instock"><%=(string)dt.Rows[0]["SKUCode"]%></span>
                        </div>
                     </div>
                     <%if (inventory != null && inventory > 0)
                       {%>
                     <div class="addtocart_qty">
                        <label for="qty">
                        Quantity :</label>
                        <div class="qty-container">
                           <select id='dd_quantity'>
                              <%for (int i = 1; i <= inventory; i++)
                                { %>
                              <option value='<%=i %>'> <%=i %> </option>
                              <%} %>
                           </select>
                        </div>
                         <div class="btn_form"> 
                             <input type="button" onclick="addtoCart()" title="add  to cart" value="BUY NOW"/>	</div>
                        
                     </div>
                     <%}%>
                     
                  </div>
                  
                  <%if ("true".Equals(isSize))
                    { %>
                  <div class="size" id='sizeDIV'>
                  <span id='errorSize' style='color:red;display:none'>Please select the verient</span>
                     Avaliable in these Varient:
                     <ul>
                        <%for (int i = 0; i < sizeDT.Rows.Count; i++)
                          { %>
                        <li namespace='sizeBtn' onclick="selectSize(this)" sku="<%=sizeDT.Rows[i]["SKUCode"] %>" size='<%=sizeDT.Rows[i]["Size"] %>' ><%=sizeDT.Rows[i]["Size"] %> <%=sizeDT.Rows[i]["SizeDataType"]%> </li>
                        <%} %>   
                     </ul>
                  </div>
                  <%} %>  
                 <%-- <%if ("true".Equals(isColor))
                    {%> 
                  <div class="color">
                     <div class="avl">
                        <span>Color:</span><span class="avlcolor"><%=(string)colorDT.Rows[0]["Color"]%></span>
                     </div>
                     Also available in these colors:
                     <ul>
                        <%for (int i = 0; i < colorDT.Rows.Count; i++)
                          { %>
                        <li>
                           <a href='<%=ConfigUtil.hostURL()%>?htm=<%=colorDT.Rows[i]["SKUCode"] %>'>  
                           <img style='height:60px;width:50px;' src='<%=ConfigUtil.getServerPath()%><%=colorDT.Rows[i]["PathInternaldetailsSmallImage"] %>'/>
                           </a>
                        </li>
                        <%} %>   
                     </ul>
                  </div>
                  <%} %>
--%>
                  <div class="wishlist" style="clear:both">

                     <%if (SFloor.DAO.FavDAO.isItemExist(Session.SessionID, dt.Rows[0]["SKUCode"] + ""))
                       {%>
                         <a href="javascript:void(0);" class="removewishlist-cat" title="remove from wishlist" name='saveLater' sku="<%=dt.Rows[0]["SKUCode"] %>">remove from wishlist</a>
                    <%}
                       else
                       { %>
                          <a href="javascript:void(0);" class="addwishlist-cat" title="add to wishlist" name='saveLater' sku="<%=dt.Rows[0]["SKUCode"] %>">add to wishlist</a>
                    <%} %>

                  </div>
               </div>
			
			   	 </div>
          	    <div class="clearfix"></div>
               <div class="aboutproduct">
                <div class="single-bottom1">
					<h6>Details</h6>
					<div class="prod-desc">
                           <h4><%=dt.Rows[0]["SKUName"] %></h4>
                        <%=dt.Rows[0]["SKULongDescription"]%>
                    </div>
                    </div>
				
				<div class="single-bottom1">
					<h6>Retuns</h6>
					<div class="prod-desc" style="display: none">
                        <p>We will leave no stone unturned in getting that curve back on your face.</p>
                        <p>Whatever may be the reason, if you want to return your purchase, we will pick the product back from your doorstep, free of cost. <%=dt.Rows[0]["ShippingReturns"]%>&nbsp;of receipt.</p>
                        <p>Please make sure it is not a USED product, should be in the original box and with all price tags attached as you got them.</p>
                        <p>To know more, please&nbsp;<a style="color:#ef6910" href="faq.aspx">Click here</a></p>
					</div>
				</div>
               </div>
             </div>
            </div>
            
         </div>
		  	 <div class="clearfix"></div>
	       	  <div class="single-bottom2">
					<h6>Related Products</h6>
	           <div id="related-product" class="catdetail_button owl-carousel">
            <%for (int i = 0; i < relProductDT.Rows.Count; i++)
                    {%>
                <div class="item">     <a href="<%=ConfigUtil.hostURL() %><%=StringUtil.urlEncode(relProductDT.Rows[i]["SKUName"]+"") %>?htm=<%=relProductDT.Rows[i]["SKUCode"] %>" >
                <img class="img-responsive"  src="<%=ConfigUtil.getServerPath() %><%=relProductDT.Rows[i]["PathInternaldetailsSmallImage"] %>" alt="image01" /><br>
              <span style="width:230px; overflow:hidden" ><%=relProductDT.Rows[i]["SKUName"] %></span><br>
                <span>Rs.<%=relProductDT.Rows[i]["SpecialPrice"] %></span>
              </a>
                       </div><%} %>
                 </div>
   
	       </div>	
	<%--      	 <div class="clearfix"></div>
	       	    <div class="single-bottom2">
					<h6>Recent Products</h6>
	           <div id="recent-product" class=" owl-carousel">
               <%for (int i = 0; i < recentProductTD.Rows.Count; i++)
                 {%>
				 <div class="item">   
					<a href="<%=ConfigUtil.hostURL() %><%=StringUtil.urlEncode(recentProductTD.Rows[i]["SKUName"]+"") %>?htm=<%=recentProductTD.Rows[i]["SKUCode"] %>" >
					<img class="img-responsive"  src="<%=ConfigUtil.getServerPath() %><%=recentProductTD.Rows[i]["PathInternaldetailsSmallImage"] %>" alt="image01" /><br>
					<span style="width:230px; overflow:hidden" ><%=relProductDT.Rows[i]["SKUName"] %></span><br>
					<span>Rs.<%=recentProductTD.Rows[i]["SpecialPrice"] %></span>
					</a>
                       </div><%} %>
                 </div>
   
	       </div>	

--%> 
    

	       	</div>

	<!-- end content -->



    </div>


<input type="hidden" id='style' value='<%=style%>' />
            <input type="hidden" id='color' value='<%=color%>' />
            <input type="hidden" id='isColor' value='<%=isColor%>' />
            <input type="hidden" id='size' value='' />
            <input type="hidden" id='isSku' value='<%=isSku%>' />
            <input type="hidden" id='isSize' value='<%=isSize%>' />

            <!-- End -->
            <%=Footer %>
      </body>
</html>
