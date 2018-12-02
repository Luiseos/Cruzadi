<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="CreacionPregunta.aspx.vb" Inherits="APPCRUZADI.CreacionPregunta" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w3-container">
    
    <div class="w3-card-4" style="width: 100%;">
        <header class="w3-container w3-deep-orange">
            <h1 class="w3-center">Creacion de Preguntas </h1>
        </header>
        <fieldset>


            <div class="w3-container">
       
              <%--  <label><b>ID_Pregunta</b></label>
                <input runat="server" id="txtIDPregunta" class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Rol" name="rol" style="text-transform: uppercase"  disabled="disabled">
            --%>    
                <label><b>Pregunta</b></label>
                <input runat="server" id="txtpregunta" autocomplete="off"  class="w3-input w3-border w3-margin-bottom" type="text" onkeyup="DobleEspacio(this,event)" placeholder="Pregunta" name="Pregunta" style="text-transform: uppercase" >
                <br>
        
           


                <div class="container w3-panel w3-round-small ">
                      <h3>

                            <span style="float: right;"><small>Total de Ejecutivas :</small>
                                <asp:Label ID="lblTotalesPregunta" runat="server" CssClass="label label-warning" /></span>
                        </h3>
                                <div class="table-responsive">
             <asp:GridView ID="GVPregunta1" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Pregunta_id" AllowSorting="false">
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
                                        <asp:Label ID="LblPaginadorPregunta" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>
                    </div>

                </div>

                <hr>
                <br>
            </div>
        </fieldset>
        <br />

               <div class="w3-container w3-center">

            <button runat="server" id="btnguardar" class="w3-deep-orange btn-lg">Guardar</button>
            <button runat="server" id="btnmodificar" class="w3-deep-orange btn-lg">Modificar</button>
            <button runat="server" id="btneliminar" class="w3-deep-orange btn-lg">Eliminar</button>
        </div>
        <br />
    </div>

    <footer class="w3-container w3-deep-orange">
 
        <a href="/inicio.aspx"  style='color: white'>
            <h3>INICIO</h3>
        </a>

    </footer>
  </div>

</asp:Content>
