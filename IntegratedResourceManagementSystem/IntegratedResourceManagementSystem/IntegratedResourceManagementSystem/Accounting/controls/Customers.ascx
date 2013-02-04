<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Customers.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.Customers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link rel="stylesheet" type="text/css" href="../../Styles/modal-controls.css" />
<style type="text/css">
   
    .sizeLogo
    {
        margin-top: 5px;
        float: left;
        font-size: 10px;
        color: #FFFFFF;
        letter-spacing: 2px;
        font-weight: 700;
        text-shadow: 1px 1px 0px #A0B051;
        cursor: pointer;
    }
    
    .modalWarningButtonYes
    {
        font-family: Verdana;
        font-size: 11px;
        height: 30px;
        text-align: right;
        width: 57px;
        cursor: pointer;
        background: url('../Resources/yes.png'), rgb(213,206,166); /* Old browsers */ /* IE9 SVG, needs conditional override of 'filter' to 'none' */
        background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iI2Q1Y2VhNiIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjQwJSIgc3RvcC1jb2xvcj0iI2M5YzE5MCIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiNiN2FkNzAiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
        background: url('../Resources/yes.png'), -moz-linear-gradient(top,  rgba(213,206,166,1) 0%, rgba(201,193,144,1) 40%, rgba(183,173,112,1) 100%); /* FF3.6+ */
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(213,206,166,1)), color-stop(40%,rgba(201,193,144,1)), color-stop(100%,rgba(183,173,112,1))); /* Chrome,Safari4+ */
        background: url('../Resources/yes.png'),-webkit-linear-gradient(top,  rgba(213,206,166,1) 0%,rgba(201,193,144,1) 40%,rgba(183,173,112,1) 100%); /* Chrome10+,Safari5.1+ */
        background: url('../Resources/yes.png'),-o-linear-gradient(top,  rgba(213,206,166,1) 0%,rgba(201,193,144,1) 40%,rgba(183,173,112,1) 100%); /* Opera 11.10+ */
        background: url('../Resources/yes.png'), -ms-linear-gradient(top,  rgba(213,206,166,1) 0%,rgba(201,193,144,1) 40%,rgba(183,173,112,1) 100%); /* IE10+ */
        background: url('../Resources/yes.png'), linear-gradient(to bottom,  rgba(213,206,166,1) 0%,rgba(201,193,144,1) 40%,rgba(183,173,112,1) 100%); /* W3C */
        filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#d5cea6', endColorstr='#b7ad70',GradientType=0 ); /* IE6-8 */
        padding: 5px 5px;
        background-repeat: no-repeat;
        background-position: left;
        border-radius: 5px 5px 0px 0px;
        text-shadow: 1px 1px 1px #fcffad;
        color: #696969;
        border-radius: 5px;
        border: 1px Solid #899A2B;
        border-radius: 5px 3px 5px 3px;
    }
    .style1
    {
        font-family: Verdana;
        font-size: small;
    }


.btnBrowse
{
	font-family:Verdana ;
	font-weight :bold;
	font-size: 10px;
	height :20px;
	text-align :right;
	background: rgb(252,234,187); /* Old browsers */
	/* IE9 SVG, needs conditional override of 'filter' to 'none' */
	background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iI2ZjZWFiYiIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjUwJSIgc3RvcC1jb2xvcj0iI2ZjY2Q0ZCIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjUxJSIgc3RvcC1jb2xvcj0iI2Y4YjUwMCIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiNmYmRmOTMiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
	background:url('../Resources/openfile.png'),  -moz-linear-gradient(top,  rgba(252,234,187,1) 0%, rgba(252,205,77,1) 50%, rgba(248,181,0,1) 51%, rgba(251,223,147,1) 100%); /* FF3.6+ */
	background:url('../Resources/openfile.png'),  -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(252,234,187,1)), color-stop(50%,rgba(252,205,77,1)), color-stop(51%,rgba(248,181,0,1)), color-stop(100%,rgba(251,223,147,1))); /* Chrome,Safari4+ */
	background: url('../Resources/openfile.png'), -webkit-linear-gradient(top,  rgba(252,234,187,1) 0%,rgba(252,205,77,1) 50%,rgba(248,181,0,1) 51%,rgba(251,223,147,1) 100%); /* Chrome10+,Safari5.1+ */
	background: url('../Resources/openfile.png'), -o-linear-gradient(top,  rgba(252,234,187,1) 0%,rgba(252,205,77,1) 50%,rgba(248,181,0,1) 51%,rgba(251,223,147,1) 100%); /* Opera 11.10+ */
	background: -ms-linear-gradient(top,  rgba(252,234,187,1) 0%,rgba(252,205,77,1) 50%,rgba(248,181,0,1) 51%,rgba(251,223,147,1) 100%); /* IE10+ */
	background: linear-gradient(to bottom,  rgba(252,234,187,1) 0%,rgba(252,205,77,1) 50%,rgba(248,181,0,1) 51%,rgba(251,223,147,1) 100%); /* W3C */
	filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#fceabb', endColorstr='#fbdf93',GradientType=0 ); /* IE6-8 */

	background-repeat:no-repeat;
	background-position:left;
	color:#775c16;
	padding-left:17px;      
	cursor:pointer;
	text-shadow: 1px 1px 1px #E0E0E0;
	border-radius:5px 3px 5px 3px;
	border:1px Solid #7F921C;
}

 
    

