<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Head.ascx.cs" Inherits="sfloor_pages_Headl" %>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title>Fab N Fresh </title>
 <meta name="description" content="fabnfresh.com is a online grocery shopping portal. we have many product imported and also original Indian product" />
 <meta name="keywords" content="fabnfresh, fabnfresh.com, shopping grocery site, Online Grocery, Online Grocery shopping site, Aata, vegetables, fruits, oils, cosmetic, condoms" />
<meta name="viewport" content="width=device-width, minimum-scale=1, maximum-scale=1"/>
<link rel="icon" href="<%=ConfigUtil.StaticPath() %>new-images/menulogo.png" type="image/x-icon"/>
<script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/lib/jquery-1.8.3.min.js"></script>
<script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/lib/angular.js'></script>
<script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/lib/owl.carousel.js?v=10002"></script>
<link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/slider.css?v=10002"/>
<link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/slider.defalult.css?v=10002"/>
  <script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/lib/jquery-ui.min.js"></script>
	<link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/jquery-ui.css?v=10002"/>
<link rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/fwslider.css" media="all">

<script src="<%=ConfigUtil.StaticPath() %>new-js/lib/fwslider.js"></script>
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
<script type="text/javascript">
    var staticPath = '<%=ConfigUtil.StaticPath() %>';
    var path = '<%=ConfigUtil.hostURL() %>';
    var serverPath = '<%=ConfigUtil.getServerPath() %>';
