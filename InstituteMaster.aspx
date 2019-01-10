<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="InstituteMaster.aspx.cs" Inherits="InstituteMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
    
    <div id="dvMain" runat="server">
        <asp:HiddenField ID="hdnInstituteId" runat="server" Value="0"></asp:HiddenField>
        <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" />
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblInstituteName" runat="server" Text="Institute Name"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:TextBox ID="txtInstituteName" runat="server" MaxLength="60"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvInstituteName" runat="server" ErrorMessage="Enter Institute Name" ControlToValidate="txtInstituteName"
                        Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:Label ID="lblLocality" runat="server" Text="Locality"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                  <asp:TextBox ID="txtLocality" runat="server" MaxLength="60"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLocality" runat="server" ErrorMessage="Enter Locality" ControlToValidate="txtLocality"
                        Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblInstituteType" runat="server" Text="Institute Type"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:RadioButtonList ID="rblInstituteType" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="School" Value="SCHOOL" />
                        <asp:ListItem Text="College" Value="COLLEGE" />
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="rfvInstituteType" runat="server" ErrorMessage="Select Institute Type" ControlToValidate="rblInstituteType"
                        Display="None" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>

                <td colspan="3">
                    
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


        <asp:GridView ID="gvInstitutes" runat="server" AutoGenerateColumns="false"
            OnPageIndexChanging="gvInstitutes_PageIndexChanging" Width="60%"
            EmptyDataText="No records found" AllowPaging="true" PageSize="10"
            AllowSorting="true" OnRowCommand="gvInstitutes_RowCommand">
            <Columns>


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EDT" CommandArgument='<%# Eval("institute_id") %>' CausesValidation="false" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DEL" CommandArgument='<%# Eval("institute_id") %>' 
                            CausesValidation="false" OnClientClick="return confirm('Do you really want to delete this record?');"  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Institute Name" DataField="institute_name" />
                <asp:BoundField HeaderText="Locality" DataField="locality" />
                <asp:BoundField HeaderText="Institute Type" DataField="institute_type" />                
            </Columns>
            <PagerSettings Mode="Numeric" Position="Bottom" />
        </asp:GridView>
        <asp:HiddenField ID="hdnSort" runat="server" Value="ASC" />

    </div>

    <asp:LinkButton Text=" Trash" ID="lnkTrash" Visible="false" runat="server"
        OnClick="lnkTrash_Click" CausesValidation="false" />

    <asp:GridView ID="gvInstitutesTrash" runat="server" AutoGenerateColumns="false" Width="60%"
        OnRowCommand="gvInstitutesTrash_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnRestore" runat="server"
                        CommandName="RESTORE" Text="Restore" CausesValidation="false"
                        CommandArgument='<%# Eval("institute_id") %>'></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField HeaderText="Institute Name" DataField="institute_name" />
                <asp:BoundField HeaderText="Locality" DataField="locality" />
                <asp:BoundField HeaderText="Institute Type" DataField="institute_type" />               
        </Columns>
    </asp:GridView>

    </center>

</asp:Content>

