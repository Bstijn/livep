using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modellen;
using System.Data.SqlClient;

namespace Dal
{
    public class OverzichtDalSQL : IOverzichtDal
    {
        static SqlConnection conn = new SqlConnection("user id=Test;Password=AnneFrank123;Server=192.168.19.2;Database=Politiek;");

        public List<Partij> geefAllePartijen()
        {
            List<Partij> partijen = new List<Partij>();
            string query = "select * from Partij";
            SqlCommand cmd = new SqlCommand(query,conn);
            open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Partij p = new Partij();
                p.Id = reader.GetInt32(0);
                p.Naam = reader.GetString(1);
                p.Lijsttrekker = reader.GetString(2);
                partijen.Add(p);
            }
            close();
            return partijen;
        }

        public List<Verkiezing> geefAlleVerkiezingen()
        {
            List<Verkiezing> verkiezingen = new List<Verkiezing>();
            string query = "select v.*, count(u.naam) as aantaluitslagen from Verkiezing v " +
                            "inner join Uitslag u on u.Verkiezing_id = v.id " +
                            "group by v.id,v.naam,v.zetels";
            SqlCommand cmd = new SqlCommand(query, conn);
            open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Verkiezing v = new Verkiezing();
                v.Id = reader.GetInt32(0);
                v.Naam = reader.GetString(1);
                v.totZetels = reader.GetInt32(2);
                v.Uitslagen.Capacity = reader.GetInt32(3);
                verkiezingen.Add(v);
            }
            close();
            return verkiezingen;
        }

        public List<Partij> Partijenvan(Verkiezing verkiezing)
        {
            List<Partij> partijen = new List<Partij>();
            string query = "select p.id,lijsttrekker,naam from Verkiezing_Partij vp " +
                           "inner join Partij p on p.id = vp.Partij_id " +
                           "where vp.Verkiezing_id = @id";
            SqlParameter pm = new SqlParameter("@id", verkiezing.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(pm);
            open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Partij p = new Partij();
                p.Id = reader.GetInt32(0);
                p.Naam = reader.GetString(2);
                p.Lijsttrekker = reader.GetString(1);
                partijen.Add(p);
            }
            close();
            return partijen;
        }

        public Uitslag UitslagDetails(string naam)
        {
            throw new NotImplementedException();
        }

        public List<Uitslag> UitslagenVan(Verkiezing verkiezing)
        {
            List<Uitslag> uitslagen = new List<Uitslag>();
            string query = "select naam,datum,totstemmen,id from Uitslag "+
                            "where Verkiezing_id = @vid";
            SqlParameter pm = new SqlParameter("@vid", verkiezing.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(pm);
            open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Uitslag u = new Uitslag();
                u.Naam = reader.GetString(0);
                u.Datum = reader.GetDateTime(1);
                u.TotaalStemmen = reader.GetInt32(2);
                u.Id = reader.GetInt32(3);
                uitslagen.Add(u);
            }
            close();
            return uitslagen; 
        }

        public List<Partij> UitslagPartijen(string naam)
        {
            List<Partij> partijen = new List<Partij>();
            string query = "select p.*,up.stemmen,up.zetels from Uitslag_Partij up inner join partij p on up.Partij_id = p.id where up.Uitslag_id = (select id from Uitslag where naam = @naam)";
            SqlParameter pm = new SqlParameter("@naam", naam);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(pm);
            open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Partij p = new Partij();
                p.Id = reader.GetInt32(0);
                p.Naam = reader.GetString(1);
                p.Lijsttrekker = reader.GetString(2);
                p.Stemmen = reader.GetInt32(3);
                p.Zetels = reader.GetInt32(4);
                partijen.Add(p);
            }
            close();
            return partijen;
        }

        private void close()
        {
            conn.Close();
        }
        private void open()
        {
            conn.Open();
        }
    }
}
