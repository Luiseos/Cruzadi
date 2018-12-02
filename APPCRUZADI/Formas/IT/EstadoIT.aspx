<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="EstadoIT.aspx.vb" Inherits="APPCRUZADI.EstadoIT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  
     <br />
 <br />
    <article>

        <div class="w3-card-4" style="width: 100%">
            <header class="w3-container w3-center w3-deep-orange">
                <h1>Estado IT</h1>
            </header>

            <div class="w3-container">
                <br />
                <br />
                <fieldset>
                    <label>Descripcion</label>
                    <input id="txtDescripcion" runat="server" onkeypress="return Letras(event)" onkeyup="DobleEspacio(this,event)" style="text-transform: uppercase" class="w3-input" type="text" autocomplete="off" placeholder="Descripcion de Estado" />
                    <br />
                    <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Estados :</small>
                                <asp:Label ID="lblEstados" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
                            <asp:GridView ID="GVEstadoIT" runat="server" AutoGenerateColumns="false" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="estado_it_id" AllowSorting="True">
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                <%-- <alternatingrowstyle backcolor= #e0e0d1 
          font-italic="true"/>--%>
                                <Columns>
                                    <asp:BoundField DataField="estado_it_id" HeaderText="ID" />
                                    <asp:BoundField DataField="Descripcion_estado" HeaderText="ESTADO" />
                                </Columns>
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
                                        <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />

                        </div>

                    </div>
                    <br />

                </fieldset>
                <br />
                <br />
                <div class="w3-container w3-center">

                    <button runat="server" id="btnguardar" class="w3-deep-orange btn-lg">Guardar</button>
                    <button runat="server" id="BtnModificar" class="w3-deep-orange btn-lg">Modificar</button>

                </div>
                <br />
                <br />

            </div>
        </div>

        <br />
        <footer class="w3-container w3-deep-orange">
            <a href="/inicio.aspx" style='color: white'>
                <h3>INICIO</h3>
            </a>

        </footer>

    </article>
   
</asp:Content>
