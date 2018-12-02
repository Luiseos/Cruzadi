<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="GestionIT.aspx.vb" Inherits="APPCRUZADI.GestionIT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <br />
        <br />
  <article>
                            <br />

    <div class="w3-card-4" style="width:100%">
            <header class="w3-container w3-center w3-deep-orange">
                <h1>Gestion IT</h1>
            </header>

            <div class="w3-container">
                <br />
                <br />
                <fieldset>
                    <label>Descripcion</label>
                    <input  runat="server" id="TxtDescripcion" onkeypress="return Letras(event)"  onkeyup="DobleEspacio(this,event)" style="text-transform: uppercase" class="w3-input" type="text" autocomplete="off" placeholder="Descripcion de Estado" />
                    <br />
                 <div class="container w3-panel w3-round-small ">
                     <h3>

                            <span style="float: right;"><small>Total de Gestion :</small>
                                <asp:Label ID="lblgestion" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">

                                                
                          <br/> 
      <asp:GridView  runat="server" ID="GVGestionIT" AutoGenerateColumns="false" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="gestion_it_id" AllowSorting="false" >
              
           <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Registros seleccionados!  
                                </EmptyDataTemplate>

                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />

                                <RowStyle BackColor="#f5f5f0"
                                    Font-Italic="true"
                                    HorizontalAlign="Center" />
              <Columns>
                  <asp:BoundField DataField="gestion_it_id" HeaderText="ID" />
                  <asp:BoundField DataField="descripcion_gestion" HeaderText="GESTION" />
               </Columns>
          </asp:GridView>
        <br/> </div>

                    </div>

                    <br />

                </fieldset>
                <br />
                <br />
                   <div class="w3-container w3-center">

                <button runat="server" id="btnguardar"  class="w3-deep-orange btn-lg" >Guardar</button>
                <button runat="server" id="BtnModificar" class="w3-deep-orange btn-lg" >Modificar</button>

            </div>
        <br/> 
        <br/>

            </div>
        </div>

        <br />
        <br />

        <footer class="w3-container w3-deep-orange">
                  <a href="/inicio.aspx" style='color: white'>
             <h3>INICIO</h3>
            </a>

        </footer>
    </article>
</asp:Content>
