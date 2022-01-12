using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DepartmentEFMvc.Models
{
    public partial class DepartmentContext : DbContext
    {
        public DepartmentContext()
            : base("name=DepartmentContext")
        {
        }
        public virtual  DbSet<Managers> managers  { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
