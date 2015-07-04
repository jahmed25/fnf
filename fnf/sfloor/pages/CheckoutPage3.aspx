<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckoutPage3.aspx.cs" Inherits="sfloor_pages_checkoutPage3" %>
<%@ Register src="~/sfloor/pages/CheckoutHeader.ascx" tagname="checkoutHeader" tagprefix="ch" %>
<%@ Register src="~/sfloor/pages/CheckoutOrderPanal.ascx" tagname="checkoutOP" tagprefix="cp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head>
      <title>Check-out Step three</title>
   
   </head>
   <body>
      <ch:checkoutHeader runat="server" ID="chHeader"/>
     <script>
         function submitForm(valid) {
             $.ajax({
                 type: "POST",
                 url: path + 'sfloor/pages/AjaxService.aspx?action=addShipping',
                 data: $('#cForm').serialize(),
                 success: function (data) {
                     if (data.status) {
                         thirdTab();
                         var city = $('#cityTxt').val();
                         var state = $('#stateTxt').val();
                         var scope = angular.element($("body")).scope();
                         scope.$apply(function () {
                             scope.ship.city = city;
                             scope.ship.state = state;
                         });
                     } else {
                         alert('not added');
                     }
                 },
                 error: function (msg) {
                     alert(msg.status + ' ' + msg.statusText);
                 }
             });
         }
      </script>
      <%if (!MFO.Commom.CommonUtil.DT.isEmptyOrNull(cartDT))
        { %>
      <div class="ckeckoutmain_sec">
         <div class="ckeckoutmain">
            <ul class="tabs">
               <li><a href="<%=ConfigUtil.hostURL() %>checkout-step-1">Email Or Login <span>1</span></a></li>
               <li><a href="<%=ConfigUtil.hostURL() %>checkout-step-2" >Shipping <span>2</span></a></li>
               <li class='selected'><a >Payment <span>3</span></a></li>
            </ul>
            <div class="tabcontents">
              
                    <div class="chosoe_pmt" style='display:block'>
                        <span class="payemnt_sec_head">Choose your mode of payment</span>
                        <p>
                            <input type="radio" id="cod" name="cod" selected><label for="cod">Cash-On-Delivery</label></p>
                        <p>
                            <input type="radio" id="nb" name="cod" disabled><label for="nb">Net Bankiing</label></p>
                        <p>
                            <input type="radio" id="debitcard" name="cod" disabled><label for="debitcard">Debit Cart & ATM</label></p>
                        <p>
                            <input type="radio" id="creditcard" name="cod" disabled><label for="creditcard">Credit Card</label></p>
                        <a class="btn_shipinfo" href='<%=ConfigUtil.hostURL() %>doPaymint'  title="Confirm Order">Confirm Order</a>
                    </div>
                    <div class="cnfrm_add" style='display:block'>
                         <p>Shipping Address<a class="edit_btn" title="Edit shipping details" href='<%=ConfigUtil.hostURL() %>checkout-step-2'>Edit</a></p>
                         <ul><li> <%=shipDT.Rows[0]["NAME"]%> </li>
                        <li> <%=shipDT.Rows[0]["ADDRESS"]%>,<%=shipDT.Rows[0]["CITY"]%></li>
                        <li><%=shipDT.Rows[0]["STATE"]%> <%=shipDT.Rows[0]["PIN"]%></li>
                         <li><%=shipDT.Rows[0]["EMAIL"]%></li>
                         <li><%=shipDT.Rows[0]["MOBILE"]%></li>
                         </ul>
                          
                    </div>
               
            </div>
           
             
         </div>
         <section>
            <cp:checkoutOP runat="server" ID="checkOrderPanal"/>
           </section>
      </div>
      <%}else
        { %>
        <div class="ckeckoutmain_sec">
         <div class="ckeckoutmain">
         <div class="tabcontents">
         <h3 style="color:Red">You Cart Is Empty!!</h3> <a href='<%=MFO.Utils.ConfigUtil.hostURL() %>Home'>Click here to Shopping continue.</a></span>
         <br />
            <br />
            <br />
            <br />
            <br />
            <br />
         <br /> 
         </div>
         </div>
         </div>
      <%} %>
      <footer>
         <div class="chkout_footer">
            <div class="chkout_footsec">
               <div><span><a href="#">About us</a></span>|<span><a href="#">Help</a></span>|<span><a href="#">Privacy</a></span>|<span><a href="#">Contact</a></span>|
                  <span><a href="#">Terms & Conditions</a></span>
               </div>
               <div><span>© 2015 <a href="http://www.fabnfresh.com">fabnfresh.com</a>. ALL RIGHTS RESERVED.</span></div>
            </div>
         </div>
      </footer>
      
   </body>
</html>
