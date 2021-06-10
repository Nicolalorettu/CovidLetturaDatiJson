using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidLetturaDatiJson
{
    public partial class Visualizzatore : Form
    {
        
        private void visualizzatore_Load(object sender, EventArgs e)
        {


        }
        public Visualizzatore(Tuple<List<AndamentoNazionale>, List<AndamentoProvince>, List<AndamentoRegioni>> finaltable)
        {
            InitializeComponent();
            
            string[] removehour = { "T18:00:00", "T17:00:00" };
            int j = 0;
            int pointx = 10;
            int pointy = 20;
            //Ciclo per conteggio casi nazionali
            for (int i = finaltable.Item1.Count - 1; i >= 0; i--)
            {
                string[,] nationalenumerationarray = new string[,] { { "Stato", finaltable.Item1[i].stato }, { "Ricoverati con Sintomi", Convert.ToString(finaltable.Item1[i].ricoverati_con_sintomi) }, { "Terapia Intensiva", Convert.ToString(finaltable.Item1[i].terapia_intensiva) }, { "Totale Ospedalizzati", Convert.ToString(finaltable.Item1[i].totale_ospedalizzati) }, { "Isolamento Domiciliare", Convert.ToString(finaltable.Item1[i].isolamento_domiciliare) }, { "Totale Positivi", Convert.ToString(finaltable.Item1[i].totale_positivi) }, { "Variazione Totale Positivi", Convert.ToString(finaltable.Item1[i].variazione_totale_positivi) }, { "Nuovi Positivi", Convert.ToString(finaltable.Item1[i].nuovi_positivi) }, { "Dimessi Guariti", Convert.ToString(finaltable.Item1[i].dimessi_guariti) }, { "Deceduti", Convert.ToString(finaltable.Item1[i].deceduti) }, { "Casi da Sospetto Diagnostico", Convert.ToString(finaltable.Item1[i].casi_da_sospetto_diagnostico) }, { "Casi da Screening", Convert.ToString(finaltable.Item1[i].casi_da_screening) }, { "Totale Casi", Convert.ToString(finaltable.Item1[i].totale_casi) }, { "Tamponi", Convert.ToString(finaltable.Item1[i].tamponi) }, { "Casi Testati", Convert.ToString(finaltable.Item1[i].casi_testati) }, { "Note", Convert.ToString(finaltable.Item1[i].note) }, { "Ingressi Terapia Intensiva", Convert.ToString(finaltable.Item1[i].ingressi_terapia_intensiva) }, { "Note Test", Convert.ToString(finaltable.Item1[i].note_test) }, { "Note Casi", Convert.ToString(finaltable.Item1[i].note_casi) }, { "Totale Positivi Test Molecolare", Convert.ToString(finaltable.Item1[i].totale_positivi_test_molecolare) }, { "Totale Positivi Test Antigenico Rapido", Convert.ToString(finaltable.Item1[i].totale_positivi_test_antigenico_rapido) }, { "Tamponi Test Molecolare", Convert.ToString(finaltable.Item1[i].tamponi_test_molecolare) }, { "Tamponi Test Antigenico Rapido", Convert.ToString(finaltable.Item1[i].tamponi_test_antigenico_rapido) } };
                //string[,] provincenumerationarray = new string[,] { { "Stato", finaltable.Item2[i].stato }, {"Codice Regione", Convert.ToString(finaltable.Item2[i].codice_regione)},{"Denominazione Regione", Convert.ToString(finaltable.Item2[i].denominazione_regione)},{"Codice Provincia", Convert.ToString(finaltable.Item2[i].codice_provincia)}, {"Denominazione Provincia", Convert.ToString(finaltable.Item2[i].denominazione_provincia)},{"Sigla Provincia", Convert.ToString(finaltable.Item2[i].sigla_provincia)},{"Lat", Convert.ToString(finaltable.Item2[i].lat)},{"Long", Convert.ToString(finaltable.Item2[i].longi)}, {"Totale Casi", Convert.ToString(finaltable.Item2[i].totale_casi)}, {"Note", Convert.ToString(finaltable.Item2[i].note)},{"Codice Nuts 1", Convert.ToString(finaltable.Item2[i].codice_nuts_1)},{"Codice Nuts 2", Convert.ToString(finaltable.Item2[i].codice_nuts_2)},{"Codice Nuts 3", Convert.ToString(finaltable.Item2[i].codice_nuts_3)}};
                //string[,] regionalnumerationarray = new string[,] { { "Stato", finaltable.Item3[i].stato }, { "Codice Regione", Convert.ToString(finaltable.Item3[i].codice_regione) }, { "Denominazione Regione", Convert.ToString(finaltable.Item3[i].denominazione_regione) }, { "Lat", Convert.ToString(finaltable.Item3[i].lat) }, { "Long", Convert.ToString(finaltable.Item3[i].longi) }, { "Ricoverati con Sintomi", Convert.ToString(finaltable.Item3[i].ricoverati_con_sintomi) }, { "Terapia Intensiva", Convert.ToString(finaltable.Item3[i].terapia_intensiva) }, { "Totale Ospedalizzati", Convert.ToString(finaltable.Item3[i].totale_ospedalizzati) }, { "Isolamento Domiciliare", Convert.ToString(finaltable.Item3[i].isolamento_domiciliare) }, { "Totale Positivi", Convert.ToString(finaltable.Item3[i].totale_positivi) }, { "Variazione Totale Positivi", Convert.ToString(finaltable.Item3[i].variazione_totale_positivi) }, { "Nuovi Positivi", Convert.ToString(finaltable.Item3[i].nuovi_positivi) }, { "Dimessi Guariti", Convert.ToString(finaltable.Item3[i].dimessi_guariti) }, { "Deceduti", Convert.ToString(finaltable.Item3[i].deceduti) }, { "Casi da Sospetto Diagnostico", Convert.ToString(finaltable.Item3[i].casi_da_sospetto_diagnostico) }, { "Casi da Screening", Convert.ToString(finaltable.Item3[i].casi_da_screening) }, { "Totale Casi", Convert.ToString(finaltable.Item3[i].totale_casi) }, { "Tamponi", Convert.ToString(finaltable.Item3[i].tamponi) }, { "Casi Testati", Convert.ToString(finaltable.Item3[i].casi_testati) }, { "Note", Convert.ToString(finaltable.Item3[i].note) }, { "Ingressi Terapia Intensiva", Convert.ToString(finaltable.Item3[i].ingressi_terapia_intensiva) }, { "Note Test", Convert.ToString(finaltable.Item3[i].note_test) }, { "Note Casi", Convert.ToString(finaltable.Item3[i].note_casi) }, { "Totale Positivi Test Molecolare", Convert.ToString(finaltable.Item3[i].totale_positivi_test_molecolare) }, { "Totale Positivi Test Antigenico Rapido", Convert.ToString(finaltable.Item3[i].totale_positivi_test_antigenico_rapido) }, { "Tamponi Test Molecolare", Convert.ToString(finaltable.Item3[i].tamponi_test_molecolare) }, { "Tamponi Test Antigenico Rapido", Convert.ToString(finaltable.Item3[i].tamponi_test_antigenico_rapido) }, { "Codice Nuts 1", Convert.ToString(finaltable.Item3[i].codice_nuts_1) }, { "Codice Nuts 2", Convert.ToString(finaltable.Item3[i].codice_nuts_2) } };
                string transitvalueindex = Convert.ToString(finaltable.Item1[i].data);
                int first = transitvalueindex.IndexOf('T');
                int last = transitvalueindex.Count()-first;
                string valuetabindex = transitvalueindex.Remove(first, last);
                DateTime regulardate = Convert.ToDateTime(valuetabindex);
                tabControl2.TabPages.Add(regulardate.ToString("dd/MM/yyyy")); 
                tabControl2.SelectedIndex = j;
                TabPage tabPage = tabControl2.SelectedTab;
                tabPage.AutoScroll = true;
                for (int k = 0; k< (nationalenumerationarray.Length/2)-1; k++)
                {
                    Label Etnat = new Label();
                    Etnat.Location = new System.Drawing.Point(pointx, pointy);
                    Etnat.AutoSize = true;
                    Etnat.Text = nationalenumerationarray[k,0] + " " + nationalenumerationarray[k, 1];
                    tabPage.Controls.Add(Etnat);
                    pointy = pointy + 20;
                }
                pointx = 10;
                pointy = 20;
                j++;
            }
            //
            tabControl2.SelectedIndex = 0;
            TabPage tabPagecomplete = tabControl2.SelectedTab;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }
    }
}
