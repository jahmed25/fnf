<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckoutPage2.aspx.cs" Inherits="sfloor_pages_checkoutPage2" %>
<%@ Register src="~/sfloor/pages/CheckoutHeader.ascx" tagname="checkoutHeader" tagprefix="ch" %>
<%@ Register src="~/sfloor/pages/CheckoutOrderPanal.ascx" tagname="checkoutOP" tagprefix="cp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head>
      <title>Check-out Step two</title>
   
   </head>
   <body ng-app='registration' ng-controller='regCtrl' >
      <ch:checkoutHeader runat="server" ID="chHeader"/>
       <%if(!MFO.Commom.CommonUtil.DT.isEmptyOrNull(shipDT)){ %>
           <script type="text/javascript">
               $(document).ready(function () { 
                   var scope = angular.element($("body")).scope();
                   scope.$apply(function () {
                       scope.ship = { city: '<%=shipDT.Rows[0]["CITY"] %>',
                           state: '<%=shipDT.Rows[0]["STATE"] %>',
                           email: '<%=shipDT.Rows[0]["EMAIL"] %>',
                           fName: '<%=shipDT.Rows[0]["NAME"] %>',
                           phone: '<%=shipDT.Rows[0]["MOBILE"] %>',
                           pin: '<%=shipDT.Rows[0]["PIN"] %>',
                           address: '<%=shipDT.Rows[0]["ADDRESS"] %>'
                       }
                   });
           });
           </script>
        <%} %>
      <script type="text/javascript">
               $(document).ready(function () { 

          $("#pinTxt").autocomplete({
	            source: function (request, response) {
	                $.ajax({
	                    type: "POST",
	                    url: path + 'sfloor/pages/AjaxService.aspx?action=getPin',
	                    data: { startWith: request.term },
	                    success: function (data) {
	                        response(data);
	                    },
	                    error: function (msg) {
	                        alert(msg.status + ' ' + msg.statusText);
	                    }
	                })
	            },
	            select: function (event, ui) {
	                $.ajax({
	                    type: "POST",
	                    url: path + 'sfloor/pages/AjaxService.aspx?action=getCityState',
	                    data: { pin: ui.item.label },
	                    success: function (data) {
                            var scope = angular.element($("body")).scope();
                               scope.$apply(function () {
                                   scope.ship.city = data.city;
                                   scope.ship.state= data.state;
                               });
	                    },
	                    error: function (msg) {
	                        alert(msg.status + ' ' + msg.statusText);
	                    }
	                })
	            }
	        });
	        $("#cityTxt").autocomplete({

	            source: function (request, response) {
                     $.ajax({
	                    type: "POST",
	                    url: path + 'sfloor/pages/AjaxService.aspx?action=getCity',
	                    data: { startWith: request.term },
	                    success: function (data) {
	                        response(data);
	                    },
	                    error: function (msg) {
	                        alert(msg.status + ' ' + msg.statusText);
	                    }
	                })

	            }
	        });
	        $("#stateTxt").autocomplete({
	            source: function (request, response) {
	                $.ajax({
	                    type: "POST",
	                    url: path + 'sfloor/pages/AjaxService.aspx?action=getState',
	                    data: { startWith: request.term },
	                    success: function (data) {
	                        response(data);
	                    },
	                    error: function (msg) {
	                        alert(msg.status + ' ' + msg.statusText);
	                    }
	                });
	            }
	        });
	    });
	    function submitForm() {
	       
	            $.ajax({
	                type: "POST",
	                url: path + 'sfloor/pages/AjaxService.aspx?action=addShipping',
	                data: $('#cForm').serialize(),
	                success: function (data) {
	                    if (data.status) {
	                        window.location = path + "checkout-step-3"
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
      <%if(!MFO.Commom.CommonUtil.DT.isEmptyOrNull(cartDT)){ %>
      <div class="ckeckoutmain_sec">
         <div class="ckeckoutmain">
            <ul class="tabs">
               <li><a href="<%=ConfigUtil.hostURL() %>checkout-step-1">Email Or Login <span>1</span></a></li>
               <li class='selected'><a >Shipping <span>2</span></a></li>
               <li><a>Payment <span>3</span></a></li>
            </ul>
            <div class="tabcontents">
              
                    		<h1> Shipping Information</h1>
			<form id='cForm' name="cForm" novalidate > 
			<table>
				<tr>
					<th>Email Id*</th>
					<td>
						<input type="email" name="email" required ng-model="ship.email">
						<small class="error" ng-show="cForm.email.$error.required && !cForm.email.$pristine ">Email Id is required.</small>
						<small class="error" ng-show="cForm.email.$invalid && !cForm.email.$pristine &&!cForm.email.$error.required">This is not an Email Id.</small>
					</td>
				</tr>
				<tr>
					<th>Name*</th>
					<td>
						<input type="text" name="fname"  required ng-model="ship.fName" ng-pattern="/^[a-z\s]+$/i"/>
						<small class="error" ng-show="cForm.fname.$error.required && !cForm.fname.$pristine ">Name  required.</small>
						<small class="error" ng-show="cForm.fname.$invalid && !cForm.fname.$pristine &&!cForm.fname.$error.required ">Name should not contain digit and Spacial Character</small>
					</td>
				</tr>
				<tr>
					<th>Phone No.*</th>
					<td>
						<input type="text" name="phone"  required ng-model="ship.phone" ng-pattern="/[0-9]/" ng-minlength="10" ng-maxlength="10"/>
						<small class="error" ng-show="cForm.phone.$error.required && !cForm.phone.$pristine ">Phone No  required.</small>
						<small class="error" ng-show="cForm.phone.$error.minlength ||cForm.phone.$error.maxlength && !cForm.phone.$pristine && !cForm.phone.$error.required">Phone No should  have 10 digit</small>
					</td>
				</tr>
				<tr>
					<th>Pin*</th>
					<td>
						<input type="text"  id='pinTxt'  name="pin" required ng-model="ship.pin" ng-pattern="/[0-9]/" ng-minlength="6" ng-maxlength="6"/>
						<small class="error" ng-show="(cForm.pin.$error.minlength || cForm.pin.$error.maxlength) && !cForm.pin.$pristine && !cForm.pin.$error.required">Pin No should have 6 digit.</small>
						<small class="error" ng-show="cForm.pin.$error.required  && !cForm.pin.$pristine">Pin required.</small>
					</td>
				</tr>
				<tr>
					<th>City*</th>
					<td>
						<input type="text" name="city" id="cityTxt" ng-keyup="getCity()" required ng-model="ship.city"/>
						<small class="error" ng-show="cForm.city.$error.required  && !cForm.city.$pristine">City required.</small>
					</td>
				</tr>
				<tr>
					<th>State*</th>
					<td>
						<input type="text" name="state"  id='stateTxt' required  updateVal ng-model="ship.state"/>
						<small class="error" ng-show="cForm.state.$error.required  && !cForm.state.$pristine ">State required.</small>
					</td>
				</tr>
				<tr>
					<th>Address street</th>
					<td>
						<textarea name="address"   spellcheck="true" ng-model="ship.address"></textarea>
					</td>
				</tr>
				<tr>
					<td>
					</td>
					<td>
						<button class="btn_shipinfo" ng-disabled="cForm.$invalid" id="submitBtn" onclick='submitForm()' >Continue</button>
					</td>
				</tr>
			</table>
			</form>
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
         <footer style="margin-bottom:0">
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
