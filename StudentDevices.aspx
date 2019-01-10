<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="StudentDevices.aspx.cs" Inherits="StudentDevices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <table style="width:90%">
            <tr style="vertical-align:top;">
                <td style="width:50%">
                    
                  <div style="overflow: auto; height: 540px;">
                        
                        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="false" 
        EmptyDataText="No records found"  OnRowCommand="gvQuestionsLikes_RowCommand"  Width="90%" >
        <Columns>
               <asp:TemplateField HeaderText="Students"  >
                <ItemTemplate>
                  <b>  <%#Eval("fullname")%></b><br />
                 <small>   Mobile: <%#Eval("mobile")%><br /></small>
                 <small>   Email:  <%#Eval("email")%></small>
                   
                </ItemTemplate>
          </asp:TemplateField>
           
          
              <asp:TemplateField HeaderText="Devices"  >
                <ItemTemplate>
                    <asp:button text='<%#Eval("Devices")%>'   runat="server"  CommandArgument='<%# Eval("userid") %>' CommandName="VIEW" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView> </div></td>
                <td>
                    <div style="overflow: auto; height: 540px;">
         <asp:GridView ID="gvStudentDevices" runat="server" AutoGenerateColumns="true"  
        EmptyDataText="No records found"  Width="90%" >
    </asp:GridView>
                        </div>
                        </td>
            </tr>
        </table>
  
        </center>
</asp:Content>

