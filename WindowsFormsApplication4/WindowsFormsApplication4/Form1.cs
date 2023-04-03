using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;
using Sesija;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Broker.DajSesiju().VratiSveUcenike();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text) && !String.IsNullOrWhiteSpace(textBox3.Text))
                {
                    Ucenik ucenik = new Ucenik
                    {
                        jmbg = textBox1.Text,
                        ime = textBox2.Text,
                        prezime = textBox3.Text,
                    };
                    try
                    {
                        int rezultat = Broker.DajSesiju().UbaciUcenikaUBazu(ucenik);
                        if (rezultat > 0)
                        {
                            MessageBox.Show("Uspesno ste dodali");
                        }
                        else
                        {
                            MessageBox.Show("Niste uspesno dodali");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Postoji problem", ex.Message);
                    }
                    dataGridView1.DataSource = Broker.DajSesiju().VratiSveUcenike();
                }
            }
            if (radioButton2.Checked)
            {
                if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text) && !String.IsNullOrWhiteSpace(textBox3.Text))
                {
                    Ucenik ucenik = new Ucenik
                    {
                        jmbg = textBox1.Text,
                        ime = textBox2.Text,
                        prezime = textBox3.Text,
                    };
                    try
                    {
                        int rezultat = Broker.DajSesiju().IzmeniUcenika(ucenik);
                        if (rezultat > 0)
                        {
                            MessageBox.Show("Uspesno ste izmenili");
                        }
                        else
                        {
                            MessageBox.Show("Niste uspesno izmenili");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Postoji problem", ex.Message);
                    }
                    dataGridView1.DataSource = Broker.DajSesiju().VratiSveUcenike();
                }
            }
        }
    }
}
