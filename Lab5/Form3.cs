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
    public partial class Form3 : Form
    {
        public static List<string> list_bul = new List<string>();
        public static List<string> list_bul_sr = new List<string>();
        int [] mas = new int[Form2.stolb_int];
        int[] mas_sr = new int[Form2.stolb_int];
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.RowCount = Form2.stroki_int + 1;
            this.tableLayoutPanel1.ColumnCount = Form2.stolb_int + 1;

            for (int i = 0; i < Form2.stolb_int; i++)
            {
                int zn;
                bool success = Int32.TryParse(Form2.list[i], out zn);
                if (success)
                {
                    mas[i] = 1;
                }
                else
                {
                    mas[i] = 0;
                }
            }

            for (int i = 0; i < Form2.stolb_int; i++)
            {
                int zn;
                bool success = Int32.TryParse(Form2.list_sr[i], out zn);
                if (success)
                {
                    mas_sr[i] = 1;
                }
                else
                {
                    mas_sr[i] = 0;
                }
            }

            for (int i = 0; i < Form2.stroki_int; i++)
            {
                for (int j = 0; j < Form2.stolb_int; j++)
                {
                    int k = i * Form2.stolb_int + j;
                    if (mas[j] == 1)
                    {
                        float count = 0;
                        for (int p = 0; p < Form2.stroki_int; p++)
                        {
                            int n = p * Form2.stolb_int + j;
                            count += Convert.ToInt32(Form2.list[n]);
                        }
                        count /= Form2.stroki_int;
                        int m = Convert.ToInt32(Form2.list[k]);
                        if (m >= count)
                        {
                            list_bul.Add("1");
                        }
                        else
                        {
                            list_bul.Add("0");
                        }
                    }
                    else
                    {
                        if (Form2.list[k] == Form2.list[j])
                        {
                            list_bul.Add("1");
                        }
                        else
                        {
                            list_bul.Add("0");
                        }
                    }
                }
            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < Form2.stolb_int; j++)
                {
                    int k = i * Form2.stolb_int + j;
                    if (mas[j] == 1)
                    {
                        float count = 0;
                        for (int p = 0; p < Form2.stroki_int; p++)
                        {
                            int n = p * Form2.stolb_int + j;
                            count += Convert.ToInt32(Form2.list[n]);
                        }
                        count /= Form2.stroki_int;
                        int m = Convert.ToInt32(Form2.list_sr[k]);
                        if (m >= count)
                        {
                            list_bul_sr.Add("1");
                        }
                        else
                        {
                            list_bul_sr.Add("0");
                        }
                    }
                    else
                    {
                        if (Form2.list_sr[k] == Form2.list[j])
                        {
                            list_bul_sr.Add("1");
                        }
                        else
                        {
                            list_bul_sr.Add("0");
                        }
                    }
                }
            }
            for (int i = 0; i < list_bul_sr.Count; i++)
                System.Console.Write(list_bul_sr[i] + " || ");
            System.Console.WriteLine();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Show();
            this.Hide();
        }

        private void бинарнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.Controls.Clear();
            for (int i = 1; i < Form2.stroki_int + 1; i++)
            {
                Label par = new Label();
                par.Size = new Size(30, 30);
                par.Text = Convert.ToString("a" + i);
                par.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel1.Controls.Add(par, 0, i);
            }
            for (int j = 1; j < Form2.stolb_int + 1; j++)
            {
                Label par = new Label();
                par.Size = new Size(30, 30);
                par.Text = Convert.ToString("x" + j);
                par.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel1.Controls.Add(par, j, 0);
            }
            for (int i = 0; i < Form2.stroki_int; i++)
            {
                for (int j = 0; j < Form2.stolb_int; j++)
                {
                    int k = i * Form2.stolb_int + j;
                    Label dl = new Label();
                    dl.Size = new Size(50, 20);
                    dl.Text = list_bul[k];
                    this.tableLayoutPanel1.Controls.Add(dl, (j + 1), (i + 1));
                }
            }
        }

        private void основнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.Controls.Clear();
            for (int i = 1; i < Form2.stroki_int + 1; i++)
            {
                Label par = new Label();
                par.Size = new Size(30, 30);
                par.Text = Convert.ToString("a" + i);
                par.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel1.Controls.Add(par, 0, i);
            }
            for (int j = 1; j < Form2.stolb_int + 1; j++)
            {
                Label par = new Label();
                par.Size = new Size(30, 30);
                par.Text = Convert.ToString("x" + j);
                par.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel1.Controls.Add(par, j, 0);
            }
            for (int i = 0; i < Form2.stroki_int; i++)
            {
                for (int j = 0; j < Form2.stolb_int; j++)
                {
                    int k = i * Form2.stolb_int + j;
                    Label dl = new Label();
                    dl.Size = new Size(50, 20);
                    dl.Text = Form2.list[k];
                    this.tableLayoutPanel1.Controls.Add(dl, (j + 1), (i + 1));
                }
            }
        }
    }
}
