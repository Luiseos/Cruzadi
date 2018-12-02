<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="BusquedaCLienteArpon.aspx.vb" Inherits="APPCRUZADI.BusquedaCLienteArpon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br /> <br /> 
     <div class="w3-card-4" style="width:100%;">
    <header class="w3-container  w3-center w3-deep-orange">
<h2 class="w3-center">Modificar</h2>
    </header>
    <br><br>
   
      <div class="w3-center" >
       <%-- <h2 class="w3-center">Buscar</h2>
  <label><span class="glyphicon glyphicon-search"></span></label>
  <input runat="server" id="txtbuscar" type="text" placeholder="Buscar..">
         <button runat="server" id="btnbuscar"></button>--%>
          <%--  --%>
             <div class="w3-center" >
        <h2 class="w3-center" >Buscar</h2>
  <label for="buscacliente" ><span class="glyphicon glyphicon-search"></span></label>
  <%--<input id="TXtBuscar2" runat="server" type="text"   placeholder="Buscar.." autofocus="autofocus" class="auto-style1" AutoPostBack="True" OnTextChanged="TxtBuscar_TextChanged"">--%>
   <asp:TextBox ID="TXtBuscar1" runat="server"  AutopostBack="true" ></asp:TextBox>    
   </div>

          <%--  --%>
   <hr>
   <%--<asp:TextBox ID="TXtBuscar1" runat="server"  AutopostBack="true" ></asp:TextBox>--%>    
   </div>
   <hr>
<br><br>
 
<div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Clientes :</small>
                                <asp:Label ID="lblTotalesCliente" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />

     <asp:GridView ID="Gvbuscarcliente" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="RFC" AllowSorting="false">
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
                       <%--         <Columns>
                              
     
   


     

  

                                      <asp:BoundField DataField="cliente_id" HeaderText="ID" />
                                     <asp:BoundField DataField="RFC" HeaderText="RFC"  />
                                    <asp:BoundField DataField="rtn" HeaderText="RTN"  />
                                    <asp:BoundField DataField="nombre" HeaderText="NOMBRE"  />
                                    <asp:BoundField DataField="nombre_tipo" HeaderText="TIPO CLIENTE"/>
                                    <asp:BoundField DataField="telefono" HeaderText="TELEFONO"  />
                                    <asp:BoundField DataField="e_mail" HeaderText="EMAIL"  />
                                    <asp:BoundField DataField="direccion" HeaderText="DIRECCION"/>
                                    <asp:BoundField DataField="contacto" HeaderText="CONTACTO"  />
                                   
                                                                  </Columns>--%>
                              
     </asp:GridView>
                                 <div class="row" style="margin-top: 20px;">

                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="LblPaginadorCliente" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />
                            </div>
  </div>

</div>



</asp:Content>
