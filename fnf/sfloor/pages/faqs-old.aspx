<%@ Page Language="C#" AutoEventWireup="true" CodeFile="faqs.aspx.cs" Inherits="faqs" %>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
   <head>
      <link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/etalage.css?v=3001">
      <%=Head %>
   </head>
   <body>
    
         <%=Header %>
         <div class="container">
            <div class="row">
               <div class="col-md-12">
               <div class="faq-head-title">FAQ'S</div>
                   </div></div>
        <div class="row">
               <div class="col-md-3">
                  <div class="faqleft">
                     <p class="qk-link">Quick Links</p>
                     <ul>
                        <li><a href="#ordering">Ordering</a></li>
                        <li><a href="#payments">Payments</a></li>
                        <li>
                           <a href="#voucher">Fab N Fresh  Vouchers</a>
                           <ul>
                              <li><a href="#4">Welcome Vouchers</a></li>
                              <li><a href="#5">Promo Vouchers</a></li>
                           </ul>
                        </li>
                        <li>
                           <a href="#shipping-and-tracking">Shipping & Tracking</a>
                           <ul>
                              <li><a href="#7">Shipping</a></li>
                              <li><a href="#8">Tracking</a></li>
                           </ul>
                        </li>
                        <li>
                           <a href="#refund">Returns & Refunds</a>
                           <ul>
                              <li><a href="#9">Returns</a></li>
                              <li><a href="#10">Drop Ship</a></li>
                              <li><a href="#11">Exchange Policy</a></li>
                           </ul>
                        </li>
                        <li>
                           <a href="#credit">Fab N Fresh  Credits</a>
                           <ul>
                              <li><a href="#13">Credits</a></li>
                              <li><a href="#14">Gift Cards</a></li>
                           </ul>
                        </li>
                        <li><a href="#gift-wrapping">Gift Wrapping</a></li>
                        <li><a href="#self-pickup">Self Pick-up</a></li>
                      
                     </ul>
                  </div>
               </div>
               <div class="col-md-9">
              <%--Ordering--%>
               <div class="odering">
                   <div class="sectitle">Ordering</div>
                  <div class="faqright container-innerleft">
                     <h3><a href="javascript:void(0);" id="ordering">How do I place an order?</a></h3>
                     <div class="left-slidebox">Select a category - Choose the product of your choice. We have multiple ways to place an Order.
                    <ul><li>Parchi System : just write down your order  in parchi system on to the home page of the website and submit it With your name Address and Mobile no., Our customer care executive  will contact you soon for the confirmation of your order and an email will sent to you after telephonic confirmation.</li>
                    <li>Direct Call : Just call us and tell your order directly to our customer care executive your requirement and we will submit your order.</li>
                    <li>Whats App us :  Just write down your order on a paper and click a clear picture of it or simply type your order and what’s app us on our customer care No. which is :7042121501/02.</li>
                    <li>Order Online : Just go to our website www.fabnfresh.com and choose the particular items of your choice add it to your cart and check out with giving your name address to deliver, E-mail id, and contact number. Our customer care will sent you the bill on your submitted E-mail id and call you for order confirmation.</li>
                    </ul> 
                     </div>
                     <h3><a href="javascript:void(0);">How will my order be delivered to me?</a></h3>
                     <div class="left-slidebox">Your order would be delivered to you by our self employed person, so that you could get efficient service.</div>

                     <h3><a href="javascript:void(0);">How will I know if order is placed successfully?</a></h3>
                     <div class="left-slidebox">Once your order is success fully placed, you will receive a mail containing your bill and our customer care executive will contact you.</div>
                     
                      <h3><a href="javascript:void(0);" id="3">Do you take orders over phone?</a></h3>
                     <div class="left-slidebox">Yes, we do take order over phone our customer care no. is : 7042121501/502.</div>
                     
                      <h3><a href="javascript:void(0);">I want to place order using my credit card, debit card, net banking or swipe on delivery but  there is  no option.</h3>
                     <div class="left-slidebox">Unfortunately right now only cash on delivery option is available.</div>
                    
                     <h3><a href="javascript:void(0);">How do i check status of my order.?</h3>
                     <div class="left-slidebox">Your order status is updated to you via mail or call. If in case of any unforeseen event, which delays your order you will receive a call from our end.
                     </div>

                     <h3><a href="javascript:void(0);">I tried placing my order using my debit card/credit card/Net Banking but the order was not successful. What happens to Jabong Credits deducted from my Account?</a></h3>
                     <div class="left-slidebox">    In case your order is not successful and Jabong Credits has been deducted from your account money has been credited to our account we would proactively initiate refund within 3 days.</div>
                     <h3><a href="javascript:void(0);">How do I check the status of my order?</a></h3>
                     <div class="left-slidebox">    Your order status is updated to you via emails and sms at every step. Once your order is placed you would receive an sms and an email with your order details. Again after your order is dispatched we send you an sms with your tracking details. Please check your spam and old sms-es for the status of your order, if you don't see any updates. In case of any unforeseen events which delays your order you would receive a special update from our end.</div>
                     <h3><a href="javascript:void(0);">Can I cancel my order?</a></h3>
                     <div class="left-slidebox">    If you wish to cancel your order, get in touch with Customer Care as soon as possible with your order number. As long as your order has not been dispatched we can cancel it and refund your amount.
                        If your order has been dispatched but yet to be delivered, please do not accept delivery and contact Customer Care to inform them of the same. In case of Prepaid orders Refunds will be processed as per our Return policies. Any Jabong Credits used in the purchase of the Order will be credited back to your account.
                        For certain product categories such as Furniture once you place an order, it cannot be cancelled. This is also indicated on the individual product pages . In rare cases when we are unable to deliver the product in spite of repeated attempts at the shipping address, an amount of Rs. 1000 would be charged on the refund amount.
                     </div>
                     <h3><a href="javascript:void(0);">I got a confirmation call for my order. Why is that?</a></h3>
                     <div class="left-slidebox">I got a confirmation call for my order. Why is that?
                        You receive a confirmation call for your order to verify if there isn't any change with your order.
                     </div>
                     <h3><a href="javascript:void(0);">Can I place a bulk order for an item(s)?</a></h3>
                     <div class="left-slidebox"> No, Bulk orders cannot be placed through Jabong.com as the website only caters to end customers.</div>
                     <h3><a href="javascript:void(0);">How do I do a trial of the product I purchased?</a></h3>
                     <div class="left-slidebox">    We encourage you try the items you bought, however please ensure the product is left in a re-saleable condition after the trial with original tags, unwashed, undamaged and with the original packing. Please note that all categories are not returnable. For more information please check our Return policies.</div>
                     <h3><a href="javascript:void(0);">Do you allow exchanges ?</a></h3>
                     <div class="left-slidebox">    Have you ordered a size too small or too big? No problem! We offer exchange for our customers too. Please read up our exchange policies for details.</div>
                     <h3><a href="javascript:void(0);">Can I add an item to my order after I have placed my order?</a></h3>
                     <div class="left-slidebox">Unfortunately no, however you can simply place another order.</div>
                  </div>
                </div>
              <%--Payments--%>
               <div class="payment">
                   <div class="sectitle"  id="payments">Payments</div>
                  <div class="faqright container-innerleft">
                     <h3><a href="javascript:void(0);" id="A1">How do I place an order?</a></h3>
                     <div class="left-slidebox">Select a category - Choose the product of your choice
                        Please note: -Fabric / material/colour / style / length / fit -Refer to size guide -Warranty -SKU Code -Check the expected delivery time by entering your Pin code on the right More accurate, detailed information about your items will be communicated via SMS/Email once you have placed an order 
                        Create an account by registering or you can also proceed by entering your email id Note: if you register with us you will get the following benefits: -speeds up the ordering process -allows us to keep you informed about your orders and refund through email -access to Jabong Credits 
                        Carefully enter your shipping address
                        Enter the Welcome Voucher/Discount coupon codes as applicable.
                        Check the final price {COD/Shipping charges}. Select one of the payment options (COD, Prepaid, Net-Banking/Debit or Credit Card) YOUR ORDER IS PLACED!!!
                        You will now receive a confirmation mail and a SMS from Team Jabong.
                        You can check Order history in ‘My Account’ in case you had logged into your account while placing the Order.
                        Didn’t receive any communication? OR Facing Issues while placing order? OR Website hung up at the payment page? OR Order was not successful? You can always place your Cash-On-Delivery order over phone with our 24*7 available customer care executives at 0124-6128000 
                     </div>
                     <h3><a href="javascript:void(0);" id="A2">How will my order be delivered to me?</a></h3>
                     <div class="left-slidebox">1. Your order would be delivered through reputed courier companies at your doorstep</div>
                     <h3><a href="javascript:void(0);">How will I know if order is placed successfully?</a></h3>
                     <div class="left-slidebox">Once your Order is successfully placed,you will receive a confirmation over email and text message from Jabong.com This mail will have all the details related to your order. Order details can also be viewed at My Account -> My Orders if you have placed the order on your own online.</div>
                     <h3><a href="javascript:void(0);" id="A3">Do you take orders over phone?</a></h3>
                     <div class="left-slidebox">    Yes. We do take orders over phone. The payment mode possible for these orders is Cash On Delivery only.</div>
                     <h3><a href="javascript:void(0);">I tried placing order using my credit card but it isn't working. Can you help me place an order?</a></h3>
                     <div class="left-slidebox">1. Yes if your debit/credit card isn't working we can always take your order over phone. Do call us.</div>
                    </div>
                </div>
              <%--Voucher--%>
               <div class="voucher" id="voucher">
                   <div class="sectitle">Voucher</div>
                  <div class="faqright container-innerleft">
                     <h3><a href="javascript:void(0);" id="A4">How do I place an order?</a></h3>
                     <div class="left-slidebox">    Select a category - Choose the product of your choice
                        Please note: -Fabric / material/colour / style / length / fit -Refer to size guide -Warranty -SKU Code -Check the expected delivery time by entering your Pin code on the right More accurate, detailed information about your items will be communicated via SMS/Email once you have placed an order 
                        Create an account by registering or you can also proceed by entering your email id Note: if you register with us you will get the following benefits: -speeds up the ordering process -allows us to keep you informed about your orders and refund through email -access to Jabong Credits 
                        Carefully enter your shipping address
                        Enter the Welcome Voucher/Discount coupon codes as applicable.
                        Check the final price {COD/Shipping charges}. Select one of the payment options (COD, Prepaid, Net-Banking/Debit or Credit Card) YOUR ORDER IS PLACED!!!
                        You will now receive a confirmation mail and a SMS from Team Jabong.
                        You can check Order history in ‘My Account’ in case you had logged into your account while placing the Order.
                        Didn’t receive any communication? OR Facing Issues while placing order? OR Website hung up at the payment page? OR Order was not successful? You can always place your Cash-On-Delivery order over phone with our 24*7 available customer care executives at 0124-6128000 
                     </div>
                     <h3><a href="javascript:void(0);" id="A5">How will my order be delivered to me?</a></h3>
                     <div class="left-slidebox">1. Your order would be delivered through reputed courier companies at your doorstep</div>
                     <h3><a href="javascript:void(0);">How will I know if order is placed successfully?</a></h3>
                     <div class="left-slidebox">Once your Order is successfully placed,you will receive a confirmation over email and text message from Jabong.com This mail will have all the details related to your order. Order details can also be viewed at My Account -> My Orders if you have placed the order on your own online.</div>
                     <h3><a href="javascript:void(0);" id="A6">Do you take orders over phone?</a></h3>
                     <div class="left-slidebox">    Yes. We do take orders over phone. The payment mode possible for these orders is Cash On Delivery only.</div>
                     <h3><a href="javascript:void(0);">I tried placing order using my credit card but it isn't working. Can you help me place an order?</a></h3>
                     <div class="left-slidebox">1. Yes if your debit/credit card isn't working we can always take your order over phone. Do call us.</div>
                    </div>
                </div>
              <%--Shipping & Tracking--%>
               <div class="shiptrack" id="shipping-and-tracking">
                   <div class="sectitle">Shipping & Tracking</div>
                  <div class="faqright container-innerleft">
                     <h3><a href="javascript:void(0);" id="A7">How do I place an order?</a></h3>
                     <div class="left-slidebox">    Select a category - Choose the product of your choice
                        Please note: -Fabric / material/colour / style / length / fit -Refer to size guide -Warranty -SKU Code -Check the expected delivery time by entering your Pin code on the right More accurate, detailed information about your items will be communicated via SMS/Email once you have placed an order 
                        Create an account by registering or you can also proceed by entering your email id Note: if you register with us you will get the following benefits: -speeds up the ordering process -allows us to keep you informed about your orders and refund through email -access to Jabong Credits 
                        Carefully enter your shipping address
                        Enter the Welcome Voucher/Discount coupon codes as applicable.
                        Check the final price {COD/Shipping charges}. Select one of the payment options (COD, Prepaid, Net-Banking/Debit or Credit Card) YOUR ORDER IS PLACED!!!
                        You will now receive a confirmation mail and a SMS from Team Jabong.
                        You can check Order history in ‘My Account’ in case you had logged into your account while placing the Order.
                        Didn’t receive any communication? OR Facing Issues while placing order? OR Website hung up at the payment page? OR Order was not successful? You can always place your Cash-On-Delivery order over phone with our 24*7 available customer care executives at 0124-6128000 
                     </div>
                     <h3><a href="javascript:void(0);" id="A8">How will my order be delivered to me?</a></h3>
                     <div class="left-slidebox">1. Your order would be delivered through reputed courier companies at your doorstep</div>
                     <h3><a href="javascript:void(0);">How will I know if order is placed successfully?</a></h3>
                     <div class="left-slidebox">Once your Order is successfully placed,you will receive a confirmation over email and text message from Jabong.com This mail will have all the details related to your order. Order details can also be viewed at My Account -> My Orders if you have placed the order on your own online.</div>
                     <h3><a href="javascript:void(0);" id="A9">Do you take orders over phone?</a></h3>
                     <div class="left-slidebox">    Yes. We do take orders over phone. The payment mode possible for these orders is Cash On Delivery only.</div>
                     <h3><a href="javascript:void(0);">I tried placing order using my credit card but it isn't working. Can you help me place an order?</a></h3>
                     <div class="left-slidebox">1. Yes if your debit/credit card isn't working we can always take your order over phone. Do call us.</div>
                    </div>
                </div>
              <%--Returns & Refunds--%>
               <div class="retref" id="refund">
                   <div class="sectitle">Returns & Refunds</div>
                  <div class="faqright container-innerleft">
                     <h3><a href="javascript:void(0);" id="A10">How do I place an order?</a></h3>
                     <div class="left-slidebox">    Select a category - Choose the product of your choice
                        Please note: -Fabric / material/colour / style / length / fit -Refer to size guide -Warranty -SKU Code -Check the expected delivery time by entering your Pin code on the right More accurate, detailed information about your items will be communicated via SMS/Email once you have placed an order 
                        Create an account by registering or you can also proceed by entering your email id Note: if you register with us you will get the following benefits: -speeds up the ordering process -allows us to keep you informed about your orders and refund through email -access to Jabong Credits 
                        Carefully enter your shipping address
                        Enter the Welcome Voucher/Discount coupon codes as applicable.
                        Check the final price {COD/Shipping charges}. Select one of the payment options (COD, Prepaid, Net-Banking/Debit or Credit Card) YOUR ORDER IS PLACED!!!
                        You will now receive a confirmation mail and a SMS from Team Jabong.
                        You can check Order history in ‘My Account’ in case you had logged into your account while placing the Order.
                        Didn’t receive any communication? OR Facing Issues while placing order? OR Website hung up at the payment page? OR Order was not successful? You can always place your Cash-On-Delivery order over phone with our 24*7 available customer care executives at 0124-6128000 
                     </div>
                     <h3><a href="javascript:void(0);" id="A11">How will my order be delivered to me?</a></h3>
                     <div class="left-slidebox">1. Your order would be delivered through reputed courier companies at your doorstep</div>
                     <h3><a href="javascript:void(0);">How will I know if order is placed successfully?</a></h3>
                     <div class="left-slidebox">Once your Order is successfully placed,you will receive a confirmation over email and text message from Jabong.com This mail will have all the details related to your order. Order details can also be viewed at My Account -> My Orders if you have placed the order on your own online.</div>
                     <h3><a href="javascript:void(0);" id="A12">Do you take orders over phone?</a></h3>
                     <div class="left-slidebox">    Yes. We do take orders over phone. The payment mode possible for these orders is Cash On Delivery only.</div>
                     <h3><a href="javascript:void(0);">I tried placing order using my credit card but it isn't working. Can you help me place an order?</a></h3>
                     <div class="left-slidebox">1. Yes if your debit/credit card isn't working we can always take your order over phone. Do call us.</div>
                    </div>
                </div>
              <%--Credits--%>
               <div class="credit" id="credit">
                   <div class="sectitle">Credits</div>
                  <div class="faqright container-innerleft">
                     <h3><a href="javascript:void(0);" id="A13">How do I place an order?</a></h3>
                     <div class="left-slidebox">    Select a category - Choose the product of your choice
                        Please note: -Fabric / material/colour / style / length / fit -Refer to size guide -Warranty -SKU Code -Check the expected delivery time by entering your Pin code on the right More accurate, detailed information about your items will be communicated via SMS/Email once you have placed an order 
                        Create an account by registering or you can also proceed by entering your email id Note: if you register with us you will get the following benefits: -speeds up the ordering process -allows us to keep you informed about your orders and refund through email -access to Jabong Credits 
                        Carefully enter your shipping address
                        Enter the Welcome Voucher/Discount coupon codes as applicable.
                        Check the final price {COD/Shipping charges}. Select one of the payment options (COD, Prepaid, Net-Banking/Debit or Credit Card) YOUR ORDER IS PLACED!!!
                        You will now receive a confirmation mail and a SMS from Team Jabong.
                        You can check Order history in ‘My Account’ in case you had logged into your account while placing the Order.
                        Didn’t receive any communication? OR Facing Issues while placing order? OR Website hung up at the payment page? OR Order was not successful? You can always place your Cash-On-Delivery order over phone with our 24*7 available customer care executives at 0124-6128000 
                     </div>
                     <h3><a href="javascript:void(0);" id="A14">How will my order be delivered to me?</a></h3>
                     <div class="left-slidebox">1. Your order would be delivered through reputed courier companies at your doorstep</div>
                     <h3><a href="javascript:void(0);">How will I know if order is placed successfully?</a></h3>
                     <div class="left-slidebox">Once your Order is successfully placed,you will receive a confirmation over email and text message from Jabong.com This mail will have all the details related to your order. Order details can also be viewed at My Account -> My Orders if you have placed the order on your own online.</div>
                     <h3><a href="javascript:void(0);" id="A15">Do you take orders over phone?</a></h3>
                     <div class="left-slidebox">    Yes. We do take orders over phone. The payment mode possible for these orders is Cash On Delivery only.</div>
                     <h3><a href="javascript:void(0);">I tried placing order using my credit card but it isn't working. Can you help me place an order?</a></h3>
                     <div class="left-slidebox">1. Yes if your debit/credit card isn't working we can always take your order over phone. Do call us.</div>
                    </div>
                </div>
              <%--Gift Wrapping--%>
               <div class="gift" id="gift-wrapping">
                   <div class="sectitle">Gift Wrapping</div>
                  <div class="faqright container-innerleft">
                     <h3><a href="javascript:void(0);" id="A16">How do I place an order?</a></h3>
                     <div class="left-slidebox">    Select a category - Choose the product of your choice
                        Please note: -Fabric / material/colour / style / length / fit -Refer to size guide -Warranty -SKU Code -Check the expected delivery time by entering your Pin code on the right More accurate, detailed information about your items will be communicated via SMS/Email once you have placed an order 
                        Create an account by registering or you can also proceed by entering your email id Note: if you register with us you will get the following benefits: -speeds up the ordering process -allows us to keep you informed about your orders and refund through email -access to Jabong Credits 
                        Carefully enter your shipping address
                        Enter the Welcome Voucher/Discount coupon codes as applicable.
                        Check the final price {COD/Shipping charges}. Select one of the payment options (COD, Prepaid, Net-Banking/Debit or Credit Card) YOUR ORDER IS PLACED!!!
                        You will now receive a confirmation mail and a SMS from Team Jabong.
                        You can check Order history in ‘My Account’ in case you had logged into your account while placing the Order.
                        Didn’t receive any communication? OR Facing Issues while placing order? OR Website hung up at the payment page? OR Order was not successful? You can always place your Cash-On-Delivery order over phone with our 24*7 available customer care executives at 0124-6128000 
                     </div>
                     <h3><a href="javascript:void(0);" id="A17">How will my order be delivered to me?</a></h3>
                     <div class="left-slidebox">1. Your order would be delivered through reputed courier companies at your doorstep</div>
                     <h3><a href="javascript:void(0);">How will I know if order is placed successfully?</a></h3>
                     <div class="left-slidebox">Once your Order is successfully placed,you will receive a confirmation over email and text message from Jabong.com This mail will have all the details related to your order. Order details can also be viewed at My Account -> My Orders if you have placed the order on your own online.</div>
                     <h3><a href="javascript:void(0);" id="A18">Do you take orders over phone?</a></h3>
                     <div class="left-slidebox">    Yes. We do take orders over phone. The payment mode possible for these orders is Cash On Delivery only.</div>
                     <h3><a href="javascript:void(0);">I tried placing order using my credit card but it isn't working. Can you help me place an order?</a></h3>
                     <div class="left-slidebox">1. Yes if your debit/credit card isn't working we can always take your order over phone. Do call us.</div>
                    </div>
                </div>
              <%--Self Pick-up--%>
               <div class="pick-up" id="self-pickup">
                   <div class="sectitle" >Self Pick-up</div>
                  <div class="faqright container-innerleft">
                     <h3><a href="javascript:void(0);" id="A19">How do I place an order?</a></h3>
                     <div class="left-slidebox">    Select a category - Choose the product of your choice
                        Please note: -Fabric / material/colour / style / length / fit -Refer to size guide -Warranty -SKU Code -Check the expected delivery time by entering your Pin code on the right More accurate, detailed information about your items will be communicated via SMS/Email once you have placed an order 
                        Create an account by registering or you can also proceed by entering your email id Note: if you register with us you will get the following benefits: -speeds up the ordering process -allows us to keep you informed about your orders and refund through email -access to Jabong Credits 
                        Carefully enter your shipping address
                        Enter the Welcome Voucher/Discount coupon codes as applicable.
                        Check the final price {COD/Shipping charges}. Select one of the payment options (COD, Prepaid, Net-Banking/Debit or Credit Card) YOUR ORDER IS PLACED!!!
                        You will now receive a confirmation mail and a SMS from Team Jabong.
                        You can check Order history in ‘My Account’ in case you had logged into your account while placing the Order.
                        Didn’t receive any communication? OR Facing Issues while placing order? OR Website hung up at the payment page? OR Order was not successful? You can always place your Cash-On-Delivery order over phone with our 24*7 available customer care executives at 0124-6128000 
                     </div>
                     <h3><a href="javascript:void(0);" id="A20">How will my order be delivered to me?</a></h3>
                     <div class="left-slidebox">1. Your order would be delivered through reputed courier companies at your doorstep</div>
                     <h3><a href="javascript:void(0);">How will I know if order is placed successfully?</a></h3>
                     <div class="left-slidebox">Once your Order is successfully placed,you will receive a confirmation over email and text message from Jabong.com This mail will have all the details related to your order. Order details can also be viewed at My Account -> My Orders if you have placed the order on your own online.</div>
                     <h3><a href="javascript:void(0);" id="A21">Do you take orders over phone?</a></h3>
                     <div class="left-slidebox">    Yes. We do take orders over phone. The payment mode possible for these orders is Cash On Delivery only.</div>
                     <h3><a href="javascript:void(0);">I tried placing order using my credit card but it isn't working. Can you help me place an order?</a></h3>
                     <div class="left-slidebox">1. Yes if your debit/credit card isn't working we can always take your order over phone. Do call us.</div>
                    </div>
                </div>
               </div>
            </div>
      <script type="text/javascript">
          jQuery(document).ready(function () {
              jQuery("div.left-slidebox").hide();
              jQuery(".container-innerleft h3").click(function () {
                  jQuery(this).next("div.left-slidebox").slideToggle("")
              .siblings("div.left-slidebox").slideUp("");
                  jQuery(this).toggleClass("active");
                  jQuery(this).siblings("h3").removeClass("active");
              });

          });
 </script>
 <script type="text/javascript">
     jQuery(document).ready(function () {
         jQuery('a[href*=#]:not([href=#])').click(function () {
             if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '')
                               || location.hostname == this.hostname) {
                 var target = jQuery(this.hash);
                 target = target.length ? target : jQuery('[name=' + this.hash.slice(1) + ']');
                 if (target.length) {
                     jQuery('html,body').animate({
                         scrollTop: target.offset().top - 95
                     }, 1000);
                     return false;
                 }
             }
         });
     });
     </script>
     
         </div>
         <%=Footer %>
 
   </body>
</html>
