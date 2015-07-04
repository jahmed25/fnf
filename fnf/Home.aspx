<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
    <title>Fab N Fresh Aata, vegetables, fruits, oils, cosmetic</title>
    <%=Head %>
</head>
<body >
    <%=Header %>
    <!-- start Slider-->
    <!-- content -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('.home-banner').owlCarousel({
                loop: true,
                margin: 10,
                nav: true,
                items: 1,
                dots: true,
                loop: true,
                autoplay: true
             // animateOut: 'fadeOut'
            });
            $('.parchilist a').click(function () {
                $(this).parent().slideUp();
                $(this).parent().next().slideDown();
            });
            $('.parchiadd .back').click(function () {
                $('.parchiadd').slideUp();
                $('.parchilist').slideDown();
            });

            $('.parchidesc .back').click(function () {
                $('parchidesc').fadeOut('fast');
                $('.parchilist').fadeIn('fast');
            });
        }); 
    </script>
    <div class="container">
        <div class="main">
            <div class="row content_top">
                <div class="col-md-8 content_left">
                    <!-- start slider -->
                     <div id="fwslider">
                        <div class="slider_container">
                            <div class="slide"> 
                                <!-- Slide image -->
                                   <a href="<%=ConfigUtil.hostURL() %>Food-n-Groceries/Oil-n-Ghee"> 
						                <img src='<%=ConfigUtil.StaticPath() %>new-images/banner/Banner4.jpg' class="img-responsive" alt="" />
						                </a>
                            </div>
           
                             <div class="slide"> 
                                <!-- Slide image -->
                                   <a href="<%=ConfigUtil.hostURL() %>Fruits-n-Vegetables/Fruits"> 
						                <img src='<%=ConfigUtil.StaticPath() %>new-images/banner/Banner1.jpg' class="img-responsive" alt="" />
						                </a>
                            </div>
                            <!-- /Duplicate to create more slides -->
                            <div class="slide">
              	                <a href="<%=ConfigUtil.hostURL() %>Fruits-n-Vegetables/Fruits">
						                <img src='<%=ConfigUtil.StaticPath() %>new-images/banner/Banner2.jpg' class="img-responsive" alt="" />
						
						                </a>
                            </div>
                            <div class="slide">
                              <a href="<%=ConfigUtil.hostURL() %>Fruits-n-Vegetables/Fruits">
						                <img src='<%=ConfigUtil.StaticPath() %>new-images/banner/Banner3.jpg' alt="" />
						                </a>
                            </div>
                            <!--/slide -->
                        </div>
                        <div class="timers"></div>
                        <div class="slidePrev"><span></span></div>
                        <div class="slideNext"><span></span></div>
                    </div>
                    <!-- end  slider -->
                </div>
                <div class="col-md-4 sidebar">
                   <div class="parchi">
                    <div><h6>We Explore New Features Parchi system</h6><h2>Simply write down your order here!</h2></div>
                       <h5 class="msg parchMsg">Thanks. Our support team get back to you shortly.</h5>
                       <div class="parchilist">
                        <textarea class="parchiText" placeholder="e.g. Safola Oil 5 lt, Sugar 2 KG, Orange 1 KG etc."></textarea>
                       <a href="javascript:void(0)" title="click next for address">Next</a>
                  </div>

                    <div class="parchiadd">
                           <input placeholder="Name"type="text" name=" class="parchiName"/> 
                           <small class="error"  id="parchiNameError" style="display:none;color:red;width:100%" ng-show="purchiFrm.name.$error.required && !purchiFrm.name.$pristine ">Phone No  required.</small>
                           <textarea placeholder="Addess" name="address" class="parchiAddress"></textarea>
                           <small class="error" id="parchiAddressError" style="display:none;color:red;width:100%" ng-show="purchiFrm.address.$error.required && !purchiFrm.address.$pristine ">Phone No  required.</small>
                           <input placeholder="Mobhile No" style="float:left;display:inline-block" ng-pattern="/[0-9]/" name="phone" maxlength="10" ng-minlength="10" ng-maxlength="10" type="text"  class="parchiPhone"/>
						   <small class="error" id="parchiPhoneError" style="display:none;color:red;width:100%" ng-show="purchiFrm.phone.$error.minlength ||purchiFrm.phone.$error.maxlength && !purchiFrm.phone.$pristine && !purchiFrm.phone.$error.required">Phone No should  have 10 digit</small>
                           <a href="javascript:void(0)" class="back">Back</a>
                           <a href="javascript:void(0)"  onclick="submitPurchi()" class="submit">Submit</a>
                            <span class="process"></span>
                  </div>
                       <div class="parchidesc">
                           <div class="list">

                           </div>
                           <a href="javascript:void(0)" class="back">Back</a>
                       </div>
                </div>
                 </div>
                <div class="clearfix"></div>
            </div>
        <script>
           
        </script>
            <!-- start content -->
            <div class="content">
                <div class="content_text">
                    <h3>Why we are?</h3>
                    <h4>Fab N Fresh is the biggest online Groceries outlet to fulfill all your Daily needs.</h4>
                    <p>We are Providing Free Delivery within 2-3hrs, Saving Your Fuel and Time so why Standing in Queues and waiting For Parking
                        When we are delivering, Giving Best Unmatched Quality, service and Discounts only on Fabnfresh.com</p>
                </div>
                <!-- grids_of_3 -->
                <div class="row grids">
                    <div class="col-md-3 col-sm-3 col-xs-6 grid1">
                        <a href="<%=ConfigUtil.hostURL() %>Refreshment/Drinks-N-Bevrages/Tea-N-Coffee">
                            <img src="<%=ConfigUtil.StaticPath() %>new-images/banner/bottom_banner_8.jpg" class="img-responsive" alt="" />
                            <div class="look">
                                <h4>TEA</h4>
                            </div>
                        </a>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-6 grid1">
                        <a href="<%=ConfigUtil.hostURL() %>Selfcare/Bodycare/Body-Talk">
                            <img src="<%=ConfigUtil.StaticPath() %>new-images/banner/bottom_banner_7.jpg" class="img-responsive" alt="" />
                            <div class="look">
                                <h4>HAIR N CARE</h4>
                            </div>
                        </a>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-6  grid1">
                        <a href="<%=ConfigUtil.hostURL() %>Food-n-Groceries/Oil-n-Ghee">
                            <img src="<%=ConfigUtil.StaticPath() %>new-images/banner/bottom_banner_6.jpg" class="img-responsive" alt="" />
                            <div class="look">
                                <h4>OILS</h4>
                            </div>
                        </a>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-6 grid1">
                        <a href="<%=ConfigUtil.hostURL() %>Selfcare/Bodycare/Deo-N-Spray">
                            <img src="<%=ConfigUtil.StaticPath() %>new-images/banner/bottom_banner_5.jpg" class="img-responsive" alt="" />
                            <div class="look">
                                <h4>PERFUME </h4>
                                <p>BODY SPRY</p>
                            </div>
                        </a>
                    </div>
                </div>
                <!-- end grids_of_3 -->
                <!-- grids_of_3 -->
                <div class="row grids">
                    <div class="col-md-3 col-sm-3 col-xs-6 grid1 effect-oscar">
                        <a href="<%=ConfigUtil.hostURL() %>Fruits-n-Vegetables/Fruits">
                            <img src="<%=ConfigUtil.StaticPath() %>new-images/banner/bottom_banner_4.jpg" class="img-responsive" alt="">
                            <div>
                                <h2>VEGITABLE</h2>
                            </div>
                        </a>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-6 grid1 effect-oscar">
                        <a href="<%=ConfigUtil.hostURL() %>Food-n-Groceries/Spices">
                            <img src="<%=ConfigUtil.StaticPath() %>new-images/banner/bottom_banner_3.jpg" class="img-responsive" alt="">
                            <div>
                                <h2><span>SPICES</span></h2>
                            </div>
                        </a>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-6 grid1 effect-oscar">
                        <a href="<%=ConfigUtil.hostURL() %>Food-n-Groceries/Dals">
                            <img src="<%=ConfigUtil.StaticPath() %>new-images/banner/bottom_banner_2.jpg" class="img-responsive" alt="">
                            <div>
                                <h2>LENTILE N PULSES</h2>
                            </div>
                        </a>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-6 grid1 effect-oscar">
                        <a href="<%=ConfigUtil.hostURL() %>Fruits-n-Vegetables/Fruits">
                            <img src="<%=ConfigUtil.StaticPath() %>new-images/banner/bottom_banner_1.jpg" class="img-responsive" alt="">
                            <div>
                                <h2>FRUITS</h2>
                            </div>
                        </a>
                    </div>

                    <!-- end grids_of_3 -->
                </div>
                <!-- end content -->
            </div>
        </div>
    </div>
    <%=Footer %>
</body>
</html>
