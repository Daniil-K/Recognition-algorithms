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
    public partial class Form2 : Form
    {
        public static string stroki, stolb, grupp;
        public static int stroki_int, stolb_int, grupp_int;
        public static List<string> list = new List<string>();
        public static List<string> list_sr = new List<string>();
        public static List<int> str_grupp = new List<int>();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            stroki_int = Convert.ToInt32(stroki);
            stolb_int = Convert.ToInt32(stolb);
            grupp_int = Convert.ToInt32(grupp);
            for (int i = 0; i < stroki_int; i++)
            {
                Label p1 = new Label();
                p1.Size = new Size(70, 30);
                p1.Text = Convert.ToString((i + 1) + " строка:");
                p1.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel1.Controls.Add(p1, 0, i);
                TextBox dl = new TextBox();
                dl.Size = new Size(150, 30);
                dl.Text = "";
                this.tableLayoutPanel1.Controls.Add(dl, 1, i);
            }
            int num_grupp = 0;
            for (int i = stroki_int; i < grupp_int + stroki_int; i++)
            {
                Label p2 = new Label();
                p2.Size = new Size(150, 30);
                p2.Text = Convert.ToString("Кол-во строчек в " + (num_grupp + 1) + " группе:");
                p2.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel1.Controls.Add(p2, 0, i);
                TextBox d2 = new TextBox();
                d2.Size = new Size(50, 30);
                d2.Text = "";
                this.tableLayoutPanel1.Controls.Add(d2, 1, i);
                num_grupp++;
            }
            Label p2_sr = new Label();
            p2_sr.Size = new Size(150, 30);
            p2_sr.Text = Convert.ToString("Строка для сравнения: ");
            p2_sr.TextAlign = ContentAlignment.TopCenter;
            this.tableLayoutPanel1.Controls.Add(p2_sr, 0, grupp_int + stroki_int);
            TextBox d2_sr = new TextBox();
            d2_sr.Size = new Size(150, 30);
            d2_sr.Text = "";
            this.tableLayoutPanel1.Controls.Add(d2_sr, 1, grupp_int + stroki_int);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] cifry = new string[2];
            string[] b = new string[stolb_int];
            for (int i = 0; i < stroki_int; i++)
            {
                string a = this.tableLayoutPanel1.GetControlFromPosition(1, i).ToString();
                cifry = a.Split(':');
                cifry[1] = cifry[1].Remove(0, 1);
                b = cifry[1].Split(' ');
                b[0].Replace(" ", "");
                for (int j = 0; j < stolb_int; j++)
                    list.Add(b[j]);
            }
            for (int i = stroki_int; i < stroki_int + grupp_int; i++)
            {
                string a = this.tableLayoutPanel1.GetControlFromPosition(1, i).ToString();
                cifry = a.Split(':');
                cifry[1] = cifry[1].Remove(0, 1);
                a = cifry[1];
                str_grupp.Add(Convert.ToInt32(a));
            }
            string a_sr = this.tableLayoutPanel1.GetControlFromPosition(1, grupp_int + stroki_int).ToString();
            cifry = a_sr.Split(':');
            cifry[1] = cifry[1].Remove(0, 1);
            b = cifry[1].Split(' ');
            b[0].Replace(" ", "");
            for (int j = 0; j < stolb_int; j++)
                list_sr.Add(b[j]);
            Form3 newForm = new Form3();
            newForm.Show();
            this.Hide();
        }
    }
}
