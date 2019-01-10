<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="Earning.aspx.cs" Inherits="Earning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    

    <center>
        <br />
      <input type="button" id="btnAdd" value="Search" style="display: none;width:120px" class="button" />
            <div style="width:60%;position: relative;">
              <input type="button" id="btnClose" value="X" class="buttonSecond"  style=" position: absolute;right: 10px; top:10px;" /></div><br />
  <div id="effect" class="ui-widget-content ui-corner-all" style="width:60%">
      <br /><br />
      <table>
          <tr>
              <td><asp:label text="Name" runat="server" /></td>
              <td><asp:TextBox ID="txtName" runat="server" /></td>
                <td><asp:label text="Status" runat="server" /></td>
              <td><asp:DropDownList ID="ddlStatus" runat="server">
                  
                  </asp:DropDownList></td>
              <td><asp:button text="Search" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />

               <asp:button text="Clear" ID="btnClear" OnClick="btnClear_Click" runat="server" />
              </td>
            
          </tr>
      </table>
      </div>
        <asp:Label id="lblError" runat="server" SkinID="LabelError" />
                            <div style="overflow: auto; height: 480px;">
    <asp:GridView ID="gvEarning" runat="server" AutoGenerateColumns="false" Width="90%"
        EmptyDataText="No records found" OnRowDataBound="gvEarning_RowDataBound"  >
        <Columns>
            <asp:BoundField HeaderText="Transaction Number" DataField="Transaction Number" />
            <asp:BoundField HeaderText="Transaction Date" DataField="Transaction Date" />
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Status" DataField="Status" />
            <asp:BoundField HeaderText="Amount" DataField="Amount" />
            <asp:BoundField HeaderText="Renewal Days" DataField="Renewal Days" />
            <asp:BoundField HeaderText="Plan" DataField="Plan" />
            
        </Columns>
    </asp:GridView>
                                </div>
        </center>
</asp:Content>

