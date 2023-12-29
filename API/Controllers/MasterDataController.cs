using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : Controller
    {
        public John_APIDBContext _context { get; set; }
        public MasterDataController(John_APIDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("[action]")]
        
            public IEnumerable<MasterData> Masterdatalist(string WK_Type)
        {
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "dbo.GetMasterData";
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State != ConnectionState.Open)
            {
                 cmd.Connection.Open();
            }
            cmd.Parameters.Add(new SqlParameter("@Type", WK_Type));
            DataTable retObject = new DataTable();
            retObject.Load(cmd.ExecuteReader());
            List<MasterData> MasterDataList = new List<MasterData>();

            if (retObject != null && retObject.Rows.Count != 0)
            {
                for (int i = 0; i < retObject.Rows.Count; i++)
                {
                    MasterData masterData = new MasterData();

                    //  users.password = ClsStringEncryptionDecryption.Decrypt(retObject.Rows[i]["Password"].ToString(), false) ;
                    masterData.name = retObject.Rows[i]["Name"].ToString();
                    masterData.type = retObject.Rows[i]["Type"].ToString();
                    MasterDataList.Add(masterData);
                }
            }
            return MasterDataList;
        }





        [HttpGet]
        [Route("[action]")]

        public IEnumerable<HomesInfo> Homedatalist(string WK_Type)
        {
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "dbo.HomeList";
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.Parameters.Add(new SqlParameter("@Type", WK_Type));
            DataTable retObject = new DataTable();
            retObject.Load(cmd.ExecuteReader());
            List<HomesInfo> HomesInfolist = new List<HomesInfo>();

            if (retObject != null && retObject.Rows.Count != 0)
            {
                for (int i = 0; i < retObject.Rows.Count; i++)
                {
                    HomesInfo HomesInfo = new HomesInfo();

                    //  users.password = ClsStringEncryptionDecryption.Decrypt(retObject.Rows[i]["Password"].ToString(), false) ;
                    HomesInfo.homeid = retObject.Rows[i]["homeid"].ToString();
                    HomesInfo.home_name = retObject.Rows[i]["home_name"].ToString();
                    HomesInfolist.Add(HomesInfo);
                }
            }
            return HomesInfolist;
        }
    }
}
