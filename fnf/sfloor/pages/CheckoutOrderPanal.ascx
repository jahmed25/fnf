<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CheckoutOrderPanal.ascx.cs" Inherits="OrderSummary" %>

<script>
    $("[qtyUpdate]").on("change", function () {
        var sku = $(this).attr('qtyUpdate');
        var qty = $(this).val();
        $.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx?action=updateQty', data: { sku: sku, qty: qty} })
					.success(function (msg) {
					    window.location = path + 'check-out';
					});
    });
    $("[remove]").on("click", function () {
        var sku = $(this).attr('sku')
        $.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx?action=removeFromCart', data: { sku: sku} })
					.success(function (msg) {
					    window.location = path + 'check-out';
					});

    });
</script>
<div class="order-summary">
    <div class="order-summary_head">Order Summary</div>
   <%if (!MFO.Commom.CommonUtil.DT.isEmptyOrNull(cartDT))
     { %>
    <table><thead class="header">
            <tr>
                <th>Product</th>
                <th>Name</th>
                <th>Brand</th>
                <th>Scale</th>
             	<th>Qty</th>
                <th class="price-col">Price</th>
            </tr></thead>
		<!--Loop content-->
		 <%for (int i = 0; i < cartDT.Rows.Count; i++)
        {    %>
        <%if (invDic.ContainsKey(cartDT.Rows[i]["SKU"] + "")){ %>
            <tr>
                <td colspan='3'> <span style="color:Red"><%=invDic[cartDT.Rows[i]["SKU"] + ""]%> </span></td>
                <td>
                    <a class='class="rem_sfl"'href='#' remove sku='<%=cartDT.Rows[i]["SKU"] %>'>Remove</a>
                </td>          
            </tr>
        <%} %>
		<tr class="order_cont">
                <td class="image_sec"><img alt="" src="<%=ConfigUtil.getServerPath() %><%=cartDT.Rows[i]["PathInternaldetailsSmallImage"] %>"></td>
                <td class="name"><%=cartDT.Rows[i]["SKUName"]%></td>
                <td class=""><%=cartDT.Rows[i]["SKUBrand"]%></td>
                
                <td class=""> 
                <%if (!MFO.Utils.StringUtil.isNullOrEmpty(cartDT.Rows[i]["Size"] + ""))%>
                     <%=cartDT.Rows[i]["Size"]%> <%=cartDT.Rows[i]["SizeDataType"]%> 
                </td>
                
                <td class="">
                    <%if (invDic.ContainsKey(cartDT.Rows[i]["SKU"] + "")){ %>
                      <input type='text' maxlength='3' size='3' qtyUpdate='<%=cartDT.Rows[i]["SKU"]%>' value='<%=cartDT.Rows[i]["QTY"]%>' />
                    <%} else{ %>
                        <%=cartDT.Rows[i]["QTY"]%>
                     <%} %>
                 </td>
               
                <td class=""><%=cartDT.Rows[i]["TOTAL"]%></td>
        </tr>
        <%} %>
        <!--End loop-->
		<tr  class="subtotal">
                <td colspan="5">Subtotal</td>
                 <td><%=subTotal%></td>
            </tr>
            <tr class="subtotal">
              <td colspan="5" class="">Cash on Delivery Charges</td>
                    <td class="">Available</td>
			</tr>
		<%--	<tr class="subtotal">
			        <td colspan="5" class="">Shipping Charges</td>
                    <%if (ConfigUtil.getValue("ShippigCharge") == "0"){ %>
                        <td class="shipping">FREE SHIPPING</td>
                    <%}else{ %>
                        <td class="shipping"><%=ConfigUtil.getValue("ShippigCharge")%></td>
                    <%} %>
			</tr> --%>
            <tr class="total">
                <td colspan="5">Total</td>
                <td class="sel-total">Rs.<%=total%></td>
            </tr>
    </table>
    <%}else{ %>
        <p style="color:red">Your Cart is empty</p>        
    <%} %>
	</div>