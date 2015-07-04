<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckoutPage1.aspx.cs" Inherits="sfloor_pages_checkoutPage1" %>
<%@ Register src="~/sfloor/pages/CheckoutHeader.ascx" tagname="checkoutHeader" tagprefix="ch" %>
<%@ Register src="~/sfloor/pages/CheckoutOrderPanal.ascx" tagname="checkoutOP" tagprefix="cp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head>
      <title>Check-out Step one</title>
      <style type="text/css">
         #checkout_overlay_form
         {
         background: WHITE;
         z-index: 100000;
         }
         .checkout_background_overlay
         {
         position: fixed;
         left: 0px;
         top: 0px;
         width: 100%;
         height: 100%;
         z-index: 100000;
         background: black;
         opacity: 0.9;
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
         background: black;
         opacity: 0.8;
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
         color: #FA787E; font-size:12px;
         }
         .error{color:red}
         .button input.disabled{background-color:Blue}
      </style>
   </head>
   <body ng-app='registration' ng-controller='regCtrl'>
      <ch:checkoutHeader runat="server" ID="chHeader"/>
      <script type="text/javascript">
          function showShipping(v) {
              if (v == 1) {
                  window.location = path + "checkout-step-2"
                  return;
              }
              if ($("[name='uType']:checked").val() == "guest") {
                  window.location = path + "checkout-step-2"
              } else if ($("[name='uType']:checked").val() == "regular") {
                  $("#checkout_overlay_form").fadeIn(1000);
                  $(".checkout_background_overlay").fadeIn(500);
                  popup();
              } else { $("#errorSpan").text("Make the selection.").css({ display: block }); }
          }
          $(window).bind('resize', popup);
          function popup() {
              if (!$("#checkout_overlay_form").is(':visible')) {
                  return;
              }
              $("#checkout_overlay_form").css({
                  left: ($(window).width() - $('#checkout_overlay_form').width()) / 2,
                  top: ($(window).width() - $('#checkout_overlay_form').width()) / 7,
                  position: 'absolute'
              });
          }
      </script>
      <%if(!MFO.Commom.CommonUtil.DT.isEmptyOrNull(cartDT)){ %>
      <div class="ckeckoutmain_sec">
         <div class="ckeckoutmain">
            <ul class="tabs">
               <li class='selected'><a href="#view1">Email Or Login <span>1</span></a></li>
               <li><a ">Shipping <span>2</span></a></li>
               <li><a >Payment <span>3</span></a></li>
            </ul>
            <div class="tabcontents">
               <span id='errorSpan' style='color: red'></span>
               <% if (Session[MFO.Constants.Constant.Session.LOGED_IN_EMAIL] == null)
                  { %>
               <p>
                  <input type="radio" name="uType" value='guest' />&nbsp;&nbsp;Continue without password
                  <br>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i><small>(You do not need a password)</small></i>
               </p>
               <p>
                  <input type="radio" id="checkoutlogin" name="uType" value='regular' onclick='showShipping()'/>&nbsp;&nbsp;I
                  have a Fab N Fresh account and password
                  <br>
                  &nbsp;&nbsp; &nbsp;&nbsp;<i><small>Sign in to your account and checkout faster</small></i>
               </p>
               <input class="btn_shipinfo" onclick='showShipping(0)' style="float: right" type="button"
                  value="CONTINUE" />
               <%}
                  else
                  { %>
               You are already logged in as '<%=Session[MFO.Constants.Constant.Session.LOGED_IN_EMAIL] %>'.
               <input class="btn_shipinfo" type="button" onclick='showShipping(1)' value="CONTINUE">
               <br>
               <small>If you wish to login with another account you can <a href='<%=ConfigUtil.hostURL()%>logout'>
               click here</a> to logout</small>
               <%} %>
            </div>
         </div>
         <section>
            <cp:checkoutOP runat="server" ID="checkOrderPanal"/>
          </section>
      </div>
      <footer>
         <div class="chkout_footer">
            <div class="chkout_footsec">
               <div><span><a href="#">About us</a></span>|<span><a href="#">Help</a></span>|<span><a href="#">Privacy</a></span>|<span><a href="#">Contact</a></span>|
                  <span><a href="#">Terms & Conditions</a></span>
               </div>
               <div><span>© 2014 <a href="http://fabnfresh.com/">fabnfresh.com</a>. ALL RIGHTS RESERVED.</span></div>
            </div>
         </div>
      </footer>
      <div class="checkout_background_overlay" style="display: none;"></div>
      <section>
         <div  id="checkout_overlay_form" style="display:none" class="loginregisterform" >
            <a title="close" class="x" id="close" href="#" >x</a>		
            <div class="loginform">
               <div class="headtitle"><span>Login</span></div>
               <form name='loginForm' class='css-form' >
                  <p ng-show="login.errors.system" class="help-block" id='P2'> {{login.errors.system}}.</p>
                  <table>
                     <tr>
                        <th>Username:</th>
                        <td>
                           <input type="email" name='logEmail' ng-keyup="validateEmail()" placeholder="e.g. example@example.com" required  ng-model="login.email" 
                              ng-change="removelogErro('email')">
                           <p ng-show="loginForm.logEmail.$invalid && !loginForm.logEmail.$pristine" class="help-block">Email is not valid.</p>
                           <p ng-show="login.errors.email" class="help-block" id='P4'> {{login.errors.email}}.</p>
                           <p ng-show="login.errors.info" style="color:Green" id='P3'> {{login.errors.info}}.</p>
                        </td>
                     </tr>
                     <tr>
                        <th>Password:</th>
                        <td>
                           <input type="Password" name='logPwd' placeholder="Password" required  ng-model="login.pwd" ng-minlength="8" ng-maxlength="20" 
                              ng-change="removelogErro('pwd')">
                           <p ng-show="loginForm.logPwd.$invalid && !loginForm.logPwd.$pristine" class="help-block">Password required length between 8 to 20</p>
                           <p ng-show="login.errors.pwd" class="help-block" id='errlogPwd'> {{login.errors.pwd}}.</p>
                        </td>
                     </tr>
                     <tr>
                        <th></th>
                        <td>
                           <p id="fgt_clk_hre" ><a class="fgtclk">Forgot password? click here</a></p>
                        </td>
                     </tr>
                     <tr>
                        <th></th>
                        <td> <input type="button" value="Login" ng-click="login()" ng-disabled="loginForm.$invalid"></td>
                     </tr>
                  </table>
               </form>
            </div>
            <div class="midline"></div>
            <div class="registerform">
               <div class="headtitle"><span>Register</span></div>
               <form name='regForm' class='css-form' ng-submit="register()">
                  <p ng-show="user.errors.system" class="help-block" id='errSystem'>{{user.errors.system}}.</p>
                  <table>
                     <tr>
                        <th>Email ID:</th>
                        <td>
                           <input type="email" name='email'  ng-keyup="validateRegEmail()" placeholder="e.g. example@example.com" required  ng-model="user.email" ng-change="removeErro('email')">
                           <p ng-show="regForm.email.$invalid && !regForm.email.$pristine" class="help-block">Email is not valid.</p>
                           <p ng-show="user.errors.email" class="help-block" id='errUsrEmail'> {{user.errors.email}}.</p>
                           <p ng-show="user.errors.info" style="color:Green" id='P5'> {{user.errors.info}}.</p>
                        </td>
                     </tr>
                     <tr>
                        <th>Password:</th>
                        <td>
                           <input type="password" name='pwd' ng-change="removeErro('pwd')" placeholder="Password" required ng-model="user.pwd" ng-minlength="8" ng-maxlength="20">
                           <p ng-show="regForm.pwd.$invalid && !regForm.pwd.$pristine" class="help-block">Password required length between 8 to 20</p>
                           <p ng-show="user.errors.pwd" class="help-block" id='errPwd'> {{user.errors.pwd}}.</p>
                        </td>
                     </tr>
                     <tr>
                        <th>Mobile:</th>
                        <td>
                           <input type="text" name='mobile' ng-pattern="/[0-9]/" placeholder="Mobile" ng-model="user.mobile" ng-minlength="10" ng-maxlength="10">
                           <p ng-show="regForm.mobile.$invalid && !regForm.mobile.$pristine" class="help-block">Mobile no length should be 10 digit</p>
                           <p ng-show="user.errors.mobile" class="help-block" id='errMobile'> {{user.errors.mobile}}.</p>
                        </td>
                     </tr>
                  
                     <tr>
                        <td colspan="2" class="offercheck"><input type="checkbox" name="checkbox" ng-model="user.newsLts">&nbsp;&nbsp;I want to receive news and special offers</td>
                     </tr>
                     <tr>
                        <th></th>
                        <td><input type="button" value="Signup" ng-click="register()" ng-disabled="regForm.$invalid"></td>
                     </tr>
                  </table>
               </form>
            </div>
         </div>
      </section>
      <div class="fgt_background_overlay" style="display: none;"></div>
      <section>
         <div  id="fgt_overlay_form" style="display:none;" class="loginregisterform" ng-app='registration' ng-controller='regCtrl'>
            <a title="close" class="x" id="fgt_close" href="#" >x</a>		
            <div class="loginform">
               <div class="headtitle"><span>Forgot Password</span></div>
               <form name='loginForm' class='css-form fgt_form ' >
                  <p ng-show="login.errors.system" class="help-block" id='P6'> {{login.errors.system}}.</p>
                  <table>
                     <tr>
                        <td>Enter your email address</td>
                     </tr>
                     <tr>
                        <td>
                           <input type="email" name='logEmail' ng-keyup="validateEmail()" placeholder="e.g. example@example.com" required  ng-model="login.email" 
                              ng-change="removelogErro('email')">
                           <p ng-show="loginForm.logEmail.$invalid && !loginForm.logEmail.$pristine" class="help-block">Email is not valid.</p>
                           <p ng-show="login.errors.email" class="help-block" id='P7'> {{login.errors.email}}.</p>
                           <p ng-show="login.errors.info" style="color:Green" id='P8'> {{login.errors.info}}.</p>
                        </td>
                     </tr>
                     <tr>
                        <td>
                           <p>We'll send you a link to reset your password.</p>
                        </td>
                     </tr>
                     <tr>
                        <td><input type="button" value="Send" class="button" ng-click="login()" ng-disabled="loginForm.$invalid"></td>
                     </tr>
                     <tr>
                        <td>
                           <p><a id="logsign">Signup / Login</a></p>
                        </td>
                     </tr>
                  </table>
               </form>
            </div>
         </div>
      </section>
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
         <footer>
         <div class="chkout_footer">
            <div class="chkout_footsec">
               <div><span><a href="#">About us</a></span>|<span><a href="#">Help</a></span>|<span><a href="#">Privacy</a></span>|<span><a href="#">Contact</a></span>|
                  <span><a href="#">Terms & Conditions</a></span>
               </div>
               <div><span>© 2014 Fab N Fresh.COM. ALL RIGHTS RESERVED.</span></div>
            </div>
         </div>
      </footer>
      <%} %>
   </body>
</html>