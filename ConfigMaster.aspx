 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="ConfigMaster.aspx.cs" Inherits="ConfigMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <center>
        <div>
            <asp:HiddenField ID="hdnUserid" runat="server" Value="0"></asp:HiddenField>
            <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false"  />
            <table>
              <tr>
         <td colspan="6">
            <center>
                            <asp:Label runat="server" Text="Theme" />
                     <br />
                            <asp:DropDownList runat="server" ID="ddlTheme" AutoPostBack="true" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged">
                                <asp:ListItem Text="Green" Value="Green" />
                                <asp:ListItem Text="Violet" Value="SkyBlue" />
                                <asp:ListItem Text="Red" Value="Red" />
                            </asp:DropDownList>
                        <br /><br />
              
       </center></td></tr>
                <tr>
                    
                    <td>
                        <asp:Label runat="server" Text="Min. Payment Amount"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <%--MinAmountForPayment--%>
                        <asp:TextBox ID="txtMinPaymentAmt" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqMinPaymentAmt" runat="server" ErrorMessage="Enter Min. Payment Amount" ControlToValidate="txtMinPaymentAmt" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                        
                    <td>
                        <asp:Label ID="lblChatDuration" runat="server" Text="Chat Duration"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtChatDuration" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvChatDuration" runat="server" ErrorMessage="Enter Chat Duration" ControlToValidate="txtChatDuration" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>

              
                  <tr>
                    <td>
                        <asp:Label ID="lblRatePerStar" runat="server" Text="Rate Per Star (INR)"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                      <asp:TextBox ID="txtRatePerStar" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfcRatePerStar" runat="server" ErrorMessage="Enter Rate Per Star" ControlToValidate="txtRatePerStar" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                       
                    </td>
                      <td>
                        <asp:Label ID="lblRatePerStarForWall" runat="server" Text="Rate Per Star For Answer (INR)"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                      <asp:TextBox ID="txtRatePerStarForWall" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfcRatePerStarForWall" runat="server" ErrorMessage="Enter Rate Per Star for Answer"
                            ControlToValidate="txtRatePerStarForWall" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                       
                    </td>
                </tr>

                <tr>
                    <td>
                         
                        <asp:Label ID="lblmaxchatduration" runat="server" Text="Maximum Chat Duration"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                           <asp:TextBox ID="txtmaxchatduration" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvmaxchatduration" runat="server" ErrorMessage="Enter Maximum Chat Duration" ControlToValidate="txtmaxchatduration" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                    <td>
                         
                        <asp:Label ID="Label1" runat="server" Text="Chat Timer Duration"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                           <asp:TextBox ID="txttimerduration" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtimerduration" runat="server" ErrorMessage="Enter Chat Timer Duration" ControlToValidate="txttimerduration" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                    <tr>
                    <td>
                         
                        <asp:Label ID="Label2" runat="server" Text="Max. Chats with Teacher/day"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                           <asp:TextBox ID="txtmaxchatwithteacher" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvmaxchatwithteacher" runat="server" ErrorMessage="Enter Max. Chats with Teacher" ControlToValidate="txttimerduration" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                    <td>
                         
                        <asp:Label ID="Label3" runat="server" Text="Free Trail Days"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                           <asp:TextBox ID="txtFreeTrailDays" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFreeTrailDays" runat="server" 
                            ErrorMessage="Enter Free Trail Days" ControlToValidate="txtFreeTrailDays" 
                            Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>



              <tr>
         <td colspan="6">
              <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></center>
                
         </td>
                </tr>

            </table>

       

          
        </div>



         
            </center>


</asp:Content>

