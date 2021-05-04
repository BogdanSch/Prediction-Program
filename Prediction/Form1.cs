using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Training
{
    public partial class Form1 : Form
    {
        private string[] predictions = new string[14];
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadPredictions(StreamReader reader)
        {
            for (int i = 0; i < predictions.Length; i++)
            {
                predictions[i] = reader.ReadLine();
            }
            reader.Close();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i <= 100; i++)
            {
                pBV.Value = i;
                Thread.Sleep(10);
            }
            MakePrediction();

        }

        private void MakePrediction()
        {
            string pred = GetPrediction();
            MessageBox.Show(pred, "Предсказание");
        }

        private string GetPrediction()
        {
            StreamReader reader = new StreamReader("Examples.txt");

            ReadPredictions(reader);

            int whatElement = rnd.Next(0, predictions.Length - 1);

            return predictions[whatElement];
        }
    }
}
