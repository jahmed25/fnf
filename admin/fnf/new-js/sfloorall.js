
   jQuery(document).ready(function () {

       // hide #back-top first
       jQuery("#back-top").hide();

       // fade in #back-top
       jQuery(function () {
           jQuery(window).scroll(function () {
               if (jQuery(this).scrollTop() > 100) {
                   jQuery('#back-top').fadeIn();
               } else {
                   jQuery('#back-top').fadeOut();
               }
           });
           // scroll body to 0px on click
           jQuery('#back-top').click(function () {
               jQuery('body,html').animate({
                   scrollTop: 0
               }, 800);
               return false;
           });
       });

   });

   //fixed navbar
//   jQuery(function () {
//       var header = jQuery('.nav-container').offset().top;
//       jQuery(window).scroll(function () {
//           if (jQuery(window).scrollTop() > header) {
//               jQuery('.nav-container').addClass("sticky");
//           } else {
//               jQuery('.nav-container').removeClass("sticky");
//           }
//       });
   //   });
  
   jQuery(function () {
       jQuery('.sf').hide();
       var nav = jQuery('.nav-container');
       var cartstick = jQuery('.cart-stick');
       var searchstick = jQuery('.search-stick');
   var scrolled = false;
   jQuery(window).scroll(function () {
       if (80 < jQuery(window).scrollTop() && !scrolled) {
           nav.addClass('sticky').animate({ top: '0px' });
           cartstick.addClass('cart-sticky').animate({ top: '0px' });
           searchstick.addClass('search-sticky').animate({ top: '0px' });
           scrolled = true;
           jQuery('.sf').show();

       }
       if (80 > jQuery(window).scrollTop() && scrolled) {
           nav.removeClass('sticky').css('top', '0px');
           cartstick.removeClass('cart-sticky').animate({ top: '0px' });
           searchstick.removeClass('search-sticky').animate({ top: '0px' });
           scrolled = false;
           jQuery('.sf').hide();
       }

   });

});
// 
//   jQuery(function () {
//       var header = jQuery('.cart-stick').offset().top;
//       jQuery(window).scroll(function () {
//           if (jQuery(window).scrollTop() > header) {
//               jQuery('.cart-stick').addClass("cart-sticky");
//           } else {
//               jQuery('.cart-stick').removeClass("cart-sticky");
//           }
//       });
//   });
//   jQuery(function () {
//       var header = jQuery('.search-stick').offset().top;
//       jQuery(window).scroll(function () {
//           if (jQuery(window).scrollTop() > header) {
//               jQuery('.search-stick').addClass("search-sticky");
//           } else {
//               jQuery('.search-stick').removeClass("search-sticky");
//           }
//       });
//   });