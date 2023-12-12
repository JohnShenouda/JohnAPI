using System.Data;
using System.Collections;


namespace DDBS.DBO
{
  public static class DBEngine
  {
    public static string glb_strUserName;
    public static string glb_strPassword;
    public static string glb_strDBName;
    public static string glb_strServerName;
    public static string glb_strConnStr;
    public static System.Collections.ArrayList glb_ArrayList;
   
    public static void SetConnection()
    {
      //glb_strConnStr = "workstation id=" + HRPayroll.Program.strServerName + ";packet size=4096;user id=" + HRPayroll.Program.strSQLUser + ";data source=" + HRPayroll.Program.strServerName + ";persist security info=True;initial catalog=" + HRPayroll.Program.strDatabaseName + " ;password=" + HRPayroll.Program.strPassword+ "";
      //glb_strConnStr = "workstation id=" + HRPayroll.Program.strServerName + ";packet size=4096;user id=" + HRPayroll.Program.strSQLUser + ";data source=" + HRPayroll.Program.strServerName + ";persist security info=True;initial catalog=" + HRPayroll.Program.strDatabaseName + " ;password=" + HRPayroll.Program.strPassword + "";
      //HRPayroll.Program.conectionString = glb_strConnStr;
      //glb_strConnStr =  "Dsn=" + par_strDSN + ";uid=" + par_strUserName + ";pwd=" + par_strPassword;;
    }

       
          public static void getODBCDSN()
    {
      Microsoft.Win32.RegistryKey lcl_regkeyMyKey1 = (Microsoft.Win32.Registry.CurrentUser).OpenSubKey("Software\\ODBC\\ODBC.INI\\ODBC Data Sources");
      Microsoft.Win32.RegistryKey lcl_regkeyMyKey2 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\ODBC\\ODBC.INI\\ODBC Data Sources");
      try
      {
        glb_ArrayList = new ArrayList();
        glb_ArrayList.Clear();
        for (int count = 0; count < lcl_regkeyMyKey1.GetValueNames().Length; count++)
        {
          glb_ArrayList.Add(lcl_regkeyMyKey1.GetValueNames().GetValue(count).ToString());
        }

        for (int count = 0; count < lcl_regkeyMyKey2.GetValueNames().Length; count++)
        {
          glb_ArrayList.Add(lcl_regkeyMyKey2.GetValueNames().GetValue(count).ToString());
        }
      }
      catch
      { }
      finally
      { }

    }
    public static bool fun_ConvertImageToBytes(string par_strImagePath,
                                     out byte[] Buffer,
                                     ref string par_strError)
    {
      bool lcl_bolRetValue;

      System.IO.FileStream lcl_FileStream = new System.IO.FileStream(par_strImagePath,
                                                                         System.IO.FileMode.Open,
                                                                         System.IO.FileAccess.Read);


      Buffer = null;
      Buffer = new byte[lcl_FileStream.Length];
      try
      {
        lcl_FileStream.Read(Buffer, 0, (int)lcl_FileStream.Length);
        par_strError = "";
        lcl_bolRetValue = true;
      }
      catch (Exception par_expt)
      {
        par_strError = par_expt.Message;
        lcl_bolRetValue = false;
      }
      finally
      {
        lcl_FileStream.Close();
      }
      return lcl_bolRetValue;
    }
    








  }
}
