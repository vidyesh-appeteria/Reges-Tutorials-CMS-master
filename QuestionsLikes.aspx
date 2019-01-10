<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="QuestionsLikes.aspx.cs" Inherits="QuestionsLikes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <table style="width:90%">
            <tr style="vertical-align:top;">
                <td style="width:50%">
                    
                   <%-- <asp:panel runat="server" Height="450px" SkinID="pnlMenu1"  ScrollBars="Vertical">   --%>
                        <div style="overflow: auto; height: 540px;">
                        <asp:GridView ID="gvQuestionsLikes" runat="server" AutoGenerateColumns="false" 
        EmptyDataText="No records found"  OnRowCommand="gvQuestionsLikes_RowCommand"  Width="90%" >
        <Columns>
          
            <asp:BoundField HeaderText="Question" DataField="question" />
            <asp:BoundField HeaderText="Tags" DataField="tags" />
            <asp:BoundField HeaderText="Raised By" DataField="Raised By" />
          
              <asp:TemplateField HeaderText="Likes"  >
                <ItemTemplate>
                    <asp:button text='<%#   Eval("Likes") + " Likes" %>'  runat="server" CommandArgument='<%# Eval("question_id") %>' CommandName="VIEW" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView> </div></td>
                <td>
                    <div style="overflow: auto; height: 540px;">
         <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="true"  
        EmptyDataText="No records found"  Width="90%" >
    </asp:GridView>
                        </div>  
                        </td>
            </tr>
        </table>
  
        </center>
</asp:Content>

