namespace XuongMay_Nhom2.Data
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
