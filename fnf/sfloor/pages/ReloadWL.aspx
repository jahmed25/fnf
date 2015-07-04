<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReloadWL.aspx.cs" Inherits="sfloor_pages_ReloadeWL" %>
                                <div id="mini_cart_block" name='WLContainer'>
                                    <div class="icon-wishlist-big">

                                       <a class="cart-url" href='<%=ConfigUtil.hostURL() %>fav-items'><span class="wlcount"><b id='favCount'><%=favDT.Rows.Count%></b></span></a>
                                    </div>
                                       <!--<span class="top-cart-icon"></span>-->
                                       <span class="top-cart-title-wishlist">Wishlist</span><span class="cart-arrow"></span>
                                       <div style="display: none;" class="top-cart-content" id='wishListDiv'>
                                          <%if(favDT.Rows.Count>0){ %>
                                          <div class="headnav-popup"><a href="<%=ConfigUtil.hostURL() %>fav-items" style='color:blue'>View ALL</a> 
                                             <a href="#" style="float:right;color:red" onclick="clearFav()">Clear All</a>
                                          </div>
                                          <div id='wishContent' id="wlContent">
                                             <%for (int i = 0; i < favDT.Rows.Count; i++)
                                                { %>
                                             <div class="wishlist-content" >
                                                <a class="imglist" href='<%=ConfigUtil.hostURL() %>?htm=<%=favDT.Rows[i]["SKUCode"]%>' title='<%=favDT.Rows[i]["SKUName"]%>'>
                                                <img  src='<%=ConfigUtil.getServerPath() %><%=favDT.Rows[i]["PathInternaldetailsSmallImage"] %>' /></a>
                                                <div class="main-cont">
                                                   <span class="cross-del" title="Delete item" sku='<%=favDT.Rows[i]["SKUCode"]%>' WL></span> 
                                                   <p class="empty"><%=favDT.Rows[i]["SKUName"]%></p>
                                                   <p><span>Price</span><span class="price">Rs. <%=favDT.Rows[i]["SpecialPrice"]%></span></p>
                                                   <p><span>Brand</span><span class="price"> <%=favDT.Rows[i]["SKUBrand"]%></span></p>
                                                   <p><a class="wishbutton" href='<%=ConfigUtil.hostURL() %>?htm=<%=favDT.Rows[i]["SKUCode"]%>' title='Buy Now'>Buy Now</a></p>
                                                </div>
                                             </div>
                                             <%} %>
                                          </div>
                                          <%}else {%>
                                                    <div class="empty_item"> <span>Your WishList Is Empty</span></div>
                                          <%} %>
                                       </div>
                                    </div>
        