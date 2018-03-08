using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Consultas
    {
        public string rootPath { get; set; }
        public string user  { get; set; }
        public string nameReport { get; set; }
        public string idCompany { get; set; }
        public string year { get; set; }
        
        Paths paths = new Paths();
        MergeTables mergeTables = new MergeTables();
        // EFNTER = Estados financieros NIIF y tributario: Estado de resultado
        public decimal GetTotalByReportEFNTER(bool moneda, int mesProceso)
        {
            string JsonDatasetN005 = "", JsonDatasetN010 = "", JsonDatasetN015 = "", JsonDatasetN103 = "", JsonDatasetN105 = "", JsonDatasetN110 = "", JsonDatasetN205 = "", JsonDatasetN210 = "", JsonDatasetN215 = "", JsonDatasetN220 = "",
                    JsonDatasetN225 = "", JsonDatasetN230 = "", JsonDatasetN235 = "", JsonDatasetN305 = "", JsonDatasetN310 = "", JsonDatasetN315 = "", JsonDatasetN405 = "", JsonDatasetN410 = "", JsonDatasetN415 = "", JsonDatasetN420 = "",
                    JsonDatasetN425 = "", JsonDatasetN430 = "", JsonDatasetN505 = "", JsonDatasetN510 = "", JsonDatasetN515 = "", JsonDatasetN520 = "", JsonDatasetN525 = "", JsonDatasetN805 = "", JsonDatasetN810;

            decimal totalN005 = 0, totalN010 = 0, totalN015 = 0, totalN099 = 0, totalN103 = 0, totalN105 = 0, totalN110 = 0, totalN199 = 0, totalN205 = 0, totalN299 = 0, totalN210 = 0, totalN215 = 0, totalN220 = 0, totalN225 = 0, totalN230 = 0, totalN235 = 0, totalN305 = 0, totalN310 = 0,
                    totalN315 = 0, totalN405 = 0, totalN410 = 0, totalN415 = 0, totalN420 = 0, totalN425 = 0, totalN430 = 0, totalN505 = 0, totalN510 = 0, totalN515 = 0, totalN520 = 0, totalN525 = 0, totalN805 = 0, totalN810 = 0, totalN399 = 0, totalN499 = 0, totalN599 = 0, totalN999 = 0;
            string simboloMoneda = "", JsonDatasetF005 = "", JsonDatasetF105 = "", JsonDatasetF206 = "", JsonDatasetF211 = "", JsonDatasetF212 = "", JsonDatasetF213 = "", JsonDatasetF214 = "",
                    JsonDatasetF215 = "", JsonDatasetF320 = "", JsonDatasetF350 = "", JsonDatasetF380 = "", JsonDatasetF403 = "", JsonDatasetF405 = "", JsonDatasetF415 = "", JsonDatasetF710 = "", JsonDatasetF805 = "";
            decimal totalF005 = 0, totalF105 = 0, totalF199 = 0, totalF206 = 0, totalF211 = 0, totalF212 = 0, totalF213 = 0, totalF214 = 0, totalF215 = 0, totalF299 = 0, totalF320 = 0, totalF350 = 0, totalF380 = 0, totalF403 = 0, totalF405 = 0, totalF415 = 0, totalF699 = 0, totalF710 = 0, totalF799 = 0, totalF805 = 0, totalF999 = 0;
            //    Naturaleza
            JsonDatasetN005 = GetStringByJsonData("N005"); JsonDatasetN010 = GetStringByJsonData("N010"); JsonDatasetN015 = GetStringByJsonData("N015"); JsonDatasetN103 = GetStringByJsonData("N103"); JsonDatasetN105 = GetStringByJsonData("N105"); JsonDatasetN110 = GetStringByJsonData("N110");
            JsonDatasetN205 = GetStringByJsonData("N205"); JsonDatasetN210 = GetStringByJsonData("N210"); JsonDatasetN215 = GetStringByJsonData("N215"); JsonDatasetN220 = GetStringByJsonData("N220"); JsonDatasetN225 = GetStringByJsonData("N225"); JsonDatasetN230 = GetStringByJsonData("N230");
            JsonDatasetN235 = GetStringByJsonData("N235"); JsonDatasetN305 = GetStringByJsonData("N305"); JsonDatasetN310 = GetStringByJsonData("N310"); JsonDatasetN315 = GetStringByJsonData("N315"); JsonDatasetN405 = GetStringByJsonData("N405"); JsonDatasetN410 = GetStringByJsonData("N410");
            JsonDatasetN415 = GetStringByJsonData("N415"); JsonDatasetN420 = GetStringByJsonData("N420"); JsonDatasetN425 = GetStringByJsonData("N425"); JsonDatasetN430 = GetStringByJsonData("N430"); JsonDatasetN505 = GetStringByJsonData("N505"); JsonDatasetN510 = GetStringByJsonData("N510");
            JsonDatasetN515 = GetStringByJsonData("N515"); JsonDatasetN520 = GetStringByJsonData("N520"); JsonDatasetN525 = GetStringByJsonData("N525"); JsonDatasetN805 = GetStringByJsonData("N805"); JsonDatasetN810 = GetStringByJsonData("N810");

            totalN005 = mergeTables.GeTotalByTablePlan(JsonDatasetN005, moneda, mesProceso, false); totalN010 = mergeTables.GeTotalByTablePlan(JsonDatasetN010, moneda, mesProceso, false); totalN015 = mergeTables.GeTotalByTablePlan(JsonDatasetN015, moneda, mesProceso, false);
            totalN099 = totalN005 + totalN010 + totalN015;

            totalN103 = mergeTables.GeTotalByTablePlan(JsonDatasetN103, moneda, mesProceso, false); totalN105 = mergeTables.GeTotalByTablePlan(JsonDatasetN105, moneda, mesProceso, false); totalN110 = mergeTables.GeTotalByTablePlan(JsonDatasetN110, moneda, mesProceso, false);
            totalN199 = totalN103 + totalN105 + totalN110 + totalN099;

            totalN205 = mergeTables.GeTotalByTablePlan(JsonDatasetN205, moneda, mesProceso, false); totalN210 = mergeTables.GeTotalByTablePlan(JsonDatasetN210, moneda, mesProceso, false); totalN215 = mergeTables.GeTotalByTablePlan(JsonDatasetN215, moneda, mesProceso, false);
            totalN220 = mergeTables.GeTotalByTablePlan(JsonDatasetN220, moneda, mesProceso, false); totalN225 = mergeTables.GeTotalByTablePlan(JsonDatasetN225, moneda, mesProceso, false); totalN230 = mergeTables.GeTotalByTablePlan(JsonDatasetN230, moneda, mesProceso, false);
            totalN235 = mergeTables.GeTotalByTablePlan(JsonDatasetN235, moneda, mesProceso, false); totalN299 = totalN205 + totalN210 + totalN215 + totalN220 + totalN225 + totalN230 + totalN235 + totalN199;

            totalN305 = mergeTables.GeTotalByTablePlan(JsonDatasetN305, moneda, mesProceso, false); totalN310 = mergeTables.GeTotalByTablePlan(JsonDatasetN310, moneda, mesProceso, false); totalN315 = mergeTables.GeTotalByTablePlan(JsonDatasetN315, moneda, mesProceso, false);
            totalN399 = totalN305 + totalN310 + totalN315 + totalN299;

            totalN405 = mergeTables.GeTotalByTablePlan(JsonDatasetN405, moneda, mesProceso, false); totalN410 = mergeTables.GeTotalByTablePlan(JsonDatasetN410, moneda, mesProceso, false); totalN415 = mergeTables.GeTotalByTablePlan(JsonDatasetN415, moneda, mesProceso, false);
            totalN420 = mergeTables.GeTotalByTablePlan(JsonDatasetN420, moneda, mesProceso, false); totalN425 = mergeTables.GeTotalByTablePlan(JsonDatasetN425, moneda, mesProceso, false); totalN430 = mergeTables.GeTotalByTablePlan(JsonDatasetN430, moneda, mesProceso, false);
            totalN499 = totalN405 + totalN410 + totalN415 + totalN420 + totalN425 + totalN430 + totalN399;

            totalN505 = mergeTables.GeTotalByTablePlan(JsonDatasetN505, moneda, mesProceso, false); totalN510 = mergeTables.GeTotalByTablePlan(JsonDatasetN510, moneda, mesProceso, false); totalN515 = mergeTables.GeTotalByTablePlan(JsonDatasetN515, moneda, mesProceso, false);
            totalN520 = mergeTables.GeTotalByTablePlan(JsonDatasetN520, moneda, mesProceso, false); totalN525 = mergeTables.GeTotalByTablePlan(JsonDatasetN525, moneda, mesProceso, false); totalN599 = totalN505 + totalN510 + totalN515 + totalN520 + totalN525 + totalN499;

            totalN805 = mergeTables.GeTotalByTablePlan(JsonDatasetN805, moneda, mesProceso, false); totalN810 = mergeTables.GeTotalByTablePlan(JsonDatasetN810, moneda, mesProceso, false); totalN999 = totalN805 + totalN810 + totalN599;

            //Función
            JsonDatasetF005 = GetStringByJsonData("F005"); JsonDatasetF105 = GetStringByJsonData("F105"); JsonDatasetF206 = GetStringByJsonData("F206"); JsonDatasetF211 = GetStringByJsonData("F211"); JsonDatasetF212 = GetStringByJsonData("F212"); JsonDatasetF213 = GetStringByJsonData("F213");
            JsonDatasetF214 = GetStringByJsonData("F214"); JsonDatasetF215 = GetStringByJsonData("F215"); JsonDatasetF320 = GetStringByJsonData("F320"); JsonDatasetF350 = GetStringByJsonData("F350"); JsonDatasetF380 = GetStringByJsonData("F380"); JsonDatasetF403 = GetStringByJsonData("F403");
            JsonDatasetF405 = GetStringByJsonData("F405"); JsonDatasetF415 = GetStringByJsonData("F415"); JsonDatasetF710 = GetStringByJsonData("F710"); JsonDatasetF805 = GetStringByJsonData("F805");

            totalF005 = mergeTables.GeTotalByTablePlan(JsonDatasetF005, moneda, mesProceso, false); totalF105 = mergeTables.GeTotalByTablePlan(JsonDatasetF105, moneda, mesProceso, false); totalF199 = totalF005 + totalF105;

            totalF206 = mergeTables.GeTotalByTablePlan(JsonDatasetF206, moneda, mesProceso, false); totalF211 = mergeTables.GeTotalByTablePlan(JsonDatasetF211, moneda, mesProceso, false); totalF212 = mergeTables.GeTotalByTablePlan(JsonDatasetF212, moneda, mesProceso, false);
            totalF213 = mergeTables.GeTotalByTablePlan(JsonDatasetF213, moneda, mesProceso, false); totalF214 = mergeTables.GeTotalByTablePlan(JsonDatasetF214, moneda, mesProceso, false); totalF215 = mergeTables.GeTotalByTablePlan(JsonDatasetF215, moneda, mesProceso, false);
            totalF299 = totalF206 + totalF211 + totalF212 + totalF213 + totalF214 + totalF215 + totalF199;

            totalF320 = mergeTables.GeTotalByTablePlan(JsonDatasetF320, moneda, mesProceso, false); totalF350 = mergeTables.GeTotalByTablePlan(JsonDatasetF350, moneda, mesProceso, false); totalF380 = mergeTables.GeTotalByTablePlan(JsonDatasetF380, moneda, mesProceso, false);
            totalF403 = mergeTables.GeTotalByTablePlan(JsonDatasetF403, moneda, mesProceso, false); totalF405 = mergeTables.GeTotalByTablePlan(JsonDatasetF405, moneda, mesProceso, false); totalF415 = mergeTables.GeTotalByTablePlan(JsonDatasetF415, moneda, mesProceso, false);
            totalF699 = totalF320 + totalF350 + totalF380 + totalF403 + totalF405 + totalF415 + totalF299;

            totalF710 = mergeTables.GeTotalByTablePlan(JsonDatasetF710, moneda, mesProceso, false); totalF799 = totalF710 + totalF699;
            totalF805 = mergeTables.GeTotalByTablePlan(JsonDatasetF805, moneda, mesProceso, false); totalF999 = totalF805 + totalF799;
            return totalN999;
        }
        // EFNTESF = Estados financieros NIIF y tributario: Estado de situación financiera
        

        public DataTable GetTableByJsonData(string nameFile, string nameTable) {
            //string nameFile, String rootPath, string user, string nameReport, string idCompany, string year
            string jsonData     = paths.GetStringByFileJson(nameFile, rootPath, user, nameReport, idCompany, year);
            DataSet dataSet     = JsonConvert.DeserializeObject<DataSet>(jsonData);
            DataTable dataTable = dataSet.Tables[nameTable];
            return dataTable;
        }
        public string GetStringByJsonData(string nameFile)
        {
            //string nameFile, String rootPath, string user, string nameReport, string idCompany, string year
            string jsonData = paths.GetStringByFileJson(nameFile, rootPath, user, nameReport, idCompany, year);
            return jsonData;
        }
    }
}
