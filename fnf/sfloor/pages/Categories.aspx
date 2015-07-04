<%@ Page Language="C#" CodeFile="Categories.aspx.cs" Inherits="Categories" %>

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
    <%=Head %>

    <link href='<%=ConfigUtil.StaticPath() %>new-css/internalpage.css' rel="stylesheet" type="text/css" />

    <script src='<%=ConfigUtil.StaticPath() %>new-js/fixsidemenu.js' type="text/javascript"></script>
    <script type="text/javascript" src='<%=ConfigUtil.StaticPath() %>new-js/category.js'></script>
    <style>
        div#spinner {
            display: none;
            width: 350px;
            height: 100px;
            position: fixed;
            top: 50%;
            left: 50%;
            text-align: center;
            margin-left: -50px;
            margin-top: -100px;
            z-index: 999999992;
            overflow: auto;
        }

        #overlay_form_quick {
            position: fixed !important;
            background: none repeat scroll 0 0 #fff;
            border-radius: 10px;
            bottom: 0;
            left: 0;
            position: fixed;
            right: 0;
            top: 0;
            z-index: 99999;
        }

        .background_overlay_quick {
            background: none repeat scroll 0 0 BLACK;
            height: 100%;
            left: 0;
            opacity: 0.8;
            position: fixed;
            top: 0;
            width: 100%;
            z-index: 9999;
        }

        #pcd_overlay_form_quick {
            background: WHITE;
            z-index: 100000;
            border-radius: 10px;
        }

        .pcd_background_overlay_quick {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 100000;
            background: black;
            opacity: 0.9;
        }
    </style>
    <script type="text/javascript">

        function removeFromCompareList(sku) {
            jQuery("#compareProductList").find("li[sku='" + sku + "']").remove();
            jQuery("[compare][sku='" + sku + "']").removeAttr("checked");
            //            if (jQuery("#compare_list").is(":visible") && jQuery("#compareProductList li").size() == 0) {
            //                jQuery("#compare_list").hide();

            //            }
        }

        jQuery(document).ready(function () {
            jQuery("[ver-select]").live("change", function () {
                var current = this;
                var selected = jQuery(this).find("option:selected").attr("sku");
                //alert(selected)
                jQuery.ajax({
                    type: "get",
                    url: "<%=ConfigUtil.hostURL()%>sfloor/pages/BuyFromCat.aspx?bfc=" + selected,
                    success: function (data) {
                        jQuery(current).parents(".categorydetails_info_bottom").html(jQuery(data).html())
                    },
                    error: function (result) {
                        alert("Error......");
                    }
                });

            });
            jQuery('[addTocart]').live("click", function () {
                var sku1 = jQuery(this).attr("sku");
                var style = jQuery(this).attr("styl");
                var data = {
                    sku: sku1,
                    qty: jQuery("#qty-" + sku1 + " option:selected").val(),
                    color: "",
                    size: jQuery("#ver-" + sku1 + " option:selected").val(),
                    isColor: false,
                    isSize: style.length > 0,
                    isSku: style.length > 0
                }
                jQuery.ajax({
                    type: "get",
                    contentType: "application/json; charset=utf-8",
                    url: "<%=ConfigUtil.hostURL()%>sfloor/pages/AjaxService.aspx?action=addToCart",
                    data: data,
                    success: function (data) {
                        reloadCart();
                        if (data.error != null) {
                            alert(error);
                            //jQuery('#errorSize').css('display', 'block').text(data.error);
                        } else {
                            // window.location = '<%=ConfigUtil.hostURL()%>Add-To-Cart'
                        }
                    },
                    error: function (result) {
                        alert("Error......");
                    }
                });

            });
            jQuery("#showProd").live("click", function () {
                jQuery("#relatedProd").slideToggle(1000);
            });

            jQuery("#compareButton").live("click", function () {
                if (jQuery("#compareProductList li").length == 0)
                    return;
                var str = "";
                jQuery("#compareProductList li").each(function (i) {
                    str += "sku" + i + "=" + jQuery(this).attr("sku") + "&"
                });
                window.open(path + "Compare-Products?" + str);
            })
            jQuery("#close-compare").live("click", function () {

                jQuery("[compare]").each(function () {
                    jQuery(this).removeAttr("checked");
                });
                jQuery("#compareProductList").html("<p> compare list is empty</p>");
            });
            jQuery("[compare]").live("click", function () {

                if (jQuery("#compareProductList>p").length > 0) {
                    jQuery("#compareProductList>p").remove();
                }
                var sku = jQuery(this).attr("sku");

                if (jQuery(this).is(":checked")) {

                    if (jQuery("#compareProductList li").size() == 4) {
                        alert("You can compare upto four items only.");
                        jQuery(this).removeAttr("checked");
                        return;
                    }

                    var src = jQuery(".image_slider[sku='" + sku + "']").find(".disp > img").attr("src");
                    var name = jQuery(this).attr('pName');
                    var brand = jQuery(this).attr('pBrand');
                    var html = "<li sku='" + sku + "'>"
                           + "<div style='height:80px;'>"
                               + "<img width='60' height='80' style='float:left' src='" + src + "'/>"
                               + "<span style='float:right; width:102px; overflow:hidden;'>" + name + "</span>"
                               + "<span style='float:right; width:102px; overflow:hidden;color:green'>" + brand + "</span>"
                              + "<a  class='cross-del' href='javascript:void(0);' title='Close' sku='" + sku + "' removeCompare></a>"
                           + "</div>"
                       + "</li>";
                    jQuery("#compareProductList").append(html);
                    if (!jQuery("#compare_list").is(":visible")) {

                        jQuery("#compare_list").slideDown();
                    }
                } else {
                    removeFromCompareList(sku);

                }
                if (jQuery(".compare_product").css('width') != '215px') {
                    jQuery(".arrow-right").click();
                }
            });
            jQuery("[removecompare]").live("click", function () {
                removeFromCompareList(jQuery(this).attr("sku"));
            });
            if (jQuery('#crumb4').text().trim().length == 0) {

                jQuery('#crumb4').css('display', 'none');
            }
            else {
                jQuery('#crumb4').css('display', 'block');
            }
        });
        jQuery(document).ready(function () {
            jQuery(".filter-body > .head-title").click(function () {
                if (jQuery(this).hasClass('active')) {
                    jQuery(this).next(".filter-body > div.inner-body").slideToggle("");
                    jQuery(this).removeClass('active');
                }
                else {
                    jQuery(this).next(".filter-body > div.inner-body").slideToggle("");

                    jQuery(this).toggleClass("active");
                    jQuery(this).addClass("active");
                }
            });
            jQuery('.filter_icon').click(function () {
                jQuery('#floating_filter').toggle()
            });
        });

      </script>
    <script type="text/javascript" id="sourcecode">
        jQuery(function () {
            jQuery('.scroll-pane').jScrollPane();
        });
        </script>
