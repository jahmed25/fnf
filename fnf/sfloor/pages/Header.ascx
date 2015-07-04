<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Header" %>
<%@ Register Src="Menu.ascx" TagName="MenuUserControl" TagPrefix="m" %>
<%@ Import Namespace="MFO.Constants" %>
<!-- MENU -->

<div class="header-wrapper">
    <div class="top_bg">
        <div class="container">
            <div class="header_top row">
                <div class="top_left col-md-4 col-sm-4 col-xs-12">
                    <h2><a href="#">(+91) 7042121501 / 02</a></h2>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();">Free Shipping above order of Rs. 299/-. </marquee>
                </div>
                <div class="top_right col-md-4 col-sm-4 col-xs-12">
                    <ul class="links">
                        <%if (Session[Constant.Session.LOGED_IN_USER_ID] == null)
                          { %>
                        <li id="pop"><a href="#" id="log" title="Login and Create account">LOG IN / REGISTER</a></li>
                        <%if (Total != "")
                          {%>
                        <li><a href='<%=ConfigUtil.hostURL() %>check-out' title="Checkout">CHECKOUT</a></li>
                        <%} %>
                        <li><a href='<%=ConfigUtil.hostURL() %>sfloor/pages/faqs.aspx'>FAQ</a></li>
                        <%}
                          else
                          { %>
                        <li>
                            <a href='<%=ConfigUtil.hostURL() %>Logout' title="Logout">LOGOUT</a>
                        </li>
                        <li id="acc_sec">
                            <a href="<%=ConfigUtil.hostURL() %>Account" title="My Account">MY ACCOUNT<i class="arrow-down"></i></a>
                            <ul class="acc_menu">
                                <li><a href="<%=ConfigUtil.hostURL() %>Account?tab=profile">VIEW PROFILE</a></li>
                                <li><a href="<%=ConfigUtil.hostURL() %>Account?tab=order-details">ORDER TRACKING</a></li>
                                <li><a href="<%=ConfigUtil.hostURL() %>Account?tab=address-details">VIEW ADDRESS</a></li>
                                <li><a href="<%=ConfigUtil.hostURL() %>Account?tab=change-password">CHANGE PASSWORD</a></li>
                                <li><a href="<%=ConfigUtil.hostURL() %>Account?tab=credit">CREDIT</a></li>
                                <li><a href="<%=ConfigUtil.hostURL() %>Account?tab=profile">STATUS</a></li>
                                <li><a href="<%=ConfigUtil.hostURL() %>fav-items">WISHLIST</a></li>
                                <li><a href="<%=ConfigUtil.hostURL() %>fAdd-To-Cart">CART</a></li>
                            </ul>
                        </li>
                        <%if (Total != "")
                          {%>
                        <li><a href='<%=ConfigUtil.hostURL() %>check-out' title="Checkout">CHECKOUT</a></li>
                        <%} %>
                        <li><a href='<%=ConfigUtil.hostURL() %>sfloor/pages/faqs.aspx'>FAQ</a></li>
                        <%} %>
                    </ul>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <div class="header_bg">
        <div class="container">
            <div class="header">
                <div class="logo col-md-3 col-sm-3 col-xs-6">
                    <a href='<%=ConfigUtil.hostURL() %>Home' title="Feb N Fresh" class="logo"><strong>Feb N Fresh</strong>
                        <img src='<%=ConfigUtil.StaticPath() %>new-images/newlogo.png' alt="Feb N Fresh floor"></a>
                </div>
              <div class="col-md-3 col-sm-3 col-xs-6" style="float: right">
                    <%--addtocart--%>
                    <div class="top-cart-wrapper add-to-carttp">
                        <div name='cartContainer' class="top-cart-contain">
                            <div class="icon-cart-big">
                                <a class="cart-url" href='<%=ConfigUtil.hostURL() %>Add-To-Cart'>
                                    <span class="atccount"><b id='cCount'><%=CartDT.Rows.Count%></b></span></a>
                            </div>
                            <!--<span class="top-cart-icon"></span>-->
                            <span class="top-cart-title">My Cart </span><span class="cart-arrow"></span>
                            <div style="display: none;" class="top-cart-content" id='cartDiv'>
                                <%if (CartDT.Rows.Count > 0)
                                  { %>
                                <div>
                                        <div class="headnav-popup">Total :<span class="price"><%=Total%></span>&nbsp;&nbsp;<a href="<%=ConfigUtil.hostURL() %>Add-To-Cart" style='color: blue'>View ALL</a>&nbsp;&nbsp;<a style='color: blue' href="<%=ConfigUtil.hostURL() %>Checkout">Checkout</a> <a href="#" style="float: right; color: red" onclick="clearCart()">Clear All</a></div>
                                    
                                    <%for (int i = 0; i < CartDT.Rows.Count; i++)
                                      { %>
                                    <div class="wishlist-content">

                                        <a class="imglist" href='<%=ConfigUtil.hostURL() %>Add-To-Cart' title='<%=CartDT.Rows[i]["SKUName"]%>'>
                                            <img src='<%=ConfigUtil.getServerPath() %><%=CartDT.Rows[i]["PathInternaldetailsSmallImage"] %>' /></a>
                                        <div class="main-cont">
                                            <span class="cross-del" title="Delete item" sku='<%=CartDT.Rows[i]["SKU"]%>' cart></span>
                                            <p class="empty" title="<%=CartDT.Rows[i]["SKUName"]%>"><%=CartDT.Rows[i]["SKUName"]%></p>
                                            <p><span>Brand</span><span class="price">Rs.   <%=CartDT.Rows[i]["SKUBrand"]%></span></p>
                                            <p><span>Unit Price</span><span class="price">Rs.   <%=CartDT.Rows[i]["UNIT_PRICE"]%></span></p>
                                            <p><span>Quantity</span> <span class="price"><%=CartDT.Rows[i]["QTY"]%></span></p>
                                            <p><span>SubTotal</span> <span class="price">Rs. <%=CartDT.Rows[i]["TOTAL"]%></span></p>
                                        </div>
                                    </div>
                                    <%} %>
                                </div>
                                <%}
                                  else
                                  { %>
                                <div class="empty_item">
                                    <span>Your Cart is Empty</span>
                                </div>
                                <%} %>
                            </div>
                        </div>
                    </div>
                    <%--end--%>

                    <%--wishlist--%>
                    <div class="top-cart-wrapper wishlist-cart">
                        <div class="top-cart-contain" name='WLContainer'>

                            <div class="icon-wishlist-big">
                                <a class="cart-url" href='<%=ConfigUtil.hostURL() %>fav-items'><span class="wlcount"><b id='favCount'><%=FavDT.Rows.Count%></b></span></a>
                            </div>
                            <!--<span class="top-cart-icon"></span>-->
                            <span class="top-cart-title-wishlist">Wishlist</span><span class="cart-arrow"></span>
                            <div style="display: none;" class="top-cart-content" id='wishListDiv'>
                                <%if (FavDT.Rows.Count > 0)
                                  { %>

                                <div id='wishContent' id="wlContent" style="width: 100%">
                                    <div class="headnav-popup"><a href="<%=ConfigUtil.hostURL() %>fav-items" style='color: blue'>View ALL</a>
                                    <a href="#" style="float: right; color: red" onclick="clearFav()">Clear All</a></div>
                                    <%for (int i = 0; i < FavDT.Rows.Count; i++)
                                      { %>
                                    <div class="wishlist-content">
                                        <a class="imglist" href='<%=ConfigUtil.hostURL() %>?htm=<%=FavDT.Rows[i]["SKUCode"]%>' title='<%=FavDT.Rows[i]["SKUName"]%>'>
                                            <img src='<%=ConfigUtil.getServerPath() %><%=FavDT.Rows[i]["PathInternaldetailsSmallImage"] %>' /></a>
                                        <div class="main-cont">
                                            <span class="cross-del" title="Delete item" sku='<%=FavDT.Rows[i]["SKUCode"]%>' wl></span>
                                            <p class="empty"><%=FavDT.Rows[i]["SKUName"]%></p>
                                            <p><span>Price</span><span class="price">Rs. <%=FavDT.Rows[i]["SpecialPrice"]%></span></p>
                                            <p><span>Brand</span><span class="price"> <%=FavDT.Rows[i]["SKUBrand"]%></span></p>
                                            <p><a class="wishbutton" href='<%=ConfigUtil.hostURL() %>?htm=<%=FavDT.Rows[i]["SKUCode"]%>' title='Buy Now'>Buy Now</a></p>
                                        </div>
                                    </div>
                                    <%} %>
                                </div>
                                <%}
                                  else
                                  {%>
                                <div class="empty_item"><span>Your Wishlist Is Empty</span></div>
                                <%} %>
                            </div>
                        </div>

                    </div>
                   <%--end--%>
                </div>
            <div class="search col-md-6 col-sm-6 col-xs-12">
                <input id="search" name="q" onfocus="if(this.value == 'Search Here...') { this.value = ''; }"
                    onblur="this.value=!this.value?'Search Here...':this.value;" value="Search Here..."
                    class="input-text" maxlength="128" type="text" />
                <button type="submit" title="Search" class="button" searchbtn></button>
                <div id="search_autocomplete" class="search-autocomplete">
                </div>
                
            </div>    
              
            
                <div class="clearfix"></div>

            <!-- start header menu -->
        </div>
    </div></div>
</div>
<m:MenuUserControl ID="menu" runat="server" />
