<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="AnswerRating.aspx.cs" Inherits="AnswerRating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <table style="width:90%">
            <tr style="vertical-align:top;">
                <td style="width:50%">
                    
                <%--    <asp:panel runat="server" Height="450px" SkinID="pnlMenu1"  ScrollBars="Vertical">   --%>
                        <div style="overflow: auto; height: 540px;">
                        <asp:GridView ID="gvAnswerRating" runat="server" AutoGenerateColumns="false" 
        EmptyDataText="No records found"  OnRowCommand="gvQuestionsLikes_RowCommand"  Width="90%" >
        <Columns>
               <asp:TemplateField HeaderText="Question"  >
                <ItemTemplate>
                  <b>  <%#Eval("Question")%></b><br />
                 <small>   Tags: <%#Eval("Tags")%><br /></small>
                 <small>   Raised By:  <%#Eval("Raised By")%></small>
                </ItemTemplate>
          </asp:TemplateField>
           
           <asp:BoundField HeaderText="Answer" DataField="Answer" ItemStyle-VerticalAlign="Top"/>
              <asp:TemplateField HeaderText="Avg. Rating"  >
                <ItemTemplate>
                    <asp:button text='<%#Eval("rating","{0:n}")%>'   runat="server"  DataFormatString="{0:0.00}" CommandArgument='<%# Eval("answer_id") %>' CommandName="VIEW" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView> </div></td>
                <td>
                    <div style="overflow: auto; height: 540px;">
         <asp:GridView ID="gvRatedBy" runat="server" AutoGenerateColumns="true"  
        EmptyDataText="No records found"  Width="90%" >
    </asp:GridView>
                        </div></td>
            </tr>
        </table>
  
        </center>
</asp:Content>

