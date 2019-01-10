<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="ChapterTeachers.aspx.cs" Inherits="ChapterTeachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <table style="width:90%">
            <tr style="vertical-align:top;">
                <td style="width:50%">
                    
                    <%--<asp:panel runat="server" Height="450px" SkinID="pnlMenu1"  ScrollBars="Vertical">   --%>
                        <div style="overflow: auto; height: 540px;">
                        <asp:GridView ID="gvChapterTeachers" runat="server" AutoGenerateColumns="false" 
        EmptyDataText="No records found"  OnRowCommand="gvChapterTeachers_RowCommand"  Width="96%" >
        <Columns>
         
            <asp:BoundField HeaderText="Chapter" DataField="Chapter" />
            <asp:BoundField HeaderText="Standard" DataField="Standard" />
            
                <asp:TemplateField HeaderText="Teachers"  >
                <ItemTemplate>
                    <asp:button text='<%#   Eval("Teachers") + " Teachers" %>'  Width="150px" runat="server" CommandArgument='<%# Eval("chapter_id") %>' CommandName="VIEW" />
                </ItemTemplate>
            </asp:TemplateField>
            
                			
        </Columns>
    </asp:GridView> </div></td>
                <td>
                    <div style="overflow: auto; height: 540px;">
         <asp:GridView ID="gvTeachers" runat="server" AutoGenerateColumns="true"  
        EmptyDataText="No records found"  >
    </asp:GridView>
                        </div>
                        </td>
            </tr>
        </table>
  
        </center>
</asp:Content>

