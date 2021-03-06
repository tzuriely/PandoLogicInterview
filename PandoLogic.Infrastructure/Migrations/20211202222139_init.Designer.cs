// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PandoLogic.Infrastructure.Data;

namespace PandoLogic.Infrastructure.Migrations
{
    [DbContext(typeof(PandoLogicContext))]
    [Migration("20211202222139_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PandoLogic.Domain.Day", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("ActiveJobs")
                        .HasColumnType("bigint");

                    b.Property<long>("CumulativePredicted")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalViews")
                        .HasColumnType("bigint");

                    b.HasKey("Date");

                    b.ToTable("Dates");
                });
#pragma warning restore 612, 618
        }
    }
}
