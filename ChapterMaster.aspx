<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="ChapterMaster.aspx.cs" Inherits="ChapterMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script>
        $(function () {
            var chName = '#<%= txtChapterName.ClientID%>';
            var chSub = '#<%= ddlSubject.ClientID%>';
            var chStd = '#<%= ddlStandard.ClientID%>';
            $("#btnClear").on("click", function () {
                $(chName).val("");
                $(chSub).get(0).selectedIndex = 0;
                $(chStd).get(0).selectedIndex = 0;

            });
        });
    </script>

    <center>
               
        <div id="dvMain" runat="server">
                              

            <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false"  /><br />
             <input type="button" id="btnAdd" value="Add New" style="display: none;width:120px" class="button" />
            <div style="width:45%;position: relative;">
              <input type="button" id="btnClose" value="X" class="buttonSecond"  style=" position: absolute;right: 10px; top:10px;" /></div><br />
  <div id="effect" class="ui-widget-content ui-corner-all" style="width:45%">
  
            <table>

                  <tr>
                    <td>
                        <asp:Label ID="lblChapterName" runat="server" Text="Chapter Name" ></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtChapterName" runat="server" placeholder="Enter Chapter Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvChapterName" runat="server" ErrorMessage="Enter Chapter Name" ControlToValidate="txtChapterName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>


                
                  <tr>
                    <td>
                        <asp:Label ID="lblSubject" runat="server" Text="Subject"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubject" runat="server">
                         
                        </asp:DropDownList>
<%--                        <asp:TextBox ID="txtBoardName" runat="server"></asp:TextBox>--%>
<%--                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Standard Name" ControlToValidate="txtStandardName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>--%>

                    </td>
                </tr>

              
                  <tr>
                    <td>
                        <asp:Label ID="lblStandard" runat="server" Text="Standard"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStandard" runat="server">
                        </asp:DropDownList>
<%--                        <asp:TextBox ID="txtBoardName" runat="server"></asp:TextBox>--%>
<%--                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Standard Name" ControlToValidate="txtStandardName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>--%>

                    </td>
                </tr>

              <tr>
         <td colspan="3">
              
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <input type="button" id="btnClear" value="Clear" class="buttonSecond"  />
             <%--    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />--%>
                
         </td>
                </tr>

            </table>
    
      </div>
      
  <fieldset style="width:65%"><legend>Search</legend>
      <table >
          <tr><td>
                 <asp:TextBox ID="txtChapterSearch" runat="server"></asp:TextBox>

              </td>
              <td>    <asp:DropDownList ID="ddlSubjectSearch" runat="server">
                           
                        </asp:DropDownList></td>
              <td>
                   <asp:DropDownList ID="ddlStandardSearch" runat="server">
                        </asp:DropDownList>
              </td>
              <td>
                  <asp:button text="Search" ID="btnSearch" OnClick="btnSearch_Click" runat="server" CausesValidation="false" />
                  <asp:button text="Show All" Width="120px" ID="btnClearSearch" OnClick="btnClearSearch_Click" runat="server" CausesValidation="false" />
              </td>
          </tr>
      </table>
          </fieldset>

            <asp:GridView ID="gvChapter" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvChapter_RowDataBound"
                 OnPageIndexChanging="gvChapter_PageIndexChanging"   Width="60%"
                 OnRowEditing="gvChapter_RowEditing" OnRowCancelingEdit="gvChapter_RowCancelingEdit" OnRowUpdating="gvChapter_RowUpdating" OnRowDeleting="gvChapter_RowDeleting" EmptyDataText="No records found" AllowPaging="true" PageSize="5" 
                AllowSorting="true">
                <Columns>
                           
                         <asp:TemplateField>
                        <ItemTemplate>
                                         
                    
                          <asp:HiddenField ID="hdnChapterId" runat="server" Value='<%# Eval("chapter_id") %>'></asp:HiddenField>
                            </ItemTemplate>
                             </asp:TemplateField>


                    <asp:TemplateField ItemStyle-Height="40px" HeaderText="Chapter">
                        <ItemTemplate>
                           <asp:Label ID="lblChapter" runat="server" Text='<%# Eval("chapter_name") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtChapter" runat="server"  Text='<%# Eval("chapter_name") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>     
                    
                    
                    

                     <asp:TemplateField ItemStyle-Height="40px" HeaderText="Subject">
                        <ItemTemplate>
                           <asp:Label ID="lblSubjectName" runat="server" Text='<%# Eval("Subject_name") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
<%--                            <asp:DropDownList ID="ddlBoard" runat="server" />--%>
                       <asp:DropDownList runat="server" ID="ddlSubjectName" />

                           <asp:HiddenField ID="hdnSubjectid" Value='<%# Eval("subject_id") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>                   




                     <asp:TemplateField ItemStyle-Height="40px" HeaderText="Standard (Board)">
                        <ItemTemplate>
                           <asp:Label ID="lblStandardName" runat="server" Text='<%# Eval("standard") +"(" + Eval("board") + ")"  %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
<%--                            <asp:DropDownList ID="ddlBoard" runat="server" />--%>
                       <asp:DropDownList runat="server" ID="ddlStandardName" />

                          <asp:HiddenField ID="hdnStandardid" Value='<%# Eval("Standard_id") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>                   
              


                   <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton ="true" CausesValidation="false" HeaderText="Action"  ControlStyle-Height="30px" ControlStyle-Width="80px"/>
                                    </Columns>


                    




               

                <PagerSettings Mode="Numeric" Position="Bottom" />
            </asp:GridView>
            <asp:HiddenField    id="hdnSort" runat="server" Value="ASC" />
          
        </div>


          <asp:LinkButton Text=" Trash" ID="lnkTrash" Visible="false" runat="server"
        OnClick="lnkTrash_Click" CausesValidation="false"  />
          <asp:panel runat="server" ScrollBars="Vertical" Height="450px" SkinID="none">
            <asp:GridView ID="gvChapterTrash" runat="server" AutoGenerateColumns="false" Width="60%" OnRowCommand="gvChapterTrash_RowCommand">
                <Columns>
                           <asp:BoundField  HeaderText="Chapter" DataField="chapter_name" />
                          <asp:BoundField  HeaderText="Subject" DataField="Subject_name" />
                         
                     <asp:TemplateField ItemStyle-Height="40px" HeaderText="Standard (Board)">
                        <ItemTemplate>
                           <asp:Label ID="lblStandardName" runat="server" Text='<%# Eval("standard") +"(" + Eval("board") + ")"  %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                   
                       
<asp:TemplateField>
    <ItemTemplate>
        <asp:button text="Restore" CommandName="RESTORE" CommandArgument='<%# Eval("chapter_id") %>' runat="server" />
    </ItemTemplate>
</asp:TemplateField>
                    </Columns>
            </asp:GridView>
              </asp:panel>
            </center>

    <asp:HiddenField ID="hdnUserid" runat="server" Value="0"></asp:HiddenField>


</asp:Content>

