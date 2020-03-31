using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LitzGrafica
{
    public partial class CambiarEscala : Form
    {
        System.Windows.Forms.DataVisualization.Charting.Chart actual;

        public CambiarEscala(object sender)
        {
            InitializeComponent();
            actual = (System.Windows.Forms.DataVisualization.Charting.Chart)sender;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            actual.ChartAreas[0].AxisX.Minimum = Double.Parse(desdeX.Text);
            actual.ChartAreas[0].AxisX.Maximum = Double.Parse(hastaX.Text);
            actual.ChartAreas[0].AxisY.Minimum = Double.Parse(desdeY.Text);
            actual.ChartAreas[0].AxisY.Maximum = Double.Parse(hastaY.Text);

            for(int i = 0; i < actual.Series.Count; i++)
            {
                actual.Series[i].Enabled = chkCurvas.GetItemChecked(i);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
        private void CambiarEscala_Load(object sender, EventArgs e)
        {
            desdeX.Text = actual.ChartAreas[0].AxisX.Minimum.ToString();
            hastaX.Text = actual.ChartAreas[0].AxisX.Maximum.ToString();
            desdeY.Text = actual.ChartAreas[0].AxisY.Minimum.ToString();
            hastaY.Text = actual.ChartAreas[0].AxisY.Maximum.ToString();

            for(int i = 0; i < actual.Series.Count; i++)
            {
                int a = chkCurvas.Items.Add(actual.Series[i].Name);
                chkCurvas.SetItemChecked(a, true);
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
