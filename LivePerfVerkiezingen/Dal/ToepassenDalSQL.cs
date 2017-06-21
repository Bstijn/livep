using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modellen;
using System.Data.SqlClient;

namespace Dal
{
    public class ToepassenDalSQL : IToepassenDal
    {
        static SqlConnection conn = new SqlConnection("user id=Test;Password=AnneFrank123;Server=192.168.19.2;Database=Politiek;");
        public FileStyleUriParser maakExport(Uitslag uitslag)
        {
            throw new NotImplementedException();
        }

        public void NieuweUitslag(Uitslag uitslag)
        {
            string q1 = "insert into Uitslag(totstemmen,datum,naam,Verkiezing_id) values (@totstemmen,@datum,@naam,@verkiezing_id)";
            SqlParameter[] pms =
            {
                new SqlParameter("@totstemmen",uitslag.TotaalStemmen),
                new SqlParameter("datum",uitslag.Datum),
                new SqlParameter("@naam",uitslag.Naam),
                new SqlParameter("@verkiezing_id",uitslag.verkiezing.Id)
            };
            SqlCommand cdm1 = new SqlCommand(q1, conn);
            cdm1.Parameters.AddRange(pms);
            open();
            cdm1.ExecuteNonQuery();
            close();
            int uitslag_id = 0;
            string q2 = "select id from uitslag where naam = @naam";
            SqlParameter p1 = new SqlParameter("@naam", uitslag.Naam);
            SqlCommand cmd2 = new SqlCommand(q2, conn);
            cmd2.Parameters.Add(p1);
            open();
            SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                uitslag_id = reader.GetInt32(0);
            }
            close();
            foreach (Partij p in uitslag.verkiezing.Partijen)
            {
                voegpartijtoeaanuitslag(uitslag_id, p);
            }


        }
        private void voegpartijtoeaanuitslag(int uitslag_id, Partij p)
        {
            string query = "insert into Uitslag_Partij (Partij_id,Uitslag_id,stemmen,zetels) values (@partij_id,@uitslag_id,@stemmen,@zetels)";
            SqlParameter[] pms =
                {
                    new SqlParameter("@partij_id",p.Id),
                    new SqlParameter("@uitslag_id",uitslag_id),
                    new SqlParameter("@stemmen",p.Stemmen),
                    new SqlParameter("@zetels",p.Zetels)
                };
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(pms);
            open();
            cmd.ExecuteNonQuery();
            close();
        }

        public bool PasPartijAan(Partij partij)
        {
            string query = "update Partij " +
            "set naam = @naam, lijsttrekker = @lijsttrekker " +
            "where id = @id";
            SqlParameter[] pms =
            {
                new SqlParameter("@naam",partij.Naam),
                new SqlParameter("@lijsttrekker",partij.Lijsttrekker),
                new SqlParameter("@id",partij.Id)
            };
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(pms);
            open();
            try
            {
                cmd.ExecuteNonQuery();
                close();
            }
            catch (SqlException)
            {
                close();
                return false;
            }
            close();
            return true;
        }

        public void SlaCoalitieOp(Coalitie coalitie)
        {
            throw new NotImplementedException();
        }

        public bool UitslagAanpassen(int Uitslag_id, Uitslag aangepasteUitslag)
        {
            throw new NotImplementedException();
        }

        public bool VerkiezingVoegPartijToe(Verkiezing verkiezing, Partij partij)
        {
            throw new NotImplementedException();
        }

        public void verwijderPartij(Partij partij)
        {
            throw new NotImplementedException();
        }

        public bool VoegPartijToe(Partij partij)
        {
            string query = "insert into Partij (naam,lijsttrekker) values(@naam,@lijsttrekker)";
            SqlParameter[] pms =
            {
                new SqlParameter("@naam",partij.Naam),
                new SqlParameter("@lijsttrekker",partij.Lijsttrekker)
            };
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(pms);
            open();
            try
            {
                cmd.ExecuteNonQuery();
                close();
            }
            catch (SqlException)
            {
                close();
                return false;
            }
            return true;
        }
        private void close()
        {
            conn.Close();
        }
        private void open()
        {
            conn.Open();
        }

        public Partij geefPartij(string naam, int id)
        {
            Partij p = new Partij();
            string query = "select * from Partij p " +
            "inner join Uitslag_Partij up on p.id = up.Partij_id " +
            "where naam = @naam and Uitslag_id = @uitslag_id";
            SqlParameter[] pms =
            {
                new SqlParameter("@naam", naam),
                new SqlParameter("uitslag_id",id)
            };
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(pms);
            open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                p.Id = reader.GetInt32(0);
                p.Naam = reader.GetString(1);
                p.Lijsttrekker = reader.GetString(2);
                p.Stemmen = reader.GetInt32(5);
                p.Zetels = reader.GetInt32(6);
            }
            close();
            return p;
        }
    }
}
