using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidLetturaDatiJson
{
    public class AndamentoNazionale
    {
        public string data { get; set; }
        public string stato { get; set; }
        public double ricoverati_con_sintomi { get; set; }
        public int terapia_intensiva { get; set; }
        public int totale_ospedalizzati { get; set; }
        public int isolamento_domiciliare { get; set; }
        public int totale_positivi { get; set; }
        public int variazione_totale_positivi { get; set; }
        public int nuovi_positivi { get; set; }
        public int dimessi_guariti { get; set; }
        public int deceduti { get; set; }
        public string casi_da_sospetto_diagnostico { get; set; }
        public string casi_da_screening { get; set; }
        public int totale_casi { get; set; }
        public int tamponi { get; set; }
        public string casi_testati { get; set; }
        public string note { get; set; }
        public string ingressi_terapia_intensiva { get; set; }
        public string note_test { get; set; }
        public string note_casi { get; set; }
        public string totale_positivi_test_molecolare { get; set; }
        public string totale_positivi_test_antigenico_rapido { get; set; }
        public string tamponi_test_molecolare { get; set; }
        public string tamponi_test_antigenico_rapido { get; set; }
        
    }
    public class AndamentoProvince
    {
        public string data { get; set; }
        public string stato { get; set; }
        public int codice_regione { get; set; }
        public string denominazione_regione { get; set; }
        public int codice_provincia { get; set; }
        public string denominazione_provincia { get; set; }
        public string sigla_provincia { get; set; }
        public string lat { get; set; }
        public string longi { get; set; }
        public int totale_casi { get; set; }
        public string note { get; set; }
        public string codice_nuts_1 { get; set; }
        public string codice_nuts_2 { get; set; }
        public string codice_nuts_3 { get; set; }
    }
    public class AndamentoRegioni
    {
        public string data { get; set; }
        public string stato { get; set; }
        public int codice_regione { get; set; }
        public string denominazione_regione { get; set; }
        public string lat { get; set; }
        public string longi { get; set; }
        public double ricoverati_con_sintomi { get; set; }
        public int terapia_intensiva { get; set; }
        public int totale_ospedalizzati { get; set; }
        public int isolamento_domiciliare { get; set; }
        public int totale_positivi { get; set; }
        public int variazione_totale_positivi { get; set; }
        public int nuovi_positivi { get; set; }
        public int dimessi_guariti { get; set; }
        public int deceduti { get; set; }
        public string casi_da_sospetto_diagnostico { get; set; }
        public string casi_da_screening { get; set; }
        public int totale_casi { get; set; }
        public int tamponi { get; set; }
        public string casi_testati { get; set; }
        public string note { get; set; }
        public string ingressi_terapia_intensiva { get; set; }
        public string note_test { get; set; }
        public string note_casi { get; set; }
        public string totale_positivi_test_molecolare { get; set; }
        public string totale_positivi_test_antigenico_rapido { get; set; }
        public string tamponi_test_molecolare { get; set; }
        public string tamponi_test_antigenico_rapido { get; set; }
        public string codice_nuts_1 { get; set; }
        public string codice_nuts_2 { get; set; }

    }
    public class Deserialize
    {

        public static string[] listjson { get; set; } = new string[2];
        public Tuple<List<AndamentoNazionale>, List<AndamentoProvince>, List<AndamentoRegioni>> Deserializzatore(string[] ListJson)
        {
            List<AndamentoNazionale> andamentonazionale = new List<AndamentoNazionale>();
            List<AndamentoProvince> andamentoprovinciale = new List<AndamentoProvince>();
            List<AndamentoRegioni> andamentoregionale= new List<AndamentoRegioni>();

            
            listjson = ListJson;
            for (int i = 0; i<3; i++)
            {
                if(ListJson[i] != null)
                {
                    if (ListJson[i].Contains("dpc-covid19-ita-andamento-nazionale.json"))
                    {
                        string outputpath = Path.GetFullPath(ListJson[i]);
                        andamentonazionale = JsonConvert.DeserializeObject<List<AndamentoNazionale>>(File.ReadAllText(outputpath));
                    }
                    else if (ListJson[i].Contains("dpc-covid19-ita-province.json"))
                    {
                        string outputpath = Path.GetFullPath(ListJson[i]);
                        andamentoprovinciale = JsonConvert.DeserializeObject<List<AndamentoProvince>>(File.ReadAllText(outputpath));
                    }
                    else if ((ListJson[i].Contains("dpc-covid19-ita-regioni.json")))
                    {
                        string outputpath = Path.GetFullPath(ListJson[i]);
                        andamentoregionale = JsonConvert.DeserializeObject<List<AndamentoRegioni>>(File.ReadAllText(outputpath));
                    }
                }
                else
                {
                    Form1 error = new Form1();
                    string message = "File non inseriti o parziali o errati, riprovare";
                    error.Outputmessage(message);
                    i = 2;

                        
                    
                }

            }
            Tuple<List<AndamentoNazionale>, List<AndamentoProvince>, List<AndamentoRegioni>> tabella = new Tuple<List<AndamentoNazionale>, List<AndamentoProvince>, List<AndamentoRegioni>>(andamentonazionale, andamentoprovinciale, andamentoregionale);
            return tabella;
        }
    }

}
