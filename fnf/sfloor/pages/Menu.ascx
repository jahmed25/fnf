<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Menu" %>
<%@ Import Namespace="SFloor.DTO" %>
<%--navigation--%>

<link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/style.css" />
<link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/megamenu.css" />
<link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/etalage.css" />
<link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/bootstrap.css" />
<script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/lib/jquery-ui.min.js"></script>
<script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/jquery.etalage.min.js"></script>
<script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/jquery.jscrollpane.min.js"></script>
<script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/jquery.mousewheel.js"></script>
<script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/megamenu.js"></script>
<script type="text/javascript" src="<%=ConfigUtil.StaticPath() %>new-js/index.js"></script>

<script type="text/javascript">jQuery(document).ready(function () { jQuery(".megamenu").megamenu(); });</script>


<div ng-app='registration' ng-controller='regCtrl'>
    <div class="nav-container">
        <div class="container">
            <!-- start header menu -->
            <ul class="megamenu skyblue">
                <li class="active grid sf" style="display: none"><a class="sf">
                    <img src='<%=ConfigUtil.StaticPath() %>new-images/menulogo.png' /></a></li>

                <%-- Start WOMens Section--%>
                <%foreach (MenuDTO toMenu in SFloor.Services.HomeService.getMenu())
                  {%>
                <li class="active grid">
                    <a class="color4" href='javascript:void(0)'><%=toMenu.Heading %></a>
                    <div class="megapanel">
                        <div class="row">
                            <%foreach (MenuDTO subMenu in toMenu.Contents)
                              {
                                  int i = 1; string first = "first"; %>

                            <div class='<%=first %> col<%=i%>'>

                                <div class="h_nav">
                                    <h4><b><a style="color: green" href='<%=subMenu.Url %>'>
                                        <%=subMenu.Heading %></a></b></h4>
                                    <div class="scroll-pane" style="height: 320px; overflow: auto">
                                        <ul>
                                            <%foreach (MenuDTO menuItem in subMenu.Contents)
                                              {%>
                                            <li><a class="itemMenuName level2" href='<%=menuItem.Url %>'><%=menuItem.Heading%></a></li>
                                            <%} i++; first = "";%>
                                    </ul>

                                    </div>

                                    
                                </div>

                            </div>

                            <%} %>
                        </div>
                    </div>
                </li>
                <%} %>
            </ul>
        </div>
    </div>
    <div class="background_overlay" style="display: none;"></div>
    <div id="overlay_form" style="display: none;" class="loginregisterform">
        <a title="close" class="x" id="close" href="#">x</a>
        <div class="loginform">
            <div class="headtitle"><span>Login</span></div>
            <form name='loginForm' class='css-form'>
                <p ng-show="login.errors.system" class="help-block" id='P2'>{{login.errors.system}}.</p>
                <div class="login-cont">
                    <div>
                        <div>Username:</div>
                        <div>
                            <input type="email" name='logEmail' ng-keyup="validateEmail()" placeholder="e.g. example@example.com" required ng-model="login.email"
                                ng-change="removelogErro('email')">
                            <span ng-show="loginForm.logEmail.$invalid && !loginForm.logEmail.$pristine" class="help-block">Email is not valid.</span>
                            <span ng-show="login.errors.email" class="help-block" id='P4'>{{login.errors.email}}.</span>
                            <span ng-show="login.errors.info" style="color: Green" id='P3'>{{login.errors.info}}.</span>
                        </div>
                    </div>
                    <div>
                        <div>Password:</div>
                        <div>
                            <input type="Password" name='logPwd' placeholder="Password" required ng-model="login.pwd" ng-minlength="8" ng-maxlength="20" ng-change="removelogErro('pwd')">
                            <span ng-show="loginForm.logPwd.$invalid && !loginForm.logPwd.$pristine" class="help-block">Password required length between 8 to 20</span>
                            <span ng-show="login.errors.pwd" class="help-block" id='errlogPwd'>{{login.errors.pwd}}.</span>
                        </div>      
                    </div>
                    
                            <p id="fgt_clk_hre"><a class="fgtclk">Forgot password? click here</a></p>
                            <p><input type="button" value="Login" class="button" ng-click="login()" ng-disabled="loginForm.$invalid">
                  </p>

                </div>
            </form>
        </div>
        <div class="midline"></div>
        <div class="registerform">
            <div class="headtitle"><span>Register</span></div>
            <form name='regForm' class='css-form' ng-submit="register()">
                <p ng-show="user.errors.system" class="help-block" id='errSystem'>{{user.errors.system}}.</p>

                <div class="register-cont">
                    <div>
                        <div>Email ID:</div>
                        <div>
                            <input type="email" name='email' ng-keyup="validateRegEmail()" placeholder="e.g. example@example.com" required ng-model="user.email" ng-change="removeErro('email')">
                            <span ng-show="regForm.email.$invalid && !regForm.email.$pristine" class="help-block">Email is not valid.</span>
                            <span ng-show="user.errors.email" class="help-block" id='errUsrEmail'>{{user.errors.email}}.</span>
                            <span ng-show="user.errors.info" style="color: Green" id='P5'>{{user.errors.info}}.</span>
                        </div>
                    </div>
                    <div>
                        <div>Password:</div>
                        <div>
                            <input type="password" name='pwd' ng-change="removeErro('pwd')" placeholder="Password" required ng-model="user.pwd" ng-minlength="8" ng-maxlength="20">
                            <span ng-show="regForm.pwd.$invalid && !regForm.pwd.$pristine" class="help-block">Password required length between 8 to 20</span>
                            <span ng-show="user.errors.pwd" class="help-block" id='errPwd'>{{user.errors.pwd}}.</span>
                        </div>
                    </div>
                    <div>
                        <div>Mobile:</div>
                        <div>
                            <input type="text" name='mobile' ng-pattern="/[0-9]/" placeholder="Mobile" ng-model="user.mobile" maxlength="10" ng-minlength="10" ng-maxlength="10">
                            <span ng-show="regForm.mobile.$invalid && !regForm.mobile.$pristine" class="help-block">Mobile no length should be 10 digit</span>
                            <span ng-show="user.errors.mobile" class="help-block" id='errMobile'>{{user.errors.mobile}}.</span>
                        </div>
                    </div>
                    <div>
                       
                        <p><input type="checkbox" name="checkbox" ng-model="user.newsLts">&nbsp;&nbsp;I want to receive news and special offers</td>
                           </p>     
                        <p>     <input type="button" value="Signup" class="button" ng-click="register()" ng-disabled="regForm.$invalid">
                       </p>
                </div>
        </form>
    </div>
</div>
</div>
<div id="fgt_overlay_form" style="display: none;" class="loginregisterform">
    <a title="close" class="x" id="fgt_close" href="#">x</a>
    <div class="loginform">
        <div class="headtitle"><span>Forgot Password</span></div>
        <form name='loginForm' class='css-form fgt_form '>
            <p ng-show="login.errors.system" class="help-block" id='P6'>{{login.errors.system}}.</p>
            <table>
                <tr>
                    <td>Enter your email address</td>
                </tr>
                <tr>
                    <td>
                        <input type="email" name='logEmail' ng-keyup="validateEmail()" placeholder="e.g. example@example.com" required ng-model="login.email"
                            ng-change="removelogErro('email')">
                        <p ng-show="loginForm.logEmail.$invalid && !loginForm.logEmail.$pristine" class="help-block">Email is not valid.</p>
                        <p ng-show="login.errors.email" class="help-block" id='P7'>{{login.errors.email}}.</p>
                        <p ng-show="login.errors.info" style="color: Green" id='P8'>{{login.errors.info}}.</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>We'll send you a link to reset your password.</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="button" value="Send" class="button" ng-click="login()" ng-disabled="loginForm.$invalid"></td>
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
    <div class="fgt_background_overlay" style="display: none;"></div>

