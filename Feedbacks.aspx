<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="Feedbacks.aspx.cs" Inherits="Feedbacks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <div style="overflow: auto; height: 540px;">
    <asp:GridView ID="gvFeedbacks" runat="server" AutoGenerateColumns="true" Width="60%"
        EmptyDataText="No records found" >
    </asp:GridView>
            </div>
        </center>
</asp:Content>

