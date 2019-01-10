<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="TeacherAnswers.aspx.cs" Inherits="TeacherAnswers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>

    <br />
    <table style="width: 90%">
        <tr style="vertical-align: top;">
            <td style="width: 50%">

                <%--<asp:panel runat="server" Height="450px" SkinID="pnlMenu1"  ScrollBars="Vertical">   --%>
                <div style="overflow: auto; height: 540px;">
                    <asp:GridView ID="gvTeacherAnswers" runat="server" AutoGenerateColumns="false"
                        EmptyDataText="No records found" OnRowCommand="gvTeacherAnswers_RowCommand" Width="90%">
                        <Columns>
                            <asp:BoundField HeaderText="Name" DataField="fullname" />
                            <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
                            <asp:BoundField HeaderText="Email" DataField="email" />
                            <asp:TemplateField HeaderText="Answers">
                                <ItemTemplate>
                                    <asp:Button Text='<%#Eval("Answers") + " Answers"  %>' runat="server" Width="120px" CommandArgument='<%# Eval("userid") %>' CommandName="VIEW" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </td>
            <td>
                <div style="overflow: auto; height: 540px;">
                    <asp:GridView ID="gvAnswers" runat="server" AutoGenerateColumns="false"
                        EmptyDataText="No records found" Width="90%">
                        <Columns>
                            <asp:TemplateField HeaderText="Answers">
                                <ItemTemplate>
                                    <asp:Label Text='<%#Eval("Question") %>' runat="server" /><br />
                                    <br />
                                    <asp:Label Text='<%#Eval("Answer") %>' runat="server" Font-Size="12px" />
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>

    </center>
</asp:Content>

