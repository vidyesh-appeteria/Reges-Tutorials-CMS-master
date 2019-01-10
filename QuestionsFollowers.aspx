<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="QuestionsFollowers.aspx.cs" Inherits="QuestionsFollowers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <table style="width:90%">
            <tr style="vertical-align:top;">
                <td style="width:50%">
                    
                  <div style="overflow: auto; height: 540px;">
                        <asp:GridView ID="gvQuestionsFollowers" runat="server" AutoGenerateColumns="false" 
        EmptyDataText="No records found"  OnRowCommand="gvQuestionsLikes_RowCommand"  Width="90%" >
        <Columns>
               <asp:TemplateField HeaderText="Question"  >
                <ItemTemplate>
                  <b>  <%#Eval("Question")%></b><br />
                 <small>   Tags: <%#Eval("Tags")%><br /></small>
                 <small>   Followed By:  <%#Eval("followed_by")%></small>
                      <small>   Followed On:  <%#Eval("followed On")%></small>
                </ItemTemplate>
          </asp:TemplateField>
           
          
              <asp:TemplateField HeaderText="Followers"  >
                <ItemTemplate>
                    <asp:button text='<%#Eval("followers")%>'   runat="server"  CommandArgument='<%# Eval("question_id") %>' CommandName="VIEW" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView> </div></td>
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

