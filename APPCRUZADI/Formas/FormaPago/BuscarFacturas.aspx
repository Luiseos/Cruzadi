<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="BuscarFacturas.aspx.vb" Inherits="APPCRUZADI.BuscarFacturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br /> <br /> 

         <div class="w3-card-4" style="width:100%;">
    <header class="w3-container  w3-center w3-deep-orange">
<h2 class="w3-center">Facturas</h2>
    </header>
    <br><br>
   <div class="w3-center" >
        <h2 class="w3-center" >Parametros de Fechas</h2>

       <input runat="server" id="TxtFechaInicio" type="datetime-local" />
              <input runat="server" id="TxtFechaFinal" type="datetime-local" />
       <br />
        <div class="form-group">
                    <div class="w3-container w3-center">
            
  <button runat="server" id="BtnGenerar" class="w3-deep-orange btn-lg" type="button"><span class="glyphicon glyphicon-ok"></span>Buscar Facturas</button>

                    </div>
                            </div>
     

   </div>
   <hr>
             
<br><br>

    

    <section>
  <fieldset >
      <legend>Facturas Filtradas</legend>
                         <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Finalizados:</small>
                                <asp:Label ID="lblPagos" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
                            <asp:GridView ID="GVFacturasPagos" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Serie" AllowSorting="false">
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
                                        <asp:Label ID="lblPaginadorPagos" runat="server" CssClass="label label-warning" /></h3>
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

</asp:Content>