</script>
<script type="text/javascript">
    function reloadCart() {
        jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/ReloadCart.aspx' })
          .success(function (msg) {
              jQuery("[name='cartContainer']").html(jQuery(msg).filter('#mini_cart_block').html());
              jQuery("#cartDiv").slideDown(); //.slideUp('100000');
              setTimeout('jQuery("#cartDiv").slideDown()', 5000);
          });
      }
      function submitPurchi() {
          var name = jQuery(".parchiName").val();
          var address = jQuery(".parchiAddress").val();
          var purchiText = jQuery(".parchiText").val();
          var purchiPhone = jQuery(".parchiPhone").val();
          var error = 0;
          if (name.length == 0) {
              var v = jQuery("#parchiNameError").css("display", "block");
              console.log('name  \n'+v);
              error = 1;
          }
          if (address.length == 0) {
              var v = jQuery("#parchiAddressError").css("display", "block");
              console.log('address  \n' + v);
              error = 1;
          }
          if (purchiPhone.length < 10) {
              jQuery("#parchiPhoneError").css("display","block");
              console.log('purchiPhone  \n' + v);
              error = 1;
          }
          if (error == 1)
              return;
          else {
              jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx?action=purchiSubmit',
                  data: {
                      parchiName: name,
                      parchiAddress: address,
                      parchiText: purchiText,
                      purchiPhone: purchiPhone
                  }
              }).success(function (msg) {
                  var json = msg; // parseJSON(msg);
                  if (json.error == undefined || json.error.length==0)
                      jQuery(".parchMsg").text(json.info);
                  else {
                      jQuery(".parchMsg").text(json.error);

                  }
                  $('.parchiadd').slideUp();
                  $('.parchilist').slideDown();
                  jQuery('.parchMsg').show().fadeOut(10000);

              });
          }
      }
    function removeWLItem(sku) {
      var param = { action: 'removeFromWL', sku: sku };
      jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx', data: param })
			    .success(function (msg) {
			        jQuery("[name='WLContainer']").html(jQuery(msg).filter('#mini_cart_block').html());
			        if (jQuery(".wishlist-container[sku='" + sku +"' ]").length > 0) {
                        if(jQuery(".wishlist-container").size()==1){
                              jQuery(".wishlist-head").html("<center><br><br> <span style='color:red'>There zero item in your Wishlist !!</span><br><br></center>").after("<br>");
                          }
                          jQuery(".wishlist-container[sku='" + sku + "' ]").remove();

			        }
			    });
              }

              jQuery(document).ready(function () {

                  // jQuery("body").hide().fadeIn(2000);
                  jQuery("body").append("<input type='hidden' id='searchId' value='' />");
                  jQuery("body").append("<input type='hidden' id='searchType' value='' />");
                  var cache = {}, lastXhr;
                  jQuery("[searchbtn]").live("click", function () {
                      if (jQuery("#searchId").val().trim() == "" && jQuery("#search").val().trim() == "") {
                          return;
                      }
                      else if (jQuery("#searchId").val().trim() == "") {
                          window.location = path + "Search?searchId=" + jQuery("#search").val() + "&searchType=FREE_SEARCH";
                      }
                      else {
                          window.location = path + "Search?searchId=" + jQuery("#searchId").val() + "&searchType=" + jQuery("#searchType").val();
                      }
                  });
                  jQuery("#search").change(function () {
                      if (jQuery("#searchId").length > 0)
                          jQuery("#searchId").val('');
                  });
                  jQuery("#search").live("keypress", function (e) {
                      if (e.keyCode == 13) {
                          if (jQuery("#searchId").val().trim() == "" && jQuery("#search").val().trim() == "") {
                              return;
                          }
                          else if (jQuery("#searchId").val().trim() == "") {
                              window.location = path + "Search?searchId=" + jQuery("#search").val() + "&searchType=FREE_SEARCH";
                          }
                          else {
                              window.location = path + "Search?searchId=" + jQuery("#searchId").val() + "&searchType=" + jQuery("#searchType").val();
                          }
                      }
                  });
                  jQuery("#search").autocomplete({
                      source: function (request, response) {
                          var searchKey = jQuery("#search").val();
                          if (searchKey in cache) {
                              response(cache[searchKey]);
                              return;
                          }

                          lastXhr = jQuery.ajax({
                              type: "POST",
                              url: path + 'sfloor/pages/AjaxService.aspx?action=search',
                              data: { searchKey: searchKey },
                              success: function (data, status, xhr) {
                                  var results;
                                  if (xhr === lastXhr) {
                                      results = jQuery.map(data, function (el, index) {

                                          return {
                                              searchVal: el.SearchVal,
                                              name: el.Name,
                                              img: el.Src,
                                              type: el.Type
                                          };
                                      });
                                      cache[searchKey] = results;
                                      response(results);
                                  }

                              },
                              error: function (msg) {
                                  // alert(msg.status + ' ' + msg.statusText);
                              }
                          });
                      },
                      select: function (event, ui) {
                          this.value = ui.item.name;
                          jQuery("#searchId").val(ui.item.searchVal);
                          jQuery("#searchType").val(ui.item.type);
                          return false;
                      }
                  }).data("ui-autocomplete")._renderItem = function (ul, item) {

                      if (item.type == "product") {
                          if (jQuery(ul).find("#search_prod").length == 0)
                              jQuery(ul).append("<li><div style='text-align:left; background-color:#F1F1F1' id='search_prod'><B>Products</B><div></li>");
                          return jQuery("<li />")
								.append("<a style='text-overflow: ellipsis;' type='" + item.type + "' sku='" + item.searchVal + "'><img src='" + serverPath + item.img + "' height='60px' width='60px' />" + item.name + "</a>")
							.appendTo(ul);
                      }
                      else if (item.type == "category") {
                          if (jQuery(ul).find("#search_cat").length == 0)
                              jQuery(ul).append("<li><div style='text-align:left;background-color:#F1F1F1' id='search_cat'><B>Categories</B><div></li>")
                          return jQuery("<li />")
								.append("<a style='text-overflow: ellipsis;' type='" + item.type + "' sku='" + item.searchVal + "'>" + item.name + " </a>")
							.appendTo(ul);
                      }
                      else if (item.type == "Brand") {
                          if (jQuery(ul).find("#search_brand").length == 0)
                              jQuery(ul).append("<li><div style='text-align:left;background-color:#F1F1F1' id='search_brand'><B>Brands</B><div></li>")
                          return jQuery("<li />")
								.append("<a style='text-overflow: ellipsis;' type='" + item.type + "' sku='" + item.searchVal + "'>" + item.name + " </a>")
							.appendTo(ul);
                      }
                      else if (item.type == "subcategory") {
                          if (jQuery(ul).find("#search_subCat").length == 0)
                              jQuery(ul).append("<li><div style='text-align:left;background-color:#F1F1F1' id='search_subCat'><B>Sub-Categories</B><div></li>")
                          return jQuery("<li />")
								.append("<a style='text-overflow: ellipsis;' type='" + item.type + "' sku='" + item.searchVal + "'>" + item.name + " </a>")
							.appendTo(ul);
                      }
                      else if (item.type == "sku") {
                          if (jQuery(ul).find("#search_sku").length == 0)
                              jQuery(ul).append("<li><div style='text-align:left;background-color:#F1F1F1' id='search_sku'><B>SKU-Code</B><div></li>")
                          return jQuery("<li />")
								.append("<a style='text-overflow: ellipsis;' type='" + item.type + "' sku='" + item.searchVal + "'>" + item.name + " </a>")
							.appendTo(ul);
                      }
                      return ul;
                  };

                  //open popup
                  jQuery("#log,[logiPpop]").on("click", function () {
                      jQuery("#overlay_form").fadeIn(1000);
                      jQuery(".background_overlay").fadeIn(500);
                      positionPopup();
                  });

                  //close popup
                  jQuery("#close, .background_overlay").on("click", function () {
                      jQuery("#overlay_form").fadeOut(500);
                      jQuery(".background_overlay").fadeOut(500);
                  });
                  jQuery(window).bind('resize', positionPopup);

                  jQuery("[WL]").live('click', function () {
                      var sku = jQuery(this).attr('sku');
                      removeWLItem(sku);
                  });
                  jQuery("[cart]").live('click', function () {
                      var sku = jQuery(this).attr('sku');
                      var param = { action: 'removeFromCart', sku: sku };
                      jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx', data: param })
			        .success(function (msg) {
			            jQuery("[name='cartContainer']").html(jQuery(msg).filter('#mini_cart_block').html());
			        });
                  });
                  //maintain the popup at center of the page when browser resized
                  jQuery("a[name='saveLater']").live('click', function () {

                      var sku1 = jQuery(this).attr('sku');
                      var inner = jQuery(this).attr('inner');
                      var href = this;
                      jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx?action=toggleFav', data: { sku: sku1} })
			        .success(function (msg) {
			            if (msg.status == 'done') {
			                reloadWL(sku1);
			                if ($(href).text() == "Add to wishlist")
			                    $(href).text("Remove From Wishlist");
			                else if ($(href).text() == "Remove From Wishlist")
			                    $(href).text("Add to wishlist");

			            } else
			                alert("Opps!! something went wrong, Please try again");
			        });
                  });

                  //---------------

                  //---------------

                  //---------------
                  //open popup
                  jQuery('#checkoutlogin').on("click", function () {
                      jQuery("#checkout_overlay_form").fadeIn(1000);
                      jQuery(".checkout_background_overlay").fadeIn(500);
                      checkout_positionPopup();
                  });
                  //close popup
                  jQuery("#close, .checkout_background_overlay").on("click", function () {
                      jQuery("#checkout_overlay_form").fadeOut(500);
                      jQuery(".checkout_background_overlay").fadeOut(500);
                  });
                  jQuery(window).bind('resize', checkout_positionPopup);

                  //open popup
                  jQuery('#fgt_clk_hre').on("click", function () {
                      jQuery("#overlay_form").fadeOut(500);
                      jQuery(".background_overlay").fadeOut(500);
                      jQuery("#checkout_overlay_form").fadeOut(500);

                      jQuery(".checkout_background_overlay").fadeOut(500);
                      jQuery("#fgt_overlay_form").fadeIn(1000);
                      jQuery(".fgt_background_overlay").fadeIn(500);
                      fgt_positionPopup();
                  });
                  jQuery('#logsign').live("click", function () {
                      jQuery("#fgt_overlay_form").fadeOut(1000);
                      jQuery(".fgt_background_overlay").fadeOut(500);
                      jQuery("#checkout_overlay_form").fadeIn(500);

                      jQuery(".checkout_background_overlay").fadeIn(500);

                      jQuery("#overlay_form").fadeIn(500);
                      jQuery(".background_overlay").fadeIn(500);
                      fgt_positionPopup();
                  });
                  //close popup
                  jQuery("#fgt_close, .fgt_background_overlay").on("click", function () {
                      jQuery("#fgt_overlay_form").fadeOut(500);
                      jQuery(".fgt_background_overlay").fadeOut(500);
                  });
                  jQuery(window).bind('resize', fgt_positionPopup);

              });
