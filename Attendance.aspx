<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="Attendance.aspx.cs" Inherits="Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $('#<%= txtDate.ClientID %>').datepicker({ dateFormat: 'dd-M-yy' });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <center>
    <%--<asp:HiddenField ID="hdnttId" runat="server" Value="0"></asp:HiddenField>--%>
    <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" />
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" 
                    MaxLength="15" AutoPostBack="true"
                    OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="Select Date" ControlToValidate="txtDate"
                    Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
            <td>
                <asp:Label ID="lblBatch" runat="server" Text="Batch"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <asp:DropDownList ID="ddlBatch" runat="server"
                    AutoPostBack="true" 
                    Width="360px"
                    OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged" />

            </td>
        </tr>
    </table>

    <asp:GridView ID="gvAttendance" runat="server"
        AutoGenerateColumns="false" Width="30%"
        EmptyDataText="No records found" OnRowCommand="gvAttendance_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Student">
                <ItemTemplate>
                    <asp:image imageurl='<%# "/user_photos/" + Eval("photo_name")%>'
                        Width="75px"
                        runat="server" />
                    <br />
                    <asp:label text='<%# Eval("full_name") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Status" DataField="Present" />

          <%--  <asp:ImageField  DataImageUrlField='<%# "/user_photos/" + Eval("photo_name")%>' />--%>
            <asp:TemplateField >
                <ItemTemplate>
                    <asp:button text="Mark Absent"  Visible='<%# Convert.ToString( Eval("Present"))=="Present" %>'  
                        CommandArgument='<%# Eval("user_id") %>'
                        CommandName="ABSENT"
                        Width="180px"
                        runat="server" />

                    <asp:button text="Mark Present" SkinID="ButtonSecond"
                        Visible='<%# Convert.ToString( Eval("Present"))=="Absent" %>'  
                        CommandArgument='<%# Eval("user_id") %>'
                        CommandName="PRESENT"
                        Width="180px"
                        runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
                			
        </Columns>
        <RowStyle  HorizontalAlign="Center" />
    </asp:GridView>
    </>
</asp:Content>

