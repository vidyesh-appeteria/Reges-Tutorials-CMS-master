<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="QuestionsAsked.aspx.cs" Inherits="QuestionsAsked" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <table style="width:90%">
            <tr style="vertical-align:top;">
                <td style="width:50%">
                    
                    <asp:panel runat="server" Height="450px" SkinID="pnlMenu1"  ScrollBars="Vertical">   
                        
                        <asp:GridView ID="gvQuestionsAsked" runat="server" AutoGenerateColumns="false" 
        EmptyDataText="No records found"  OnRowCommand="gvQuestionsAsked_RowCommand"  Width="90%" >
        <Columns>
            <asp:BoundField HeaderText="Raised By" DataField="Raised By" />
          
              <asp:TemplateField HeaderText="No of questions"  >
                <ItemTemplate>
                    <asp:button text='<%#   Eval("count") + " Questions" %>' width="150px"  runat="server" CommandArgument='<%# Eval("userid") %>' CommandName="VIEW" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView> </asp:panel></td>
                <td>
                      <asp:panel runat="server" Height="450px" SkinID="pnlMenu1"  ScrollBars="Vertical">   
         <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="true"  
        EmptyDataText="No records found"  Width="90%" >
    </asp:GridView>
                          </asp:panel>
                          </td>
            </tr>
        </table>
  
        </center>
</asp:Content>

