﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MovieApp.Models.Movie>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
               <%-- <%: Html.LabelFor(model => model.Id) %>--%>
               <label for="Id">Id:</label>
            </div>
            <div class="editor-field">
             <%--   <%: Html.TextBoxFor(model => model.Id) %>
                <%: Html.ValidationMessageFor(model => model.Id) %>--%>
                <%= Html.TextBox("Id") %>
                 <%= Html.ValidationMessage("Id", "*") %>  
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title) %>
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Director) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Director) %>
                <%: Html.ValidationMessageFor(model => model.Director) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DateReleased) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DateReleased) %>
                <%: Html.ValidationMessageFor(model => model.DateReleased) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

