<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="SendNotification.aspx.cs" Inherits="SendNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    --%>
<center>
    <div id="dvMain" runat="server">

        <asp:HiddenField ID="hdnNotificationId" runat="server" Value="0"></asp:HiddenField>
        <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" />
        <br />
        <%--             <input type="button" id="btnAdd" value="Add New" style="display: none;width:120px" class="button" />--%>
        <div style="width: 45%; position: relative;">
            <input type="button" id="btnClose" value="X" class="buttonSecond" style="position: absolute; right: 10px; top: 10px;" />
        </div>
        <br />
        <%--<div id="effect" class="ui-widget-content ui-corner-all" style="width:45%">--%>
        <div style="width: 75%">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblUserType" runat="server" Text="Send to "></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUserType">
                            <asp:ListItem Text="All Users" Value="0" />
                            <asp:ListItem Text="Students" Value="STUDENT" />
                            <asp:ListItem Text="Teachers" Value="TEACHER" />
                            <asp:ListItem Text="Parents" Value="PARENT" />
                        </asp:DropDownList>

                    </td>
                    <td>
                        <asp:Label ID="lblBoards" runat="server" Text="Boards" ></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlBoard" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                        <td>
                        <asp:Label ID="lblStandard" runat="server" Text="Standards"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlStandard" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged"></asp:DropDownList>
                    </td>

                    <td>
                    <asp:Label ID="lblMedium" runat="server" Text="Medium"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged"
                        />
                   
                </td>
                  
                </tr>
                <tr>
                    
                         <td>
                    <asp:Label ID="lblBatch" runat="server" Text="Batch"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlBatch" runat="server" />
               
                </td>
                       <td>
                        <asp:Label ID="lblTittle" runat="server" Text="Tittle"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTittle" runat="server" MaxLength="500"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTittle" runat="server" ErrorMessage="Enter Tittle" ControlToValidate="txtTittle"
                            Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>

                </tr>
<tr>
                    <td>
                        <asp:Label ID="lblLink" runat="server" Text="Link"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>

                    </td>
                    <td>
                        <asp:Label ID="lblImage" runat="server" Text="Image"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:FileUpload ID="fuImage" runat="server" />
                          <a href="#" target="_blank" id="lnkImage" runat="server">
                        <asp:Image ID="imgImage" runat="server" style="width:75px" 
                            Visible="false"
                           CausesValidation="false"
                            ForeColor="Black"></asp:Image></a>
                        <asp:linkbutton text="Remove File" runat="server" ID="btnRemove" OnClick="btnRemove_Click" CausesValidation="false" />
                    </td>
                </tr>

                <tr>
                     <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtDescription" runat="server" MaxLength="5000" TextMode="MultiLine" Rows="2" Width="90%"></asp:TextBox>


                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                     OnClientClick="return confirm('Are you sure, you want to send the notification?');"
                     />
               <%--<asp:Button  id="btnClear" runat="server" Text="Clear" class="buttonSecond" onclick="btnClear_Click"  />--%>
                 <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />
            </center>
                    </td>
                </tr>

            </table>
        </div>

        <asp:Panel runat="server" ScrollBars="Vertical" Width="80%" Height="300px" SkinID="123">
         <asp:GridView ID="gvNotifications" runat="server" AutoGenerateColumns="false"
            Width="96%"             OnRowCommand="gvNotifications_RowCommand"            AllowSorting="true"
            EmptyDataText="No records found" >
            <Columns>


                <asp:TemplateField>
                    <ItemTemplate>


                        <asp:HiddenField ID="hdnNotificationId" runat="server" Value='<%# Eval("notification_id") %>'
                            
                            
                            
                            ></asp:HiddenField>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Height="40px" HeaderText="Tittle">
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("title") %>' ForeColor="Black"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTitle" runat="server" Text='<%# Eval("title") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Height="40px" HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("description") %>'
                            ForeColor="Black"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("description") %>' CssClass="datepicker" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Height="40px" HeaderText="Link">
                    <ItemTemplate>
                        <asp:HyperLink Target="_blank" NavigateUrl='<%# Eval("link") %>' ID="lblLink" runat="server" Text='<%# Eval("link") %>' ForeColor="Black"></asp:HyperLink>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLink" runat="server" Text='<%# Eval("link") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Height="40px" HeaderText="Image">
                    <ItemTemplate>
                        <a href='<%# "/notification_images/" + Eval("file_name") %>' target="_blank">
                        <asp:Image ID="imgImage" runat="server" style="width:75px" ImageUrl='<%# "~/notification_images/" + Eval("file_name") %>'
                            Visible='<%# Convert.ToString( Eval("file_name"))!=string.Empty %>' 
                           CausesValidation="false"
                            ForeColor="Black"></asp:Image></a>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:FileUpload runat="server" ID="fuImage" SelectedValue='<%# Eval("file_name") %>' />
                    </EditItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Resend">
                    <ItemTemplate>
                        <asp:button text="Resend" runat="server" CommandName="RESEND"  CausesValidation="false" CommandArgument='<%# Eval("notification_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>










            <PagerSettings Mode="Numeric" Position="Bottom" />
        </asp:GridView>
            </asp:Panel>
        <asp:HiddenField ID="hdnSort" runat="server" Value="ASC" />

    </div>

    <%--  <asp:LinkButton Text=" Trash" ID="lnkTrash" Visible="false" runat="server"
        OnClick="lnkTrash_Click" CausesValidation="false"  />

          <asp:GridView ID="gvCouponCodeTrash" runat="server" AutoGenerateColumns="false" 
                OnRowCommand="gvCouponCodeTrash_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Coupon Code" DataField="coupon_code" />
                    <asp:BoundField HeaderText="Valid Till" DataField="valid_till" />
                    <asp:BoundField HeaderText="No of Coupons" DataField="coupon_count" />
                    <asp:BoundField HeaderText="Discount(%)" DataField="Discount" />
                         <asp:TemplateField>
                        <ItemTemplate>
                                         
                    
                          <asp:Button ID="btnRestore" runat="server"
                              CommandName="RESTORE" Text="Restore"
                               CommandArgument='<%# Eval("Coupon_id") %>'></asp:Button>
                            </ItemTemplate>
                             </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
            </center>

</asp:Content>

