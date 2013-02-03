<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionExpired.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.LogOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SESSION EXPIRED</title>
    <style type="text/css" >
    
    .container
    {
        background: #eab92d; /* Old browsers */
/* IE9 SVG, needs conditional override of 'filter' to 'none' */
background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iI2VhYjkyZCIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiNjNzk4MTAiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
background: -moz-linear-gradient(top,  #eab92d 0%, #c79810 100%); /* FF3.6+ */
background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#eab92d), color-stop(100%,#c79810)); /* Chrome,Safari4+ */
background: -webkit-linear-gradient(top,  #eab92d 0%,#c79810 100%); /* Chrome10+,Safari5.1+ */
background: -o-linear-gradient(top,  #eab92d 0%,#c79810 100%); /* Opera 11.10+ */
background: -ms-linear-gradient(top,  #eab92d 0%,#c79810 100%); /* IE10+ */
background: linear-gradient(to bottom,  #eab92d 0%,#c79810 100%); /* W3C */
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#eab92d', endColorstr='#c79810',GradientType=0 ); /* IE6-8 */
 padding:10px;
 text-align :center;
 width:250px;
 border:1px Solid #D7DCC0;
-webkit-box-shadow: 0 8px 6px -6px #95A63F;
-moz-box-shadow: 0 8px 6px -6px #95A63F;
box-shadow: 0 8px 6px -6px #95A63F;
border-radius:10px 5px 20px 2px;
font-family: Verdana;
color: #6B5F14;
white-space:normal;
text-shadow: 1px 1px 0px #E0E0E0;
font-weight: bold;
margin-top:20%;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <center>
    <div class="container"> 
        <img src="../Resources/sessionicon.png" alt="Session" />
        <div>
        Your Session is Expired!
        <a href="Login.aspx">LOG-IN</a>
        </div>
    </div>
    </center>
    </form>
</body>
</html>
