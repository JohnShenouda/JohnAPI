using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelingdataController : Controller
    {
        public John_APIDBContext _context { get; set; }
        public TravelingdataController(John_APIDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Travlingdata> Travlingdatalist()
        {
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "dbo.TravlingTran";
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
           // cmd.Parameters.Add(new SqlParameter("@Type", WK_Type));
            DataTable retObject = new DataTable();
            retObject.Load(cmd.ExecuteReader());
            List<Travlingdata> TravlingdataList = new List<Travlingdata>();

            if (retObject != null && retObject.Rows.Count != 0)
            {
                for (int i = 0; i < retObject.Rows.Count; i++)
                {
                    Travlingdata Travlingdata = new Travlingdata();

                    Travlingdata.recID = Convert.ToInt32(retObject.Rows[i]["RecID"]);
                    Travlingdata.homeID = Convert.ToInt32(retObject.Rows[i]["HomeID"]);
                    Travlingdata.travlingInfo = retObject.Rows[i]["TravlingInfo"].ToString();
                    Travlingdata.endstatus = retObject.Rows[i]["EndStatus"].ToString();
                    
                    TravlingdataList.Add(Travlingdata);
                }
            }
            return TravlingdataList;
        }


        [HttpPost]
        [Route("[action]")]
        public Travlingdata addnewtraveling(Travlingdata trip)
        {
            if (trip != null)
            {
                var cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "dbo.AddTravling_dataSave";
                cmd.CommandType = CommandType.StoredProcedure;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (cmd.Connection.State != ConnectionState.Open)
                {
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    cmd.Connection.Open();
                }

                //  cmd.Parameters.Add(new SqlParameter("@Password", ClsStringEncryptionDecryption.Encrypt(users.password, false)));

                cmd.Parameters.Add(new SqlParameter("@HomeID", trip.homeID));
                cmd.Parameters.Add(new SqlParameter("@fromdate", trip.fromdate));
                cmd.Parameters.Add(new SqlParameter("@todate", trip.todate));
                cmd.Parameters.Add(new SqlParameter("@endsatatus", trip.endstatus));
                cmd.Parameters.Add(new SqlParameter("@TravlingInfo", trip.travlingInfo));
        



                // cmd.Parameters.Add(new SqlParameter("@itpicture", users.itpicture));




                cmd.ExecuteNonQuery();
                return trip;
            }
            return null;
        }
    }
}