</script>
   <script type="text/javascript" id="sourcecode">
       function scrollMenu(){
           jQuery('.scroll-pane').jScrollPane();
           console.log('2');
       }
        </script>

<!--For Header.ascx Start-->
<link href='<%=ConfigUtil.StaticPath() %>new-css/login-forms.css?v=10001' rel="stylesheet" type="text/css" />
<!--For Header.ascx End -->

<script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/sfloorall.js?v=10002'></script>
<!-- For Menu.axcx  Start-->
<script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/menu.js?v=10002'></script>
<!-- For Menu.axcx  End-->



<!-- For Menu.axcx  Start-->
<style>
   #overlay_form
   {
   background: WHITE;
   z-index: 100000;
   }
   .background_overlay
   {
   position: fixed;
   left: 0px;
   top: 0px;
   width: 100%;
   height: 100%;
   z-index: 10000;
   background:rgba(0, 0, 0, 0.7);
   }
   .background_overlay_cat
   {
   position: fixed;
   left: 0px;
   top: 0px;
   width: 100%;
   height: 100%;
   z-index: 100000;
   background:rgba(0, 0, 0, 0.7);
     }
   #fgt_overlay_form
   {
   background: WHITE;
   z-index: 100000;
   }
   .fgt_background_overlay
   {
   position: fixed;
   left: 0px;
   top: 0px;
   width: 100%;
   height: 100%;
   z-index: 99999;
   background:rgba(0, 0, 0, 0.7);
   }
   .css-form input.ng-invalid.ng-dirty
   {
   border: 2PX SOLID #FA787E;
   }
   .css-form input.ng-valid.ng-dirty
   {
   border: 2PX SOLID #78FA89;
   }
   .css-form .help-block
   {
   color: #fa787e;
    font-size: 12px;
    padding: 0;
    line-height: 2;
    margin:0
   }
