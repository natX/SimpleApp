<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Domain.Entities.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Products
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% foreach (var p in Model)
       {%>
        <div class="item">
            <h3><%=p.Name%></h3>
            <%=p.Description%>
            <h4><%=p.Price.ToString("c")%></h4>
        </div>
        <%
       }%>
</asp:Content>
