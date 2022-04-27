using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoiPoi.BLL;
using PoiPoi.DTO;

namespace PoiPoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxLopSH.Items.Add(new CBBItem
            {
                Value = 0,
                Text = "All"
            });
            comboBoxLopSH.Items.AddRange(BLLQLSV.Instance.GetAllCBB().ToArray());
            comboBoxLopSH.SelectedIndex=0;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            int id = ((CBBItem) comboBoxLopSH.SelectedItem).Value;
            dataGridView1.DataSource = BLLQLSV.Instance.GetSVByLopSH(id);
        }
    }
}
