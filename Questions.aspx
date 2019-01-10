<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="Questions.aspx.cs" Inherits="Questions" %>

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
                        <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="false" 
        EmptyDataText="No records found"  OnRowCommand="gvQuestionsLikes_RowCommand"  Width="90%" >
        <Columns>
               <asp:TemplateField HeaderText="Question"  >
                <ItemTemplate>
                  <b>  <%#Eval("Question")%></b><br />
                 <small>   Tags: <%#Eval("Tags")%><br /></small>
                 <small>   Raised By:  <%#Eval("Raised By")%></small>
                    <small>   Raised On:  <%#Eval("raised_on")%></small>
                </ItemTemplate>
          </asp:TemplateField>
           
         
              <asp:TemplateField HeaderText="Answers"  >
                <ItemTemplate>
                    <asp:button text='<%#Eval("Answers") + " Answers"  %>'  runat="server"  Width="120px"  CommandArgument='<%# Eval("question_id") %>' CommandName="VIEW" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete"  >
                <ItemTemplate>
                    <asp:button text="Delete"  runat="server"  Width="120px"  CommandArgument='<%# Eval("question_id") %>' CommandName="DEL" />
                </ItemTemplate>
            </asp:TemplateField>

            
        </Columns>
    </asp:GridView> </div></td>
                <td>
                    <div style="overflow: auto; height: 540px;">
         <asp:GridView ID="gvAnswers" runat="server" AutoGenerateColumns="false"  
        EmptyDataText="No records found"  Width="90%" OnRowCommand="gvAnswers_RowCommand" >
             <Columns>
               <asp:BoundField  HeaderText="Answer" DataField="answer" />
               <asp:TemplateField HeaderText="Solved By"  >
                <ItemTemplate>
                  <b>  <%#Eval("fullname")%></b><br />
                     <small>    <%#Eval("Mobile")%><br /></small>
                 <small>    <%#Eval("Email")%></small>
                    </ItemTemplate></asp:TemplateField>
                  
             </Columns>
    </asp:GridView>
                        </div></td>
            </tr>
        </table>
  
        </center>
</asp:Content>

