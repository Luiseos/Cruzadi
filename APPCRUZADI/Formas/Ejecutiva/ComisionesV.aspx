<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ComisionesV.aspx.vb" Inherits="APPCRUZADI.EjecutivaV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /> <br /> 

      <div class="w3-card-4"  style="width:100%;">
    <header class="w3-container w3-center w3-deep-orange">
      <h1>Comision de Ventas</h1>
    </header>

           <div class="w3-center" >
        <h2 class="w3-center" >Parametros de Fechas</h2>

       <input runat="server" id="TxtFechaInicio" type="date" />
              <input runat="server" id="TxtFechaFinal" type="date" />
       <br />
            </div>

    <div class="w3-container">
      <br/>
      <br/>
      <fieldset>
        <label>Ejecutiva</label>
   
          <select runat="server" id="CbEjecutiva" class="w3-input"  ></select>
  <br />
        <label>Mes</label>
        <input class="w3-input" type="date" runat="server" id="txtMes"   autocomplete="off" />
        <label>Base Comisionable</label>
        <input class="w3-input" type="text" runat="server" id="txtbasecomisionable"  placeholder="Base Comisionable"/>
        <label>Evaluacion</label>
        <input class="w3-input" type="text" runat="server" id="txtEvaluacion"  placeholder="Evaluacion" autocomplete="off"/>%
        <label>Comision de Venta</label>
        <input class="w3-input" type="text" runat="server" id="txtcomisonventas" placeholder="Comision de Ventas" autocomplete="off"/>
        <br/> 
        <br/>
       
        </fieldset>
               <br/> 
        <br/>
        
        <div class="w3-container w3-center">
         <button runat="server" id="btnGuardar" class="w3-deep-orange btn-lg" >Guardar</button>
        <button runat="server" id="btnCancelar" class="w3-deep-orange btn-lg"  >Cancelar</button>
              </div>
          <br/>
    </div>
    </div>

 
      <br/>
      <br/>
    <fieldset>
     
<div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Ejecutivas :</small>
                                <asp:Label ID="lblTotalesComisiones" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />

     <asp:GridView ID="GvComisionesv" runat="server" AutoGenerateColumns="false" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="cliente_id" AllowSorting="false">
    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Registros seleccionados!  
                                </EmptyDataTemplate>

                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />

                                <RowStyle BackColor="#f5f5f0"
                                    Font-Italic="true"
                                    HorizontalAlign="Center" />


                                <%-- <alternatingrowstyle backcolor= #e0e0d1 
          font-italic="true"/>--%>
                                
                              
     </asp:GridView>
                                 <div class="row" style="margin-top: 20px;">

                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="LblPaginadorComisionesv" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />
                            </div>
  </div>
        </fieldset>

     <footer class="w3-container w3-deep-orange">
            <a href="/inicio.aspx" style='color: white'>
                   <h3>INICIO</h3>
            </a>

    </footer>
 

  <footer class="w3-container w3-deep-orange">
            <a href="/inicio.aspx" style='color: white'>
                  <h3>INICIO</h3>
            </a>

    </footer>

     

</asp:Content>
