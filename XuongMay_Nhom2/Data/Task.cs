using Microsoft.CodeAnalysis;
using System.Threading.Tasks;

namespace XuongMay_Nhom2.Data
{
    public class Task
    {
        public int TaskId {  get; set; }    
        public string  TaskName {  get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; } 
        public int ProductionLineId { get; set; }
        public int OrderId { get; set; }
        public virtual ProductionLine ProductionLine { get; set; }
        public virtual Order Order { get; set; }
    }
}
