<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting-Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="UsersPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting_Admin.UsersPanel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
     #FormContentPlaceHolder_gvUsers tr:nth-child(n+2):hover
        {
background: rgb(157,213,58); /* Old browsers */
/* IE9 SVG, needs conditional override of 'filter' to 'none' */
background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iIzlkZDUzYSIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjUwJSIgc3RvcC1jb2xvcj0iI2ExZDU0ZiIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjUxJSIgc3RvcC1jb2xvcj0iIzgwYzIxNyIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiM3Y2JjMGEiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
background: -moz-linear-gradient(top,  rgba(157,213,58,1) 0%, rgba(161,213,79,1) 50%, rgba(128,194,23,1) 51%, rgba(124,188,10,1) 100%); /* FF3.6+ */
background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(157,213,58,1)), color-stop(50%,rgba(161,213,79,1)), color-stop(51%,rgba(128,194,23,1)), color-stop(100%,rgba(124,188,10,1))); /* Chrome,Safari4+ */
background: -webkit-linear-gradient(top,  rgba(157,213,58,1) 0%,rgba(161,213,79,1) 50%,rgba(128,194,23,1) 51%,rgba(124,188,10,1) 100%); /* Chrome10+,Safari5.1+ */
background: -o-linear-gradient(top,  rgba(157,213,58,1) 0%,rgba(161,213,79,1) 50%,rgba(128,194,23,1) 51%,rgba(124,188,10,1) 100%); /* Opera 11.10+ */
background: -ms-linear-gradient(top,  rgba(157,213,58,1) 0%,rgba(161,213,79,1) 50%,rgba(128,194,23,1) 51%,rgba(124,188,10,1) 100%); /* IE10+ */
background: linear-gradient(top,  rgba(157,213,58,1) 0%,rgba(161,213,79,1) 50%,rgba(128,194,23,1) 51%,rgba(124,188,10,1) 100%); /* W3C */
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#9dd53a', endColorstr='#7cbc0a',GradientType=0 ); /* IE6-8 */

        }
