<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="ChatHistory.aspx.cs" Inherits="ChatHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <table style="width:96%">
            <tr style="vertical-align:top;">
                <td style="width:50%">
                    
                    <div style="overflow: auto; height: 540px;">
                        
                        <asp:GridView ID="gvChatHistory" runat="server" AutoGenerateColumns="false" 
        EmptyDataText="No records found"  OnRowCommand="gvQuestionsLikes_RowCommand"  Width="96%" >
        <Columns>

            <asp:BoundField HeaderText="Teacher" DataField="teacher_name" />
            <asp:BoundField HeaderText="Student" DataField="student_name" />
            <asp:BoundField HeaderText="Question" DataField="question" />
            <asp:BoundField HeaderText="Chat On" DataField="chat_time" />
            
              <asp:TemplateField HeaderText="Messages"  >
                <ItemTemplate>
                    <asp:button text='<%#Eval("messages")%>'   runat="server"  CommandArgument='<%# Eval("queue_id") %>' CommandName="VIEW" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView> </div></td>
                <td>
               <div style="overflow: auto; height: 540px;">
         <asp:GridView ID="gvChatMessages" runat="server" AutoGenerateColumns="false"  
        EmptyDataText="No records found"  Width="90%" >
             <Columns>
                  <asp:TemplateField HeaderText="Message"  >
                <ItemTemplate>
                    <asp:Label text='<%#Eval("message")%>'   runat="server"  
                        Visible='<%# (string)Eval("type")=="text"%>'  />

                    <a href='<%#Eval("message")%>' target="_blank">
                    <asp:Image ImageUrl='<%# (string)Eval("type")=="image"? "~/images/img_placeholder.png": "~/images/video_placeholder.jpg" %>'
                        Visible='<%# (string)Eval("type")!="text"%>' runat="server" Width="45px" /></a>
                </ItemTemplate>
                      
            </asp:TemplateField>
                 <asp:BoundField HeaderText ="Message By" DataField="messageBy" />
                 <asp:BoundField HeaderText="Message On" DataField="messageOn" />
             </Columns>
    </asp:GridView></div>
                        </td>
            </tr>
        </table>
  
        </center>
</asp:Content>

