<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="RSPHotelManagementAPP.HeaderAndFooter.Header" %>
<%@ Import Namespace="RSPHotelManagementModel.NavigationModel" %>


<nav class="navbar navbar-expand-lg navbar-light bg-dark">
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo03" aria-controls="navbarTogglerDemo03" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <a class="navbar-brand fontcolor" href="/Index.aspx"><b class="fontcolor">RSP Hotel Services</b></a>

  <div class="collapse navbar-collapse" id="navbarTogglerDemo03">
    <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
        <%foreach (var item in navigationModels)
            {
                if (item.IsChild == false && item.ChildMenuUUID==null)
                {
                    %>
        <li class="nav-item active">
        <a class="nav-link" href="<%:item.URL!=null? ResolveUrl(item.URL):"#"%>" title="<%:item.Name%>"><span class="fontcolor"><%:item.Name%></span> <span class="sr-only">(current)</span></a>
      </li>
        <%}
                if(item.IsChild==true)
                {%>
        <li class="nav-item dropdown fontcolor">
        <a class="nav-link dropdown-toggle fontcolor" href="<%:item.URL!=null?ResolveUrl(item.URL):"#"%>" title="<%:item.Name%>" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
          <span class="fontcolor"><%:item.Name %></span>
        </a>
            <div class="dropdown-menu fontcolor" aria-labelledby="navbarDropdownMenuLink">
            <%
                foreach (var childitem in navigationModels)
                {
                    if (item.SystemMenuUUID == childitem.ChildMenuUUID)
                    {
                            %>
        
        
          <a class="dropdown-item" href="<%:childitem.URL != null ? ResolveUrl(childitem.URL) : "#"%>"><%:childitem.Name %></a>
                 <%     }
                             }
                             %>
        </div>
      </li>
                <%  
                    
                }
            }%>

      <%--<li class="nav-item active">
        <a class="nav-link" href="#"><span class="fontcolor">Home</span> <span class="sr-only">(current)</span></a>
      </li>--%>
      <%--<li class="nav-item">
        <a class="nav-link" href="#"><span class="fontcolor">About</span></a>
      </li>
        <li class="nav-item dropdown fontcolor">
        <a class="nav-link dropdown-toggle fontcolor" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
          <span class="fontcolor">Report</span>
        </a>
        <div class="dropdown-menu fontcolor" aria-labelledby="navbarDropdownMenuLink">
          <a class="dropdown-item" href="#">Action</a>
          <a class="dropdown-item" href="#">Another action</a>
          <a class="dropdown-item" href="#">Something else here</a>
        </div>
      </li>--%>
      
    </ul>
      
          <form class="form-inline my-2 my-lg-0" style="margin-left:100px;">
      <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
              <asp:Button  runat="server" Text="Search" ID="searchbtn" OnClick="searchbtn_Click" class="btn btn-outline-success my-2 my-sm-0"/>
    </form>
      
  </div>
</nav>