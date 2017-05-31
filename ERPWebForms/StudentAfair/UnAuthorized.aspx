<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.Master" AutoEventWireup="true" CodeBehind="UnAuthorized.aspx.cs" Inherits="ERPWebForms.StudentAfair.UnAuthorized" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div align="center">
        <p><span style="color: red; font-weight: bold">
            <asp:Label ID="label1" runat="server" Text="UnAuthorized" meta:resourcekey="label1Resource1"></asp:Label>
        </span></p>
    </div>
</asp:Content>
