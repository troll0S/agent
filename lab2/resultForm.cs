using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class resultForm : Form
    {
        public resultForm()
        {
            InitializeComponent();
        }

        private void resultForm_Load(object sender, EventArgs e)
        {

        }

        public void SetData(ZestawDanych[] zestawy)
        {
            if (zestawy == null)
            {
                MessageBox.Show("Zestaw danych jest pusty.");
                return;
            }
            // Ustawienie danych jako źródło DataGridView
            dataGridView1.DataSource = zestawy.Select(z => new
            {
                Średnia = z.favg,
                Czas = z.T,
                Liczba = z.N,
                PrawdopodobieństwoPn = z.pn,
                PrawdopodobieństwoPk = z.pk
            }).ToList();

            // Opcjonalnie: dostosowanie szerokości kolumn
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
