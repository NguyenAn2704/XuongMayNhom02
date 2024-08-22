namespace XuongMay_Nhom2.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public int ProductionLineId { get; set; }
        public int OrderId { get; set; }
    }
}
