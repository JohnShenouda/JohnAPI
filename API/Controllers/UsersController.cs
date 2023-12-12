using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using API.Models;
 

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : Controller
  {
    public John_APIDBContext _context { get; set; }
    public UsersController(John_APIDBContext context)
    {
      _context = context;
    }
    [HttpGet]
    [Route("[action]")]
    public Users GetUser(string userID)
    {
      var cmd = _context.Database.GetDbConnection().CreateCommand();
      cmd.CommandText = "dbo.Users_DataLoad";
      cmd.CommandType = CommandType.StoredProcedure;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
      if (cmd.Connection.State != ConnectionState.Open)
      {
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        cmd.Connection.Open();
      }

      cmd.Parameters.Add(new SqlParameter("@UserID", userID));
     
      DataTable retObject = new DataTable();
      retObject.Load(cmd.ExecuteReader());
      Users users = new Users();

      if (retObject != null && retObject.Rows.Count != 0)
      {
        for (int i = 0; i < retObject.Rows.Count; i++)
        {


                    //  users.password = ClsStringEncryptionDecryption.Decrypt(retObject.Rows[i]["Password"].ToString(), false) ;
                    users.recid = retObject.Rows[i]["RecID"].ToString();
                    users.fullname = retObject.Rows[i]["FullName"].ToString();
                    users.area = retObject.Rows[i]["Area"].ToString();
                    users.sub_area = retObject.Rows[i]["Sub_Area"].ToString();
                    users.relation = retObject.Rows[i]["Relation"].ToString();
                    users.gender = retObject.Rows[i]["Gender"].ToString();
                    users.service = retObject.Rows[i]["Service"].ToString();
                    users.floor = retObject.Rows[i]["Floor"].ToString();
                    users.notes = retObject.Rows[i]["Notes"].ToString();
                    users.ser = retObject.Rows[i]["ser"].ToString();
                    users.married = retObject.Rows[i]["married"].ToString();
                    users.tripsattend = retObject.Rows[i]["TripsAttend"].ToString();
                    users.usechair = retObject.Rows[i]["UseChair"].ToString();
                    users.needhelp = retObject.Rows[i]["NeedHelp"].ToString();
                    users.sleepwith = retObject.Rows[i]["SleepWith"].ToString();
                    users.phone = retObject.Rows[i]["Phone"].ToString();
                    users.address = retObject.Rows[i]["Address"].ToString();
                    users.retardation = retObject.Rows[i]["Retardation"].ToString();
                    users.dob = retObject.Rows[i]["DOB"].ToString();
                    users.listening = retObject.Rows[i]["listening"].ToString();
                    users.seeing = retObject.Rows[i]["seeing"].ToString();
                    users.speaking = retObject.Rows[i]["speaking"].ToString();
                    users.eating = retObject.Rows[i]["eating"].ToString();
                    users.medicine = retObject.Rows[i]["medicine"].ToString();
                    users.crisis = retObject.Rows[i]["crisis"].ToString();
                    users.healthy = retObject.Rows[i]["healthy"].ToString();
                    users.listen = retObject.Rows[i]["listen"].ToString();
                    users.speak = retObject.Rows[i]["speak"].ToString();
                    users.eat = retObject.Rows[i]["eat"].ToString();
                    users.see = retObject.Rows[i]["see"].ToString();
                    users.health = retObject.Rows[i]["health"].ToString();
                    users.medicaments = retObject.Rows[i]["medicaments"].ToString();
                    users.panic = retObject.Rows[i]["panic"].ToString();
                    users.age = retObject.Rows[i]["age"].ToString();
                    users.retardationreason = retObject.Rows[i]["retardationreason"].ToString();
                    users.study = retObject.Rows[i]["study"].ToString();
                    users.job = retObject.Rows[i]["job"].ToString();
                    users.parents = retObject.Rows[i]["parents"].ToString();
                    users.marital = retObject.Rows[i]["marital"].ToString();
                    users.confession = retObject.Rows[i]["confession"].ToString();
                    users.ziina = retObject.Rows[i]["ziina"].ToString();
                    users.entrydate = retObject.Rows[i]["EntryDate"].ToString();
                    users.hellp = retObject.Rows[i]["Hellp"].ToString();
                    users.number_of_hellpers = retObject.Rows[i]["Number_of_Hellpers"].ToString();
                    users.groups = retObject.Rows[i]["Groups"].ToString();
                    users.needcar = retObject.Rows[i]["NeedCar"].ToString();
                    users.userid = retObject.Rows[i]["UserID"].ToString();
                    users.username = retObject.Rows[i]["UserName"].ToString();
                    users.password = retObject.Rows[i]["Password"].ToString();

                    string kk = retObject.Rows[i]["ITPicture"].ToString();
          if (retObject.Rows[i]["ITPicture"] != DBNull.Value || retObject.Rows[i]["ITPicture"].ToString() != "") 
                        users.itpicture = ((byte[])retObject.Rows[i]["ITPicture"]);


        }
      }
      return users;
    }
    [HttpPost]
    [Route("[action]")]
    public Users AddUserImags(Users users)
    {
      if (users != null)
      {
        var cmd = _context.Database.GetDbConnection().CreateCommand();
        cmd.CommandText = "dbo.Users_img_DataSave";
        cmd.CommandType = CommandType.StoredProcedure;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        if (cmd.Connection.State != ConnectionState.Open)
        {
#pragma warning restore CS8602 // Dereference of a possibly null reference.
          cmd.Connection.Open();
        }
        cmd.Parameters.Add(new SqlParameter("@UserID", users.userid));
        cmd.Parameters.Add(new SqlParameter("@ITPicture", users.itpicture));
        cmd.ExecuteNonQuery();
        return users;
      }
      return null;
    }


        
    [HttpGet]
    [Route("[action]")]
    public Users GetImage(string userID)
        {
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "dbo.Images_DataLoad";
            cmd.CommandType = CommandType.StoredProcedure;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (cmd.Connection.State != ConnectionState.Open)
            {
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                cmd.Connection.Open();
            }

            cmd.Parameters.Add(new SqlParameter("@UserID", userID));

            DataTable retObject = new DataTable();
            retObject.Load(cmd.ExecuteReader());
            Users users = new Users();

            if (retObject != null && retObject.Rows.Count != 0)
            {
                for (int i = 0; i < retObject.Rows.Count; i++)
                {

                    //  users.password = ClsStringEncryptionDecryption.Decrypt(retObject.Rows[i]["Password"].ToString(), false) ;
     
                    users.userid = retObject.Rows[i]["UserID"].ToString();
                    users.username = retObject.Rows[i]["UserName"].ToString();
                    users.password = retObject.Rows[i]["Password"].ToString();

                    string kk = retObject.Rows[i]["ITPicture"].ToString();
                    if (retObject.Rows[i]["ITPicture"] != DBNull.Value || retObject.Rows[i]["ITPicture"].ToString() != "")
                        users.itpicture = ((byte[])retObject.Rows[i]["ITPicture"]);


                }
            }
            return users;
        }




        [HttpPost]
    [Route("[action]")]
    public Users AddUser(Users users)
    {
      if (users != null)
      {
        var cmd = _context.Database.GetDbConnection().CreateCommand();
        cmd.CommandText = "dbo.Users_DataSave";
        cmd.CommandType = CommandType.StoredProcedure;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        if (cmd.Connection.State != ConnectionState.Open)
        {
#pragma warning restore CS8602 // Dereference of a possibly null reference.
          cmd.Connection.Open();
        }

                //  cmd.Parameters.Add(new SqlParameter("@Password", ClsStringEncryptionDecryption.Encrypt(users.password, false)));

                cmd.Parameters.Add(new SqlParameter("@recid", users.recid));
                cmd.Parameters.Add(new SqlParameter("@fullname", users.fullname));
                cmd.Parameters.Add(new SqlParameter("@area", users.area));
                cmd.Parameters.Add(new SqlParameter("@sub_area", users.sub_area));
                cmd.Parameters.Add(new SqlParameter("@relation", users.relation));
                cmd.Parameters.Add(new SqlParameter("@gender", users.gender));
                cmd.Parameters.Add(new SqlParameter("@service", users.service));
                cmd.Parameters.Add(new SqlParameter("@floor", users.floor));
                cmd.Parameters.Add(new SqlParameter("@notes", users.notes));
                cmd.Parameters.Add(new SqlParameter("@ser", users.ser));
                cmd.Parameters.Add(new SqlParameter("@married", users.married));
                cmd.Parameters.Add(new SqlParameter("@tripsattend", users.tripsattend));
                cmd.Parameters.Add(new SqlParameter("@usechair", users.usechair));
                cmd.Parameters.Add(new SqlParameter("@needhelp", users.needhelp));
                cmd.Parameters.Add(new SqlParameter("@sleepwith", users.sleepwith));
                cmd.Parameters.Add(new SqlParameter("@phone", users.phone));
                cmd.Parameters.Add(new SqlParameter("@address", users.address));
                cmd.Parameters.Add(new SqlParameter("@retardation", users.retardation));
                cmd.Parameters.Add(new SqlParameter("@dob", users.dob));
                cmd.Parameters.Add(new SqlParameter("@listening", users.listening));
                cmd.Parameters.Add(new SqlParameter("@seeing", users.seeing));
                cmd.Parameters.Add(new SqlParameter("@speaking", users.speaking));
                cmd.Parameters.Add(new SqlParameter("@eating", users.eating));
                cmd.Parameters.Add(new SqlParameter("@medicine", users.medicine));
                cmd.Parameters.Add(new SqlParameter("@crisis", users.crisis));
                cmd.Parameters.Add(new SqlParameter("@healthy", users.healthy));
                cmd.Parameters.Add(new SqlParameter("@listen", users.listen));
                cmd.Parameters.Add(new SqlParameter("@speak", users.speak));
                cmd.Parameters.Add(new SqlParameter("@eat", users.eat));
                cmd.Parameters.Add(new SqlParameter("@see", users.see));
                cmd.Parameters.Add(new SqlParameter("@health", users.health));
                cmd.Parameters.Add(new SqlParameter("@medicaments", users.medicaments));
                cmd.Parameters.Add(new SqlParameter("@panic", users.panic));
                cmd.Parameters.Add(new SqlParameter("@age", users.age));
                cmd.Parameters.Add(new SqlParameter("@retardationreason", users.retardationreason));
                cmd.Parameters.Add(new SqlParameter("@study", users.study));
                cmd.Parameters.Add(new SqlParameter("@job", users.job));
                cmd.Parameters.Add(new SqlParameter("@parents", users.parents));
                cmd.Parameters.Add(new SqlParameter("@marital", users.marital));
                cmd.Parameters.Add(new SqlParameter("@confession", users.confession));
                cmd.Parameters.Add(new SqlParameter("@ziina", users.ziina));
                cmd.Parameters.Add(new SqlParameter("@entrydate", users.entrydate));
                cmd.Parameters.Add(new SqlParameter("@hellp", users.hellp));
                cmd.Parameters.Add(new SqlParameter("@number_of_hellpers", users.number_of_hellpers));
                cmd.Parameters.Add(new SqlParameter("@groups", users.groups));
                cmd.Parameters.Add(new SqlParameter("@needcar", users.needcar));
                cmd.Parameters.Add(new SqlParameter("@userid", users.userid));
                cmd.Parameters.Add(new SqlParameter("@username", users.username));
                cmd.Parameters.Add(new SqlParameter("@password", users.password));
               // cmd.Parameters.Add(new SqlParameter("@itpicture", users.itpicture));




                cmd.ExecuteNonQuery();
        return users;
      }
      return null;
    }

    [HttpDelete]
    [Route("[action]")]
    public Users DeleteUser(string userID)
    {
      var cmd = _context.Database.GetDbConnection().CreateCommand();
      cmd.CommandText = "dbo.Users_DataDelete";
      cmd.CommandType = CommandType.StoredProcedure;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
      if (cmd.Connection.State != ConnectionState.Open)
      {
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        cmd.Connection.Open();
      }
      cmd.Parameters.Add(new SqlParameter("@UserID", userID));
      DataTable retObject = new DataTable();
      retObject.Load(cmd.ExecuteReader());
      Users users = new Users();

      if (retObject != null && retObject.Rows.Count != 0)
      {
        for (int i = 0; i < retObject.Rows.Count; i++)
        {
                    users.recid = retObject.Rows[i]["RecID"].ToString();
                    users.fullname = retObject.Rows[i]["FullName"].ToString();
                    users.area = retObject.Rows[i]["Area"].ToString();
                    users.sub_area = retObject.Rows[i]["Sub_Area"].ToString();
                    users.relation = retObject.Rows[i]["Relation"].ToString();
                    users.gender = retObject.Rows[i]["Gender"].ToString();
                    users.service = retObject.Rows[i]["Service"].ToString();
                    users.floor = retObject.Rows[i]["Floor"].ToString();
                    users.notes = retObject.Rows[i]["Notes"].ToString();
                    users.ser = retObject.Rows[i]["ser"].ToString();
                    users.married = retObject.Rows[i]["married"].ToString();
                    users.tripsattend = retObject.Rows[i]["TripsAttend"].ToString();
                    users.usechair = retObject.Rows[i]["UseChair"].ToString();
                    users.needhelp = retObject.Rows[i]["NeedHelp"].ToString();
                    users.sleepwith = retObject.Rows[i]["SleepWith"].ToString();
                    users.phone = retObject.Rows[i]["Phone"].ToString();
                    users.address = retObject.Rows[i]["Address"].ToString();
                    users.retardation = retObject.Rows[i]["Retardation"].ToString();
                    users.dob = retObject.Rows[i]["DOB"].ToString();
                    users.listening = retObject.Rows[i]["listening"].ToString();
                    users.seeing = retObject.Rows[i]["seeing"].ToString();
                    users.speaking = retObject.Rows[i]["speaking"].ToString();
                    users.eating = retObject.Rows[i]["eating"].ToString();
                    users.medicine = retObject.Rows[i]["medicine"].ToString();
                    users.crisis = retObject.Rows[i]["crisis"].ToString();
                    users.healthy = retObject.Rows[i]["healthy"].ToString();
                    users.listen = retObject.Rows[i]["listen"].ToString();
                    users.speak = retObject.Rows[i]["speak"].ToString();
                    users.eat = retObject.Rows[i]["eat"].ToString();
                    users.see = retObject.Rows[i]["see"].ToString();
                    users.health = retObject.Rows[i]["health"].ToString();
                    users.medicaments = retObject.Rows[i]["medicaments"].ToString();
                    users.panic = retObject.Rows[i]["panic"].ToString();
                    users.age = retObject.Rows[i]["age"].ToString();
                    users.retardationreason = retObject.Rows[i]["retardationreason"].ToString();
                    users.study = retObject.Rows[i]["study"].ToString();
                    users.job = retObject.Rows[i]["job"].ToString();
                    users.parents = retObject.Rows[i]["parents"].ToString();
                    users.marital = retObject.Rows[i]["marital"].ToString();
                    users.confession = retObject.Rows[i]["confession"].ToString();
                    users.ziina = retObject.Rows[i]["ziina"].ToString();
                    users.entrydate = retObject.Rows[i]["EntryDate"].ToString();
                    users.hellp = retObject.Rows[i]["Hellp"].ToString();
                    users.number_of_hellpers = retObject.Rows[i]["Number_of_Hellpers"].ToString();
                    users.groups = retObject.Rows[i]["Groups"].ToString();
                    users.needcar = retObject.Rows[i]["NeedCar"].ToString();
                    users.userid = retObject.Rows[i]["UserID"].ToString();
                    users.username = retObject.Rows[i]["UserName"].ToString();
                    users.password = retObject.Rows[i]["Password"].ToString();



                }
            }
      return users;
    }

    [HttpGet]
    [Route("[action]")]
    public IEnumerable<Users> UsersLookupTop()
    {
      var cmd = _context.Database.GetDbConnection().CreateCommand();
      cmd.CommandText = "dbo.UsersTop_Lookup";
      cmd.CommandType = CommandType.StoredProcedure;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
      if (cmd.Connection.State != ConnectionState.Open)
      {
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        cmd.Connection.Open();
      }

      DataTable retObject = new DataTable();
      retObject.Load(cmd.ExecuteReader());
      List<Users> UsersList = new List<Users>();

      if (retObject != null && retObject.Rows.Count != 0)
      {
        for (int i = 0; i < retObject.Rows.Count; i++)
        {
          Users users = new Users();
                     //          users.password = ClsStringEncryptionDecryption.Decrypt(retObject.Rows[i]["Password"].ToString(), false);
                    users.recid = retObject.Rows[i]["RecID"].ToString();
                    users.fullname = retObject.Rows[i]["FullName"].ToString();
                    users.area = retObject.Rows[i]["Area"].ToString();
                    users.sub_area = retObject.Rows[i]["Sub_Area"].ToString();
                    users.relation = retObject.Rows[i]["Relation"].ToString();
                    users.gender = retObject.Rows[i]["Gender"].ToString();
                    users.service = retObject.Rows[i]["Service"].ToString();
                    users.floor = retObject.Rows[i]["Floor"].ToString();
                    users.notes = retObject.Rows[i]["Notes"].ToString();
                    users.ser = retObject.Rows[i]["ser"].ToString();
                    users.married = retObject.Rows[i]["married"].ToString();
                    users.tripsattend = retObject.Rows[i]["TripsAttend"].ToString();
                    users.usechair = retObject.Rows[i]["UseChair"].ToString();
                    users.needhelp = retObject.Rows[i]["NeedHelp"].ToString();
                    users.sleepwith = retObject.Rows[i]["SleepWith"].ToString();
                    users.phone = retObject.Rows[i]["Phone"].ToString();
                    users.address = retObject.Rows[i]["Address"].ToString();
                    users.retardation = retObject.Rows[i]["Retardation"].ToString();
                    users.dob = retObject.Rows[i]["DOB"].ToString();
                    users.listening = retObject.Rows[i]["listening"].ToString();
                    users.seeing = retObject.Rows[i]["seeing"].ToString();
                    users.speaking = retObject.Rows[i]["speaking"].ToString();
                    users.eating = retObject.Rows[i]["eating"].ToString();
                    users.medicine = retObject.Rows[i]["medicine"].ToString();
                    users.crisis = retObject.Rows[i]["crisis"].ToString();
                    users.healthy = retObject.Rows[i]["healthy"].ToString();
                    users.listen = retObject.Rows[i]["listen"].ToString();
                    users.speak = retObject.Rows[i]["speak"].ToString();
                    users.eat = retObject.Rows[i]["eat"].ToString();
                    users.see = retObject.Rows[i]["see"].ToString();
                    users.health = retObject.Rows[i]["health"].ToString();
                    users.medicaments = retObject.Rows[i]["medicaments"].ToString();
                    users.panic = retObject.Rows[i]["panic"].ToString();
                    users.age = retObject.Rows[i]["age"].ToString();
                    users.retardationreason = retObject.Rows[i]["retardationreason"].ToString();
                    users.study = retObject.Rows[i]["study"].ToString();
                    users.job = retObject.Rows[i]["job"].ToString();
                    users.parents = retObject.Rows[i]["parents"].ToString();
                    users.marital = retObject.Rows[i]["marital"].ToString();
                    users.confession = retObject.Rows[i]["confession"].ToString();
                    users.ziina = retObject.Rows[i]["ziina"].ToString();
                    users.entrydate = retObject.Rows[i]["EntryDate"].ToString();
                    users.hellp = retObject.Rows[i]["Hellp"].ToString();
                    users.number_of_hellpers = retObject.Rows[i]["Number_of_Hellpers"].ToString();
                    users.groups = retObject.Rows[i]["Groups"].ToString();
                    users.needcar = retObject.Rows[i]["NeedCar"].ToString();
                    users.userid = retObject.Rows[i]["UserID"].ToString();
                    users.username = retObject.Rows[i]["UserName"].ToString();
                    users.password = retObject.Rows[i]["Password"].ToString();




                    UsersList.Add(users);
        }
      }
      return UsersList;
    }
  }
}