</style>
<div>
    <asp:Label ID="Label1" runat="server" Text="CUSTOMER :" Style="font-family: Verdana;
        font-size: small"></asp:Label>
        <asp:TextBox ID="txtCustNo" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
    <asp:TextBox ID="txtCustName" runat="server" ReadOnly="True" 
        style="text-align: left" Width="193px"></asp:TextBox>
    <asp:Button ID="cboBrowse" runat="server" Text="......." 
        Style="font-size: small" CssClass="btnBrowse" ToolTip="BROWSE RECORD" />
    <asp:ModalPopupExtender ID="cboBrowse_ModalPopupExtender" runat="server" DynamicServicePath=""
        Enabled="True" PopupControlID="Panel" PopupDragHandleControlID="PanelDrag" TargetControlID="cboBrowse">
    </asp:ModalPopupExtender>
</div>
<asp:Panel ID="Panel" runat="server" Height="326px" Width="411px" 
    CssClass = "modal">
    <div>
        <asp:Panel ID="PanelDrag" runat="server" Height="27px" CssClass = "modalDrag" Style="text-align: right;
            background-color: #666666">
            <div class="sizeLogo">
                <asp:Image ID="Image3" runat="server" Height="16px" ImageAlign="AbsBottom" ImageUrl="~/Resources/usermode.png" />
                OUTLETS LIST
            </div>
            <asp:ImageButton ID="imgClose" runat="server" Height="24px" ImageUrl="~/Resources/cancel_gray.png"/>
        </asp:Panel>
    </div>
    
    <div class="SearchTextContainer" align="right">
        <span>SEARCH</span>:
        <asp:TextBox ID="txtSearchOutlet" runat="server" CssClass="modalText" 
            Height="16px" ToolTip="FILTER BY COMPANY NAME"></asp:TextBox>
        
        <asp:ImageButton ID="imgBtnSearchOutlet" runat="server" ImageUrl="~/Resources/search.png"
            ImageAlign="AbsMiddle" OnClick="imgBtnSearchOutlet_Click" 
            ToolTip="FILTER BY COMPANY NAME" />
    </div>
    <div style="height: 209px; background-color: #C0C0C0">
        <asp:Panel ID="Panel1" runat="server" Height="224px" ScrollBars="Both"  
            Width="408px"> 
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" Font-Names="Verdana" Font-Size="11px"
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                GridLines="Horizontal" AllowPaging="True" 
                OnPageIndexChanging="GridView1_PageIndexChanging" 
                onselectedindexchanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="imgOutlet" runat="server" 
                                ImageUrl="~/Resources/invoice.png" Height="16px" Width="16px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="CustomerNumber" HeaderText="CUSTOMER NUMBER">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CompanyName" HeaderText="COMPANY">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Brand" HeaderText="BRAND">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </asp:Panel>
        <div align="center" style = "padding:5px;">
            <asp:Button ID="btnSelectOutlet" runat="server" CssClass="modalWarningButtonYes"
                OnClick="btnSelectOutlet_Click" Text="OK" />
        </div>
    </div>
</asp:Panel>
