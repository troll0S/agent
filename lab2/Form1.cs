using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicMathsNamespace;
using CalculationsNamesapce;
using UtilityNamespace;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            d_value.Items.AddRange(new object[] { "0,1", "0,01", "0,001", "0,0001" });
            d_value.SelectedIndex = 0;
        }


        private void a_value_TextChanged(object sender, EventArgs e)
        {

        }

        private void b_value_TextChanged(object sender, EventArgs e)
        {

        }

        private void n_value_TextChanged(object sender, EventArgs e)
        {

        }

        private void d_value_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (a_value.Text != "-" && a_value.Text != "" && 
                b_value.Text != "-" && b_value.Text != "" &&
                d_value.Text != "" && n_value.Text != ""  &&
                pk_Value.Text != "" && pn_Value.Text != "" )
                
            {

                
                double aValue, bValue, dValue,pkValue,pnValue;
                int nValue,tValue;
                bool elite;
                aValue = double.Parse(a_value.Text.Replace('.', ','));
                bValue = double.Parse(b_value.Text.Replace('.', ','));
                dValue = double.Parse(d_value.Text);
                nValue = int.Parse(n_value.Text);
                pkValue = double.Parse(pk_Value.Text.Replace('.', ','));
                pnValue = double.Parse(pn_Value.Text.Replace('.', ','));
                tValue = int.Parse(T_value.Text);
                if (elita_value.Checked) elite = true;
                else elite = false;
                if (aValue > bValue)
                {
                    
                    double temp = aValue;
                    aValue = bValue;
                    bValue = temp;
                    a_value.Text = aValue.ToString();
                    b_value.Text = bValue.ToString();
                }
                BasicMaths myFunc = new BasicMaths(aValue, bValue, dValue);
                //Calculations myCalc = new Calculations();
                DataTable table = new DataTable();
                table.Columns.Add("Lp.");
                table.Columns.Add("xreal");
                table.Columns.Add("xbin");
                table.Columns.Add("f(x)");
                table.Columns.Add("%");
                
                


                double[] xreal = new double[nValue]; 
                string[] xbin = new string[nValue];
                double[] funcx = new double[nValue]; 
                double[] funcgx = new double[nValue]; 
                double[] p = new double[nValue]; 
                double[] q = new double[nValue]; 
                double[] r = new double[nValue]; 
                double[] xrealselection = new double[nValue]; 
                string[] xbinselection = new string[nValue]; 
                bool[] parents = new bool[nValue]; 
                int[] pairs = new int[nValue];
                int[] pc = new int[nValue]; 
                string[] child = new string[nValue]; 
                string[] pokrzyzu = new string[nValue]; 
                string[] mutacje = new string[nValue]; 
                string[] xbinmutacja = new string[nValue]; 
                double[] xrealmutacja = new double[nValue]; 
                double[] funcx2 = new double[nValue];
                double[] maxVal = new double[2];
                double min;


                for (int i = 0; i < nValue; ++i)
                {
                    xreal[i] = myFunc.rand_xreal();
                }


                for (int t = 0; t < tValue; ++t)
                {




                    for (int i = 0; i < nValue; ++i)
                    {

                        funcx[i] = myFunc.func(xreal[i]);
                        xbin[i] = myFunc.calculate_xbin(myFunc.calculate_xint(xreal[i]));
                    }

                    maxVal[0] = myFunc.max_in_table(funcx);
                    maxVal[1] = xreal[Array.IndexOf(funcx, maxVal[0])];


                    min = myFunc.min_in_table(funcx);
                    for (int i = 0; i < nValue; ++i)
                    {
                        funcgx[i] = myFunc.func_gx_max(xreal[i], min);
                    }

                    for (int i = 0; i < nValue; ++i)
                    {
                        p[i] = Calculations.calculatep(funcgx[i], funcgx);
                        r[i] = Utility.myFate.NextDouble();
                    }
                    q[0] = p[0];
                    for (int i = 1; i < nValue; ++i)
                    {
                        q[i] = q[i - 1] + p[i];
                    }

                    for (int i = 0; i < nValue; ++i)
                    {

                        xrealselection[i] = xreal[Calculations.findindex(r[i], q)];
                        xbinselection[i] = myFunc.calculate_xbin(myFunc.calculate_xint(xrealselection[i]));
                        parents[i] = Calculations.isDrawn(pkValue);

                    }
                    int tmp = 0;
                    int pre = 0;
                    for (int i = 0; i < nValue; ++i)
                    {
                        if (parents[i])
                        {
                            if (tmp == 0)
                            {
                                pairs[i] = i;
                                tmp = 1;
                                pre = i;
                            }
                            else
                            {
                                pairs[i] = i;
                                tmp = 0;
                                Utility.Swap(ref pairs[i], ref pairs[pre]);
                                pc[i] = pc[pre] = Utility.myFate.Next(1, myFunc.getL());
                                pre = 0;

                            }
                        }
                    }
                    for (int i = 0; i < nValue; ++i)
                    {
                        if (parents[i])
                        {
                            child[i] = xbinselection[i];
                            child[pairs[i]] = xbinselection[pairs[i]];
                            myFunc.childs(pc[i], ref child[i], ref child[pairs[i]]);
                            i = pairs[i];
                        }
                    }

                    for (int i = 0; i < nValue; ++i)
                    {
                        if (parents[i])
                        {
                            pokrzyzu[i] = child[i];
                        }
                        else
                        {
                            pokrzyzu[i] = xbinselection[i];
                        }
                    }

                    for (int i = 0; i < nValue; ++i)
                    {
                        xbinmutacja[i] = pokrzyzu[i];
                        for (int j = 0; j < pokrzyzu[i].Length; ++j)
                        {

                            if (Calculations.isDrawn(pnValue))
                            {
                                mutacje[i] += (j + 1).ToString() + " ";
                                xbinmutacja[i] = Utility.Swapbit(xbinmutacja[i], j);
                            }
                        }
                        xrealmutacja[i] = myFunc.calculate_xreal(myFunc.calculate_xint_bin(xbinmutacja[i]));
                        funcx2[i] = myFunc.func(xrealmutacja[i]);
                    }

                    if (elite)
                    {
                        int temp_index = Utility.myFate.Next(nValue);
                        if (maxVal[0] > funcx2[temp_index])
                        {
                            xrealmutacja[temp_index] = maxVal[1];
                            funcx2[temp_index] = maxVal[0];
                        }
                    }
                    for(int i = 0; i < nValue; ++i)
                    {
                        xreal[i] = xrealmutacja[i];
                    }


                }
                Dictionary<double,int> results = new Dictionary<double,int>();
                foreach( double value in xreal)
                {
                    if (results.ContainsKey(value))
                    {
                        results[value]++;
                    }
                    else
                    {
                        results[value] = 1;
                    }
                }
                var sortedResult = results.OrderByDescending(pair => pair.Value).ToList();
                int count = 0;
                foreach(var pair in sortedResult)
                {
                    DataRow row = table.NewRow();
                    row[0] = count + 1;
                    row[1] = pair.Key;
                    row[2] = myFunc.calculate_xbin(myFunc.calculate_xint(pair.Key));
                    row[3] = myFunc.func(pair.Key);
                    row[4] = pair.Value*100/nValue;
                    table.Rows.Add(row);
                    ++count;
                }
                 
                    
                

                    dataGridView1.DataSource = table;
            }
        }

        private void displayBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void a_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = (sender as TextBox).Text;
            int position = (sender as TextBox).SelectionStart;

            //blokowanie znaku '-' w innym miejscu niż na początku
            if(position != 0 && e.KeyChar == '-')
            {
                e.Handled = true;
                return;
            }
            // przecinek lub kropka jako pierwszy znak
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (position == 0 || !char.IsDigit(text[position - 1])))
            {
                e.Handled = true;
                return;
            }
            //zablokowanie wielu znaków ',' lub '.'
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (text.IndexOf(',') != -1 || text.IndexOf('.') != -1))
            {
                e.Handled = true;
                return; 
            }
            //dozwolone znaki tylko ',' '.' '-' i cyfry
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }

        }

        private void b_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = (sender as TextBox).Text;
            int position = (sender as TextBox).SelectionStart;

            //blokowanie znaku '-' w innym miejscu niż na początku
            if (position != 0 && e.KeyChar == '-')
            {
                e.Handled = true;
                return;
            }
            // przecinek lub kropka jako pierwszy znak
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (position == 0 || !char.IsDigit(text[position - 1])))
            {
                e.Handled = true;
            }

            //zablokowanie wielu znaków ',' lub '.'
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (text.IndexOf(',') != -1 || text.IndexOf('.') != -1))
            {
                e.Handled = true;
                return;
            }
            //dozwolone znaki tylko ',' '.' '-' i cyfry
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }
        }

        private void n_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Akceptuj tylko cyfry oraz klawisz Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Blokuje niepoprawne znaki
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pkValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = (sender as TextBox).Text;
            int position = (sender as TextBox).SelectionStart;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (position == 0 || !char.IsDigit(text[position - 1])))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && (text.IndexOf(',') != -1 || text.IndexOf('.') != -1))
            {
                e.Handled = true;
                return;
            }
            //dozwolone znaki tylko ',' '.'  i cyfry
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }
        }

        private void pnValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = (sender as TextBox).Text;
            int position = (sender as TextBox).SelectionStart;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (position == 0 || !char.IsDigit(text[position - 1])))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && (text.IndexOf(',') != -1 || text.IndexOf('.') != -1))
            {
                e.Handled = true;
                return;
            }
            //dozwolone znaki tylko ',' '.'  i cyfry
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void T_value_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void T_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Blokuje niepoprawne znaki
            }
        }


        private void wykresButton_Click(object sender, EventArgs e)
        {
            
        }


        private void testyButon_Click(object sender, EventArgs e)
        {

        }

        private void wykresPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
