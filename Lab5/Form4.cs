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
    public partial class Form4 : Form
    {
        public static List<int> apm = new List<int>();
        public static List<int> apm_vyh = new List<int>();
        public static List<int> vyh = new List<int>();
        public static List<string> vyh_p = new List<string>();
        public static List<string> vyh_end = new List<string>();
        public static List<string> tabl_end = new List<string>();
        int srav = 0;
        int ost_str = 0;
        string[] mas_konec = new string[500];
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form2.grupp_int; i++)
            {
                for (int j = i + 1; j < Form2.grupp_int; j++)
                {
                    srav += Form2.str_grupp[i] * Form2.str_grupp[j];
                }
            }
            int sch_apm = 0;
            int count = Form2.str_grupp[sch_apm];
            do
            {
                for(int i = 0; i < Form2.stroki_int; i++)
                {
                    for (int j = i + count; j < Form2.stroki_int; j++)
                    {
                        for (int k = 0; k < Form2.stolb_int; k++)
                        {
                            int m = i * Form2.stolb_int + k; 
                            int n = j * Form2.stolb_int + k;
                            if (Form3.list_bul[m] != Form3.list_bul[n])
                            {
                                apm.Add(1);
                            }
                            else
                            {
                                apm.Add(0);
                            }
                        }
                    }
                    count -= 1;
                    if (count == 0)
                    {
                        sch_apm++;
                        if (sch_apm == Form2.grupp_int - 1)
                            break;
                        count = Form2.str_grupp[sch_apm];
                    }
                }
            }
            while (sch_apm != Form2.grupp_int - 1);

            this.tableLayoutPanel1.RowCount = Form2.stroki_int + 1;
            this.tableLayoutPanel1.ColumnCount = Form2.stolb_int + 1;
            for (int i = 1; i < srav + 1; i++)
            {
                Label par = new Label();
                par.Size = new Size(30, 30);
                par.Text = Convert.ToString("S" + i);
                par.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel1.Controls.Add(par, 0, i);
            }
            for (int j = 1; j < Form2.stolb_int + 1; j++)
            {
                Label par = new Label();
                par.Size = new Size(30, 30);
                par.Text = Convert.ToString("p" + j);
                par.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel1.Controls.Add(par, j, 0);
            }
            for (int i = 0; i < srav; i++)
            {
                for (int j = 0; j < Form2.stolb_int; j++)
                {
                    int k = i * Form2.stolb_int + j;
                    Label dl = new Label();
                    dl.Size = new Size(50, 20);
                    dl.Text = apm[k].ToString();
                    this.tableLayoutPanel1.Controls.Add(dl, (j + 1), (i + 1));
                }
            }

            apm_vyh = apm;

            int[] ed_apm = new int[srav];
            for (int i = 0; i < srav; i++)
            {
                int count_ed = 0;
                for (int j = 0; j < Form2.stolb_int; j++)
                {
                    int k = i * Form2.stolb_int + j;
                    if (apm[k] == 1)
                        count_ed++;
                }
                ed_apm[i] = count_ed;
            }

            for (int i = 0; i < srav; i++)
            {
                for (int j = 0; j < srav; j++)
                {
                    if (i == j)
                        continue;
                    int count_sr = 0;
                    for (int k = 0; k < Form2.stolb_int; k++)
                    {
                        int m = i * Form2.stolb_int + k;
                        int n = j * Form2.stolb_int + k;
                        if (apm_vyh[m] == 1 && apm_vyh[n] == 1)
                        {
                            count_sr++;
                            if (ed_apm[i] <= ed_apm[j])
                            {
                                if (count_sr == ed_apm[i])
                                {
                                    for(int x = 0; x < Form2.stolb_int; x++)
                                    {
                                        int x1 = j * Form2.stolb_int + x;
                                        apm_vyh[x1] = 9;
                                    }
                                }
                            }
                            else
                            {
                                if (count_sr == ed_apm[j])
                                {
                                    for (int x = 0; x < Form2.stolb_int; x++)
                                    {
                                        int x1 = i * Form2.stolb_int + x;
                                        apm_vyh[x1] = 9;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < srav; i++)
            {
                for (int j = 0; j < Form2.stolb_int; j++)
                {
                    int k = i * Form2.stolb_int + j;
                    if (apm_vyh[k] == 9)
                    {
                        vyh.Add(i + 1);
                        break;
                    }
                }
            }
            apm_vyh.RemoveAll(item => item == 9);

            this.tableLayoutPanel2.RowCount = Form2.stroki_int + 1;
            this.tableLayoutPanel2.ColumnCount = Form2.stolb_int + 1;

            for (int i = 1; i < srav - vyh.Count + 1; i++)
            {
                Label par = new Label();
                par.Size = new Size(30, 30);
                par.Text = Convert.ToString("S" + i);
                par.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel2.Controls.Add(par, 0, i);
            }
            for (int j = 1; j < Form2.stolb_int + 1; j++)
            {
                Label par = new Label();
                par.Size = new Size(30, 30);
                par.Text = Convert.ToString("p" + j);
                par.TextAlign = ContentAlignment.TopCenter;
                this.tableLayoutPanel2.Controls.Add(par, j, 0);
            }
            for (int i = 0; i < srav - vyh.Count; i++)
            {
                for (int j = 0; j < Form2.stolb_int; j++)
                {
                    int k = i * Form2.stolb_int + j;
                    Label dl = new Label();
                    dl.Size = new Size(50, 20);
                    dl.Text = apm_vyh[k].ToString();
                    this.tableLayoutPanel2.Controls.Add(dl, (j + 1), (i + 1));
                }
            }
            int q = 0;
            for (int i = srav; i < srav + vyh.Count; i++)
            {
                Label dl = new Label();
                dl.Size = new Size(50, 20);
                dl.Text = ("Del " + vyh[q].ToString() + " str").ToString();
                this.tableLayoutPanel2.Controls.Add(dl, 0, (i + 1));
                q++;
            }
            ost_str = srav - vyh.Count;

        }

        private void уравненияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.Controls.Clear();
            vyh.Clear();
            System.Console.WriteLine("DL list: " + apm_vyh.Count);
            string txt = "";
            for (int i = 0; i < ost_str; i++)
            {
                int q = 0;
                txt = "";
                txt += ((i+1) + " str: (  ").ToString();
                for (int j = 0; j < Form2.stolb_int; j++)
                {
                    int k = i * Form2.stolb_int + j;
                    if (q == 0)
                    {
                        if (apm_vyh[k] == 1)
                        {
                            txt += ("P" + (j + 1)).ToString();
                            vyh_p.Add(("P" + (j + 1)).ToString());
                            vyh_end.Add(("P" + (j + 1)).ToString());
                            q++;
                        }
                    }
                    else
                    {
                        if (apm_vyh[k] == 1)
                        {
                            txt += (" v P" + (j + 1)).ToString();
                            vyh_p.Add(("P" + (j + 1)).ToString());
                            vyh_end.Add(("P" + (j + 1)).ToString());
                            q++;
                        }
                    }                    
                }
                vyh.Add(q);
                txt += " )";
                Label dl = new Label();
                dl.Size = new Size(450, 20);
                dl.Text = txt;
                this.tableLayoutPanel1.Controls.Add(dl, 0, i);
            }

            int count = 0;
            //int x = 0;
            for (int i = 0; i < ost_str - 1; i++)
            {
                int z = vyh.ElementAt(i);
                int z_last = vyh.ElementAt(vyh.Count - 1);
                int x = 0;
                txt = "";
                int n1 = vyh_p.Count - z_last - 1;
                for (int j = 0; j < z; j++)
                {
                    int n = n1;
                    for (int k = 0; k < z_last; k++)
                    {
                        n++;
                        if (vyh_end.ElementAt(count) == vyh_p.ElementAt(n))
                        {
                            vyh_p.Add(vyh_end.ElementAt(count));
                            x++;
                        }
                        else
                        {
                            vyh_p.Add(vyh_end.ElementAt(count) + vyh_p.ElementAt(n));
                            x++;
                        }
                    }
                    count++;
                }
                vyh.Add(x);
                int pred1 = vyh_p.Count;
                int[] udal1 = new int[x];
                int sch1 = 0;
                for (int c = pred1 - vyh.ElementAt(vyh.Count - 1); c < pred1; c++)
                {
                    string str_r = vyh_p.ElementAt(c);
                    for (int l = 1; l < str_r.Length - 2; l += 2)
                    {
                        for (int cl = l + 2; cl < str_r.Length; cl += 2)
                        {
                            if (str_r[l] == str_r[cl])
                            {
                                str_r = str_r.Remove(cl - 1, 2);
                                cl -= 2;

                            }
                            if (Convert.ToInt32(str_r[l]) > Convert.ToInt32(str_r[cl]))
                            {
                                char tmp = str_r[l];
                                char tmp1 = str_r[cl];
                                str_r = str_r.Replace(tmp, '0').Replace(tmp1, tmp).Replace('0', tmp1);
                            }
                        }
                    }
                    vyh_p[c] = str_r;
                }
                for (int c = pred1 - vyh.ElementAt(vyh.Count - 1); c < pred1; c++)
                {
                    udal1[sch1] = vyh_p[c].Length;
                    sch1++;
                }
                int kol_vo_min = 0;
                for (int c = 0; c < udal1.Length; c++)
                {
                    if (udal1[c] == udal1.Min())
                    {
                        kol_vo_min++;
                    }
                }
                int[] mas_index = new int[kol_vo_min + 1];
                int pp = 0;
                for (int c = 0; c < udal1.Length; c++)
                {
                    if (udal1[c] == udal1.Min())
                    {
                        int indexMin1 = pred1 - vyh.ElementAt(vyh.Count - 1) + c;
                        mas_index[pp] = indexMin1;
                        pp++;
                    }
                    if (c == kol_vo_min)
                    {
                        mas_index[pp] = 0;
                    }
                }
                for (int c = 0; c < mas_index.Length - 1; c++)
                {
                    for (int cc = c + 1; cc < mas_index.Length; cc++)
                    {
                        if (vyh_p[mas_index[c]] == vyh_p[mas_index[cc]])
                        {
                            List <int> tmp = mas_index.ToList();
                            tmp.RemoveAt(cc);
                            kol_vo_min--;
                            mas_index = tmp.ToArray();
                        }
                    }
                }
                x = vyh.ElementAt(vyh.Count - 1);
                sch1 = 0; // Кол-во удаляемых
                int sch11 = 0; // Кол-во элементов меньше следующего минимального
                int dob_el = 0; // Кол-во добавляемых
                int[] mas_udal = new int[vyh_p.Count];
                pred1 = vyh_p.Count;
                int dob_el_all = 0;
                int sch1_all = 0;
                int vnos = 0;
                for (int cc = 0; cc < kol_vo_min; cc++)
                {
                    vnos = 1;
                    int pk = cc;
                    if (sch1 == 0 || sch1 == 1)
                        pk = 0;
                    int indexMin1 = mas_index[cc] - sch11;/* sch1_all + dob_el_all - pk;*/
                    int indexMin2 = mas_index[cc + 1] - sch1_all; /*+ dob_el_all - pk;*/
                    vyh_p.Add(vyh_p.ElementAt(indexMin1));
                    sch1 = 0;
                    sch11 = 0;
                    int sch_sovp = 0;
                    dob_el = 0;
                    int schet = 0;
                    for (int c = pred1 - vyh.ElementAt(vyh.Count - 1); c < pred1; c++)
                    {
                        sch_sovp = 0;
                        int klv = vyh_p[indexMin1].Length / 2;
                        string prov_str = vyh_p[indexMin1];
                        if ((vyh_p[c] == vyh_p[indexMin1]) && (schet == 0))
                        {
                            schet++;
                            continue;
                        }
                        for (int l = 1; l < prov_str.Length; l += 2)
                        {
                            if (vyh_p[c].Contains(prov_str[l]))
                            {
                                sch_sovp++;
                            }
                        }
                        if (klv == sch_sovp)
                        {
                            x--;
                            mas_udal[sch1] = c;
                            sch1++;
                            if (c < indexMin2)
                                sch11++;
                        }
                        else
                        {
                            vyh_p.Add(vyh_p[c]);
                            dob_el++;
                            vnos++;
                        }
                    }
                    for (int qq = 0; qq < sch1; qq++)
                    {
                        vyh_p.RemoveAt(mas_udal[qq] - qq);

                    }
                    sch1_all += x - sch1;
                    vyh.Add(x);
                    pred1 = vyh_p.Count;
                }
                vyh.Add(x);
            }

            /*------------Последнее сравнение-------------------*/
            int pred_kon = vyh_p.Count;
            int sch_kon = 0;
            int[] udal_kon = new int[vyh.ElementAt(vyh.Count - 1)];
            for (int c = pred_kon - vyh.ElementAt(vyh.Count - 1); c < pred_kon; c++)
            {
                udal_kon[sch_kon] = vyh_p[c].Length;
                sch_kon++;
            }
            int kol_vo_min_kon = 0;
            for (int c = 0; c < sch_kon; c++)
            {
                if (udal_kon[c] < udal_kon.Max())
                {
                    kol_vo_min_kon++;
                }
            }
            int[] mas_index_kon = new int[kol_vo_min_kon + 1];
            int pp_kon = 0;
            for (int c = 0; c < udal_kon.Length; c++)
            {
                if (udal_kon[c] < udal_kon.Max())
                {
                    int indexMin1 = pred_kon - vyh.ElementAt(vyh.Count - 1) + c;
                    mas_index_kon[pp_kon] = indexMin1;
                    pp_kon++;
                }
                if (c == kol_vo_min_kon)
                {
                    mas_index_kon[pp_kon] = 0;
                }
            }
            for (int c = 0; c < mas_index_kon.Length - 1; c++)
            {
                for (int cc = c + 1; cc < mas_index_kon.Length; cc++)
                {
                    if (vyh_p[mas_index_kon[c]] == vyh_p[mas_index_kon[cc]])
                    {
                        List<int> tmp = mas_index_kon.ToList();
                        tmp.RemoveAt(cc);
                        kol_vo_min_kon--;
                        mas_index_kon = tmp.ToArray();
                    }
                }
            }
            int x_kon = vyh.ElementAt(vyh.Count - 1);
            int sch1_kon = 0; // Кол-во удаляемых
            int sch11_kon = 0; // Кол-во элементов меньше следующего минимального
            int dob_el_kon = 0; // Кол-во добавляемых
            int[] mas_udal_kon = new int[vyh_p.Count];
            int pred1_kon = vyh_p.Count;
            int dob_el_all_kon = 0;
            int sch1_all_kon = 0;
            int vnos_kon = 0;
            for (int cc = 0; cc < kol_vo_min_kon; cc++)
            {
                vnos_kon = 1;
                int indexMin1 = mas_index_kon[cc] - sch11_kon;
                int indexMin2 = mas_index_kon[cc + 1] - sch1_all_kon;
                vyh_p.Add(vyh_p.ElementAt(indexMin1));
                sch1_kon = 0;
                sch11_kon = 0;
                int sch_sovp = 0;
                dob_el_kon = 0;
                int schet = 0;
                for (int c = pred1_kon - vyh.ElementAt(vyh.Count - 1); c < pred1_kon; c++)
                {
                    sch_sovp = 0;
                    int klv = vyh_p[indexMin1].Length / 2;
                    string prov_str = vyh_p[indexMin1];
                    if ((vyh_p[c] == vyh_p[indexMin1]) && (schet == 0))
                    {
                        schet++;
                        continue;
                    }
                    for (int l = 1; l < prov_str.Length; l += 2)
                    {
                        if (vyh_p[c].Contains(prov_str[l]))
                        {
                            sch_sovp++;
                        }
                    }
                    if (klv == sch_sovp)
                    {
                        x_kon--;
                        mas_udal_kon[sch1_kon] = c;
                        sch1_kon++;
                        if (c < indexMin2)
                            sch11_kon++;
                    }
                    else
                    {
                        vyh_p.Add(vyh_p[c]);
                        dob_el_kon++;
                        vnos_kon++;
                    }
                }
                for (int qq = 0; qq < sch1_kon; qq++)
                {
                    vyh_p.RemoveAt(mas_udal_kon[qq] - qq);

                }
                sch1_all_kon += x_kon - sch1_kon;
                vyh.Add(x_kon);
                pred1_kon = vyh_p.Count;
            }
            vyh.Add(x_kon);

            /****************************************************/



            int pred_1 = vyh_p.Count;
            txt = "";
            //int p = 0;
            /*for (int i = pred_1 - vyh.ElementAt(vyh.Count - 1); i < pred_1; i++)
            {
                if (p == 0)
                {
                    txt += vyh_p[i];
                }
                else
                {
                    txt += " v " + vyh_p[i];
                }
                p++;
            }
            Label dl_v = new Label();
            dl_v.Size = new Size(450, 20);
            dl_v.Text = txt;
            this.tableLayoutPanel1.Controls.Add(dl_v, 0, srav);*/

            for (int i = 1; i < Form2.stolb_int + 1; i++)
            {
                int count_r = 0;
                for (int j = pred_1 - vyh.ElementAt(vyh.Count - 1); j < pred_1; j++)
                {
                    string str_r = vyh_p.ElementAt(j);
                    for (int k = 1; k < str_r.Length; k += 2)
                    {
                        if ((Convert.ToInt32(str_r[k]) - 48) == i)
                            count_r++;
                    }
                }
                txt = ("R(" + i + ") = " + count_r + "/" + vyh.ElementAt(vyh.Count - 1)).ToString();
                Label dl = new Label();
                dl.Size = new Size(450, 20);
                dl.Text = txt;
                this.tableLayoutPanel1.Controls.Add(dl, 0, srav + i);
            }

            for (int j = vyh_p.Count - vyh.ElementAt(vyh.Count - 1); j < vyh_p.Count; j++) //Элемент выходной таблицы (иксы)
            {
                string str_sr = vyh_p[j]; //Строка из выходной таблицы
                int neob_kol = str_sr.Length / 2; // Необходимое количество совпадений для каждой строки P
                System.Console.Write("Str: " + vyh_p[j]);
                int str_vhod = 0;
                for (int k = 0; k < Form2.grupp_int; k++) //Количество групп
                {
                    int sovp_gr = 0; // Совпадения в группе
                    for (int kk = 0; kk < Form2.str_grupp[k]; kk++) //Для каждой строки в группе
                    {
                        int kol_sovp = 0; // Количество совпадений для каждой строки
                        for (int kkk = 1; kkk < vyh_p[j].Length; kkk += 2) //Каждый элемент в строке
                        {
                            int el = (Convert.ToInt32(str_sr[kkk])) - 49; // Индекс строки сравнения
                            int index_el_str = str_vhod * Form2.stolb_int + el; //Индекс строки массива
                            if (Form3.list_bul_sr[el] == Form3.list_bul[index_el_str])
                            {
                                kol_sovp++; // Количество совпадений в строке
                            }
                        }
                        if (kol_sovp == neob_kol) // 
                            sovp_gr++;
                        str_vhod++;
                    }
                    System.Console.Write(" || " + sovp_gr);
                    tabl_end.Add(sovp_gr.ToString());
                }
                System.Console.WriteLine();
            }
            Form5 newForm = new Form5();
            newForm.Show();
        }
    }
}
