<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompareItems.aspx.cs" Inherits="CompareItems" %>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
   <head>
       <title>Compare</title>
        <link type="text/css" rel="stylesheet" href="<%=ConfigUtil.StaticPath() %>new-css/compare.css?v=1001">
      <%=Head %>
	  <script>
		jQuery(document).ready(function(){
			console.log("ready");
			jQuery('[delete]').on('click',function(){
				var delSku=jQuery(this).attr('delete').toString().trim();
				var url=path+"Compare-Products?";
				jQuery('[delete]').each(function(i){
					var sku=jQuery(this).attr('delete').toString().trim();
						if(delSku!=sku){
						url+="sku"+i+"="+sku+"&";
					}
				});
				window.location=url;
			});
		});
	  </script>
   </head>
   <body>
            <%=Header %>
				 <div class="container">
			  <div class="comparebox borderwht">
				 <div class="compareimg"></div>
				<p class="pname"></p>
				 <ul>
					<li>Brand</li>
					<li>MRP</li>
					<li>Price After Discount</li>
					<li>Saving Money</li>
					<li>Availability</li>
					<li>Available Colour</li>
					<li>Available Size</li>
					<li>Description</li>
				 </ul>
			  </div>
			  <!-- Start Compare Item List-->
			   <%if (compDT != null && compDT.Rows.Count > 0){ %>
				<% for(int i=0;i<compDT.Rows.Count;i++){%>
					  <div class="comparebox">
						 <a href="#" title="Delete" class="delete" delete='<%=compDT.Rows[i]["SKUCode"] %>'></a>
						 <div class="compareimg"><img class="img-responsive" src='<%=ConfigUtil.getServerPath() %><%=compDT.Rows[i]["PathIndexInternalImage"] %>' />
							<a class="addtocartbtn" href='<%=ConfigUtil.hostURL() %><%=MFO.Utils.StringUtil.urlEncode(compDT.Rows[i]["SKUName"]+"") %>?htm=<%=compDT.Rows[i]["SKUCode"] %>' />Buy Now</a>
						 </div>
						 <p class="pname"><%=compDT.Rows[i]["SKUName"] %></p>
						 <ul>
							<li><%=compDT.Rows[i]["SKUBrand"] %></li>
							<li>Rs.<%=compDT.Rows[i]["MRP"] %></li>
							<li>Rs.<%=compDT.Rows[i]["SpecialPrice"] %></li>
							<li>Rs.<%=totalDiscount(compDT.Rows[i]["MRP"], compDT.Rows[i]["SpecialPrice"])%></li>
							<li><%=availbilty(compDT.Rows[i]["SKUCode"]+"")%></li>
							<li><%=getColor(compDT.Rows[i]["SKUCode"]+"")%></li>
							<li><%=getSizes(compDT.Rows[i]["SKUCode"]+"")%></li>
							<li><%=compDT.Rows[0]["SKULongDescription"]%></li>
						 </ul>
					  </div>
				   <%}%>
			  <%}%>
              
       </div>     
            <%=Footer %>
   </body>
</html>