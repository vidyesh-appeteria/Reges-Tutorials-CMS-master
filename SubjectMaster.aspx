<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="SubjectMaster.aspx.cs" Inherits="SubjectMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    <link rel="stylesheet" href="../css/modalbox.css" />
    <script type="text/javascript" src="../js/modalbox.js"></script>--%>


    <script>
        $(function () {
            var control = '#<%= txtSubjectName.ClientID%>';
            $("#btnClear").on("click", function () {
                $(control).val("");

            });
        });
    </script>




    <center>
               
        <div id="dvMain" runat="server">
                               <%-- <center><div style="margin-top:10px;margin-bottom:20px;"><asp:Label runat="server" ID="lblMsg" ForeColor="Green" Font-Size="14px" Font-Bold="true"></asp:Label> </div></center>--%>

            <asp:Label ID="lblMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false"  /><br />
   <input type="button" id="btnAdd" value="Add New" style="display: none;width:120px" class="button" />
            <div style="width:45%;position: relative;">
              <input type="button" id="btnClose" value="X" class="buttonSecond"  style=" position: absolute;right: 10px; top:10px;" /></div><br />
  <div id="effect" class="ui-widget-content ui-corner-all" style="width:45%">
  
            <table >
              
                <tr>
                    <td>
                        <asp:Label ID="lblSubjectName" runat="server" Text="Subject"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubjectName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSubjectName" runat="server" ErrorMessage="Enter Subject Name" ControlToValidate="txtSubjectName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                                </tr>

        

              <tr>
         <td colspan="3">
              <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <input type="button" id="btnClear" value="Clear" class="buttonSecond"  />
               <%--  <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />--%>
                </center>
         </td>
                </tr>

            </table>
      </div>
         


            <asp:GridView ID="gvSubject" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gvSubject_PageIndexChanging" Height="250px" Width="600px"
                 OnRowEditing="gvSubject_RowEditing" OnRowCancelingEdit="gvSubject_RowCancelingEdit" OnRowUpdating="gvSubject_RowUpdating" OnRowDeleting="gvSubject_RowDeleting" EmptyDataText="No records found" AllowPaging="true" PageSize="5" 
                AllowSorting="true">
                <Columns>

                           
                         <asp:TemplateField>
                        <ItemTemplate>
                                         
                    
                          <asp:HiddenField ID="hdnsubject_id" runat="server" Value='<%# Eval("subject_id") %>'></asp:HiddenField>
                            </ItemTemplate>
                             </asp:TemplateField>

                    <asp:TemplateField ItemStyle-Height="40px" HeaderText="Subject Name">
                        <ItemTemplate>
                           <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("subject_name") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSubject" runat="server"  Text='<%# Eval("subject_name") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>                   


                   <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton ="true" CausesValidation="false" 
                       HeaderText="Action"  ControlStyle-Height="30px" ControlStyle-Width="80px" />
                                    </Columns>
                <PagerSettings Mode="Numeric" Position="Bottom" />
            </asp:GridView>
            <asp:HiddenField    id="hdnSort" runat="server" Value="ASC" />
          
        </div>



         
            </center>

    <asp:HiddenField ID="hdnUserid" runat="server" Value="0"></asp:HiddenField>
    <center>
    <asp:LinkButton Text=" Trash" ID="lnkTrash" Visible="false" runat="server"
        OnClick="lnkTrash_Click" CausesValidation="false"  />

        <asp:panel runat="server" ScrollBars="Vertical" Height="450px" SkinID="1">
    <asp:GridView ID="gvSubjectTrash" runat="server" AutoGenerateColumns="false"
         Width="30%" OnRowCommand="gvSubjectTrash_RowCommand" >
        <Columns>
            <asp:BoundField HeaderText="Subject" DataField="subject_name" />

            <asp:TemplateField>
                <ItemTemplate>
                       <asp:Button ID="btnRestore" runat="server" Text="Restore" Width="120px" CommandName="RESTORE" CommandArgument='<%# Eval("subject_id") %>'></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView></asp:panel>
        </center>
</asp:Content>

