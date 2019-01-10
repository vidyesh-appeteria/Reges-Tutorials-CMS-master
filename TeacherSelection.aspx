<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="TeacherSelection.aspx.cs" Inherits="TeacherSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <center>
        <br />
       <div style="overflow: auto; height: 540px;">
    <asp:GridView ID="gvTeacherSelection" runat="server" AutoGenerateColumns="false" Width="90%"
        EmptyDataText="No records found" OnRowCommand="gvTeacherSelection_RowCommand"  >
        <Columns>
              

            <asp:BoundField DataField="userid" HeaderText="User ID" />
            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="createdon" HeaderText="Signup Date" DataFormatString="{0:dd-MMM-yyyy HH:mm}" />
            <asp:BoundField DataField="qualification" HeaderText="Qualification" />
            <asp:BoundField DataField="experience" HeaderText="Experience" />
            <asp:BoundField DataField="working" HeaderText="Working at" />
            <asp:BoundField DataField="about_me" HeaderText="About" />
            <asp:BoundField DataField="profession" HeaderText="Profession" />
               <asp:TemplateField HeaderText="" >
                <ItemTemplate>
                    <asp:button text="Activate"   runat="server"  CommandArgument='<%# Eval("userid") %>' CommandName="ACTIVATE"
                        OnClientClick="return confirm('Are you sure, you have activate the account?');"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
           </div>
        </center>
</asp:Content>

