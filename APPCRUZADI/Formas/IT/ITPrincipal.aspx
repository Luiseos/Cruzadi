<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ITPrincipal.aspx.vb" Inherits="APPCRUZADI.ITPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /> <br /> <br /> 

    <div class="container w3-left-align">

    
       <%-- Recibidos --%>
    <section>
  <fieldset >
      <legend>Ticket Recibidos</legend>
                         <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Recibidos :</small>
                                <asp:Label ID="lblRecibidos" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
                            <asp:GridView ID="GVRecibidosTicket" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Num_ticket" AllowSorting="false">
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
                                        <asp:Label ID="lblPaginadorRecibidos" runat="server" CssClass="label label-warning" /></h3>
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
    <%-- Proceso --%>
    <section>
  <fieldset>

           <legend>Ticket En Procesos</legend>
                    <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total en Proceso :</small>
                                <asp:Label ID="lblProceso" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
                            <asp:GridView ID="GVProcesoTicket" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="NUM_TICKET" >
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
                                        <asp:Label ID="LblPaginadorProceso" runat="server" CssClass="label label-warning" /></h3>
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



     
        
 
  <div class="w3-card-4" style="width:100%;">
    <header class="w3-container w3-blue w3-center" >
      <h1>Estadisticas de Soporte Generales</h1>
    </header>

    <div class="w3-container ">
     
        <asp:Chart ID="Estadisticas" runat="server"  DataSourceID="Cruzadi" Width="723px" BackImageAlignment="Center" BackGradientStyle="Center" Palette="Pastel" BorderlineColor="DarkOrange" Height="290px">
        <Series>
            <asp:Series Name="Series1" label = #PERCENT{P2} labeltooltip = #VALX legendtext = #VALX  legendtooltip = #PERCENT{P2}  ChartType ="Pie" YValuesPerPoint="6" XValueMember="Estados" YValueMembers="Cantidades" ChartArea="ChartArea1" Legend="Leyenda" ></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <Area3DStyle Enable3D="True" />
            </asp:ChartArea>
        </ChartAreas>
            <Legends>
                <asp:Legend BackColor="White" Font="Times New Roman, 10pt, style=Italic" ForeColor="DarkOrange" IsTextAutoFit="False" LegendStyle="Column" Name="Leyenda" Title="Soporte" TitleFont="Times New Roman, 10pt, style=Bold, Italic" TitleSeparator="ThickGradientLine">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Name="Totales" Font="Times New Roman, 10.2pt, style=Bold, Italic" Text="Totales">
                </asp:Title>
            </Titles>
    </asp:Chart>     

                 

       <asp:Chart ID="Semanales" runat="server" DataSourceID="CruzadiSemanalSoporte" Palette="Pastel" ViewStateContent="Default, Appearance" Width="617px" Height="299px">
              <Series>
                  <asp:Series BackGradientStyle="TopBottom" BackImageAlignment="Center" BackImageTransparentColor="255, 128, 0" ChartType="Area" Font="Times New Roman, 10.2pt, style=Bold, Italic" Name="Series1" Palette="Pastel" YValuesPerPoint="2" XValueMember="Estados" YValueMembers="Cantidades">
                  </asp:Series>
              </Series>
              <ChartAreas>
                  <asp:ChartArea Name="ChartArea1">
                  </asp:ChartArea>
              </ChartAreas>
              <Titles>
                  <asp:Title Font="Times New Roman, 10.2pt, style=Bold, Italic" Name="Title1" Text="Semanales">
                  </asp:Title>
              </Titles>
        </asp:Chart>

        <div class="w3-center">

     
               <asp:SqlDataSource ID="CruzadiSemanalSoporte" runat="server" ConnectionString="<%$ ConnectionStrings:cruzadiConnectionString %>" SelectCommand="SELECT es.descripcion_estado AS Estados, COUNT(es.estado_IT_id) AS Cantidades FROM cruzadi.tbl_it_soporte AS s INNER JOIN cruzadi.tbl_estado_it AS es ON s.estado_IT_id = es.estado_IT_id WHERE (s.fecha_entrada &gt; GETDATE() - 7) GROUP BY es.estado_IT_id, es.descripcion_estado"></asp:SqlDataSource>


               <asp:Chart ID="hr24" runat="server" DataSourceID="Cruzadi24Hr" Palette="Pastel" ViewStateContent="Default, Appearance" Width="909px" Height="164px">
              <Series>
                  <asp:Series BackGradientStyle="TopBottom" BackImageAlignment="Center" BackImageTransparentColor="255, 128, 0" Font="Times New Roman, 10.2pt, style=Bold, Italic" Name="Series1" Palette="Pastel" XValueMember="Estados" YValueMembers="Cantidades" YValuesPerPoint="2">
                  </asp:Series>
              </Series>
              <ChartAreas>
                  <asp:ChartArea Name="ChartArea1">
                  </asp:ChartArea>
              </ChartAreas>
              <Titles>
                  <asp:Title Font="Times New Roman, 10.2pt, style=Bold, Italic" Name="Title1" Text="Utilimas 24 Horas">
                  </asp:Title>
              </Titles>
        </asp:Chart>
               <asp:SqlDataSource ID="Cruzadi24Hr" runat="server" ConnectionString="<%$ ConnectionStrings:cruzadiConnectionString %>" SelectCommand="SELECT es.descripcion_estado AS Estados, COUNT(es.estado_IT_id) AS Cantidades FROM cruzadi.tbl_it_soporte AS s INNER JOIN cruzadi.tbl_estado_it AS es ON s.estado_IT_id = es.estado_IT_id AND s.estado_IT_id = es.estado_IT_id WHERE (s.fecha_entrada &gt; GETDATE() - 1) GROUP BY es.estado_IT_id, es.descripcion_estado"></asp:SqlDataSource>
           </div>
                      </div>

    <footer class="w3-container w3-blue">
    
    </footer>

    </div>

    <asp:SqlDataSource ID="Cruzadi" runat="server" ConnectionString="<%$ ConnectionStrings:cruzadiConnectionString %>" SelectCommand="SELECT es.descripcion_estado AS Estados, COUNT(es.estado_IT_id) AS Cantidades FROM cruzadi.tbl_it_soporte AS s CROSS JOIN cruzadi.tbl_estado_it AS es WHERE (s.estado_IT_id = es.estado_IT_id) OR (es.descripcion_estado = 'Pendiente') AND (es.descripcion_estado = 'Proceso') AND (es.descripcion_estado = 'Finalizado') GROUP BY es.estado_IT_id, es.descripcion_estado"></asp:SqlDataSource>
    <br />


</asp:Content>

