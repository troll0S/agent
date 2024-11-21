using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BasicMathsNamespace;
using CalculationsNamesapce;
using UtilityNamespace;
using PokolenieNamespace;

namespace lab1
{
    public partial class Form1 : Form
    {
        
        private Pokolenie[] pokolenies;
        private BasicMaths myFunc;
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
                pk_Value.Text != "" && pn_Value.Text != "" &&
                T_value.Text != "")
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


                myFunc = new BasicMaths(aValue, bValue, dValue);
                //Calculations myCalc = new Calculations();



                pokolenies = Utility.CalcPokolenies(pkValue, pnValue,elite,tValue,nValue,myFunc);
                
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
            if (pokolenies == null || pokolenies.Length == 0)
            {
                MessageBox.Show("Brak danych do wyświetlenia. Najpierw wykonaj obliczenia.");
                return;
            }
            Form chartDialog = new Form
            {
                Text = "Wykres",
                Width = 800,
                Height = 600
            };

            Chart chart = new Chart
            {
                Dock = DockStyle.Fill
            };

            chartDialog.Controls.Add(chart);


            ChartArea chartArea = new ChartArea("MainArea")
            {
                AxisX = { Title = "Pokolenie" },
                AxisY = { Title = "Wartosc funkcji"}
            };

            chart.ChartAreas.Add(chartArea);

            Series avgSeries = new Series("średnia wartość")
            {
                ChartType = SeriesChartType.Line,
                Color = System.Drawing.Color.Green,
                BorderWidth = 2
            };

            Legend legend = new Legend("Legend")
            {
                Docking = Docking.Top, 
                Alignment = StringAlignment.Center,
                LegendStyle = LegendStyle.Row 
            };
            chart.Legends.Add(legend);

            Series maxSeries = new Series("max wartość")
            {
                ChartType = SeriesChartType.Line,
                Color = System.Drawing.Color.Red,
                BorderWidth = 2
            };
            Series minSeries = new Series("min wartość")
            {
                ChartType = SeriesChartType.Line,
                Color = System.Drawing.Color.Blue,
                BorderWidth = 2
            };

            for (int i = 0; i < pokolenies.Length; ++i)
            {
                avgSeries.Points.AddXY(i + 1, pokolenies[i].getAvg());
                maxSeries.Points.AddXY(i + 1, pokolenies[i].getMaxFunc());
                minSeries.Points.AddXY(i + 1, pokolenies[i].getMinFunc());
            }
            chart.Series.Add(avgSeries);
            chart.Series.Add(maxSeries);
            chart.Series.Add(minSeries);
            chartDialog.ShowDialog();
        }


        private void testyButon_Click(object sender, EventArgs e)
        {

            int[] Ntab = Utility.CreateArray(30, 80, 5);
            double[] pktab = Utility.CreateArray(0.5, 0.91, 0.05);
            double[] pntab = Utility.CreateAlternatingArray(0.0001, 0.01);
            int[] Ttab = Utility.CreateArray(50, 100, 10);
            Tests test1 = new Tests(Ntab, Ttab, pktab, pntab);
            test1.setZestawyParallel();
            test1.SortData();
            ZestawDanych[] zestaw1 = test1.getZestaw();
            
            // Tworzenie i wyświetlanie formularza z wynikami
            resultForm resultsForm = new resultForm();
            resultsForm.SetData(zestaw1); // Przekazanie danych do formularza
            resultsForm.ShowDialog();    // Wyświetlenie jako okno dialogowe
        }

        private void dane_Click(object sender, EventArgs e)
        {
            if (pokolenies != null)
            {
                DataTable table = new DataTable();
                table.Columns.Add("Lp.");
                table.Columns.Add("xreal");
                table.Columns.Add("xbin");
                table.Columns.Add("f(x)");
                table.Columns.Add("%");
                Dictionary<double, int> results = new Dictionary<double, int>();
                double[] xreal = pokolenies[pokolenies.Length - 1].getXreal2();
                foreach (double value in xreal)
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
                foreach (var pair in sortedResult)
                {
                    DataRow row = table.NewRow();
                    row[0] = count + 1;
                    row[1] = pair.Key;
                    row[2] = myFunc.calculate_xbin(myFunc.calculate_xint(pair.Key)); // Użycie 'myFunc'
                    row[3] = myFunc.func(pair.Key);
                    row[4] = pair.Value * 100 / xreal.Length;
                    table.Rows.Add(row);
                    ++count;
                }


                dataGridView1.DataSource = table;


            }
            else
            {
                MessageBox.Show("Nie wykonano obliczeń. Proszę kliknąć 'Oblicz' przed wyświetleniem danych.");
            }
        }
    }
}
