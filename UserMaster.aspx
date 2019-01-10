<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="UserMaster.aspx.cs" Inherits="UserMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
    
    <div id="dvMain" runat="server">
        <asp:HiddenField ID="hdnUserId" runat="server" Value="0"></asp:HiddenField>
        <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" />
        <br />
        <table>
            <tr>
                <td style="width:15%">
                    <asp:Label ID="lblUserType" runat="server" Text="User Type"></asp:Label>
                </td>
                <td style="width:1%">:
                </td>
                <td style="width:39%">
                   <asp:RadioButtonList ID="rblUserType" runat="server" RepeatDirection="Horizontal"
                       OnSelectedIndexChanged="rblUserType_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Student" Value="STUDENT" />
                        <asp:ListItem Text="Parent" Value="PARENT" />
                       <asp:ListItem Text="Admin" Value="ADMIN" />
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="rfvUserType" runat="server" ErrorMessage="Select User Type" ControlToValidate="rblUserType"
                        Display="None" ForeColor="Red" ></asp:RequiredFieldValidator>

                </td>
                <td style="width:15%">
                    <asp:Label ID="lblFullName" runat="server" Text="Full Name"></asp:Label>
                </td>
                <td style="width:1%">:
                </td>
                <td>
                        <asp:TextBox ID="txtFullName" runat="server" MaxLength="60"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ErrorMessage="Enter Full Name" ControlToValidate="txtFullName"
                        Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="60"></asp:TextBox>                    
                </td>
                <td>
                    <asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                        <asp:TextBox ID="txtMobile" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfMobile" runat="server" ErrorMessage="Enter Mobile Number" ControlToValidate="txtMobile"
                        Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>

                
            </tr>
                <tr>
                <td colspan="6">
          
                    <table style="width:100%" id="tblParentView" runat="server">
          
                <tr>
                <td style="width:15%">
                    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td style="width:1%">:
                </td>
                <td style="width:39%">
                   <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Male" Value="M" />
                        <asp:ListItem Text="Female" Value="F" />                       
                    </asp:RadioButtonList>                    

                </td>
                <td style="width:15%">
                    <asp:Label ID="lblLocality" runat="server" Text="Locality"></asp:Label>
                </td>
                <td style="width:1%">:
                </td>
                <td>
                  <asp:TextBox ID="txtLocality" runat="server" MaxLength="60"></asp:TextBox>
               
                </td>
            </tr>
                        </table></td></tr>
              <tr>
                <td colspan="6">
          
                    <table style="width:100%" id="tblStudentView" runat="server">
              <tr>
                <td style="width:15%">
                    <asp:Label ID="lblInstitute" runat="server" Text="Institute"></asp:Label>
                </td>
                <td style="width:1%">:
                </td>
                <td style="width:39%">
                          <asp:DropDownList ID="ddlInstitute" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvInstitute" runat="server" ErrorMessage="Select Institute" ControlToValidate="ddlInstitute"
                        Display="None" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
                <td style="width:15%">
                    <asp:Label ID="lblMedium" runat="server" Text="Medium"></asp:Label>
                </td>
                <td style="width:1%">:
                </td>
                <td>
                    <asp:DropDownList ID="ddlMedium" runat="server" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" AutoPostBack="true" />
                    <asp:RequiredFieldValidator ID="rfvMedium" runat="server" ErrorMessage="Select Medium" ControlToValidate="ddlMedium"
                        Display="None" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBoard" runat="server" Text="Board"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" />
                    <asp:RequiredFieldValidator ID="rfvBoard" runat="server" ErrorMessage="Select Board" ControlToValidate="ddlBoard"
                        Display="None" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>

                <td>
                    <asp:Label ID="lblStandard" runat="server" Text="Standard"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged" />
                    <asp:RequiredFieldValidator ID="rfvStandard" runat="server" ErrorMessage="Select Standard" ControlToValidate="ddlStandard"
                        Display="None" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
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
                    <asp:RequiredFieldValidator ID="rfvBatch" runat="server" ErrorMessage="Select Batch" ControlToValidate="ddlBatch"
                        Display="None" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
                           <td>
                    <asp:Label ID="lblPhoto" runat="server" Text="Photo"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:FileUpload ID="fuPhoto" runat="server" />
                    <asp:image ID="ivPhoto" runat="server" Width="60px" />
                    <asp:LinkButton ID="lnkRemovePhoto" runat="server" Text="Remove Photo" OnClick="lnkRemovePhoto_Click" />
                </td>
               
</tr>
                        </table>
                    </td>
                  </tr>
            <tr>
                <td colspan="6">
                    <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Users.aspx" CausesValidation="False" SkinID="ButtonSecond" />
            </center>
                </td>
            </tr>
                <tr>
                <td colspan="6">
          <center>
                    <table style="width:100%" id="tblChilds" runat="server" visible="false">
                        <tr>
                            <td style="width:25%"><asp:Label ID="Label1" runat="server" Text=" Select Child"></asp:Label></td>
                            <td style="width:50%">
       <asp:DropDownList ID="ddlChild" runat="server" ValidationGroup="ADD"  width="99%" />
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Select Child" ControlToValidate="ddlChild"
                        Display="None" ForeColor="Red" InitialValue="0" ValidationGroup="ADD"  ></asp:RequiredFieldValidator>
             
                            </td>
                            <td>
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                     
                                <asp:gridview runat="server" ID="gvChildren" OnRowCommand="gvChildren_RowCommand" AutoGenerateColumns="false" Width="99%">
                                    <Columns>
                                        <asp:TemplateField >
                                            <ItemTemplate>
                       <asp:Button ID="btnDelete" runat="server" Text="Remove" Width="120px" CommandName="DEL" 
                           CommandArgument='<%# Eval("user_id") %>'></asp:Button>
                </ItemTemplate>
           
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText ="Name" DataField="full_name" />
                                        <asp:BoundField HeaderText ="Mobile" DataField="mobile" />
                                    </Columns>
                                </asp:gridview>
                            </td>
                        </tr>
                        </table>
              </center>
              </td></tr>
        </table>
    </div>
    </center>
</asp:Content>

