<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="branchmaster.aspx.cs" Inherits="branchmaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script>
        $(function () {
           
            $("#btnClear").on("click", function () {
                $('#<%= txtBranchName.ClientID%>').val("");
                $('#<%= txtAddress.ClientID%>').val("");
                $('#<%= txtContactPrimary.ClientID%>').val("");
                $('#<%= txtContactSecondary.ClientID%>').val("");
                $('#<%= txtLatitude.ClientID%>').val("");
                $('#<%= txtLongitude.ClientID%>').val("");
               
            });
        });
    </script>
        <center>
               
        <div id="dvMain" runat="server">
             
            <asp:HiddenField ID="hdnUserid" runat="server" Value="0"></asp:HiddenField>
            <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false"  />
            <br />
             <input type="button" id="btnAdd" value="Add New" style="display: none;width:120px" class="button" />
            <div style="width:45%;position: relative;">
              <input type="button" id="btnClose" value="X" class="buttonSecond"  style=" position: absolute;right: 10px; top:10px;" /></div><br />
  <div id="effect" class="ui-widget-content ui-corner-all" style="width:45%">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblBranchName" runat="server" Text="Branch Name"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBranchName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBranchName" runat="server" ErrorMessage="Enter Branch Name" ControlToValidate="txtBranchName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="lblAddress" runat="server" Text="Address Name"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Enter Address Name" ControlToValidate="txtAddress" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                                </tr>


                 <tr>
                    <td>
                        <asp:Label ID="lblContactPrimary" runat="server" Text="Contact Primary"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtContactPrimary" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContactPrimary" runat="server" ErrorMessage="Enter Contact Primary Name" ControlToValidate="txtContactPrimary" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="lblContactSecondary" runat="server" Text="Contact Secondary"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtContactSecondary" runat="server"></asp:TextBox>
<%--                        <asp:RequiredFieldValidator ID="rfvContactSecondary" runat="server" ErrorMessage="Enter Contact Secondary" ControlToValidate="txtContactSecondary" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>--%>

                    </td>
                                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="lblLatitude" runat="server" Text="Latitude"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLatitude" runat="server" ErrorMessage="Enter Latitude" ControlToValidate="txtLatitude" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="lblLongitude" runat="server" Text="Longitude"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLongitude" runat="server" ErrorMessage="Enter Longitude" ControlToValidate="txtLongitude" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                                </tr>


        

              <tr>
         <td colspan="3">
              
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
              <input type="button" id="btnClear" value="Clear" class="buttonSecond"  />
                 <%--<asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />--%>
                
         </td>
                </tr>

            </table>

         
      </div>

            <asp:GridView ID="gvBranch" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gvBranch_PageIndexChanging"  Width="95%"
                 OnRowEditing="gvBranch_RowEditing" OnRowCancelingEdit="gvBranch_RowCancelingEdit" OnRowUpdating="gvBranch_RowUpdating" OnRowDeleting="gvBranch_RowDeleting" EmptyDataText="No records found" AllowPaging="true" PageSize="5" 
                AllowSorting="true">
                <Columns>

                           
                         <asp:TemplateField>
                        <ItemTemplate>
                                         
                    
                          <asp:HiddenField ID="hdnBranchid" runat="server" Value='<%# Eval("branch_id") %>'></asp:HiddenField>
                            </ItemTemplate>
                             </asp:TemplateField>

                    <asp:TemplateField  HeaderText="Branch Name">
                        <ItemTemplate>
                           <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("branch_name") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBranch" runat="server"  Text='<%# Eval("branch_name") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>                   


                      <asp:TemplateField  HeaderText="Branch Address">
                        <ItemTemplate>
                           <asp:TextBox ID="lblBranchAddress" runat="server" Text='<%# Eval("address") %>' 
                               ReadOnly="true" BackColor="#e5e3f1" TextMode="MultiLine"
                               ForeColor="Black"></asp:TextBox>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBranchAddress" runat="server"  TextMode="MultiLine" Text='<%# Eval("address") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>                   


                      <asp:TemplateField  HeaderText="Contact Primary">
                        <ItemTemplate>
                           <asp:Label ID="lblBranchContactPrimary" runat="server" Text='<%# Eval("contact_primary") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBranchContactPrimary" runat="server"  Text='<%# Eval("contact_primary") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>                   


                      <asp:TemplateField  HeaderText="Contact Secondary">
                        <ItemTemplate>
                           <asp:Label ID="lblBranchContactSecondary" runat="server" Text='<%# Eval("contact_secondary") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBranchContactSecondary" runat="server"  Text='<%# Eval("contact_secondary") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>                   

                      <asp:TemplateField  HeaderText="Latitude">
                        <ItemTemplate>
                           <asp:Label ID="lblBranchLatitude" runat="server" Text='<%# Eval("latitude") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBranchLatitude" runat="server"  Text='<%# Eval("latitude") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>                   

                      <asp:TemplateField  HeaderText="Longitude">
                        <ItemTemplate>
                           <asp:Label ID="lblBranchLongitude" runat="server" Text='<%# Eval("longitude") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBranchLongitude" runat="server"  Text='<%# Eval("longitude") %>' />
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
          <asp:panel runat="server" ScrollBars="Vertical" Height="450px" SkinID="none">
               <asp:GridView ID="gvBranchTrash" runat="server" AutoGenerateColumns="false" OnRowCommand="gvBranchTrash_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Branch" DataField="branch_name" />
                    <asp:BoundField HeaderText="Address" DataField="address" />
                    <asp:BoundField HeaderText="Contact Primary" DataField="contact_primary" />
                    <asp:BoundField HeaderText="Contact Secondary" DataField="contact_secondary" />
                    <asp:BoundField HeaderText="Latitude" DataField="latitude" />
                    <asp:BoundField HeaderText="Longitude" DataField="longitude" />
                           
                         <asp:TemplateField>
                        <ItemTemplate>
                                         
                    
                          <asp:Button ID="btnRestore" CommandName="RESTORE" runat="server" Text="Restore"  CommandArgument='<%# Eval("branch_id") %>'></asp:Button>
                            </ItemTemplate>
                             </asp:TemplateField>
 </Columns>
            </asp:GridView>
          </asp:panel>

         
            </center>



</asp:Content>

