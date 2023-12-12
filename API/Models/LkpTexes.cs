namespace FocusERP_API.Models
{
  public class LkpTaxes
  {
    public string taxid { get; set; }
    public string taxname { get; set; }
    public string taxtype { get; set; }
    public decimal taxper { get; set; }
    public string taxgcode { get; set; }
    public string compcode { get; set; }
    public string userid { get; set; }
    public DateTime modifieddate { get; set; }

  }
}
