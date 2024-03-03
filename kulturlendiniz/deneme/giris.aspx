<%@ Page Title="" Language="C#" MasterPageFile="~/giris.Master" AutoEventWireup="true" CodeBehind="giris.aspx.cs" Inherits="deneme.giris2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

           <div class="form-container" id="login-form-container">
          <h1>giriş</h1>



<fieldset class="vertical">
        <input id="ReturnUrl" name="ReturnUrl" type="hidden" value="/">
        <span class="field-validation-valid" data-valmsg-for="Status" data-valmsg-replace="true"></span>
        <div>
          <label for="UserName">e-mail adresi</label>
          <asp:TextBox autofocus="autofocus" data-val="true" data-val-length="The field e-mail adresi must be a string with a maximum length of 50." data-val-length-max="50" data-val-required="kullanıcı adı boş olamaz" id="username" maxlength="130" name="UserName" runat="server"  value="" />
          <span class="field-validation-valid" data-valmsg-for="UserName" data-valmsg-replace="true"></span>
        </div>
        <div>
          <label for="Password">şifre</label>
          <asp:TextBox  id="password" maxlength="50" runat="server" type="Password"/>
          <span class="field-validation-valid" data-valmsg-for="Password" data-valmsg-replace="true"></span>
        </div>
        
        
        <div class="actions">
          <asp:Button ID="Giris" CssClass="Giris" Text="giriş" runat="server" Onclick="Giris_Click"/>
        </div>
      </fieldset>
  
               
 </div>
</asp:Content>
