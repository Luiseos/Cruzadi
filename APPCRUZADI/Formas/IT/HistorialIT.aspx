<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="HistorialIT.aspx.vb" Inherits="APPCRUZADI.HistorialIT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 0;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br /> <br /> 

         <div class="w3-card-4" style="width:100%;">
    <header class="w3-container  w3-center w3-deep-orange">
<h2 class="w3-center">Historial de Ticket Finalizados</h2>
    </header>
    <br><br>
   <div class="w3-center" >
        <h2 class="w3-center" >Buscar</h2>
  <label for="buscacliente" ><span class="glyphicon glyphicon-search"></span></label>
  <%--<input id="TXtBuscar2" runat="server" type="text"   placeholder="Buscar.." autofocus="autofocus" class="auto-style1" AutoPostBack="True" OnTextChanged="TxtBuscar_TextChanged"">--%>
   <asp:TextBox ID="TXtBuscar1" runat="server"  AutopostBack="true" ></asp:TextBox>    
   </div>
   <hr>
             
<br><br>

    

    <section>
  <fieldset >
      <legend>Ticket Finalizados</legend>
                         <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Finalizados:</small>
                                <asp:Label ID="lblFinalizados" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
                            <asp:GridView ID="GVFinalizadosTicket" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Ticket" AllowSorting="false">
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
                                        <asp:Label ID="lblPaginadorFinalizados" runat="server" CssClass="label label-warning" /></h3>
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
    <br /> <br /> <br /> <br /> 

    <br />
    <%--  --%>

    <%--  --%>
       <!-- Modal Hstorial de IT
    --------------------------------------------------------------------->
<%--    data-backdrop=”static” data-keyboard="false"--%>

        <div class="modal" id="Historial"  tabindex="-1"  role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
        <div class="modal-dialog">
            <div class="modal-content">

                <!-- Modal Cabecera -->
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel">Historial</h4>

                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span>
                        <span class="sr-only">Cerrar</span>
                    </button>

                </div>

                <!-- Modal Cuerpo contenido -->

                <div class="modal-body">
                    <p class="statusMsg"></p>
                                      <div class="form-group">
                            <label >Numero de ticket</label>
                            <input runat="server" type="text" class="form-control" id="TxtTicket" Readonly="readonly" autocomplete="off" />
                        </div>
                                             <div class="form-group">
                            <label >USUARIO</label>
                            <input runat="server" type="text" class="form-control" id="TxtUsuario" Readonly="readonly" autocomplete="off" />
                        </div>
                                                                <div class="form-group">
                            <label >Gestion </label>
                            <input runat="server" type="TEXT" class="form-control" id="TXTGESTION" Readonly="readonly" autocomplete="off" />
                        </div>
                        <br>
                        <br>
                        <div class="form-group">
                            <label for="inputMessage">Mensaje Recibido</label>
                            <textarea runat="server" class="form-control" id="TxtmsjRecibido" Readonly="readonly" rows="6"> </textarea>
                                                    </div>
                                  <div class="form-group">
                                      <hr >

                            <label >ASIGNADO A </label>
                            <input runat="server" type="text" class="form-control" id="TXTASIGNADO" Readonly="readonly" autocomplete="off" />
                        </div>
   <div class="form-group">
                            <label for="inputMessage">Mensaje Enviado</label>
                            <textarea runat="server" class="form-control" id="TxtmsjEnviado" Readonly="readonly" rows="6"> </textarea>
                                                    </div>
                                      
                </div>

                <!-- Modal Pie de Página -->
                          </div>
        </div>
    </div>

    <!-- Modal Fin IT-->




    

</asp:Content>
