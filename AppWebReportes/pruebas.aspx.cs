using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWebReportes
{
    public partial class pruebas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double num = 26.07;
            int length = Convert.ToString(num).Substring(Convert.ToString(num).IndexOf(".")).Length - 1;
            Response.Write("debería salir algodon pero nah ");
            Response.Write(length.ToString());
            string numConvert = Convert.ToString(num);
            switch (length.ToString())
            {
                case "1":
                    numConvert = numConvert + "000";
                    Response.Write(" aqui 1: " + numConvert + "; ");
                    break;
                case "2":
                    numConvert = numConvert + "00";
                    Response.Write(" aqui 2: " + numConvert + "; ");
                    break;
                case "3":
                    numConvert = numConvert + "0";
                    Response.Write(" aqui 3: " + numConvert + "; ");
                    break;
            }
            Response.Write(num);
        }

        public string CompleteZeros(decimal number)
        {
            int lengthNumber;
            try
            {
                lengthNumber = Convert.ToString(number).Substring(Convert.ToString(number).IndexOf(".")).Length - 1;
            }
            catch
            {
                lengthNumber = 4;
            }
            string numberComplete = Convert.ToString(number);
            switch (lengthNumber.ToString())
            {
                case "1":
                    numberComplete = numberComplete + "000";
                    break;
                case "2":
                    numberComplete = numberComplete + "00";
                    break;
                case "3":
                    numberComplete = numberComplete + "0";
                    break;
                default:
                    break;
            }
            return numberComplete;
        }

        protected void btnPruebas_Click(object sender, EventArgs e)
        {
            lblPruebas.Text = CompleteZeros(decimal.Parse(txtPruebas.Text));

        }
    }
}