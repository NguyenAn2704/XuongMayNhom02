using Microsoft.EntityFrameworkCore;

namespace XuongMay_Nhom2.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProductionLine> ProductionLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(c => c.CategoryId);
                e.Property(c => c.CategoryName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Product");
                e.HasKey(p => p.ProductId);
                e.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
                e.Property(p => p.Price).IsRequired();
                e.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("Role");
                e.HasKey(r => r.RoleId);
                e.Property(r => r.RoleName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.ToTable("Employee");
                e.HasKey(e => e.EmployeeId);
                e.Property(e => e.EmployeeName).IsRequired().HasMaxLength(50);
                e.Property(e => e.Gender).HasMaxLength(3).HasDefaultValue("Nam");
                e.Property(e => e.PhoneNumber).HasMaxLength(10);
                e.Property(e => e.Address).HasMaxLength(100);
                e.Property(e => e.Email).HasMaxLength(50);
                e.Property(e => e.UserName).IsRequired(false);
                e.Property(e => e.Password).IsRequired(false);
                e.HasOne(e => e.Role).WithMany(r => r.Employees).HasForeignKey(e => e.RoleId);
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.OrderId);

                e.Property(o => o.OrderDate).IsRequired();
                e.Property(o => o.DeliveryDeadline).IsRequired();
                e.Property(o => o.Unitprice).IsRequired();
                e.Property(o => o.Quantity).IsRequired();
                e.Property(o => o.ProductId).IsRequired();


                e.Property(o => o.Status).HasDefaultValue(0);
                e.Property(o => o.TotalAmount).IsRequired();



                e.HasOne(o => o.Product).WithMany(e => e.Orders).HasForeignKey(o => o.ProductId);
            });


            modelBuilder.Entity<ProductionLine>(e =>
            {
                e.ToTable("ProductionLine");
                e.HasKey(pl => pl.ProductionLineId);
                e.Property(pl => pl.ProductionLineName).IsRequired().HasMaxLength(50);
                e.HasOne(pl => pl.Employee).WithMany(e => e.ProductionLines).HasForeignKey(pl => pl.EmployeeId);
            });

            modelBuilder.Entity<Task>(e =>
            {
                e.ToTable("Task");
                e.HasKey(t => t.TaskId);
                e.Property(t => t.TaskName).IsRequired().HasMaxLength(100);
                e.Property(t => t.StartDate).IsRequired();
                e.Property(t => t.EndDate).IsRequired();
                e.Property(t => t.Quantity).IsRequired();
                e.Property(t => t.ProductionLineId).IsRequired();
                e.Property(t => t.OrderId).IsRequired();

                e.HasOne(t=>t.ProductionLine).WithMany(pl=>pl.Tasks).HasForeignKey(t => t.ProductionLineId);
                e.HasOne(t=>t.Order).WithMany(pl=>pl.Tasks).HasForeignKey(t=>t.OrderId);
            });
        }

    }
}
