<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <table align="center" style="width: 99%">
        <tr style="vertical-align: top">
            <td style="width: 33%">
                <asp:Panel runat="server" SkinID="pnlMenu">
                    <center>   <h1>New Users</h1></center>
                    
                    <asp:Chart ID="chUsers" runat="server" OnClick="chUsers_Click" Width="390px">
                        <Titles>
                            <asp:Title ShadowOffset="3" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Days" PostBackValue="#VALX" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </asp:Panel>
            </td>
            <td style="width: 33%">
                <asp:Panel runat="server" SkinID="pnlMenu">
                    <center><h1>Popular Teacher</h1></center>
                    <asp:Chart ID="chTeachers" runat="server" OnClick="chTeachers_Click" Width="390px">
                        <Titles>
                            <asp:Title ShadowOffset="3" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Followers" PostBackValue="#VALX" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </asp:Panel>
            </td>
            <td style="width: 33%">
                <asp:Panel runat="server" SkinID="pnlMenu">
                    <center><h1>Earning</h1></center>
                    <asp:Chart ID="chEarning" runat="server" OnClick="chEarning_Click" Width="390px">
                        <Titles>
                            <asp:Title ShadowOffset="3" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="INR" PostBackValue="#VALX" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </asp:Panel>
            </td>
        </tr>
        <tr style="vertical-align: top">
            <td style="width: 33%">
                <asp:Panel runat="server" SkinID="pnlMenu">
                    <center>   <h1>Active Teachers</h1></center>
                    <asp:Chart ID="chActiveTeachers" runat="server" OnClick="chActiveTeachers_Click" Width="390px">
                        <Titles>
                            <asp:Title ShadowOffset="3" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="No of Answers" PostBackValue="#VALX" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </asp:Panel>
            </td>
             <td style="width: 33%">
                <asp:Panel runat="server" SkinID="pnlMenu">
                    <center>   <h1>Active Students</h1></center>
                    <asp:Chart ID="chActiveStudents" runat="server" OnClick="chActiveStudents_Click" Width="390px">
                        <Titles>
                            <asp:Title ShadowOffset="3" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="No of Questions" PostBackValue="#VALX" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </asp:Panel>
            </td>
            <td style="width: 33%">
                <asp:Panel runat="server" SkinID="pnlMenu">
                    <center>   <h1>Teacher Earning</h1></center>
                    <asp:Chart ID="chTeacherEarning" runat="server" OnClick="chTeacherEarning_Click" Width="390px">
                        <Titles>
                            <asp:Title ShadowOffset="3" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="INR" PostBackValue="#VALX" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </asp:Panel>
            </td>
        </tr>
    </table>--%>
</asp:Content>