</head>
<body>
    <div id="spinner">
        <img src="<%=ConfigUtil.StaticPath()%>new-images/loader.gif" alt="Loading..." style='height: 35; width: 170; z-index: 999999' />
    </div>
        <%=Header %>
            <div class="container">
             
                <%--breadcrumb--%>
                
             
                <%if (catDT == null && prodDt == null)
                  {%>
                   <div class="right_inner_categorydetailssortby ">
                    <div class="bradcrumbs-contain">
                       <p style="color:Red"> No Result Found</p>
                    </div>
                   </div>
                <%}
                  else
                  { %>
                   <div class="row center">
                    <div class="bradcrumbs-contain  center col-md-8 col-xs-12">

                    <div class="breadcrumbs center" id="crumbs">
                        <ul>
                            <li id="crumb1"><a href='<%=ConfigUtil.hostURL() %>Home'>Home </a></li>
                            <li id="crumb2"><span></span><a id='catNav'>
                                <%=catName%>
                            </a>
                            </li>
                            <li id="crumb3"><span></span><a id='subCatNav' href='<%=subCatUrl%>'>
                                <%=subCatName%>
                            </a>
                            </li>
                            <li id="crumb4"><span></span><a id='pTypeNav' href='<%=pTypeUrl%>'>
                                <%=pTypeName%></a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="center col-md-3 col-xs-9">
                   <%if (MFO.Commom.CommonUtil.DT.isEmptyOrNull(prodDt) && MFO.Commom.CommonUtil.DT.isEmptyOrNull(catDT))
                     { %> 
                        <p class="wishbutton" > Total : <span id="totoalItems">0</span>Item(s) Showing </p>
                   <%}
                     else if (!MFO.Commom.CommonUtil.DT.isEmptyOrNull(catDT))
                     {%>
                        <p class="wishbutton" >Total : <span id="totoalItems"><%=catDT.Rows.Count %></span> Item(s) Showing </p>
                   <%}
                     else if (!MFO.Commom.CommonUtil.DT.isEmptyOrNull(prodDt))
                     {%>
                        <p class="wishbutton" >Total :<span id="totoalItems"><%=prodDt.Rows.Count %></span> Item(s) Showing </p>
                   <% }%>

                </div>
                <div class="dropdown col-md-1 col-xs-3">
                    <select class="dropdown-select" id="price_select">
                        <option value="0">Price</option>
                        <option value="1">Low</option>
                        <option value="2">High</option>
                    </select>
                </div>
            </div>
                <div class="row">
            <!--End here Filter category-->

                    <div class="filter_icon">Filter</div>
            <div id="filter_float_threshold_start">
            </div>
                        <div class="w_sidebar" id="floating_filter" style="position: fixed;">
                            <section class="sky-form">
                                <h4  id="MainCatHeader" class="deactslide" runat="server">Accessories<a href="javascript:void(0)"></a></h4>
                    <div>
                     <input type="text" id="catsubCatTxt" placeholder='Categories Filter.' class="txt_filter" />
                                    
                                <div class="row1 scroll-pane">
                                    <div class="col col-4">
                                       <ul id="Left_Cat_List">
                                       <%if (catNameDT != null)
                                         { %>
										 <%for (int i = 0; i < catNameDT.Rows.Count; i++)
             {%>
												<li><a class="lnkbtn_category" href='<%=catNameDT.Rows[i]["url"]%>' data="<%=catNameDT.Rows[i]["SKUProductType"]%>">
												<%=catNameDT.Rows[i]["SKUProductType"]%></a> 
												</li>
										   <%} %>
									<%} %>
                          
                        </ul>
                        </div> 
                        </div>
                     </div>
                            </section>
                            <section class="sky-form">
                                <h4 class="deactslide">brand</h4>
                                <div>
                                    <input type="text" class="deactslide" id="brandTxt" placeholder='Brands Filter' class="txt_filter"/>

                                <div class="row1 scroll-pane">
                                    <div class="col col-4">
                                   <div id="Left_Brand_List" class="scroll">
						               <%if (brandDT != null)
                       { %>
							             <%for (int i = 0; i < brandDT.Rows.Count; i++)
                      {%>
                                         <span>
							                 <label class="checkbox" for='<%=brandDT.Rows[i]["SKUBrand"]%>-cb' brands='<%=brandDT.Rows[i]["SKUBrand"]%>'><%=brandDT.Rows[i]["SKUBrand"]%>
							                 <input type="checkbox" name="checkbox" id="<%=brandDT.Rows[i]["SKUBrand"]%>-cb" brands='<%=brandDT.Rows[i]["SKUBrand"]%>' ><i></i></label>
                                         </span>
							              <%} %>
							            <%} %>
                              
                                    </div>
                                    </div>
                                    </div>
                                </div>
                            </section>
                            <section class="sky-form">
                                <h4  class="deactslide">Price</h4>
                                <div class="row1 scroll-pane">
                                    <div class="col col-4">
                                        <div class="priceinput">
                                            <input type="number" name="min" id='minTxt' min="0" placeholder="min price"/>
                                            <input id='maxTxt' type="number" min="0" name="max" placeholder="max price"/>
                                            <input type="button" value="GO" id='priceRangeBtn' /><br>
                                            <p id='errRange' style='display: none; color: red'>
                                                Please enter the min and max price
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>

                  </div>
            
            <!--End here Filter category-->
                        
               <!--Start here Images repeater -->
			         <div class="women row">
                <%if (Request.Params["searchId"] != null)
                  {%>
                    <%if (prodDt == null || prodDt.Rows.Count == 0)
                      {%>   

                      <h2 style="text-align:center;color:Red;height:100%" >No Result Found</h2>
                   <%}
                      else
                      { %>
                        <h2 class="recentitem" style="text-align:left" >Search Result</h2>
                     <%} %>
               <%} %>

               <% if (prodDt != null)
                  {%>
                 <% if (searchType == "product" || searchType == "sku")
                    {%>
                 <div id="search_result_div">
                 <%}
                    else
                    {%>
                    <div id="categories">
                 <%} %>
                    <%for (int i = 0; i < prodDt.Rows.Count; i++)
                      { %>
                                      <div class="right_inner_categorydetailsimagesdetails">
                                <div class="boxgrid">
                                <div class="loading item" sequence='<%=i%>' sku='<%=prodDt.Rows[i]["SKUCode"]%>'>
                                   <a href='<%=prodDt.Rows[i]["link"] %>'>
                                 <div class='lnkbtn_brandname'> <%=prodDt.Rows[i]["SKUBrand"]%></div>
                         
                                 <ul class="image_slider" sku='<%=prodDt.Rows[i]["SKUCode"] %>' style='left:0px'>
                                    <%= MFO.Utils.StringUtil.dispLI(prodDt.Rows[i]["PathUpperInternaldetailsSmallImage"], prodDt.Rows[i]["SKUName"], false)%>
                                    <%= MFO.Utils.StringUtil.dispLI(prodDt.Rows[i]["PathLowerInternaldetailsSmallImage"], prodDt.Rows[i]["SKUName"], false)%>
                                    <%= MFO.Utils.StringUtil.dispLI(prodDt.Rows[i]["PathBackInternaldetailsSmallImage"], prodDt.Rows[i]["SKUName"], false)%>
                                    <%= MFO.Utils.StringUtil.dispLI(prodDt.Rows[i]["PathInternaldetailsSmallImage"], prodDt.Rows[i]["SKUName"], true)%>
                                 </ul>
                              </a>
                           </div>
                     <%--      <a href="javascript:void(0);" class="previmg" prev='<%=prodDt.Rows[i]["SKUCode"]%>' ></a>
                           <a href="javascript:void(0);" class="nextimg" next='<%=prodDt.Rows[i]["SKUCode"]%>' ></a>
                     --%>   </div>
                         
                        <div class="categorydetails_info_bottom">
                            <a href='<%=prodDt.Rows[i]["link"] %>'>   
                                <div class="productpricesection">
                                <div class='lnkbtn_proname'><%=prodDt.Rows[i]["SKUName"]%></div>
                                <div class="splprice"><span class="margin">Rs.</span><%=prodDt.Rows[i]["SpecialPrice"]%></div>
                                
                                <%if (Int32.Parse(prodDt.Rows[i]["MRP"].ToString()) != (Int32.Parse(prodDt.Rows[i]["SpecialPrice"].ToString())))
                                  { %>
                                    <div class="crossprize" >Rs. <%=prodDt.Rows[i]["MRP"]%> </div>
                                <%} %>
                                </div>
                               </a>
                                <div class="optionContainer">
                               
                                <div class="select_varient">
                                <%if ("normal".Equals(prodDt.Rows[i]["SKUClassification"].ToString().Trim().ToLower()))
                                  {%>
                                <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='qty-<%=prodDt.Rows[i]["SKUCode"]%>'>
                                    <%for (int j = 1; j <= 10; j++)
                                      { %>
                                        <option value='<%=j %>'><%=j %> <%=prodDt.Rows[i]["SizeDataType"]%></option>
                                     <%} %>
                                    </select>
                                    </label><span>Select Quantity</span></a>
                                <%}
                                  else
                                  { %>
                                     <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='qty-<%=prodDt.Rows[i]["SKUCode"]%>' ver-select>
                                    <% System.Data.DataTable sDT = SFloor.Services.CatDetailsService.getSizeDT(catDT.Rows[i]["SKUCode"].ToString(), true); %>
                                    <%for (int j = 0; j < sDT.Rows.Count; j++)
                                      { %>
                                        <%if (sDT.Rows[j]["size"].ToString().Trim().Equals(catDT.Rows[i]["size"].ToString().Trim()))
                                          {%>
                                            <option selected sku="<%=sDT.Rows[j]["SKUCode"]%>" value='<%=sDT.Rows[j]["Size"]%>'><%=sDT.Rows[j]["Size"]%> <%=prodDt.Rows[i]["SizeDataType"]%></option>
                                        <%}
                                          else
                                          {%>
                                            <option  sku="<%=sDT.Rows[j]["SKUCode"]%>" value='<%=sDT.Rows[j]["Size"]%>'><%=sDT.Rows[j]["Size"]%> <%=sDT.Rows[j]["SizeDataType"]%></option>
                                        <%} %>  
                                     <%} %>
                                    </select>
                                    </label>
                                         <span>Select Varient</span></a>
                                    <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='qty-<%=prodDt.Rows[i]["SKUCode"]%>'>
                                    <%for (int j = 1; j <= 10; j++)
                                      { %>
                                        <option value='<%=j %>'><%=j %></option>
                                     <%} %>
                                    </select>
                                    </label><span>Select Quantity</span></a>
                                <%} %>
                            </div>  
                            <div class="center">
                                    <a class="compare-view1"><label><button sku='<%=prodDt.Rows[i]["SKUCode"]%>' styl='<%=prodDt.Rows[i]["StyleCode"]%>' addTocart>ADD TO CART</button></label><span>Buy Now</span></a>
                            </div>
                                  <div class="wishquick1" style="height:33px">
                                    <a class="wish-list1" name='saveLater' sku='<%=prodDt.Rows[i]["SKUCode"]%>'><span><%=getToolTip()%></span></a>
                                    <a class="quick-view1" pop='<%=prodDt.Rows[i]["SKUCode"] %>'><span>Quick View</span></a>
                                    <a class="compare-view"><input style="float:right" title="Add To Compare List" type="checkbox"  compare pName="<%=prodDt.Rows[i]["SKUName"]%>" pBrand="<%=prodDt.Rows[i]["SKUBrand"]%>"sku='<%=prodDt.Rows[i]["SKUCode"]%>'/>Compare&nbsp;<span>Compare</span></a>
                                </div>   
                            </div>          
                        </div>
                  
                     </div>
               <%}%>
               </div>
               <%if (searchType == "sku" || searchType == "product")
                 { %>
               <div class="clearfix"></div>
                   <a id="showProd" href="javascript:void(0)" style="text-align:left"><h2 class="recentitem">See Related Products</h2></a>
              <div id="relatedProd" style="display:none">
              <%} %>
               <%} %>
               <%if (catDT != null && catDT.Rows.Count > 0)
                 { %>
               <div id="categories">
               <%for (int i = 0; i < catDT.Rows.Count; i++)
                 { %>
                            <div class="right_inner_categorydetailsimagesdetails">
                                <div class="boxgrid">
                                <div class="loading item" sequence='<%=i%>' sku='<%=catDT.Rows[i]["SKUCode"]%>'>
                                   <a href='<%=catDT.Rows[i]["link"] %>'>
                                 <div class='lnkbtn_brandname'> <%=catDT.Rows[i]["SKUBrand"]%></div>
                         
                                 <ul class="image_slider" sku='<%=catDT.Rows[i]["SKUCode"] %>' style='left:0px'>
                                    <%= MFO.Utils.StringUtil.dispLI(catDT.Rows[i]["PathUpperInternaldetailsSmallImage"], catDT.Rows[i]["SKUName"], false)%>
                                    <%= MFO.Utils.StringUtil.dispLI(catDT.Rows[i]["PathLowerInternaldetailsSmallImage"], catDT.Rows[i]["SKUName"], false)%>
                                    <%= MFO.Utils.StringUtil.dispLI(catDT.Rows[i]["PathBackInternaldetailsSmallImage"], catDT.Rows[i]["SKUName"], false)%>
                                    <%= MFO.Utils.StringUtil.dispLI(catDT.Rows[i]["PathInternaldetailsSmallImage"], catDT.Rows[i]["SKUName"], true)%>
                                 </ul>
                              </a>
                           </div>
                        <%--   <a href="javascript:void(0);" class="previmg" prev='<%=catDT.Rows[i]["SKUCode"]%>' ></a>
                           <a href="javascript:void(0);" class="nextimg" next='<%=catDT.Rows[i]["SKUCode"]%>' ></a>
                        --%></div>
                         
                        <div class="categorydetails_info_bottom">
                            <a href='<%=catDT.Rows[i]["link"] %>'>   
                                <div class="productpricesection">
                                <div class='lnkbtn_proname' title="<%=catDT.Rows[i]["SKUName"]%>"><%=catDT.Rows[i]["SKUName"]%></div>
                                <div class="splprice"><span class="margin">Rs.</span><%=catDT.Rows[i]["SpecialPrice"]%></div>
                                 <%if (Int32.Parse(catDT.Rows[i]["MRP"].ToString()) != (Int32.Parse(catDT.Rows[i]["SpecialPrice"].ToString())))
                                   { %>
                                   <div class="crossprize" ><span class="margin">Rs.</span><%=catDT.Rows[i]["MRP"]%> </div>
                                <%} %>
                               </div>
                              </a>
                                <div class="optionContainer">  
                                <div class="select_varient">
                                <%if ("normal".Equals(catDT.Rows[i]["SKUClassification"].ToString().Trim().ToLower()))
                                  {%>
                                <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='qty-<%=catDT.Rows[i]["SKUCode"]%>'>
                                    <%for (int j = 1; j <= 10; j++)
                                      { %>
                                        <option value='<%=j %>'><%=j %> <%=catDT.Rows[i]["SizeDataType"]%></option>
                                     <%} %>
                                    </select>
                                    </label><span>Select Quantity</span></a>
                                <%}
                                  else
                                  { %>
                                     <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='ver-<%=catDT.Rows[i]["SKUCode"]%>' ver-select>
                                    <% System.Data.DataTable sDT = SFloor.Services.CatDetailsService.getSizeDT(catDT.Rows[i]["SKUCode"].ToString(), true); %>
                                    <%for (int j = 0; j < sDT.Rows.Count; j++)
                                      { %>
                                        <%if (sDT.Rows[j]["size"].ToString().Trim().Equals(catDT.Rows[i]["size"].ToString().Trim()))
                                          {%>
                                            <option selected sku="<%=sDT.Rows[j]["SKUCode"]%>" value='<%=sDT.Rows[j]["Size"]%>'><%=sDT.Rows[j]["Size"]%> <%=catDT.Rows[i]["SizeDataType"]%></option>
                                        <%}
                                          else
                                          {%>
                                            <option  sku="<%=sDT.Rows[j]["SKUCode"]%>" value='<%=sDT.Rows[j]["Size"]%>'><%=sDT.Rows[j]["Size"]%> <%=sDT.Rows[j]["SizeDataType"]%></option>
                                        <%} %>  
                                     <%} %>
                                    </select>
                                    </label>
                                         <span>Select Varient</span></a>
                                    <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='qty-<%=catDT.Rows[i]["SKUCode"]%>'>
                                    <%for (int j = 1; j <= 10; j++)
                                      { %>
                                        <option value='<%=j %>'><%=j %></option>
                                     <%} %>
                                   </select> </label>
                                    <span>Select Quantity</span></a>
                                <%} %>
                            </div> 
                            <div class="center">
                                    <a class="compare-view1"><label><button sku='<%=catDT.Rows[i]["SKUCode"]%>' styl='<%=catDT.Rows[i]["StyleCode"]%>' addTocart>ADD TO CART</button></label><span>Buy Now</span></a>
                            </div>
                                  <div class="wishquick1" style="height:33px">
                                    <a class="wish-list1" name='saveLater' sku='<%=catDT.Rows[i]["SKUCode"]%>'><span><%=getToolTip()%></span></a>
                                    <a class="quick-view1" pop='<%=catDT.Rows[i]["SKUCode"] %>'><span>Quick View</span></a>
                                    <a class="compare-view"><input style="float:right" title="Add To Compare List" type="checkbox"  compare pName="<%=catDT.Rows[i]["SKUName"]%>" pBrand="<%=catDT.Rows[i]["SKUBrand"]%>"sku='<%=catDT.Rows[i]["SKUCode"]%>'/>Compare&nbsp;<span>Compare</span></a>
                                </div>   
                            </div>          
                        </div>
                  
                     </div>
               <%} %>
               </div>
               <%} %>
               <%if (prodDt != null) %>
                </div>
               <% %>
               </div>
               <div class="clearfix"></div>
               <!--End here Images repeater -->
               <div style="text-align:center">
                        <a href="javascript:void(0)" id="showMoreLink"><b>See More...</b></a>
                        <img id='loadImg' src="<%=ConfigUtil.StaticPath()%>new-images/showmore.GIF" alt="Loading..." style='display: none; height: 20px; width: 160px; z-index: 999999' />
                </div>
            </div>
         
         </div>
         <div id="filter_float_threshold_end">
         </div>
         <div class="background_overlay_quick" style="display: none;">
         </div>
         <section>
                  <div id="overlay_form_quick"  style="display:none; position:fixed; left:200px; top:10px; background:white; width:1000px; border-radius:10px; height:500px; ">
                     <a title="close" style="text-align:right; font-size:20px; color:red; float:right; margin-right:10px" id="closequickview" href="#">x</a>	
                     <object type="text/html" id='quickViewObj' style=" background:white; margin:0 auto;  width:1000px; border-radius:10px; height:500px; "></object>
                  </div>
                 </section>
    <div style="clear: both">
    </div>
    <div class="compare_product">
		<div class="floating-banner">
             <div class="" id="compare_list">
                    <ul id="compareProductList">
                    </ul>
                          
                 <div class="comparebutton">  <a id="compareButton" href="javascript:void(0)" title="Go to compare page" class="button_1">Compare Now </a>
                            <a id="close-compare" href="javascript:void(0)" title="Remove all product in compare list">Remove all</a>
                  </div>

             </div>

		</div>
		<span class="arrow-left" title="slide">X</span>
		<span class="arrow-right" title="slide">Compare</span>
</div>
                </div>
    <script>
        jQuery(document).ready(function () {
            jQuery('.compare_product span').click(function (e) {
                e.stopPropagation();
                cmpSlide();
            });
        });

        function cmpSlide() {
            //console.log('1');

            if (jQuery('.compare_product').css('width') == '0px') {
                console.log('2');
                jQuery('.arrow-right').fadeOut('fast');
                jQuery('.arrow-left').fadeIn('fast');
                jQuery('.compare_product').animate({
                    'width': '215px'
                }, 0);
            } else {
                console.log('3');
                jQuery('.arrow-right').fadeIn('fast');
                jQuery('.arrow-left').fadeOut('fast');
                jQuery('.compare_product').animate({
                    'width': '0px'
                }, 0);
            }
        }
    </script>
  
         <input type="hidden" value='<%=PType%>' id="PType" />
         <input type="hidden" value="1" name="pageNo" id="pageNo"/>
         <input type="hidden" id="PBrand" value='<%=Request.Params["PBrand"] %>' />
         <input type="hidden" id="range" value="" />
         <input type="hidden" id="sortPrice" value="" />
         <input type="hidden" id="error" value="false" />
         <!-- End -->
          <%}%>
         <%=Footer %>
    
   </body>
</html>

