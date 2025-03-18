using IKEA.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.presistance.Data.Configurations.Departments
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(d => d.code).HasColumnType("varchar(50)").IsRequired();
            builder.Property(d => d.Createon).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(d => d.LastModificationOn).HasComputedColumnSql("GETDATE()");



            #region For Work Relationship
           builder.HasMany(d=>d.Employees).WithOne(e=>e.Department).HasForeignKey(e=>e.DepartmentId).OnDelete(DeleteBehavior.SetNull);
            #endregion


        }

    }
}
