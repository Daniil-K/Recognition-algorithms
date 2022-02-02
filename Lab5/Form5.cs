using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form5 : Form
    {
        public static List<int> otn = new List<int>();
        string[] alph = new string[] { "A", "B", "C", "D" };
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.RowCount = Form4.vyh.ElementAt(Form4.vyh.Count - 1) + 1;
            this.tableLayoutPanel1.ColumnCount = Form2.grupp_int + 2;
            int str_vyv = 1;
            for (int i = Form4.vyh_p.Count - Form4.vyh.ElementAt(Form4.vyh.Count - 1); i < Form4.vyh_p.Count; i++)
            {
                Label par = new Label();
                par.Size = new Size(70, 30);
                par.Text = Form4.vyh_p[i];
                par.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel1.Controls.Add(par, 0, str_vyv);
                str_vyv++;
            }
            for (int j = 1; j < Form2.grupp_int + 1; j++)
            {
                Label par = new Label();
                par.Size = new Size(30, 30);
                par.Text = alph[j - 1];
                par.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel1.Controls.Add(par, j, 0);
            }
            for (int i = 0; i < str_vyv - 1; i++)
            {
                for (int j = 0; j < Form2.grupp_int; j++)
                {
                    int k = i * Form2.grupp_int + j;
                    Label dl = new Label();
                    dl.Size = new Size(30, 30);
                    dl.Text = Form4.tabl_end[k];
                    this.tableLayoutPanel1.Controls.Add(dl, (j + 1), (i + 1));
                }
            }
            for (int i = 0; i < Form2.grupp_int; i++)
            {
                int sch = 0;
                for (int j = i; j < Form4.tabl_end.Count; j += Form2.grupp_int)
                {
                    sch += Convert.ToInt32(Form4.tabl_end[j]) - 48;
                }
                otn.Add(sch);
            }
            int index = otn.LastIndexOf(otn.Max());
            Label dl_otn = new Label();
            dl_otn.Size = new Size(150, 30);
            dl_otn.Text = "Строка относится к " + alph[index] + " массиву";
            this.tableLayoutPanel1.Controls.Add(dl_otn, Form2.grupp_int + 2, 0);
        }
    }
}
