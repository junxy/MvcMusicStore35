﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<MvcMusicStore.Models.Album>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ASP.NET MVC Music Store
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="promotion">
    </div>
    <h3>
        <em>Fresh</em> off the grill</h3>
    <ul id="album-list">
        <% foreach (var album in Model)
           {%>
        <li><a href="<%= Url.Action("Details", "Store", new { id = album.AlbumId }) %>">
            <img alt="<%= album.Title %>" src="<%= album.AlbumArtUrl %>" />
            <span>
                <%= album.Title %>
            </span></a></li>
        <% } %>
    </ul>
</asp:Content>