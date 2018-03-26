using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web.Security;
using BusinessLayer;

namespace AppWebReportes.Reportes
{
    public partial class FlujoCajaSimpleSoles : System.Web.UI.Page
    {
        CorreoElectronico correoElectronico = new CorreoElectronico();
        Seguridad seguridad = new Seguridad();
        QueriesCompleteDatabase queriesCompleteDatabase = new QueriesCompleteDatabase();
        Paths paths         = new Paths();
        protected void Page_Load(object sender, EventArgs e)
        {
            // variables temporales
            string user         = "jricra@contasis.net";
            string nameReport   = "rptStdFncr";
            string idCompany    =  /*"02"*/ /*"01"*/"ff"; ;
            string year         = /*"2015"*/ /*"2015"*/"2017";

            String rootPath             = Server.MapPath("~"); //Ruta física
            string dbCompletePlan       = paths.GetStringByFileJson("DataBaseConta", rootPath, user, nameReport, idCompany, year);
            string rubrosCompletePlan   = paths.GetStringByFileJson("listNamesRubros", rootPath, user, nameReport, idCompany, year);
            
            QueriesCompleteDatabase queriesCompleteDatabase = new QueriesCompleteDatabase() {
                identificacionReporte       = 1,
                jsonDataSetDBComplete       = dbCompletePlan,
                jsonDataSetRubrosByFormatos = rubrosCompletePlan,
                tipoMoneda                  = true,
                mesProceso                  = 3,
            };

            string cajaBancos = queriesCompleteDatabase.GetOnlyOneResult(1, "A105");

        }
    }
}