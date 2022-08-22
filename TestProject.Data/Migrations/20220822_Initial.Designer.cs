using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Data.Migrations
{
    [DbContext(typeof(ZipCoContext))]
    [Migration("20220822_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestProject.Repositories.Entities.Account", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("AccountNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<int?>("UserId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("Accounts");
            });

            modelBuilder.Entity("TestProject.Repositories.Entities.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("EmailAddess")
                    .HasColumnType("nvarchar(50)");

                b.Property<decimal>("MonthlyExpenses")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("MonthlySalary")
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(50)");

                b.HasKey("Id");

                b.HasIndex("Email")
                    .IsUnique()
                    .HasFilter("[Email] IS NOT NULL");

                b.ToTable("Users");
            });

            modelBuilder.Entity("TestProject.Data.Entities.Account", b =>
            {
                b.HasOne("TestProject.Data.Entities.User", "User")
                    .WithMany()
                    .HasForeignKey("UserId");
            });
#pragma warning restore 612, 618
        }
    }
}