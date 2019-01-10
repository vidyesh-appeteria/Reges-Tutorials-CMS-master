<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="StudyMaterial.aspx.cs" Inherits="StudyMaterial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
    
    <div id="dvMain" runat="server">
        <asp:HiddenField ID="hdnStudyMaterialId" runat="server" Value="0"></asp:HiddenField>
        <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" />
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="Select Title" ControlToValidate="txtTitle"
                        Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
                 <td>
                    <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" >
                        <asp:ListItem Text="Select" Value="0" />
                        <asp:ListItem Text="Document" Value="doc" />
                        <asp:ListItem Text="Link" Value="link" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfType" runat="server" ErrorMessage="Select Type" ControlToValidate="ddlType"
                        Display="None" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="lblBoard" runat="server" Text="Board"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" />
                
                </td>

                <td>
                    <asp:Label ID="lblStandard" runat="server" Text="Standard"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged" />
                   
                </td>

                        <td>
                    <asp:Label ID="lblBatch" runat="server" Text="Batch"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlBatch" runat="server" />
               
                </td>
            </tr>
              <tr>
                  <td>  <asp:Label ID="lblDesc" runat="server" Text="Description"></asp:Label></td>
                  <td>:
                </td>
                
                <td>
                    <asp:FileUpload     id="fuDesc" runat="server" Visible="false" />
                    <asp:LinkButton ID="lnkFile" runat="server" />
                    <asp:textbox runat="server" ID="txtDesc" />
                      <asp:RequiredFieldValidator ID="rfvDesc" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtDesc"
                        Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                  </tr>
            <tr>
                <td colspan="9">
                    <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />
            </center>
                </td>
            </tr>

        </table>


        <asp:GridView ID="gvStudyMaterial" runat="server" AutoGenerateColumns="false"
            OnPageIndexChanging="gvStudyMaterial_PageIndexChanging" Width="60%"
            EmptyDataText="No records found" AllowPaging="true" PageSize="10"
            AllowSorting="true" OnRowCommand="gvStudyMaterial_RowCommand">
            <Columns>


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EDT" CommandArgument='<%# Eval("study_material_id") %>' CausesValidation="false" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DEL" CommandArgument='<%# Eval("study_material_id") %>' 
                            CausesValidation="false"
                            OnClientClick="return confirm('Do you really want to delete this record?');"  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Title" DataField="title" />
                <asp:TemplateField HeaderText="View">
                    <ItemTemplate>
                        <asp:HyperLink Target="_blank" Text="View"
                            NavigateUrl='<%# Convert.ToString(Eval("material_type"))=="doc"
                                ?"/study_material/"+Eval("description"): Eval("description") %>' 
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:BoundField HeaderText="Material Type" DataField="material_type" />
                <asp:BoundField HeaderText="Batch" DataField="batch_name" />
                <asp:BoundField HeaderText="Board" DataField="board" />
                <asp:BoundField HeaderText="Standard" DataField="standard" />
                <asp:BoundField HeaderText="Medium" DataField="medium" />
            </Columns>
            <PagerSettings Mode="Numeric" Position="Bottom" />
        </asp:GridView>
        <asp:HiddenField ID="hdnSort" runat="server" Value="ASC" />

    </div>

    <asp:LinkButton Text=" Trash" ID="lnkTrash" Visible="false" runat="server"
        OnClick="lnkTrash_Click" CausesValidation="false" />

    <asp:GridView ID="gvStudyMaterialTrash" runat="server" AutoGenerateColumns="false" Width="60%"
        OnRowCommand="gvStudyMaterialTrash_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnRestore" runat="server"
                        CommandName="RESTORE" Text="Restore" CausesValidation="false"
                        CommandArgument='<%# Eval("study_material_id") %>'></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Title" DataField="title" />
                <asp:TemplateField HeaderText="View">
                    <ItemTemplate>
                        <asp:HyperLink Target="_blank" Text="View"
                            NavigateUrl='<%# Convert.ToString(Eval("material_type"))=="doc"
                                ?"/study_material/"+Eval("description"): Eval("description") %>' 
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField> 
                
                <asp:BoundField HeaderText="Material Type" DataField="material_type" />
                <asp:BoundField HeaderText="Batch" DataField="batch_name" />
                <asp:BoundField HeaderText="Board" DataField="board" />
                <asp:BoundField HeaderText="Standard" DataField="standard" />
                <asp:BoundField HeaderText="Medium" DataField="medium" />
        </Columns>
    </asp:GridView>

    </center>

</asp:Content>

