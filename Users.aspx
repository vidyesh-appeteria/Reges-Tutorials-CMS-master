<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       
    <center>
        <div id="dvMain" runat="server">
        <br />
            <asp:button text="Add New User" runat="server" width="150px" PostBackUrl="~/UserMaster.aspx"/>
            <br /><br />
       <fieldset style="width:96%">
      <table>
          <tr>
              <td><asp:label text="Name" runat="server" /></td>
              <td><asp:TextBox ID="txtName" runat="server" /></td>
                <td><asp:label text="User Type" runat="server" /></td>
              <td><asp:DropDownList ID="ddlUserType" runat="server">
                  <asp:ListItem Text="All" Value="" />
                  <asp:ListItem Text="Admin" Value="ADMIN" />
                  <asp:ListItem Text="Student" Value="STUDENT" />
                  <asp:ListItem Text="Parent" Value="PARENT" />
                  </asp:DropDownList></td>
              <td><asp:button text="Search" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />

               <asp:button text="Clear" ID="btnClear" OnClick="btnClear_Click" runat="server" />
              </td>
            
          </tr>
      </table>
           </fieldset>
   
         <asp:Label id="lblError" runat="server" SkinID="LabelError" />
              <asp:panel runat="server" ScrollBars="Vertical" Height="390px" SkinID="1">
    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" Width="96%"
        EmptyDataText="No records found"  OnRowCommand="gvUsers_RowCommand" >
        <Columns>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="120px" CommandName="EDT" 
                           CommandArgument='<%# Eval("user_id") %>'></asp:Button>
                       <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="120px" CommandName="DEL" 
                           CommandArgument='<%# Eval("user_id") %>' 
                           OnClientClick="return confirm('do you really want to remove this user?');"
                           ></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="Full_Name" />
            <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Locality" DataField="Locality" />
            <asp:BoundField HeaderText="School" DataField="institute_name" />
            <asp:BoundField HeaderText="Board" DataField="Board" />
            <asp:BoundField HeaderText="Standard" DataField="Standard" />
            <%--<asp:BoundField HeaderText="Future Self" DataField="Future Self" />
            <asp:BoundField HeaderText="Child Number" DataField="Child Number" />--%>
            <asp:BoundField HeaderText="User Type" DataField="user_type" />
            <asp:BoundField HeaderText="Created On" DataField="modified_on" />
        </Columns>
    </asp:GridView>
                  </asp:panel>
        </div>

          <asp:LinkButton Text=" Trash" ID="lnkTrash" Visible="false" runat="server"
        OnClick="lnkTrash_Click" CausesValidation="false"  />

        <asp:panel runat="server" ScrollBars="Vertical" Height="450px" SkinID="1" ID="pnlTrash">
    <asp:GridView ID="gvUsersTrash" runat="server" AutoGenerateColumns="false"
         Width="96%" OnRowCommand="gvUsersTrash_RowCommand" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                       <asp:Button ID="btnRestore" runat="server" Text="Restore" Width="120px" CommandName="RESTORE" CommandArgument='<%# Eval("user_id") %>'></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        <asp:BoundField HeaderText="Name" DataField="Full_Name" />
            <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Locality" DataField="Locality" />
            <asp:BoundField HeaderText="School" DataField="institute_name" />
            <asp:BoundField HeaderText="Board" DataField="Board" />
            <asp:BoundField HeaderText="Standard" DataField="Standard" />
            <%--<asp:BoundField HeaderText="Future Self" DataField="Future Self" />
            <asp:BoundField HeaderText="Child Number" DataField="Child Number" />--%>
            <asp:BoundField HeaderText="User Type" DataField="user_type" />
            <asp:BoundField HeaderText="Created On" DataField="modified_on" />
        </Columns>
    </asp:GridView></asp:panel>
        </center>


</asp:Content>

