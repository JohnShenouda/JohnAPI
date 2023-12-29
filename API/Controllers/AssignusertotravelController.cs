using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignusertotravelController : Controller
    {
        public John_APIDBContext _context { get; set; }
        public AssignusertotravelController(John_APIDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("[action]")]

        public IEnumerable<Assignusertotravel> Assignusertotraveldatalist(string Fullname, string Area, string Sub_Area)
        {
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "dbo.AdminGetdata";
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.Parameters.Add(new SqlParameter("@Fullname", Fullname));
            cmd.Parameters.Add(new SqlParameter("@Area", Area));
            cmd.Parameters.Add(new SqlParameter("@Sub_Area", Sub_Area));
            DataTable retObject = new DataTable();
            retObject.Load(cmd.ExecuteReader());
            List<Assignusertotravel> AssignusertotravelList = new List<Assignusertotravel>();

            if (retObject != null && retObject.Rows.Count != 0)
            {
                for (int i = 0; i < retObject.Rows.Count; i++)
                {
                   Assignusertotravel Assignusertotravel = new Assignusertotravel();

                    //  users.password = ClsStringEncryptionDecryption.Decrypt(retObject.Rows[i]["Password"].ToString(), false) ;
                    Assignusertotravel.recid = Convert.ToInt32(retObject.Rows[i]["recid"]);
                    Assignusertotravel.username = retObject.Rows[i]["username"].ToString();
                    Assignusertotravel.userID = retObject.Rows[i]["userID"].ToString();
                    Assignusertotravel.fullName = retObject.Rows[i]["fullName"].ToString();
                    Assignusertotravel.area = retObject.Rows[i]["area"].ToString();
                    Assignusertotravel.sub_Area = retObject.Rows[i]["sub_Area"].ToString();
                    Assignusertotravel.travlID = retObject.Rows[i]["travlID"].ToString();
                    Assignusertotravel.fromdate = retObject.Rows[i]["fromdate"].ToString();
                    Assignusertotravel.todate = retObject.Rows[i]["todate"].ToString();
                    Assignusertotravel.endStatus = retObject.Rows[i]["endStatus"].ToString();
                    Assignusertotravel.homeID = retObject.Rows[i]["homeID"].ToString();
                    Assignusertotravel.home_name = retObject.Rows[i]["home_name"].ToString();
                    Assignusertotravel.location = retObject.Rows[i]["location"].ToString();
                    Assignusertotravel.status = retObject.Rows[i]["status"].ToString();
                    Assignusertotravel.modifDate = retObject.Rows[i]["modifDate"].ToString();
                    AssignusertotravelList.Add(Assignusertotravel);
                }
            }
            return AssignusertotravelList;
        }

        [HttpGet]
        [Route("[action]")]

        public IEnumerable<Assignusertotravel> AllDatalist()
        {
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "dbo.AdminGetAllPendingdata";
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            DataTable retObject = new DataTable();
            retObject.Load(cmd.ExecuteReader());
            List<Assignusertotravel> AssignusertotravelList = new List<Assignusertotravel>();

            if (retObject != null && retObject.Rows.Count != 0)
            {
                for (int i = 0; i < retObject.Rows.Count; i++)
                {
                    Assignusertotravel Assignusertotravel = new Assignusertotravel();

                    //  users.password = ClsStringEncryptionDecryption.Decrypt(retObject.Rows[i]["Password"].ToString(), false) ;
                    Assignusertotravel.recid = Convert.ToInt32(retObject.Rows[i]["recid"]);
                    Assignusertotravel.username = retObject.Rows[i]["username"].ToString();
                    Assignusertotravel.userID = retObject.Rows[i]["userID"].ToString();
                    Assignusertotravel.fullName = retObject.Rows[i]["fullName"].ToString();
                    Assignusertotravel.area = retObject.Rows[i]["area"].ToString();
                    Assignusertotravel.sub_Area = retObject.Rows[i]["sub_Area"].ToString();
                    Assignusertotravel.travlID = retObject.Rows[i]["travlID"].ToString();
                    Assignusertotravel.fromdate = retObject.Rows[i]["fromdate"].ToString();
                    Assignusertotravel.todate = retObject.Rows[i]["todate"].ToString();
                    Assignusertotravel.endStatus = retObject.Rows[i]["endStatus"].ToString();
                    Assignusertotravel.homeID = retObject.Rows[i]["homeID"].ToString();
                    Assignusertotravel.home_name = retObject.Rows[i]["home_name"].ToString();
                    Assignusertotravel.location = retObject.Rows[i]["location"].ToString();
                    Assignusertotravel.status = retObject.Rows[i]["status"].ToString();
                    Assignusertotravel.modifDate = retObject.Rows[i]["modifDate"].ToString();
                    AssignusertotravelList.Add(Assignusertotravel);
                }
            }
            return AssignusertotravelList;
        }

        [HttpPost]
        [Route("[action]")]
        public Assignusertotravel updatetrans(Assignusertotravel update)
        {
            if (update != null)
            {
                var cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "dbo.AssignUserToTravel_Update";
                cmd.CommandType = CommandType.StoredProcedure;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (cmd.Connection.State != ConnectionState.Open)
                {
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    cmd.Connection.Open();
                }
                cmd.Parameters.Add(new SqlParameter("@recid", update.recid));
                cmd.Parameters.Add(new SqlParameter("@status", update.status));
                cmd.Parameters.Add(new SqlParameter("@Notes", update.Notes));
                cmd.ExecuteNonQuery();
                return update;
            }
            return null;
        }

    }
}
