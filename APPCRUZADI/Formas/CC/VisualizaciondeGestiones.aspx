<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="VisualizaciondeGestiones.aspx.vb" Inherits="APPCRUZADI.VisualizaciondeGestiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br /> <br /> 

         <div class="w3-card-4" style="width:100%;">
    <header class="w3-container  w3-center w3-deep-orange">
<h2 class="w3-center">Visualizacion Principal Cuentas por Cobrar</h2>
    </header>
    <br><br>

    
       <%-- Promesas --%>
    <section>
  <fieldset >
      <legend>CXC Promesas</legend>
                         <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Promesas :</small>
                                <asp:Label ID="lbltotlapromesas" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
                            <asp:GridView ID="GVPromesas" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Cliente_id" AllowSorting="false">
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                <%-- <alternatingrowstyle backcolor= #e0e0d1 
          font-italic="true"/>--%>
                                
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Registros seleccionados!  
                                </EmptyDataTemplate>

                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />

                                <RowStyle BackColor="#f5f5f0"
                                    Font-Italic="true"
                                    HorizontalAlign="Center" />

                            </asp:GridView>



                            <div class="row" style="margin-top: 20px;">

                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="lblPaginadorCXCPromesas" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />

                        </div>

                    </div>
                    <br />

                </fieldset>

    </section>

    <br /> <br /> <br /> <br /> 

    <br />
    <%-- Lllamadas --%>
    <section>
  <fieldset>

           <legend>CXC Llamadas</legend>
                    <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Llamadas :</small>
                                <asp:Label ID="lblLlamadas" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
                            <asp:GridView ID="GVLlamadas" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Cliente_id" >
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                <%-- <alternatingrowstyle backcolor= #e0e0d1 
          font-italic="true"/>--%>
                                
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Registros seleccionados!  
                                </EmptyDataTemplate>

                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />

                                <RowStyle BackColor="#f5f5f0"
                                    Font-Italic="true"
                                    HorizontalAlign="Center" />

                            </asp:GridView>



                            <div class="row" style="margin-top: 20px;">

                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="LblPaginadorLlamadas" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />

                        </div>

                    </div>
                    <br />

                </fieldset>

        </section>
        <%--  --%>

         <br /> <br /> <br /> <br /> 

    <br />
    <%-- Visitas --%>
    <section>
  <fieldset>

           <legend>CXC Visitas</legend>
                    <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Visitas :</small>
                                <asp:Label ID="LblVisitas" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
                            <asp:GridView ID="GVVisitas" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Cliente_id" >
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                <%-- <alternatingrowstyle backcolor= #e0e0d1 
          font-italic="true"/>--%>
                                
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Registros seleccionados!  
                                </EmptyDataTemplate>

                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />

                                <RowStyle BackColor="#f5f5f0"
                                    Font-Italic="true"
                                    HorizontalAlign="Center" />

                            </asp:GridView>



                            <div class="row" style="margin-top: 20px;">

                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="LblPaginadorVisitas" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />

                        </div>

                    </div>
                    <br />

                </fieldset>

        </section>
         </div>
        <%--  --%>
        
    
    <%--  --%>
     <%--  --%>
    <%--  --%>

    
  <div id="GestionRealizadas" class="w3-modal">
    <div class="w3-modal-content">
      <header class="w3-container w3-deep-orange"> 
        <span onclick="document.getElementById('GestionRealizadas').style.display='none'" 
        class="w3-button w3-display-topright">&times;</span>
        <h2>Detalle de Gestion</h2>
      </header>
        <div class="w3-container">
         <div class="w3-third w3-container">
      <br /> <br />
        <label>ID Cliente</label>
        <input runat="server" class="w3-input" type="text" id="txtidclienteGes"  disabled="disabled" />
        <label>Fecha de Emision</label>
        <input runat="server" class="w3-input" type="text" id="txtfechaemisionges"  disabled="disabled" />
  </div>
   <div class="w3-third w3-container">
     <br/> <br/>
        <label>Usuario</label>
        <input runat="server" class="w3-input" type="text" id="txtusuarioges"  disabled="disabled" />
        <label>Fecha De Programacion</label>
        <input runat="server" class="w3-input" type="text" id="txtfechaprogramacionges"  disabled="disabled" />
  </div>
   <div class="w3-third w3-container">
     <br/> <br/>
        <label>Tipo De Gestion</label>
        <input runat="server" class="w3-input" type="text" id="txttipogestionges" disabled="disabled" />
  </div>
  
  <div class="w3-container">
    <label>Descripcion</label>
<textarea runat="server" class="w3-input" disabled="disabled" id="txtdescripcionges" placeholder="descripciones"></textarea>
    </div>
      </div>
      <br/><br/>
      <footer class="w3-container w3-center w3-deep-orange">
        <p>Cruzadi</p>
      </footer>
    </div>
  </div>


</asp:Content>
