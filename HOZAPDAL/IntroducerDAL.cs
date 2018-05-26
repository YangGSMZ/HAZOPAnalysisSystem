using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HOZAPModel;
using System.Data.SqlClient;

namespace HOZAPDAL
{
    public class IntroducerDAL
    {
        public List<Introducer> Get_IntroducerList(int PramasId)
        {
            string sql = "select * from tb_Introducer where PramasId=@PramasId";
            List<Introducer> IntroducerList = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@PramasId", PramasId)))
            {
                if (sdr.HasRows)
                {
                    IntroducerList = new List<Introducer>();
                    while (sdr.Read())
                    {
                        Introducer introducer = new Introducer();
                        introducer.IntroducerId = sdr.GetInt32(0);
                        introducer.IntroducerText = sdr.GetString(1);
                        introducer.PramasId = sdr.GetInt32(2);
                        IntroducerList.Add(introducer);
                    }
                }
            }
            return IntroducerList;
        }
    }
}
