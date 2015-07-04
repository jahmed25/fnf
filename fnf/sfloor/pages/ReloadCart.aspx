<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReloadCart.aspx.cs" Inherits="sfloor_pages_ReloadCart" %>
<div name='cartContainer' id="mini_cart_block">
   <div class="icon-cart-big">
      <a class="cart-url" href='<%=ConfigUtil.hostURL() %>Add-To-Cart'>
      <span class="atccount"><b id='cCount'><%=cartDT.Rows.Count%></b></span></a>
   </div>
      <!--<span class="top-cart-icon"></span>-->
      <span class="top-cart-title" >My Cart </span><span class="cart-arrow"></span>
      <div style="display: none;" class="top-cart-content" id='cartDiv'>
         <%if (cartDT.Rows.Count > 0)
            { %>
    <div class="cartheader">Total :<span class="price"><%=total%></span>&nbsp;&nbsp;<a href="<%=ConfigUtil.hostURL() %>Add-To-Cart" style='color:blue'>View ALL</a>&nbsp;&nbsp;<a  style='color:blue' href="<%=ConfigUtil.hostURL() %>Checkout">Checkout</a> <a href="#" style="float:right;color:red" onclick="clearCart()">Clear All</a></div>     
         <%for (int i = 0; i < cartDT.Rows.Count; i++)
            { %>
         <div class="wishlist-content">
            <a class="imglist" href='<%=ConfigUtil.hostURL() %>Add-To-Cart' title='<%=cartDT.Rows[i]["SKUName"]%>'>
            <img  src='<%=ConfigUtil.getServerPath() %><%=cartDT.Rows[i]["PathInternaldetailsSmallImage"] %>' /></a>
            <div class="main-cont">
              <span class="cross-del" title="Delete item" sku='<%=cartDT.Rows[i]["SKU"]%>' cart></span> 
               <p class="empty"><%=cartDT.Rows[i]["SKUName"]%></p>
               <p><span>Brand</span><span class="price"> <%=cartDT.Rows[i]["SKUBrand"]%></span></p>
               <p><span>Unit Price</span><span class="price">Rs.   <%=cartDT.Rows[i]["UNIT_PRICE"]%></span></p>
               <p><span>Quantity</span> <span class="price">  <%=cartDT.Rows[i]["QTY"]%></span></p>
               <p><span>SubTotal</span> <span class="price">Rs. <%=cartDT.Rows[i]["TOTAL"]%></span></p>
            </div>
         </div>
         <%} %>
         <%}else{ %>
                   <div class="empty_item"> <span>Your Cart is Empty</span></div>
                         
         <%} %>
      </div>
   </div>