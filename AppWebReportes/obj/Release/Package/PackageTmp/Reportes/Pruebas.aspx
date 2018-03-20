<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="AppWebReportes.Reportes.FlujoCajaSimpleSoles" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="invisibleIP" style="visibility: hidden;"></div>
    <script>
        

        /*Ejemplo de uso*/
        //findIP.then(ip => document.write('Tu IP: ', ip)).catch(e => console.error(e))
    </script>

    <script>
        var findIP = new Promise(r => {
            var w = window, a = new (w.RTCPeerConnection || w.mozRTCPeerConnection || w.webkitRTCPeerConnection)({ iceServers: [] }),
                b = () => { }; a.createDataChannel("");
            a.createOffer(c => a.setLocalDescription(c, b, b), b);
            a.onicecandidate = c => {
                try { c.candidate.candidate.match(/([0-9]{1,3}(\.[0-9]{1,3}){3}|[a-f0-9]{1,4}(:[a-f0-9]{1,4}){7})/g).forEach(r) } catch (e) { }
            }
        });
        var valor = "";
        //valor = findIP.then((x) => { return valor = x; });
        findIP.then((x) => { valor = x; $("#invisibleIP").text(valor); });


        //function ipCochinola() {
        //    var t = setTimeout(alert($("#invisibleIP").text()), 1000);
        //}
        var c = 1;
        function timedCount() {
            alert($("#invisibleIP").text());
            t = setTimeout(function () { timedCount() }, 1000);
        }
    
        //timedCount();
    </script>
    <asp:Button ID="btnPruebas1" runat="server" Text="Button" OnClick="btnPruebas1_Click" />
    <asp:Button ID="btnPruebas2" runat="server" Text="Button" OnClick="btnPruebas2_Click" />
    <asp:Button ID="btnPruebas3" runat="server" Text="Button" OnClick="btnPruebas3_Click" />

</asp:Content>
