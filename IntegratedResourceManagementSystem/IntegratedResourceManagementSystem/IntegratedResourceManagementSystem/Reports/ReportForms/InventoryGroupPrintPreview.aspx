<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryGroupPrintPreview.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.InventoryGroupPrintPreview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>INVENTORY GROUP</title>
    <link href="../../Styles/toolbar-controls.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    #gvCustomers th 
    {
        padding:5px;
    }
     #gvCustomers tr td
    {
         padding-left:5px;
         padding-right:5px;
         padding-bottom:2px;
         padding-top:2px;
         
    }
    </style>
    <style type="text/css" media="print" >
        #btnPrint
        {
            visibility:hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size:12px; font-weight:bold; margin-bottom:3px;">
        GROUP NAME: <asp:Label ID="lblGroupName" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSourceCustomersInventory" Font-Size="10px">
            <Columns>
                <asp:BoundField DataField="ROW_COUNT" HeaderText="" ReadOnly="True" 
                    SortExpression="ROW_COUNT" >
                <ItemStyle Font-Bold="True" />
                </asp:BoundField>
               <%-- <asp:BoundField DataField="ACCOUNT_NAME" HeaderText="ACCOUNT NAME" 
                    SortExpression="ACCOUNT_NAME" />--%>
                <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="OUTLET" 
                    SortExpression="CUSTOMER_NAME" />
                <asp:BoundField DataField="BRAND_NAME" HeaderText="BRAND" 
                    SortExpression="BRAND_NAME" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceCustomersInventory" runat="server" 
            ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>" 
            SelectCommand="SELECT [CUSTOMER_NAME],[BRAND_NAME], ROW_NUMBER() OVER(PARTITION BY BRAND_NAME ORDER BY CUSTOMER_NAME ASC) AS ROW_COUNT FROM [IRMS-DB].[dbo].[CUSTOMER_INVENTORY_GROUPS] WHERE ([INVENTORY_GROUP_ID] = @INVENTORY_GROUP_ID)">
            <SelectParameters>
                <asp:QueryStringParameter Name="INVENTORY_GROUP_ID" 
                    QueryStringField="GroupNumber" Type="Int64" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Label ID="lblTotal" runat="server" Text="Label" Font-Bold="True" 
            Font-Size="11px"></asp:Label>
    </div>
    <div style="text-align:center; margin-top:10px;">
        <input id="btnPrint" type="button" class="btnPrint" value="PRINT" onclick="window.print()" />
    </div>
    </form>
</body>
</html>
