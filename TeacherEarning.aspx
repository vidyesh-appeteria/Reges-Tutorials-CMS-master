<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="TeacherEarning.aspx.cs" Inherits="TeacherFollowers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
         <table style="width:90%">
            <tr style="vertical-align:top;">
                <td style="width:50%">
                    
              <%--      <asp:panel runat="server" Height="450px" SkinID="pnlMenu1"  ScrollBars="Vertical">   --%>
                    <div style="overflow: auto; height: 540px;">
                    <asp:GridView ID="gvTeacherEarning" runat="server" AutoGenerateColumns="false" Width="90%"
        EmptyDataText="No records found" OnRowCommand="gvTeacherEarning_RowCommand" >
                          <Columns>
              <asp:TemplateField HeaderText="Teacher"  >
                <ItemTemplate>
                  <b>  <%#Eval("FullName")%></b><br />
                 <small>    <%#Eval("Mobile")%><br /></small>
                 <small>     <%#Eval("Email")%></small>
                    
                </ItemTemplate>
          </asp:TemplateField>
         <asp:BoundField    HeaderText="Chat Earning" DataField="ChatEarning" />
                              <asp:BoundField    HeaderText="Wall Earning" DataField="WallEarning" />
              <asp:TemplateField HeaderText="Earning"  >
                <ItemTemplate>
                    <asp:LinkButton text='<%# "INR "  +  Eval("Earning") %>'  runat="server" Width="150px" CommandArgument='<%# Eval("userid") %>' CommandName="VIEW" />
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Payments"  >
                <ItemTemplate>
                    <asp:LinkButton text='<%#   Eval("Payments") %>'  runat="server" Width="150px" CommandArgument='<%# Eval("userid") %>' CommandName="PAYMENT" />
                </ItemTemplate>
            </asp:TemplateField>
         <asp:TemplateField   >
                <ItemTemplate>
                    <asp:Button text="Paid"  runat="server" Width="150px" CommandArgument='<%# Eval("userid") %>' 
                        CommandName="PAID" Visible='<%# ((decimal)Eval("Earning") != 0) %>'
                        OnClientClick="return confirm('Are you sure, you have made payment of total earning?');"/>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    
                   </div></td>
                <td>
                    <div style="overflow: auto; height: 540px;">
         <asp:GridView ID="gvRatings" runat="server" AutoGenerateColumns="false"  
        EmptyDataText="No records found"  Width="90%" >
             <Columns>
                  <asp:TemplateField HeaderText="Student"  >
                <ItemTemplate>
                  <b>  <%#Eval("FullName")%></b><br />
                 <small>    <%#Eval("Mobile")%><br /></small>
                 <small>     <%#Eval("Email")%></small>
                    
                </ItemTemplate>
          </asp:TemplateField>
                 <asp:BoundField     HeaderText="Rating" DataField="rating" />
          <asp:BoundField     HeaderText="Rated On" DataField="rated_on" />
             </Columns>
    </asp:GridView>
                        
                     <asp:GridView ID="gvPaymetns" Visible="false" runat="server" AutoGenerateColumns="true"  
        EmptyDataText="No records found"  Width="90%" ></asp:GridView>
                        </div>
                </td>
            </tr>
        </table>

        </center>
</asp:Content>

