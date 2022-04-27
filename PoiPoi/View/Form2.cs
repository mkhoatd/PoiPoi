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


namespace PoiPoi.View
{
    public partial class Form2 : Form
    {
        public Form2(string m)
        {
            InitializeComponent();
            MSSV = m;
            update = BLLQLSV.Instance.Check(MSSV);
            GUI();
        }
        public Action<int, string> d;
        private bool update;
        private string MSSV;
        public void GUI()
        {
            comboBoxLopSH.Items.AddRange(BLLQLSV.Instance.GetAllLopSHAsCBBItem().ToArray());
            if (update == true)
            {
                textBoxMSSV.Text = MSSV;
                textBoxMSSV.Enabled = false;
                SV selectedSV = BLLQLSV.Instance.GetAllSV().FirstOrDefault(s => s.MSSV == MSSV);
                LopSH selectedLopSH = BLLQLSV.Instance.GetAllLopSH().FirstOrDefault(l => l.ID_Lop == selectedSV.ID_Lop);
                var A = new CBBItem
                {
                    Value = selectedLopSH.ID_Lop,
                    Text = selectedLopSH.NameLop
                };
                comboBoxLopSH.SelectedItem = A;
                textBoxName.Text = selectedSV.Name;
                textBoxDTB.Text = selectedSV.DTB.ToString();
                radioFemale.Checked = true;
                dateTimePicker1.Value = selectedSV.NS;
                radioMale.Checked = selectedSV.Gender ? true : false;
                checkBoxAnh.Checked = selectedSV.Anh ? true : false;
                checkBoxHB.Checked = selectedSV.HocBa ? true : false;
                checkBoxCCCD.Checked = selectedSV.CMND ? true : false;
            }
            else textBoxMSSV.Enabled = true;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            SV s = new SV
            {
                MSSV=textBoxMSSV.Text,
                Name=textBoxName.Text,
                ID_Lop = ((CBBItem)comboBoxLopSH.SelectedItem).Value,
                DTB = Convert.ToDouble(textBoxDTB.Text),
                NS=dateTimePicker1.Value,
                Gender=radioMale.Checked?true:false,
                Anh=checkBoxAnh.Checked?true:false,
                HocBa = checkBoxHB.Checked?true:false,
                CMND = checkBoxCCCD.Checked?true:false
            };
            BLLQLSV.Instance.AddOrUpdate(s);
            d(0, "");
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
