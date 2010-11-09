<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	New Project
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>New Project</h2>
    <%Html.BeginForm("Index", "Project");%>
        <input type="text" name="Name" placeholder="Name" />
        <input type="submit" value="Skapa"/>
        
    <%Html.EndForm();%>
</asp:Content>
