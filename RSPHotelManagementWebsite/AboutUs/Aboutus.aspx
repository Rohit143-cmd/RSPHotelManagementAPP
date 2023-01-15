<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="Aboutus.aspx.cs" Inherits="RSPHotelManagementWebsite.AboutUs.Aboutus" %>
<%@ Register Src="~/DashBoard/RecentlyView.ascx" TagPrefix="uc" TagName="RecentlyView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>This is About page</h1>
    <uc:RecentlyView  ID="ucRecentlyView" runat="server"/>
</asp:Content>
