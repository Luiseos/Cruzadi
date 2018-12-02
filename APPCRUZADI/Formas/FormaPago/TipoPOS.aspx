<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="TipoPOS.aspx.vb" Inherits="APPCRUZADI.TipoPOS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            box-shadow: 0 4px 10px 0 rgba(0,0,0,0.2),0 4px 20px 0 rgba(0,0,0,0.19);
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
     <br />


  

  <div class="auto-style1">
    <header class="w3-container w3-center w3-deep-orange">
      <h1>Tipo de POS</h1>
    </header>

    <div class="w3-container">
      <br/>
      <br/>
      <fieldset>

        <label>Tipo POS</label>
        <input runat="server" class="w3-input" type="text" id="txtDescripcion"  placeholder="Descripcion de POS" style="text-transform: uppercase"  onkeypress="return Letras(event)" onkeyup="DobleEspacio(this, event)" autocomplete="off" required />
          <br />
             <label>Tasa Cobro</label>
        <input runat="server" class="w3-input" type="text" id="TxtTasacobro"  placeholder="Descripcion de Cobro" value="10" onkeypress="return filterFloat(event,this);"  onkeyup="DobleEspacio(this, event)" autocomplete="off" required />
          <br />
                    <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Estados :</small>
                                <asp:Label ID="lblTipopos" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
      <asp:GridView ID="GVPOS" runat="server" AutoGenerateColumns="false" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Pos_id" AllowSorting="false">
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
          <Columns>
              <asp:BoundField DataField="Pos_id" HeaderText="ID" />
              <asp:BoundField DataField="Banco_POS" HeaderText="Tipo POS" />
              <asp:BoundField DataField="Tasa_Cobro" HeaderText="Tasa Cobro" />
          </Columns>
          </asp:GridView>
                            </div>
                        </div>
        <br/>
           <br/>

        </fieldset>
        <br/> 
        <br/>
        
             <div class="w3-container w3-center">

                <button runat="server" id="btnguardar" type="submit" class="w3-deep-orange btn-lg" >Guardar</button>
                <button runat="server" id="btnModificar" type="button"  class="w3-deep-orange btn-lg" >Modificar</button>

            </div>
        <br/>
        
      
    </div>
    </div>


  <footer class="w3-container w3-deep-orange">
            
            <a href="/inicio.aspx" style='color: white'>
                   <h3>INICIO</h3>
            </a>

        </footer>
 

</asp:Content>
