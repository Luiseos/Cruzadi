<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="WebForm1.aspx.vb" Inherits="APPCRUZADI.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
  <div class="container-fluid text-center">
      <div class="page-header">
        <!-- <h1 class="text-center h1-responsive">Bienvenido al Sistema</h1> -->
        <!-- <br> -->
        <br>
        <div class="row">



          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-aqua">
              <div class="inner">
                <h2>Agenda</h2>
              </div>
              <div class="icon">
                <i class="zmdi zmdi-calendar-alt"></i>
              </div>
              <a href="citas" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>

          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-green">
              <div class="inner">


                <h2>Pacientes</h2>
              </div>
              <div class="icon">
                <i class="fas fa-user-md"></i>
              </div>
              <a href="pacientes" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>

          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-yellow">
              <div class="inner">


                <h2>Usuarios</h2>
              </div>
              <div class="icon">
                <i class="fas fa-address-card"></i>
              </div>
              <a href="usuarios" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>

          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-red">
              <div class="inner">


                <h2>Laboratorio</h2>
              </div>
              <div class="icon">
                <i class="fas fa-flask"></i>
              </div>
              <a href="laboratorio" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>

        </div>

        <div class="row">
          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-green-active">
              <div class="inner">


                <h2>Motivo de Consulta</h2>
              </div>
              <div class="icon">
                <i class="fas fa-chart-pie"></i>
              </div>
              <a href="motivos_consulta_mant" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>

          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-fuchsia-active">
              <div class="inner">


                <h2>Parametros</h2>
              </div>
              <div class="icon">
              <i class="fas fa-cogs"></i>
              </div>
              <a href="parametros" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>

          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-teal-gradient">
              <div class="inner">


                <h2>Perfil de Usuario</h2>
              </div>
              <div class="icon">
                <i class="fas fa-archive"></i>
              </div>
              <a href="miperfil" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>

          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-light-blue-active">
              <div class="inner">


                <h2>Permisos</h2>
              </div>
              <div class="icon">
                <i class="fab fa-xbox"></i>
              </div>
              <a href="rolesGestion" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>

        </div>


        <div class="row">
          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-gray">
              <div class="inner">


                <h2>Productos</h2>
              </div>
              <div class="icon">
                <i class="fas fa-box-open"></i>
              </div>
              <a href="productos" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>

          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-light-blue">
              <div class="inner">


                <h2>Proveedores</h2>
              </div>
              <div class="icon">
                <i class="fas fa-medkit"></i>
              </div>
              <a href="proveedores" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>

          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-olive-active">
              <div class="inner">

                <h2>Roles</h2>
              </div>
              <div class="icon">
                <i class="fas fa-laptop"></i>
              </div>
              <a href="rolesUsuarios" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>

          <div class="col-lg-3 col-xs-6">

            <div class="small-box bg-maroon">
              <div class="inner">


                <h2>Bitacora</h2>
              </div>
              <div class="icon">
                <i class="fas fa-thumbtack"></i>
              </div>
              <a href="bitacora_mantenimientos" class="small-box-footer">Más información
                <i class="fa fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>


</div></div></div>

    <!-- Apply any bg-* class to to the info-box to color it -->
<div class="info-box bg-red">
  <span class="info-box-icon"><i class="fa fa-comments-o"></i></span>
  <div class="info-box-content">
    <span class="info-box-text">Likes</span>
    <span class="info-box-number">41,410</span>
    <!-- The progress section is optional -->
    <div class="progress">
      <div class="progress-bar" style="width: 70%"></div>
    </div>
    <span class="progress-description">
      10% Increase in 30 Days
    </span>
  </div>
  <!-- /.info-box-content -->
</div>
   

</asp:Content>
