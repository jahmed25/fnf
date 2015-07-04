<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyFromCat.aspx.cs" Inherits="sfloor_pages_BuyFromCat" %>
<div class="categorydetails_info_bottom">
                            <a href=''>   
                                <div class="productpricesection">
                                <div class='lnkbtn_proname' title="<%=dt.Rows[0]["SKUName"]%>"><%=dt.Rows[0]["SKUName"]%></div>
                                <div class="splprice"><span class="margin">Rs.</span><%=dt.Rows[0]["SpecialPrice"]%></div>
                                 <%if (Int32.Parse(dt.Rows[0]["MRP"].ToString()) != (Int32.Parse(dt.Rows[0]["SpecialPrice"].ToString())))
                                   { %>
                                   <div class="crossprize" ><span class="margin">Rs.</span><%=dt.Rows[0]["MRP"]%> </div>
                                <%} %>
                               </div>
                              </a>
                                <div class="optionContainer">  
                                <div class="select_varient">
                                <%if ("normal".Equals(dt.Rows[0]["SKUClassification"].ToString().Trim().ToLower()))
                                  {%>
                                <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='qty-<%=dt.Rows[0]["StyleCode"]%>'>
                                    <%for (int j = 1; j <= 10; j++)
                                      { %>
                                        <option value='<%=j %>'><%=j %> <%=dt.Rows[0]["SizeDataType"]%></option>
                                     <%} %>
                                    </select>
                                    </label><span>Select Quantity</span></a>
                                <%}
                                  else
                                  { %>
                                     <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='ver-<%=dt.Rows[0]["StyleCode"]%>' ver-select>
                                    <% System.Data.DataTable sDT = SFloor.Services.CatDetailsService.getSizeDT(dt.Rows[0]["SKUCode"].ToString(), true); %>
                                    <%for (int j = 0; j < sDT.Rows.Count; j++)
                                      { %>
                                        <%if (sDT.Rows[j]["size"].ToString().Trim().Equals(dt.Rows[0]["size"].ToString().Trim()))
                                          {%>
                                            <option selected sku="<%=sDT.Rows[j]["SKUCode"]%>" value='<%=sDT.Rows[j]["Size"]%>'><%=sDT.Rows[j]["Size"]%> <%=dt.Rows[0]["SizeDataType"]%></option>
                                        <%}
                                          else
                                          {%>
                                            <option  sku="<%=sDT.Rows[j]["SKUCode"]%>" value='<%=sDT.Rows[j]["Size"]%>'><%=sDT.Rows[j]["Size"]%> <%=sDT.Rows[j]["SizeDataType"]%></option>
                                        <%} %>  
                                     <%} %>
                                    </select>
                                    </label>
                                         <span>Select Varient</span></a>
                                    <a class="compare-view1" style="z-index:auto"><label>
                                    <select id='qty-<%=dt.Rows[0]["StyleCode"]%>'>
                                    <%for (int j = 1; j <= 10; j++)
                                      { %>
                                        <option value='<%=j %>'><%=j %></option>
                                     <%} %>
                                   </select> </label>
                                    <span>Select Quantity</span></a>
                                <%} %>
                            </div> 
                            <div class="center">
                                    <a class="compare-view1"><label><button sku='<%=dt.Rows[0]["StyleCode"]%>' styl='<%=dt.Rows[0]["StyleCode"]%>' addTocart>ADD TO CART</button></label><span>Buy Now</span></a>
                            </div>
                                  <div class="wishquick1" style="height:33px">
                                    <a class="wish-list1" name='saveLater' sku='<%=dt.Rows[0]["SKUCode"]%>'><span><%=getToolTip()%></span></a>
                                    <a class="quick-view1" pop='<%=dt.Rows[0]["SKUCode"] %>'><span>Quick View</span></a>
                                    <a class="compare-view"><input style="float:right" title="Add To Compare List" type="checkbox"  compare pName="<%=dt.Rows[0]["SKUName"]%>" pBrand="<%=dt.Rows[0]["SKUBrand"]%>"sku='<%=dt.Rows[0]["SKUCode"]%>'/>Compare&nbsp;<span>Compare</span></a>
                                </div>   
                            </div>          
                        </div>