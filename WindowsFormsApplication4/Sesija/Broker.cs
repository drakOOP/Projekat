using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Domen;

namespace Sesija
{
    public class Broker
    {
        private static Broker instanca;
        private OleDbConnection konekcija;
        private OleDbCommand komanda;
        private Broker()
        {
            this.konekcija = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb");
            this.komanda = konekcija.CreateCommand();

        }
        public static Broker DajSesiju()
        {
            if (instanca == null)
            {
                instanca = new Broker();
            }
            return instanca;
        }
        public List<Ucenik> VratiSveUcenike()
        {
            List<Ucenik> ucenici = new List<Ucenik>();
            try
            {
                komanda.CommandText = "select jmbg, ime, prezime from Ucenici";
                komanda.CommandType = CommandType.Text;
                konekcija.Open();
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Ucenik ucenik = new Ucenik
                    {
                        jmbg = citac["jmbg"].ToString(),
                        ime = citac["ime"].ToString(),
                        prezime = citac["prezime"].ToString(),
                    };
                    ucenici.Add(ucenik);

                }
                return ucenici;
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }

            }
        }
        public int UbaciUcenikaUBazu(Ucenik ucenik)
        {
            try
            {
                komanda.CommandText = String.Format("insert into Ucenici values('{0}','{1}','{2}')", ucenik.jmbg, ucenik.ime, ucenik.prezime);
                komanda.CommandType = CommandType.Text;
                konekcija.Open();
                return komanda.ExecuteNonQuery();

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }
        }
        public int IzmeniUcenika(Ucenik ucenik)
        {
            try
            {
                komanda.CommandText = "Update Ucenici Set ime='" + ucenik.ime + "', prezime='" + ucenik.prezime + "' Where jmbg='" + ucenik.jmbg + "'";
                komanda.CommandType = CommandType.Text;
                konekcija.Open();
                return komanda.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}