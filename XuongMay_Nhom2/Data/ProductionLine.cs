namespace XuongMay_Nhom2.Data
{
    public class ProductionLine
    {
        public int ProductionLineId {  get; set; }
        public string ProductionLineName { get; set; }
        public int NumOfEmployees { get; set;}
        public int EmployeeId { get;set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
