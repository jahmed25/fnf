<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="Footer" %>

<!-- footer_top -->
<div style="height:30px;clear:both"></div>
<div class="footer_top">
 <div class="container">
	<div class="row">
		<div class="col-md-2 col-xs-4">
			<h4>Shop</h4>
			<ul class="f_nav">
				<li><a href="<%=ConfigUtil.hostURL() %>Food-n-Groceries/Groceries">Groceries</a></li>
				<li><a href="<%=ConfigUtil.hostURL() %>DryFruits/HealthCares">Health Cares</a></li>
				<li><a href="<%=ConfigUtil.hostURL() %>Selfcare/Bodycare">Body Care</a></li>
				<li><a href="<%=ConfigUtil.hostURL() %>Fruits-n-Vegetables/Fruits">Fruits</a></li>
				<li><a href="<%=ConfigUtil.hostURL() %>Refreshment/Drinks">Drinks</a></li>
				<li><a href="<%=ConfigUtil.hostURL() %>Food-n-Groceries/Oil-n-Ghee">Oil-n-Ghee</a></li>
				<li><a href="<%=ConfigUtil.hostURL() %>Food-n-Groceries/Dals">Dals</a></li>
				<li><a href="<%=ConfigUtil.hostURL() %>Food-n-Groceries/Sabut-Spices">Sabut-Spices</a></li>
				<li><a href="<%=ConfigUtil.hostURL() %>Food-n-Groceries/Spices">Spices</a></li>
			</ul>	
		</div>
		<div class="col-md-2 col-xs-4">
			<h4>Policies</h4>
			<ul class="f_nav">
            <li><a href="<%=ConfigUtil.hostURL() %>sfloor/pages/faqs.aspx#ordering">Ordering</a></li>
            <li><a href="<%=ConfigUtil.hostURL() %>sfloor/pages/faqs.aspx#payments">Payments</a></li>
            <li><a href="<%=ConfigUtil.hostURL() %>sfloor/pages/faqs.aspx#shipping-and-tracking">Shipping And Tracking</a></li>
            <li><a href="<%=ConfigUtil.hostURL() %>sfloor/pages/faqs.aspx#cancellations-and-Returns">Cancellations And Returns</a></li>
            <li><a href="<%=ConfigUtil.hostURL() %>sfloor/pages/faqs.aspx#credit">Credit</a></li>
            <li><a href="<%=ConfigUtil.hostURL() %>sfloor/pages/privacy_policy.aspx">Privacy Policy</a></li>
    	</ul>	
		</div>
		<div class="col-md-2 col-xs-4">
			<h4>account</h4>
			<ul class="f_nav">
				<li><a logiPpop>login</a></li>
				<li><a logiPpop>create an account</a></li>
				<li><a href="<%=ConfigUtil.hostURL() %>fav-items">create wishlist</a></li>
				<li><a href="<%=ConfigUtil.hostURL() %>Add-To-Cart">my shopping bag</a></li>
			</ul>
		</div>
		
        <div class="col-md-3  col-xs-6">
			<h4>follow us need help?</h4>
        	<h5>need help?</h5>
           	<ul class="f_nav">
              <li><a href="<%=ConfigUtil.hostURL() %>contact-Us">Contact us</a> </li>
              <li><a href="<%=ConfigUtil.hostURL() %>about-Us">About us</a></li> 
            </ul>
            			<p>(or) Call us: (+91) 7042121501 / 02</p>
        	<div class="social-icons">
				<ul>
				<li><a href="https://twitter.com/fabnfresh_com" target="_blank"></a></li>
				<li style="display:none"><a href="#" target="_blank"></a></li>
		        <li><a href="https://www.facebook.com/pages/Fabnfreshcom/805626132839318" target="_blank"></a></li>
				<li><a href="https://in.linkedin.com/pub/fabnfresh-com/ba/28/386" target="_blank"></a></li>
				<li><a href="https://www.pinterest.com/fabnfresh" target="_blank"></a></li>
                <li><a href="https://plus.google.com/b/103655554454925445931" target="_blank"></a></li>
			</ul>
	    </div>
		</div>
        <div class="col-md-3 col-xs-6">
			<h4>Newsletter</h4>
			<div class="input-box">
             <input name="email" size=40 id="newsletter" title="Sign up for our newsletter" onfocus="if(this.value == 'yourname@example.com') { this.value = ''; }"
                    onblur="this.value=!this.value?'yourname@example.com':this.value;" value="yourname@example.com"
                    class="input-text required-entry validate-email" type="text">
            </div>
            <div class="actions">
                <button type="submit" title="Submit" class="button">
                    <span><span>Submit</span></span></button>
            </div>		
		</div>
		<div class="clearfix"></div>
		</div>
		<!-- start span_of_2 -->
                         <div style="display: none;" id="back-top" class="hidden-phone"><a href="#" rel="tooltip" title="Top"></a>	</div>
      
 </div>
</div>
</div>
<!-- footer -->
<div class="footer">
 <div class="container">
	<div class="copy">
		<address class="link"> &copy; 2014 FabNFresh.com | All Rights Reserved.| Design & Developer by&nbsp; <a href="#go3">Go3</a></address>
	</div>
 </div>
</div>
