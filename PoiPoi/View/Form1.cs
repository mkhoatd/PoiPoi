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
using PoiPoi.DAL;
using PoiPoi.DTO;
using PoiPoi.View;

namespace PoiPoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //them item combo box mac dinh
            comboBoxLopSH.Items.Add(new CBBItem
            {
                Value = 0,
                Text = "All"
            });
            //them cac lop vao combo box
            comboBoxLopSH.Items.AddRange(BLLQLSV.Instance.GetAllLopSHAsCBBItem().ToArray());
            comboBoxLopSH.SelectedIndex=0;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            int id = ((CBBItem) comboBoxLopSH.SelectedItem).Value;
            dataGridView1.DataSource = BLLQLSV.Instance.GetSVByLopSH(id);
        }

        private void Reload(int id, string name)
        {
            dataGridView1.DataSource = BLLQLSV.Instance.GetAllSV();
            if (id == 0 && name != "")
            {
                dataGridView1.DataSource = BLLQLSV.Instance.GetAllSV().Where(s=>s.Name.Contains(name));
            }

            if (id != 0 && name == "")
            {
                dataGridView1.DataSource = BLLQLSV.Instance.GetAllSV().Where(s => s.ID_Lop == id);
            }

            if (id != 0 && name != "")
            {
                dataGridView1.DataSource = BLLQLSV.Instance.GetAllSV().Where(s => s.ID_Lop == id).Where(s => s.Name.Contains(name)).ToList();

            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2("");
            f.d = Reload;
            f.Show();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string mssv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Form2 f = new Form2(mssv);
                f.d = Reload;
                f.Show();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                string mssv = r.Cells[0].Value.ToString();
                BLLQLSV.Instance.Del(mssv);
            }
            Reload(0,"");
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int id = ((CBBItem) comboBoxLopSH.SelectedItem).Value;
            string name = textBoxSearch.Text;
            if (!String.IsNullOrEmpty(name))
            {
                Reload(id,name);
            }
        }
    }
}
