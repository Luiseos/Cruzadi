<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Login.aspx.vb" Inherits="APPCRUZADI.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="login-block">
        <div class="container">
            <div class="row">
                <div class="col-md-4 login-sec">
                    <h2 class="text-center">Cruzadi</h2>
                    <div class="login-form">
                        <div class="form-group">

                            <label for="exampleInputEmail1" class="text-uppercase">Usuario</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                <input runat="server" id="TxtUsuario"   autocomplete="off" type="text" class="form-control" placeholder="Usuario" style="text-transform: uppercase" onkeyup="Espacio(this, event)" onkeypress="return Letras(event)"  required />
                            </div>
                                 <asp:RequiredFieldValidator ID="RFVUsuario" runat="server" ErrorMessage="RequiredFieldValidator" Text="Debe de ingresar un usuario existente" ControlToValidate="TxtUsuario" ForeColor="#FF3300" ValidateRequestMode="Inherit"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="text-uppercase">Contraseña</label>
                            <div class="input-group">
                                <span class="input-group-addon" onclick="myFunction('<%=TxtContraseña.ClientID%>')" ><i class="glyphicon glyphicon-lock" ></i></span>
                            <input runat="server" id="TxtContraseña" autocomplete="off"  type="password" class="form-control" placeholder="Contraseña" onkeyup="Espacio(this,event)" required />

                                </div>
                            <asp:RequiredFieldValidator ID="RFVContraseña" runat="server" ErrorMessage="RequiredFieldValidator" Text="Debe de ingresar una Contraseña" ControlToValidate="TxtContraseña" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />
                            <asp:CustomValidator ID="CstContraseña" runat="server" ControlToValidate="TxtContraseña" ForeColor="#FF3300" ValidateEmptyText="False"></asp:CustomValidator>
                            <br />
                        </div>


                        <div class="form-check">

                            <button runat="server" id="BtnEntrar" type="button" class="btn btn-login float-right">Entrar</button>
                        </div>
                        <div>
                         
                                <h6><a  href="../Formas/Login/RecuperarContraseña.aspx" style="text-decoration: underline">¿Olvido Contraseña?</a></h6>
                             <br />

                           <h6> <a runat="server" id="AutoRegistro"  href="../Formas/Login/Registro.aspx" style="text-decoration: underline" >Registrarse</a></h6>

                        </div>
                    </div>


                    <div class="copy-text">@Solo Personal Autorizado Cruzadi</div>
                </div>


                <div class="col-md-8 banner-sec">
                    <img class="d-block img-fluid" src="Imagenes/3.jpeg" alt="Cruzadi" />
                </div>
                </div>
            </div>

     
    </section>

   </asp:Content>