</style>
<!--For Menu.ascx End-->


<!--For Header.ascx Start-->
<script type="text/javascript">
    function clearCart() {
        jQuery.ajax({ method: 'POST', url: path + "sfloor/pages/AjaxService.aspx?action=clearCart" })
   .success(function (msg) {
       jQuery("#cartDiv").html("<div class='empty_item'><span>Your Cart Is Empty</span></div>")
       jQuery("#cCount").text("0");
       if (pageType == 'addToCart') {
           jQuery('.addtocartmain').html("<center><p style='color:red'>All item(s) has been Deleted from your Cart</center>")
       }

   });
    }
    function clearFav() {
        jQuery.ajax({ method: 'POST', url: path + "sfloor/pages/AjaxService.aspx?action=clearFav" })
   .success(function (msg) {
       jQuery("#wishListDiv").html("<div class='empty_item'><span>Your Wishlist Is Empty</span></div>")
       jQuery("#favCount").text("0");
       if (jQuery(".wishlist-head").length > 0) {
           jQuery(".wishlist-container").remove();
           jQuery(".wishlist-head").html("<center><br><br> <span style='color:red'>There zero item in your Wishlist !!</span><br><br></center>").after("<br>");
       }
   });
    }
</script>
<!--For Header.ascx End-->
<%--<script>
function slideEffectAjax() {
    jQuery('.top-cart-contain').mouseenter(function () {
        jQuery(this).find(".top-cart-content").show();
        if (jQuery("#dontHide").length > 0) {
           jQuery("#dontHide").remove();
        }
    });
    //hide submenus on exit
   jQuery('.top-cart-contain').mouseout(function (e) {
    
        if (jQuery("#dontHide").length == 0) {
            jQuery(this).find(".top-cart-content").hide();
        }
    });
}
jQuery(document).ready(function () {
    slideEffectAjax();
});
</script>
--%><script>
        function slideLogin() {
        jQuery('.top-cart-contain').mouseenter(function () {
            jQuery(this).find(".top-cart-content").stop(true, true).show();
        });
        //hide submenus on exit
        jQuery('.top-cart-contain').mouseleave(function () {
            jQuery(this).find(".top-cart-content").stop(true, true).hide();
        });
    }
        function slideacount() {
            jQuery('#acc_sec').hover(

              function (e) {
                  e.stopPropagation();
                 // jQuery(".background_overlay").stop(true, true).fadeIn(500);
                  jQuery('.acc_menu').stop(true, true).slideDown(100);
              },
                 function () {
                   ///  jQuery(".background_overlay").stop(true, true).fadeOut(500);
                     jQuery('.acc_menu').stop(true, true).slideUp(100);

              });
        }
