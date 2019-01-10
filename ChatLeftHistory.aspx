<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="ChatLeftHistory.aspx.cs" Inherits="ChatLeftHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <table style="width:90%">
            <tr style="vertical-align:top;">
                <td style="width:50%">
                    
                    <asp:panel runat="server" Height="450px" SkinID="pnlMenu1"  ScrollBars="Vertical">   
                        
                        <asp:GridView ID="gvChatLeftHistory" runat="server" AutoGenerateColumns="false" 
        EmptyDataText="No records found"  OnRowCommand="gvQuestionsLikes_RowCommand"  Width="90%" >
        <Columns>
               <asp:BoundField  HeaderText="Month"  DataField="Month" >
                </asp:BoundField>
           
          
              <asp:TemplateField HeaderText="Count"  >
                <ItemTemplate>
                    <asp:button text='<%#Eval("count")%>'   runat="server"  CommandArgument='<%# Eval("Month") %>' CommandName="VIEW" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView> </asp:panel></td>
                <td>
         <asp:GridView ID="gvChatLeftList" runat="server" AutoGenerateColumns="false"  
        EmptyDataText="No records found"  Width="90%" >
             <Columns>
                    <asp:BoundField HeaderText="Teacher" DataField="teacher_name" />
            <asp:BoundField HeaderText="Student" DataField="student_name" />
            <asp:BoundField HeaderText="Question" DataField="question" />
            <asp:BoundField HeaderText="Chat On" DataField="chat_time" />
             </Columns>
    </asp:GridView></td>
            </tr>
        </table>
  
        </center>
</asp:Content>

