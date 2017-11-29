namespace BusinessLayer
{
    public class MargenUtilidad
    {
        /*
            c = Mes
            cp = Código
            cd = Descripción
            cm = Medida
            u = Unidades
            np = NPU
            ni = NPIGV
            nc = NCOSTO
            nu = NPUD
            nd = NCOSTOD
            ca = CCOD_ALMA
            c1 = CCOD_COSTO
            c2 = CCOD_COS2
            cv = CCOD_VEND
            l = LSTOCK
            lr = LREG   
        */
        public class R_MargenUtilidad
        {
            public string c { get; set; }
            public string cp { get; set; }
            public string cd { get; set; }
            public string cm { get; set; }
            public decimal u { get; set; }
            public decimal np { get; set; }
            public decimal ni { get; set; }
            public decimal nc { get; set; }
            public decimal nu { get; set; }
            public decimal nd { get; set; }
            public string ca { get; set; }
            public string c1 { get; set; }
            public string c2 { get; set; }
            public string cv { get; set; }
            public bool l { get; set; }
            public bool lr { get; set; }
        }
    }
}