jQuery(document).ready(function () {
   // jQuery('.ajaxcartsuper-index-productview #mini_cart_block').hide(150);
    slideacount();
    slideLogin(); 
});
</script>

<!--Common1.js Start -->
<script type="text/javascript">
    function reloadWL(sku) {
        jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/ReloadWL.aspx' })
			.success(function (msg) {
			    if (jQuery("[name='WLContainer']").length > 0)
			        jQuery("[name='WLContainer']").html(jQuery(msg).filter('#mini_cart_block').html());
			    else
			        window.top.jQuery("[name='WLContainer']").html(jQuery(msg).filter('#mini_cart_block').html());
			    jQuery("#wishListDiv").show();
			   // jQuery("#wlNotificationInfo").show('slow');
			    toggleClass(jQuery("[name='saveLater'][sku='" + sku + "']"));
			    
			});
    }
    function toggleClass(tag) {
        if(jQuery(tag).find('span').text()!='Remove From WishList'){
            jQuery(tag).find('span').text('Remove From WishList');
        }else{
         jQuery(tag).find('span').text('Add To Wishlist');
        }
//        if (jQuery(tag).hasClass('wish-list1')) {
//            jQuery(tag).removeClass('wish-list1');
//            jQuery(tag).addClass('wishlist-active');
//            jQuery(tag).find('span').text('Remove From WishList');
//        } else {
//            jQuery(tag).removeClass('wishlist-active');
//            jQuery(tag).addClass('wish-list1');
//            jQuery(tag).find('span').text('Save For Later');
//        }
    } 
    //position the popup at the center of the page
    function positionPopup() {
        if (!jQuery("#overlay_form").is(':visible')) {
            return;
        }
        jQuery("#overlay_form").css({
            left: (jQuery(window).width() - jQuery('#overlay_form').width()) / 2,
            top: (jQuery(window).width() - jQuery('#overlay_form').width()) / 7,
            position: 'absolute'
        });
    }

  
    //position the popup at the center of the page
    function checkout_positionPopup() {
        if (!jQuery("#checkout_overlay_form").is(':visible')) {
            return;
        }
        jQuery("#checkout_overlay_form").css({
            left: (jQuery(window).width() - jQuery('#checkout_overlay_form').width()) / 2,
            top: (jQuery(window).width() - jQuery('#checkout_overlay_form').width()) / 7,
            position: 'absolute'
        });
    }
    //position the popup at the center of the page
    function fgt_positionPopup() {
        if (!jQuery("#fgt_overlay_form").is(':visible')) {
            return;
        }
        jQuery("#fgt_overlay_form").css({
            left: (jQuery(window).width() - jQuery('#fgt_overlay_form').width()) / 2,
            top: (jQuery(window).width() - jQuery('#fgt_overlay_form').width()) / 7,
            position: 'absolute'
        });
    }
    $(document).ready(function () {
        $(".dropdown").hover(
            function () {
                $('.dropdown-menu', this).stop(true, true).slideDown("fast");
                $(this).toggleClass('open');
            },
            function () {
                $('.dropdown-menu', this).stop(true, true).slideUp("fast");
                $(this).toggleClass('open');
            }
        );
    });
</script>
<!-- Common1.js End-->
