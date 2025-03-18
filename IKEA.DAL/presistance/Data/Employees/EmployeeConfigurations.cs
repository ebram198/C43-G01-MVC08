using IKEA.DAL.common.Enums;
using IKEA.DAL.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.presistance.Data.Employees
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
builder.Property(E=>E.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Address).HasColumnType("varchar(100)");
            builder.Property(e => e.salary).HasColumnType("decimal(8,2)");
            builder.Property(e => e.Createon).HasDefaultValueSql("GETUTCDATE()");


            #region ENum
            builder.Property(e => e.Gender).HasConversion(

                (gender)=>gender.ToString(),
                (gender)=>(Gender)Enum.Parse(typeof(Gender),gender)
                
                );
            //--------------------------------------------------------------
            builder.Property(e => e.EmployeeType).HasConversion(

          (type) => type.ToString(), // as in in Database
          (type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), type) //As the out of Database

          );
            #endregion

           

        }
    }
}
