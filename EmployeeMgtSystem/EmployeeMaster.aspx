﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeMaster.aspx.cs" Inherits="EmployeeMgtSystem.EmployeeMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:label id="Label1" runat="server" font-bold="True" font-italic="True" font-size="XX-Large" forecolor="#FF0066" text="EMPLOYEE"></asp:label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Name:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtEmployeeName" runat="server" Width="248px"></asp:TextBox>
            </td>
            <td rowspan="3">&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonField CommandName="Select" HeaderText="Select" ShowHeader="True" Text="Select" />
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="EmailId" HeaderText="Email" />
                        <asp:BoundField DataField="mob" HeaderText="Mobile" />
                        <asp:BoundField DataField="Add" HeaderText="Address" />
                        <asp:BoundField DataField="DepttName" HeaderText="Department" />
                        <asp:BoundField DataField="Designation" HeaderText="Designation" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Email:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtEmail" runat="server" Width="248px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px; height: 44px;">Mobile:</td>
            <td style="width: 216px; height: 44px;">
                <asp:TextBox ID="txtMobile" runat="server" Width="248px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="text-align: right; width: 80px">Address:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtAddress" runat="server" Width="248px" TextMode="MultiLine"></asp:TextBox>
             </td>
        </tr>
         <tr>
            <td style="text-align: right; width: 80px">Department:</td>
            <td style="width: 216px">
                <asp:DropDownList ID="ddDepartment" runat="server">
                </asp:DropDownList>
             </td>
        </tr>
         <tr>
            <td style="text-align: right; width: 80px">Designation:</td>
            <td style="width: 216px">
                <asp:DropDownList ID="ddDesignation" runat="server">
                </asp:DropDownList>
             </td>
        </tr>
         <tr>
            <td style="text-align: right; width: 80px">Status:</td>
            <td style="width: 216px">
                <asp:DropDownList ID="ddStatus" runat="server">
                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                    <asp:ListItem Value="1">Active</asp:ListItem>
                </asp:DropDownList>
             </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="92px" />
                &nbsp;&nbsp;
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" Width="92px" />
                &nbsp;&nbsp;
                <asp:Button ID="BtnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" Width="92px" OnClientClick="return confirm('Are you sure you want delete this data?')" />
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 80px">&nbsp;</td>
            <td style="width: 216px">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtId" runat="server" type="hidden"></asp:TextBox>
            </td>
            
        </tr>
    </table>
</asp:Content>
