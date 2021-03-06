// <auto-generated />
using BabyApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BabyApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("BabyApp.Models.Ninni", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Age")
                        .HasColumnType("REAL");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("ninnis");
                });

            modelBuilder.Entity("BabyApp.Models.PosSD2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Age")
                        .HasColumnType("REAL");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("posSD2s");
                });
#pragma warning restore 612, 618
        }
    }
}
