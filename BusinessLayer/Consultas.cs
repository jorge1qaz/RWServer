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
        public decimal GetTotalByReportEFNTESF(bool moneda, int mesProceso) {
            string JsonDatasetA105 = "", JsonDatasetA110 = "", JsonDatasetA115 = "", JsonDatasetA120 = "", JsonDatasetA125 = "", JsonDatasetA128 = "", JsonDatasetA130 = "", JsonDatasetA131 = "", JsonDatasetA133 = "",
                JsonDatasetA140 = "", JsonDatasetA210 = "", JsonDatasetA220 = "", JsonDatasetA510 = "", JsonDatasetA513 = "", JsonDatasetA515 = "", JsonDatasetA517 = "", JsonDatasetA520 = "", JsonDatasetA525 = "",
                JsonDatasetA530 = "", JsonDatasetA540 = "", JsonDatasetA550 = "", JsonDatasetA560 = "", JsonDatasetA570 = "", JsonDatasetA575 = "", JsonDatasetA580 = "";
            decimal totalA105, totalA110, totalA115, totalA120, totalA125, totalA128, totalA130, totalA131, totalA133, totalA140, totalA210, totalA220, totalA510, totalA513,
                totalA515, totalA517, totalA520, totalA525, totalA530, totalA540, totalA550, totalA560, totalA570, totalA575, totalA580, totalA199, totalA399, totalA599, totalA999;
            string JsonDatasetP105 = "", JsonDatasetP110 = "", JsonDatasetP120 = "", JsonDatasetP121 = "", JsonDatasetP123 = "", JsonDatasetP125 = "", JsonDatasetP130 = "", JsonDatasetP135 = "", JsonDatasetP137 = "",
                    JsonDatasetP210 = "", JsonDatasetP410 = "", JsonDatasetP415 = "", JsonDatasetP420 = "", JsonDatasetP425 = "", JsonDatasetP430 = "", JsonDatasetP435 = "", JsonDatasetP440 = "", JsonDatasetP445 = "",
                    JsonDatasetP450 = "", JsonDatasetP805 = "", JsonDatasetP810 = "", JsonDatasetP815 = "", JsonDatasetP820 = "", JsonDatasetP830 = "", JsonDatasetP835 = "", JsonDatasetP840 = "";
            decimal totalP105, totalP110, totalP120, totalP121, totalP123, totalP125, totalP130, totalP135, totalP137, totalP210, totalP410, totalP415, totalP420, totalP425, totalP430,
                    totalP435, totalP440, totalP445, totalP450, totalP699, totalP805, totalP810, totalP815, totalP820, totalP830, totalP835, totalP840, totalP199, totalP399, totalP499, totalP899, totalP999;
            string JsonDatasetF005 = "", JsonDatasetF105 = "", JsonDatasetF206 = "", JsonDatasetF211 = "", JsonDatasetF212 = "", JsonDatasetF213 = "", JsonDatasetF214 = "",
                   JsonDatasetF215 = "", JsonDatasetF320 = "", JsonDatasetF350 = "", JsonDatasetF380 = "", JsonDatasetF403 = "", JsonDatasetF405 = "", JsonDatasetF415 = "", JsonDatasetF710 = "", JsonDatasetF805 = "";
            decimal totalF005 = 0, totalF105 = 0, totalF199 = 0, totalF206 = 0, totalF211 = 0, totalF212 = 0, totalF213 = 0, totalF214 = 0, totalF215 = 0, totalF299 = 0, totalF320 = 0, totalF350 = 0, totalF380 = 0, totalF403 = 0, totalF405 = 0, totalF415 = 0, totalF699 = 0, totalF710 = 0, totalF799 = 0, totalF805 = 0, totalF999 = 0;

            JsonDatasetA105 = GetPathFile("A105"); JsonDatasetA110 = GetPathFile("A110"); JsonDatasetA115 = GetPathFile("A115"); JsonDatasetA120 = GetPathFile("A120"); JsonDatasetA125 = GetPathFile("A125"); JsonDatasetA128 = GetPathFile("A128");
            JsonDatasetA130 = GetPathFile("A130"); JsonDatasetA131 = GetPathFile("A131"); JsonDatasetA133 = GetPathFile("A133"); JsonDatasetA140 = GetPathFile("A140"); JsonDatasetA210 = GetPathFile("A210"); JsonDatasetA220 = GetPathFile("A220");
            JsonDatasetA510 = GetPathFile("A510"); JsonDatasetA513 = GetPathFile("A513"); JsonDatasetA515 = GetPathFile("A515"); JsonDatasetA517 = GetPathFile("A517"); JsonDatasetA520 = GetPathFile("A520"); JsonDatasetA525 = GetPathFile("A525");
            JsonDatasetA530 = GetPathFile("A530"); JsonDatasetA540 = GetPathFile("A540"); JsonDatasetA550 = GetPathFile("A550"); JsonDatasetA560 = GetPathFile("A560"); JsonDatasetA570 = GetPathFile("A570"); JsonDatasetA575 = GetPathFile("A575");
            JsonDatasetA580 = GetPathFile("A580"); JsonDatasetP835 = GetPathFile("P835"); JsonDatasetP840 = GetPathFile("P840"); JsonDatasetP815 = GetPathFile("P815"); JsonDatasetP820 = GetPathFile("P820"); JsonDatasetP830 = GetPathFile("P830");
            JsonDatasetP105 = GetPathFile("P105"); JsonDatasetP110 = GetPathFile("P110"); JsonDatasetP120 = GetPathFile("P120"); JsonDatasetP121 = GetPathFile("P121"); JsonDatasetP123 = GetPathFile("P123"); JsonDatasetP125 = GetPathFile("P125");
            JsonDatasetP130 = GetPathFile("P130"); JsonDatasetP135 = GetPathFile("P135"); JsonDatasetP137 = GetPathFile("P137"); JsonDatasetP210 = GetPathFile("P210"); JsonDatasetP410 = GetPathFile("P410"); JsonDatasetP415 = GetPathFile("P415");
            JsonDatasetP420 = GetPathFile("P420"); JsonDatasetP425 = GetPathFile("P425"); JsonDatasetP430 = GetPathFile("P430"); JsonDatasetP435 = GetPathFile("P435"); JsonDatasetP440 = GetPathFile("P440"); JsonDatasetP445 = GetPathFile("P445");
            JsonDatasetP450 = GetPathFile("P450"); JsonDatasetP805 = GetPathFile("P805"); JsonDatasetP810 = GetPathFile("P810");

            totalA105 = mergeTables.GeTotalByTablePlan(JsonDatasetA105, moneda, mesProceso, true); totalA110 = mergeTables.GeTotalByTablePlan(JsonDatasetA110, moneda, mesProceso, true); totalA115 = mergeTables.GeTotalByTablePlan(JsonDatasetA115, moneda, mesProceso, true);
            totalA120 = mergeTables.GeTotalByTablePlan(JsonDatasetA120, moneda, mesProceso, true); totalA125 = mergeTables.GeTotalByTablePlan(JsonDatasetA125, moneda, mesProceso, true); totalA128 = mergeTables.GeTotalByTablePlan(JsonDatasetA128, moneda, mesProceso, true);
            totalA130 = mergeTables.GeTotalByTablePlan(JsonDatasetA130, moneda, mesProceso, true); totalA131 = mergeTables.GeTotalByTablePlan(JsonDatasetA131, moneda, mesProceso, true); totalA133 = mergeTables.GeTotalByTablePlan(JsonDatasetA133, moneda, mesProceso, true);
            totalA140 = mergeTables.GeTotalByTablePlan(JsonDatasetA140, moneda, mesProceso, true); totalA210 = mergeTables.GeTotalByTablePlan(JsonDatasetA210, moneda, mesProceso, true); totalA220 = mergeTables.GeTotalByTablePlan(JsonDatasetA220, moneda, mesProceso, true);
            totalA510 = mergeTables.GeTotalByTablePlan(JsonDatasetA510, moneda, mesProceso, true); totalA513 = mergeTables.GeTotalByTablePlan(JsonDatasetA513, moneda, mesProceso, true); totalA515 = mergeTables.GeTotalByTablePlan(JsonDatasetA515, moneda, mesProceso, true);
            totalA517 = mergeTables.GeTotalByTablePlan(JsonDatasetA517, moneda, mesProceso, true); totalA520 = mergeTables.GeTotalByTablePlan(JsonDatasetA520, moneda, mesProceso, true); totalA525 = mergeTables.GeTotalByTablePlan(JsonDatasetA525, moneda, mesProceso, true);
            totalA530 = mergeTables.GeTotalByTablePlan(JsonDatasetA530, moneda, mesProceso, true); totalA540 = mergeTables.GeTotalByTablePlan(JsonDatasetA540, moneda, mesProceso, true); totalA550 = mergeTables.GeTotalByTablePlan(JsonDatasetA550, moneda, mesProceso, true);
            totalA560 = mergeTables.GeTotalByTablePlan(JsonDatasetA560, moneda, mesProceso, true); totalA570 = mergeTables.GeTotalByTablePlan(JsonDatasetA570, moneda, mesProceso, true); totalA575 = mergeTables.GeTotalByTablePlan(JsonDatasetA575, moneda, mesProceso, true);
            totalA580 = mergeTables.GeTotalByTablePlan(JsonDatasetA580, moneda, mesProceso, true);
            totalP105 = mergeTables.GeTotalByTablePlan(JsonDatasetP105, moneda, mesProceso, true); totalP110 = mergeTables.GeTotalByTablePlan(JsonDatasetP110, moneda, mesProceso, true); totalP120 = mergeTables.GeTotalByTablePlan(JsonDatasetP120, moneda, mesProceso, true);
            totalP121 = mergeTables.GeTotalByTablePlan(JsonDatasetP121, moneda, mesProceso, true); totalP123 = mergeTables.GeTotalByTablePlan(JsonDatasetP123, moneda, mesProceso, true); totalP125 = mergeTables.GeTotalByTablePlan(JsonDatasetP125, moneda, mesProceso, true);
            totalP130 = mergeTables.GeTotalByTablePlan(JsonDatasetP130, moneda, mesProceso, true); totalP135 = mergeTables.GeTotalByTablePlan(JsonDatasetP135, moneda, mesProceso, true); totalP137 = mergeTables.GeTotalByTablePlan(JsonDatasetP137, moneda, mesProceso, true);
            totalP210 = mergeTables.GeTotalByTablePlan(JsonDatasetP210, moneda, mesProceso, true); totalP410 = mergeTables.GeTotalByTablePlan(JsonDatasetP410, moneda, mesProceso, true); totalP415 = mergeTables.GeTotalByTablePlan(JsonDatasetP415, moneda, mesProceso, true);
            totalP420 = mergeTables.GeTotalByTablePlan(JsonDatasetP420, moneda, mesProceso, true); totalP425 = mergeTables.GeTotalByTablePlan(JsonDatasetP425, moneda, mesProceso, true); totalP430 = mergeTables.GeTotalByTablePlan(JsonDatasetP430, moneda, mesProceso, true);
            totalP435 = mergeTables.GeTotalByTablePlan(JsonDatasetP435, moneda, mesProceso, true); totalP440 = mergeTables.GeTotalByTablePlan(JsonDatasetP440, moneda, mesProceso, true); totalP445 = mergeTables.GeTotalByTablePlan(JsonDatasetP445, moneda, mesProceso, true);
            totalP450 = mergeTables.GeTotalByTablePlan(JsonDatasetP450, moneda, mesProceso, true); totalP805 = mergeTables.GeTotalByTablePlan(JsonDatasetP805, moneda, mesProceso, true); totalP810 = mergeTables.GeTotalByTablePlan(JsonDatasetP810, moneda, mesProceso, true);
            totalP815 = mergeTables.GeTotalByTablePlan(JsonDatasetP815, moneda, mesProceso, true); totalP820 = mergeTables.GeTotalByTablePlan(JsonDatasetP820, moneda, mesProceso, true); totalP830 = mergeTables.GeTotalByTablePlan(JsonDatasetP830, moneda, mesProceso, true);
            totalP835 = totalF999; totalP840 = mergeTables.GeTotalByTablePlan(JsonDatasetP840, moneda, mesProceso, true);

            totalA199 = totalA105 + totalA110 + totalA115 + totalA120 + totalA125 + totalA128 + totalA130 + totalA131 + totalA133 + totalA140; totalA399 = totalA210 + totalA220 + totalA199;
            totalA599 = totalA510 + totalA513 + totalA515 + totalA517 + totalA520 + totalA525 + totalA530 + totalA540 + totalA550 + totalA560 + totalA570 + totalA575 + totalA580 + totalA399; totalA999 = totalA599;
            //Labels finales
            totalP199 = totalP105 + totalP110 + totalP120 + totalP121 + totalP123 + totalP125 + totalP130 + totalP135 + totalP137; totalP399 = totalP210 + totalP199; totalP699 = totalP499 + totalP399;
            totalP499 = totalP410 + totalP415 + totalP420 + totalP425 + totalP430 + totalP435 + totalP440 + totalP445 + totalP450; totalP899 = totalP805 + totalP810 + totalP815 + totalP820 + totalP830 + totalP835 + totalP840;
            totalP999 = totalP899 + totalP399;
        }

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
