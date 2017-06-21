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
        static SqlConnection conn = new SqlConnection("Server=STIJNCOMPUTER;Database=Politiek;Trusted_Connection=True;");
        public List<Verkiezing> geefAlleVerkiezingen()
        {
            List<Verkiezing> verkiezingen = new List<Verkiezing>();
            string query = "select v.*, count(u.naam) as aantaluitslagen from Verkiezing v " +
                            "inner join Uitslag u on u.Verkiezing_id = v.id " +
                            "group by v.id,v.naam";
            SqlCommand cmd = new SqlCommand(query, conn);
            open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Verkiezing v = new Verkiezing();
                v.Id = reader.GetInt32(0);
                v.Naam = reader.GetString(1);
                v.Uitslagen.Capacity = reader.GetInt32(2);
                verkiezingen.Add(v);
            }
            close();
            return verkiezingen;
        }

        public Uitslag UitslagDetails(string naam)
        {
            throw new NotImplementedException();
        }

        public List<Uitslag> UitslagenVan(Verkiezing verkiezing)
        {
            throw new NotImplementedException();
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
