using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NavegadorWeb
{
    public partial class Form1 : Form
    {
        String ruta = "C:\\Users\\diego\\Documents\\Meso\\3er Semestre\\Progra III\\Archivo2.txt";
        public Form1()
        {
            InitializeComponent();
        }
        private void Guardar(String nombreArchivo, String texto)
        {
            FileStream stream = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);
            writer.Close();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            Guardar(ruta, comboBox1.Text);
            
            String p1 = "https://www";
            String p2 = ".com";
            bool a = comboBox1.Text.Contains(p1);
            bool b = comboBox1.Text.Contains(p2);
            if (a && b) 
            {
                webBrowser1.Navigate(new Uri(comboBox1.Text.ToString()));
            }
            if (a == true || b == true)
            {
                string[] charsToRemove = new string[] { "https://" };
                foreach (var c in charsToRemove)
                {
                    comboBox1.Text = comboBox1.Text.Replace(c, string.Empty);
                }
                webBrowser1.Navigate(new Uri("https://" + comboBox1.Text.ToString()));
                comboBox1.Text = "https://" + comboBox1.Text;
            }
            if (a == false && b == false)
            {
                webBrowser1.Navigate(new Uri("http://www.google.com/search?q=" + comboBox1.Text.ToString()));
            }
            String nombreArchivo = ruta;
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            comboBox1.Items.Clear();

            while (reader.Peek() > -1)
            {
                string texto = reader.ReadLine();
                comboBox1.Items.Add(texto);
            }
            reader.Close();

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void goForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String nombreArchivo = ruta;
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            comboBox1.Items.Clear();

            while (reader.Peek() > -1)
            {
                string texto = reader.ReadLine();
                comboBox1.Items.Add(texto);
            }
            reader.Close();
        }
    }
}
