using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablePerkalianApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            try
            {
                int baris = Convert.ToInt32(txtBaris.Text);
                int kolom = Convert.ToInt32(txtKolom.Text);

                if (baris >= 0 && kolom >= 0)
                {
                    gridTable.Rows.Clear();
                    gridTable.Columns.Clear();
                    gridTable.ColumnCount = kolom + 1;

                    // Menampilkan table perkalian di DataGridView
                    // Menggunakan Array 1 dimensi
                    /*
                    string[] arr;
                    for (int i = 0; i <= baris; i++)
                    {
                        arr = new string[kolom + 1];
                        for (int j = 0; j <= kolom; j++)
                        {
                            arr[j] = (i * j).ToString();

                            gridTable.Columns[j].Name = j.ToString();

                        }
                        gridTable.Rows.Add(arr);
                        gridTable.Rows[i].HeaderCell.Value = Convert.ToString(i);
                    }
                    */
                    // End

                    // Menampilkan table perkalian di DataGridView
                    // Menggunakan Array 2 dimensi
                    string[,] arr = new string[baris + 1, kolom + 1];

                    int row = arr.GetLength(0);
                    int column = arr.GetLength(1);

                    for (int i = 0; i < row; i++)
                    {
                        var rows = new DataGridViewRow();

                        for (int j = 0; j < column; j++)
                        {
                            arr[i, j] = (i * j).ToString();

                            rows.Cells.Add(new DataGridViewTextBoxCell()
                            {
                                Value = arr[i, j]
                            });

                            gridTable.Columns[j].Name = j.ToString();
                        }

                        gridTable.Rows.Add(rows);
                        gridTable.Rows[i].HeaderCell.Value = Convert.ToString(i);
                    }
                    // End

                    lblBaris.Text = (baris + 1).ToString();
                    lblKolom.Text = (kolom + 1).ToString();
                    lblTable.Text = "0 x 0 sampai " + baris + " x " + kolom;
                }
                else
                    MessageBox.Show("Masukkan bilangan cacah (lebih dari atau sama dengan nol)!", "Pesan Kesalahan",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Karakter yang Anda masukkan salah! \nHanya masukkan angka!", "Pesan Kesalahan",
                    MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }


        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset("");

            gridTable.AllowUserToAddRows = false;
            gridTable.ReadOnly = true;
            this.gridTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            
        }

        private void reset(String s)
        {
            lblBaris.Text = s;
            lblKolom.Text = s;
            lblTable.Text = s;
        }
    }
}
