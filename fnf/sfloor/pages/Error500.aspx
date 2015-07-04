<%@ Page Title="" Language="C#"  CodeFile="Error500.aspx.cs" Inherits="sfloor_pages_Error500" %>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
    <%=Head %>
</head>
<body>
        <div class="page">
            <%=Header %>
          <div class="container"> 
       
            <h1 style='color'>Opps !! Somethings went wrong, Internal Server Error.</h1>
            <h4 style='color'>This site is under construction, our team will review the error and will provide the solution ASAP</h4>
            <h4 style='color'>Thank You!!</h4>
			<%--"Error"+System.Web.HttpContext.Current.Session["error"] --%>
			
            <!-- End -->

       </div>      <%=Footer %>
        </div>
</body>
</html>