</style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="FormContentPlaceHolder" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upnlUser" runat="server">
        <ContentTemplate>
            <div class="tool-bar">
                <asp:Button ID="btnNew" runat="server" Text="NEW" CssClass="btn" />
                <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" CssClass="btn" />
                <asp:Button ID="btnDelete" runat="server" Text="DELETE" CssClass="btn" />
                <asp:Button ID="btnPrint" runat="server" Text="PRINT" CssClass="btn" />
                <asp:Button ID="btnAssignBrand" runat="server" CssClass="btn" />
                <asp:Label ID="lblSuccessSaved" runat="server" ></asp:Label>
                 <asp:ModalPopupExtender ID="lblSuccessSaved_ModalPopupExtender" runat="server" 
                    CancelControlID="btnOK" DynamicServicePath="" Enabled="True" 
                    PopupControlID="pnlSuccess" PopupDragHandleControlID="pnlSuccessDrag" 
                    TargetControlID="lblSuccessSaved">
                </asp:ModalPopupExtender>
                 <asp:UpdateProgress ID="upupnlUser" runat="server" AssociatedUpdatePanelID="upnlUser"
                        DisplayAfter="100">
                        <ProgressTemplate>
                            <asp:PlaceHolder ID="plcHldrLoader" runat="server">
                                <UC:LOADER ID="loader" runat="server" />
                            </asp:PlaceHolder>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                <asp:ModalPopupExtender ID="btnAssignBrand_ModalPopupExtender" runat="server" DynamicServicePath=""
                    Enabled="True" PopupControlID="pnlSetBrandModal" PopupDragHandleControlID="pnlSetBrandModalDrag"
                    TargetControlID="btnAssignBrand" BackgroundCssClass="bgModal" CancelControlID="btnCancel">
                    <Animations>
                        <OnShown>
                            <FadeIn Duration=".3" />
                        </OnShown>
                    </Animations>
                </asp:ModalPopupExtender>
                <div style="float: right;">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="searchBox" Width="100px"></asp:TextBox>
                    <asp:ImageButton ID="ibtnSearch" runat="server" ImageAlign="AbsMiddle" 
                        ImageUrl="~/Resources/search.png" onclick="ibtnSearch_Click" />
                </div>
            </div>
            <asp:GridView ID="gvUsers" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSourceUsers"
                Font-Names="Verdana" ForeColor="#663300" GridLines="None" 
                OnSelectedIndexChanged="gvUsers_SelectedIndexChanged" PageSize="15" 
                EnablePersistedSelection="True">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="USER ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" />
                    <asp:BoundField DataField="UserName" HeaderText="USER NAME" 
                        SortExpression="UserName" >
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FullName" HeaderText="FULL NAME" 
                        SortExpression="FullName" >
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Email" HeaderText="EMAIL-ADD" 
                        SortExpression="Email" >
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ListDesc" HeaderText="DEPARTMENT" 
                        SortExpression="ListDesc" >
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UserLevel" HeaderText="USER LEVEL" 
                        SortExpression="UserLevel" >
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <EmptyDataTemplate>
                    <img src="../Resources/unhappy.png" align="middle" />
                    NO RECORDS FOUND!!
                </EmptyDataTemplate>
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSourceUsers" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                SelectCommand="SELECT Users.ID, Users.UserName, Users.FullName, Users.Email, lstDept.ListDesc, lstUserLevel.ListDesc AS UserLevel FROM Users INNER JOIN lstDept ON Users.DeptID = lstDept.ID INNER JOIN lstUserLevel ON Users.UserLevelID = lstUserLevel.ID WHERE (lstDept.ID = 4)">
            </asp:SqlDataSource>
            <asp:Panel ID="pnlSetBrandModal" runat="server" CssClass="modal">
                <asp:Panel ID="pnlSetBrandModalDrag" runat="server" CssClass="modalDrag">
                    <asp:Label ID="Label1" runat="server" Text="ASSIGN BRAND" CssClass="head-title"></asp:Label>
                </asp:Panel>
           
                        <asp:Panel ID="pnlAssignBrand" runat="server">
                            <div style="margin: 5px 5px;">
                                <asp:HiddenField ID="hfUserBrandId" runat="server" />
                                <asp:Panel ID="pnlError" runat="server">
                                    <div class="info">
                                        <asp:Label ID="Label3" runat="server" Text="Set Brand for account:" Font-Names="Verdana"
                                            ForeColor="#CC6600"></asp:Label>
                                          
                                        <br />
                                        <asp:Label ID="lblUser" runat="server" Text="Please Select user from the list, and try again!!"
                                            Font-Names="Verdana" ForeColor="#993300" Font-Italic="True"></asp:Label>
                                              <br />
                                        <asp:Label ID="Label4" runat="server" Text="Password:##########"
                                            Font-Names="Verdana" ForeColor="#993300" Font-Italic="True"></asp:Label>
                                             <br />
                                            <asp:Label ID="lblAssignedbrand" runat="server" Text="assigned brand" Font-Names="Verdana"
                                            ForeColor="#CC6600"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <div>
                                    <asp:CheckBox ID="checkReAssignBrand" Text="RE ASSIGN BRAND" runat="server" 
                                        AutoPostBack="True" Font-Names="Verdana" Font-Size="11px" 
                                        oncheckedchanged="checkReAssignBrand_CheckedChanged" />
                                </div>
                                <asp:Label ID="Label2" runat="server" Text="SELECT BRAND:" Font-Bold="True" Font-Names="Verdana"
                                    Font-Size="11px" ForeColor="#993300"></asp:Label>
                                <asp:DropDownList ID="ddListBrands" runat="server" DataSourceID="SqlDataSourceBrands"
                                    DataTextField="BRAND_DESCRIPTION" DataValueField="BRAND_DESCRIPTION" Font-Bold="True"
                                    Font-Names="Verdana" Font-Size="11px" ForeColor="#CC6600" Height="20px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceBrands" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                                    SelectCommand="SELECT [BRAND_DESCRIPTION], [BRAND_CODE] FROM [BRANDS]"></asp:SqlDataSource>
                                <asp:CheckBox ID="checkAll" Text="ALL" runat="server" Font-Bold="True" 
                                    Font-Names="Verdana" Font-Size="11px" ForeColor="#CC6600" />
                            </div>
                            <div style="text-align: center; margin: 5px 5px;">
                                <asp:Button ID="btnAssign" runat="server" Text="ASSIGN" CssClass="btn" OnClick="btnAssign_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CssClass="btn" />
                            </div>
                        </asp:Panel>
                   
            </asp:Panel>

              <asp:Panel ID="pnlSuccess" runat="server" CssClass="modal">
                <asp:Panel ID="pnlSuccessDrag" runat="server" CssClass="modalDrag">
                    <asp:Label ID="Label5" runat="server" Text="SUCCESS!!" CssClass="head-title"></asp:Label>
                </asp:Panel>
                <div style ="padding:10px 5px; text-align:center;">
                    <asp:Label ID="Label6" runat="server" Text="Brand for Selected Account Successfully saved!" 
                        Font-Names="Verdana" ForeColor="#993300"></asp:Label>
                </div>
                <div style="text-align:center; margin:5px 5px;">
                    <asp:Button ID="btnOK" runat="server" Text="OK" CssClass="btn" />
                </div>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
