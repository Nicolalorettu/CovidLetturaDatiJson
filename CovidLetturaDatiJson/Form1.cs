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
    public partial class Form1 : Form
    {
        static string[] filelist = new string[3];
        static int i = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public void Outputmessage(string message)
        {
            MessageBox.Show(message,"ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox1.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.AllowDrop = true;
            richTextBox1.DragDrop += RichTextBox1_DragDrop;
            richTextBox1.KeyDown += new KeyEventHandler(rtb_KeyDown);
        }

        private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var filenames =data as string[];
                if (filenames.Length > 0)
                {
                    try
                    {
                        filelist[i] = filenames[0];
                        i = i + 1;
                        richTextBox1.SelectedText = (filenames[0] + " \n");
                    }
                    catch 
                    {
                        MessageBox.Show("Troppi file inseriti, ricomincia!", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        richTextBox1.Clear();
                        i = 0;
                    }

                }

            }
        }

        void rtb_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Deserialize ds = new Deserialize();
            Tuple<List<AndamentoNazionale>, List<AndamentoProvince>, List<AndamentoRegioni>> tabella = ds.Deserializzatore(filelist);
            if (tabella.Item1.Count != 0 || tabella.Item2.Count != 0 || tabella.Item3.Count == 0)
            {
                Visualizzatore vis = new Visualizzatore(tabella);
                this.Hide();
                vis.ShowDialog();
            }
        }
    }
}
