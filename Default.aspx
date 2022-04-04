<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio8._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>

    <div class="row">
  
        Jugador<br />
        <asp:DropDownList ID="cmbLista" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        Fecha de juego<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        Equipo<br />
        <asp:TextBox ID="txtEquipo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEquipo" runat="server" ControlToValidate="txtEquipo" ErrorMessage="Es necesario ingresar un equipo" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <br />
        <br />
        Goles anotados<br />
        <asp:TextBox ID="txtGoles" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidatorGoles" runat="server" ControlToValidate="txtGoles" ErrorMessage="Debe ingresar un numero entre 1 y 1'" MaximumValue="10" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGoles" runat="server" ControlToValidate="txtGoles" ErrorMessage="Debe ingresar un valor" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Ingresar" />
        <br />
        <br />
        <br />
  
    </div>

</asp:Content>
