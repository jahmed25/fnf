
<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="home-and-decor.aspx.cs" Inherits="home_and_decor" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
   <head>
        <title>Fab N Fresh</title>
      <%=Head %>

   </head>
   
  <body>
       
            <%=Header %>
            <!-- start Slider-->
        <script type="text/javascript">
            jQuery(document).ready(function () {
                jQuery('#sfloorCarousel').owlCarousel({
                    loop: true,
                    margin: 10,
                    nav: true,
                    items: 1,
                    dots: true,
                    loop: true,
                    autoplay: true,
                    animateOut: 'fadeOut'
                });
                jQuery('.women-slider').owlCarousel({
                    loop: true,
                    margin: 10,
                    nav: true,
                    items: 4,
                    dots: false,
                    loop: true,
                    autoplay: false,
                    animateOut: 'fadeOut',
                    lazyLoad: true,
                    responsiveClass: true,
                    responsive: {
                        0: {
                            items: 1,

                        },
                        600: {
                            items: 3,

                        },
                        1000: {
                            items: 4,

                        }
                    }
                });

                jQuery('#tabs li a:not(:first)').addClass('inactive');
                jQuery('.women-arr > .container').hide();
                jQuery('.women-arr > .container:first').show();

                jQuery('#tabs li a').click(function () {
                    var t = jQuery(this).attr('id');
                    if (jQuery(this).hasClass('inactive')) { //this is the start of our condition 
                        jQuery('#tabs li a').addClass('inactive');
                        jQuery(this).removeClass('inactive');

                        jQuery('.women-arr > .container').hide();
                        jQuery('#' + t + 'C').fadeIn('slow');
                    }
                });

            });

    </script>
    
         <div class="container">
              <div id="sfloorCarousel" class="owl-carousel home_button">
                <div class="item"><a href="#" title=""><img src='<%=ConfigUtil.StaticPath() %>new-images/File-1376491867.jpg' alt=""></a></div>
                <div class="item"><a href="#" title=""><img src='<%=ConfigUtil.StaticPath() %>new-images/File-1376491867.jpg' alt=""></a></div>
                <div class="item"><a href="#" title=""><img src='<%=ConfigUtil.StaticPath() %>new-images/File-1388467675.jpg' alt=""></a></div>
                <div class="item"><a href="#" title=""><img src='<%=ConfigUtil.StaticPath() %>new-images/File-1376400571.jpg' alt=""></a> </div>
                <div class="item"><a href="#" title=""><img src='<%=ConfigUtil.StaticPath() %>new-images/File-1376491696.jpg' alt=""></a></div>
            </div>
           <!-- End Slider-->

            <!-- end enable -->
             
               <div class="row">
                  <div class="col-md-12">
                    <div class="new-collection">
                     <h2>New Collections</h2>
                     <i class="leftarrow"></i>
                  </div>
                  </div>
               </div>
               <div class="row">
                  <div class="col-md-12">
                     <div class="women-slider collection-img">
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block3.jpg' alt="">
                        <a href="#" class="buybtn">Buy Now</a>
                        </div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">
                          <a href="#" class="buybtn">Buy Now</a>
                      </div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">
                          <a href="#" class="buybtn">Buy Now</a>
                      </div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block1.jpg' alt="">
                          <a href="#" class="buybtn">Buy Now</a>
                      </div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">
                          <a href="#" class="buybtn">Buy Now</a>
                      </div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block3.jpg' alt="">
                          <a href="#" class="buybtn">Buy Now</a>
                      </div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">
                          <a href="#" class="buybtn">Buy Now</a>
                      </div>
                     </div>
                  </div>
               </div>
              
               <div class="row">
                   <div class="col-md-12">
                    <div class="new-collection">
                     <h2>Best Seller</h2>
                     <i class="leftarrow"></i>
                  </div>
                    <div class="women-arr">
                  <ul id="tabs">
                     <li><a id="tab1">Top</a></li>
                     <li><a id="tab2">Suits</a></li>
                     <li><a id="tab3">Sari</a></li>
                     <li><a id="tab4">Footwear</a></li>
                  </ul>
                  <div class="container" id="tab1C">
                     <div class="women-slider owl-carousel">
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block3.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block1.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block3.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                     </div>
                  </div>
                  <div class="container" id="tab2C">
                     <div class="women-slider owl-carousel">
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block3.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block1.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block3.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                     </div>
                  </div>
                  <div class="container" id="tab3C">
                     <div class="women-slider owl-carousel">
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block3.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block1.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block3.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                     </div>
                  </div>
                  <div class="container" id="tab4C">
                     <div class="women-slider owl-carousel">
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block3.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block1.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block3.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                        <div class="item"><img class="owl-lazy" data-src='<%=ConfigUtil.StaticPath() %>new-images/block2.jpg' alt="">   <a href="#" class="buybtn">Buy Now</a></div>
                     </div>
                  </div>
               </div>
               </div>
            </div>
         </div>
         <!-- End -->
         <%=Footer %>
       
  </body>
</html>