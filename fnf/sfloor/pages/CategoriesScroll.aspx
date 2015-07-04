<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CategoriesScroll.aspx.cs" Inherits="CategoriesScroll" %>
  
  <% if(MFO.Commom.CommonUtil.DT.isEmptyOrNull(catDT) ){%>
    not_found
  <%}else{ %><div id="categories">
               <%for (int i = 0; i < catDT.Rows.Count; i++)
                 { %>
                            <div class="right_inner_categorydetailsimagesdetails">
                                <div class="boxgrid">
                                <div class="loading item" sequence='<%=i%>' sku='<%=catDT.Rows[i]["SKUCode"]%>'>
                                   <a href='<%=catDT.Rows[i]["link"] %>'>
                                 <div class='lnkbtn_brandname'> <%=catDT.Rows[i]["SKUBrand"]%></div>
                         
                                 <ul class="image_slider" sku='<%=catDT.Rows[i]["SKUCode"] %>' style='left:0px'>
                                    <%= MFO.Utils.StringUtil.dispLI(catDT.Rows[i]["PathUpperInternaldetailsSmallImage"], catDT.Rows[i]["SKUName"], false)%>
                                    <%= MFO.Utils.StringUtil.dispLI(catDT.Rows[i]["PathLowerInternaldetailsSmallImage"], catDT.Rows[i]["SKUName"], false)%>
                                    <%= MFO.Utils.StringUtil.dispLI(catDT.Rows[i]["PathBackInternaldetailsSmallImage"], catDT.Rows[i]["SKUName"], false)%>
                                    <%= MFO.Utils.StringUtil.dispLI(catDT.Rows[i]["PathInternaldetailsSmallImage"], catDT.Rows[i]["SKUName"], true)%>
                                 </ul>
                              </a>
                           </div>
<%--                           <a href="javascript:void(0);" class="previmg" prev='<%=catDT.Rows[i]["SKUCode"]%>' ></a>
                           <a href="javascript:void(0);" class="nextimg" next='<%=catDT.Rows[i]["SKUCode"]%>' ></a>--%>
                        </div>
                         
                        <div class="categorydetails_info_bottom">
                            <a href='<%=catDT.Rows[i]["link"] %>'>   
                                <div class="productpricesection">
                                <div class='lnkbtn_proname' title="<%=catDT.Rows[i]["SKUName"]%>"><%=catDT.Rows[i]["SKUName"]%></div>
                                <div class="splprice"><span class="margin">Rs.</span><%=catDT.Rows[i]["SpecialPrice"]%></div>
                                 <%if (Int32.Parse(catDT.Rows[i]["MRP"].ToString())!=(Int32.Parse(catDT.Rows[i]["SpecialPrice"].ToString()))){ %>
                                   <div class="crossprize" ><span class="margin">Rs.</span><%=catDT.Rows[i]["MRP"]%> </div>
                                <%} %>
                               </div>
                              </a>
                                <div class="optionContainer">  
                                <div class="select_varient">
                                <%if ("normal".Equals(catDT.Rows[i]["SKUClassification"].ToString().Trim().ToLower()))
                                  {%>
                                <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='qty-<%=catDT.Rows[i]["SKUCode"]%>'>
                                    <%for (int j = 1; j <= 10;j++ ){ %>
                                        <option value='<%=j %>'><%=j %> <%=catDT.Rows[i]["SizeDataType"]%></option>
                                     <%} %>
                                    </select>
                                    </label><span>Select Quantity</span></a>
                                <%}else{ %>
                                     <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='ver-<%=catDT.Rows[i]["SKUCode"]%>' ver-select>
                                    <% System.Data.DataTable sDT = SFloor.Services.CatDetailsService.getSizeDT(catDT.Rows[i]["SKUCode"].ToString(), true); %>
                                    <%for (int j = 0; j < sDT.Rows.Count; j++){ %>
                                        <%if (sDT.Rows[j]["size"].ToString().Trim().Equals(catDT.Rows[i]["size"].ToString().Trim())){%>
                                            <option selected sku="<%=sDT.Rows[j]["SKUCode"]%>" value='<%=sDT.Rows[j]["Size"]%>'><%=sDT.Rows[j]["Size"]%> <%=catDT.Rows[i]["SizeDataType"]%></option>
                                        <%}else{%>
                                            <option sku="<%=sDT.Rows[j]["SKUCode"]%>" value='<%=sDT.Rows[j]["Size"]%>'><%=sDT.Rows[j]["Size"]%> <%=sDT.Rows[j]["SizeDataType"]%></option>
                                        <%} %>  
                                     <%} %>
                                    </select>
                                    </label>
                                         <span>Select Varient</span></a>
                                    <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='Select1'>
                                    <%for (int j = 1; j <= 10;j++ ){ %>
                                        <option value='<%=j %>'><%=j %></option>
                                     <%} %>
                                   </select> </label>
                                    <span>Select Quantity</span></a>
                                <%} %>
                            </div> 
                            <div class="center">
                                    <a class="compare-view1"><label><button sku='<%=catDT.Rows[i]["SKUCode"]%>' styl='<%=catDT.Rows[i]["StyleCode"]%>' addTocart>ADD TO CART</button></label><span>Buy Now</span></a>
                            </div>
                                  <div class="wishquick1" style="height:33px">
                                    <a class="wish-list1" name='saveLater' sku='<%=catDT.Rows[i]["SKUCode"]%>'><span><%=getToolTip()%></span></a>
                                    <a class="quick-view1" pop='<%=catDT.Rows[i]["SKUCode"] %>'><span>Quick View</span></a>
                                    <a class="compare-view"><input style="float:right" title="Add To Compare List" type="checkbox"  compare pName="<%=catDT.Rows[i]["SKUName"]%>" pBrand="<%=catDT.Rows[i]["SKUBrand"]%>"sku='<%=catDT.Rows[i]["SKUCode"]%>'/>Compare&nbsp;<span>Compare</span></a>
                                </div>   
                            </div>          
                        </div>
                  
                     </div>
               <%} %>
               </div>
       
<input type="hidden" id="PBrand" value="<%=Request.Params["PBrand"] %>" />
<input type="hidden" value="<%=PageNo%>" name="pageNo" id="pageNo"/>
 <%} %>
