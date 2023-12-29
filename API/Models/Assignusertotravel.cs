namespace API.Models
{
    public class Assignusertotravel
    {
        public int? recid { get; set; }
        public string? username { get; set; }
        public string? userID { get; set; }
        public string? fullName { get; set; }
        public string? area { get; set; }
        public string? sub_Area { get; set; }
        public string? travlID { get; set; }
        public string? fromdate { get; set; }
        public string? todate { get; set; }
        public string? endStatus { get; set; }
        public string? homeID { get; set; }
        public string? home_name { get; set; }
        public string? location { get; set; }
        public string? status { get; set; }
        public string? modifDate { get; set; }
        public string? Notes { get; set; }

    }

    public class Assignusertotravelupdate
    {
        public int? recid { get; set; }
        public string? status { get; set; }
        public string? Notes { get; set; }

    }
}
