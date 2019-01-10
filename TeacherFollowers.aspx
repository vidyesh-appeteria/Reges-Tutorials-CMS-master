<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="TeacherFollowers.aspx.cs" Inherits="TeacherFollowers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
         <table style="width:90%">
            <tr style="vertical-align:top;">
                <td style="width:50%">
                    <div style="overflow: auto; height: 540px;">
                    <%--<asp:panel runat="server" Height="450px" SkinID="pnlMenu1"  ScrollBars="Vertical">   --%>
                    <asp:GridView ID="gvTeacherFollowers" runat="server" AutoGenerateColumns="false" Width="96%"
        EmptyDataText="No records found" OnRowCommand="gvTeacherFollowers_RowCommand" >
                          <Columns>
          
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
          
              <asp:TemplateField HeaderText="Followers"  >
                <ItemTemplate>
                    <asp:button text='<%#   Eval("Followers") + " Followers" %>'  runat="server" Width="150px" CommandArgument='<%# Eval("userid") %>' CommandName="VIEW" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    </div>
          </td>
                <td>
                    <div style="overflow: auto; height: 540px;">
         <asp:GridView ID="gvFollowers" runat="server" AutoGenerateColumns="true"  
        EmptyDataText="No records found"  Width="90%" >
    </asp:GridView>
                        </div>
                        </td>
            </tr>
        </table>

        </center>
</asp:Content>

