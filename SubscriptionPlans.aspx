<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="SubscriptionPlans.aspx.cs" Inherits="SubscriptionPlans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        $(function () {

            $("#btnClear").on("click", function () {
                $('#<%= txtActualAmount.ClientID%>').val("");
                $('#<%= txtDiscountAmount.ClientID%>').val("");
                $('#<%= txtPeriod.ClientID%>').val("");
                $('#<%= txtPlanName.ClientID%>').val("");

            });
        });

    </script>
    <center>
               
        <div id="dvMain" runat="server">
             <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false"  />   <br />
             <input type="button" id="btnAdd" value="Add New" style="display: none;width:120px" class="button" />
            <div style="width:45%;position: relative;">
              <input type="button" id="btnClose" value="X" class="buttonSecond"  style=" position: absolute;right: 10px; top:10px;" /></div><br />
  <div id="effect" class="ui-widget-content ui-corner-all" style="width:45%">
            <table>
                <tr>
                    <td>
                        <asp:Label   runat="server" Text="Plan Name"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPlanName" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPlanName" runat="server" ErrorMessage="Enter Plan Name" ControlToValidate="txtPlanName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>
            <tr>
                    <td>
                        <asp:Label runat="server" Text="Actual Amount"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtActualAmount" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvActualAmount" runat="server" ErrorMessage="Enter Actual Amount" ControlToValidate="txtActualAmount" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                                   </tr>


                  <tr>
                    <td>
                        <asp:Label runat="server" Text="Discounted Amount"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDiscountAmount" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDiscountAmount" runat="server" ErrorMessage="Enter Discount Amount" ControlToValidate="txtDiscountAmount" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                                   </tr>

                  <tr>
                    <td>
                        <asp:Label runat="server" Text="Period (Days)"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPeriod" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPeriod" runat="server" ErrorMessage="Enter Period" ControlToValidate="txtPeriod" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                                   </tr>


              <tr>
         <td colspan="3">
              <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
               <input type="button" id="btnClear" value="Clear" class="buttonSecond"  />

            </center>    
         </td>
                </tr>

            </table>
</div>
      
            <asp:GridView ID="gvSubscripnPlans" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gvSubscripnPlans_PageIndexChanging1" Height="250px" Width="75%"
                 OnRowEditing="gvSubscripnPlans_RowEditing" OnRowCancelingEdit="gvSubscripnPlans_RowCancelingEdit" OnRowUpdating="gvSubscripnPlans_RowUpdating" OnRowDeleting="gvSubscripnPlans_RowDeleting" 
                EmptyDataText="No records found" AllowPaging="true" PageSize="5" 
                AllowSorting="true">
                <Columns>

                           
                         <asp:TemplateField>
                        <ItemTemplate>
                                         
                    
                          <asp:HiddenField ID="hdnPlanId" runat="server" Value='<%# Eval("plan_id") %>'></asp:HiddenField>
                            </ItemTemplate>
                             </asp:TemplateField>

                    <asp:TemplateField ItemStyle-Height="40px" HeaderText="Plan">
                        <ItemTemplate> 
                           <asp:Label  runat="server" Text='<%# Eval("plan_name") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPlanName" runat="server"  Text='<%# Eval("plan_name") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>   
                            

                       <asp:TemplateField ItemStyle-Height="40px" HeaderText="Amount">
                        <ItemTemplate> 
                           <asp:Label  runat="server" Text='<%# Eval("actual_amount") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtActualAmount" runat="server"  Text='<%# Eval("actual_amount") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>                   

                       <asp:TemplateField ItemStyle-Height="40px" HeaderText="Discount Amount">
                        <ItemTemplate> 
                           <asp:Label  runat="server" Text='<%# Eval("discount_amount") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDiscountAmount" runat="server"  Text='<%# Eval("discount_amount") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>                   
                                      
                       <asp:TemplateField ItemStyle-Height="40px" HeaderText="Period (Days)">
                        <ItemTemplate> 
                           <asp:Label  runat="server" Text='<%# Eval("period") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPeriod" runat="server"  Text='<%# Eval("period") %>' CssClass="datepicker"/>
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
             <asp:GridView ID="gvSubscripnPlansTrash" runat="server" AutoGenerateColumns="false"
                  OnRowCommand="gvSubscripnPlansTrash_RowCommand"  Width="75%">
                <Columns>
                    <asp:BoundField HeaderText="Plan" DataField="plan_name" />
                    <asp:BoundField HeaderText="Amount" DataField="actual_amount" />
                    <asp:BoundField HeaderText="Discount Amount" DataField="discount_amount" />
                           <asp:BoundField HeaderText="Period (Days)" DataField="period" />
     <asp:TemplateField>
                        <ItemTemplate>
                          <asp:Button ID="btnRestore"  Width="120px" Text="RESTORE"  runat="server" 
                              CommandName="RESTORE"
                              CommandArgument='<%# Eval("plan_id") %>'></asp:Button>
                            </ItemTemplate>
                             </asp:TemplateField>
                 </Columns>
 
                <PagerSettings Mode="Numeric" Position="Bottom" />
            </asp:GridView>
            </center>
    <asp:HiddenField ID="hdnPlanid" runat="server" Value="0"></asp:HiddenField>
</asp:Content>

