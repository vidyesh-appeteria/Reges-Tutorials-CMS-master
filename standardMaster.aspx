<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="standardMaster.aspx.cs" Inherits="standardMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        $(function () {
            var chBoard = '#<%= ddlBoardName.ClientID%>';
            var chStd = '#<%= txtStandardName.ClientID%>';
            $("#btnClear").on("click", function () {
                $(chStd).val("");
                $(chBoard).get(0).selectedIndex = 0;
            });
        });
    </script>
    <center>
               
        <div id="dvMain" runat="server">
            
            <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false"  />
            <br />
            <fieldset style="width:43%">
            <table style="width:99%">
                  <tr>
                    <td>
                        <asp:Label ID="lblBoardName" runat="server" Text="Board"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBoardName" runat="server">
                            <asp:ListItem>

                            </asp:ListItem>
                        </asp:DropDownList>
<%--                        <asp:TextBox ID="txtBoardName" runat="server"></asp:TextBox>--%>
<%--                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Standard Name" ControlToValidate="txtStandardName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>--%>

                    </td>
              
                    <td>
                        <asp:Label ID="lblStandardName" runat="server" Text="Standard"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtStandardName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvStandardName" runat="server" ErrorMessage="Enter Standard Name" ControlToValidate="txtStandardName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>

              <tr>
         <td colspan="6">
              <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />
                </center>
         </td>
                </tr>

            </table>
                </fieldset>
     
         <br />
            <asp:GridView ID="gvStandard" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvStandard_RowDataBound" OnPageIndexChanging="gvStandard_PageIndexChanging"  Width="45%"
                 OnRowEditing="gvStandard_RowEditing" OnRowCancelingEdit="gvStandard_RowCancelingEdit" OnRowUpdating="gvStandard_RowUpdating" OnRowDeleting="gvStandard_RowDeleting" EmptyDataText="No records found" AllowPaging="true" PageSize="5" 
                AllowSorting="true">
                <Columns>
     <asp:TemplateField>
                        <ItemTemplate>
                          <asp:HiddenField ID="hdnStandardId" runat="server" Value='<%# Eval("standard_id") %>'></asp:HiddenField>
                            </ItemTemplate>
                             </asp:TemplateField>
                     <asp:TemplateField ItemStyle-Height="40px" HeaderText="Board">
                        <ItemTemplate>
                           <asp:Label ID="lblBoard" runat="server" Text='<%# Eval("Board") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
<%--                            <asp:DropDownList ID="ddlBoard" runat="server" />--%>
                       <asp:DropDownList runat="server" ID="ddlBoard" />
                            <asp:HiddenField ID="hdnboardid" Value='<%# Eval("board_id") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>                   
                    <asp:TemplateField ItemStyle-Height="40px" HeaderText="Standard">
                        <ItemTemplate>
                           <asp:Label ID="lblStandard" runat="server" Text='<%# Eval("Standard") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStandard" runat="server"  Text='<%# Eval("Standard") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>                   
                   <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton ="true" CausesValidation="false" HeaderText="Action"  ControlStyle-Height="30px" ControlStyle-Width="80px"/>
                                    </Columns>
                <PagerSettings Mode="Numeric" Position="Bottom" />
            </asp:GridView>
            <asp:HiddenField    id="hdnSort" runat="server" Value="ASC" />
          
        </div>
        
          <asp:LinkButton Text=" Trash" ID="lnkTrash" Visible="false" runat="server"
        OnClick="lnkTrash_Click" CausesValidation="false"  />
          <asp:panel runat="server" ScrollBars="Vertical" Height="450px" SkinID="none" ID="pnlTrash">
            <asp:GridView ID="gvStandardTrash" runat="server" AutoGenerateColumns="false" OnRowCommand="gvStandardTrash_RowCommand" Width="60%">
                <Columns>
                    <asp:BoundField  HeaderText="Board" DataField="Board" />
                    <asp:BoundField  HeaderText="Standard" DataField="Standard" />

     <asp:TemplateField>
                        <ItemTemplate>
                          <asp:Button ID="btnRestore" Text="Restore" CommandName="RESTORE" runat="server" 
                              CommandArgument='<%# Eval("standard_id") %>'></asp:Button>
                            </ItemTemplate>
                             </asp:TemplateField>
                  </Columns>
            </asp:GridView>
              </asp:panel>
            </center>
<asp:HiddenField ID="hdnUserid" runat="server" Value="0"></asp:HiddenField>
</asp:Content>

