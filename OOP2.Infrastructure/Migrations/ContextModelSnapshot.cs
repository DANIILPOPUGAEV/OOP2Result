// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OOP2.Infrastructure.Data;

#nullable disable

namespace OOP2.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookWriter", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WritersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BooksId", "WritersId");

                    b.HasIndex("WritersId");

                    b.ToTable("BookWriter");
                });

            modelBuilder.Entity("OOP2.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WriterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("OOP2.Domain.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("WriterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WriterId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("OOP2.Domain.Writer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Writers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("60b5b2e2-9d5c-4d77-95f5-83560e3c246b"),
                            Name = "Антон",
                            Patronymic = "Павлович",
                            SecondName = "Чехов"
                        },
                        new
                        {
                            Id = new Guid("5f5f1688-6379-441b-9ed3-66a9b1a0b10a"),
                            Name = "Фёдор",
                            Patronymic = "Михайлович",
                            SecondName = "Достоевский"
                        });
                });

            modelBuilder.Entity("BookWriter", b =>
                {
                    b.HasOne("OOP2.Domain.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OOP2.Domain.Writer", null)
                        .WithMany()
                        .HasForeignKey("WritersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OOP2.Domain.Book", b =>
                {
                    b.HasOne("OOP2.Domain.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("OOP2.Domain.Genre", b =>
                {
                    b.HasOne("OOP2.Domain.Writer", null)
                        .WithMany("Genres")
                        .HasForeignKey("WriterId");
                });

            modelBuilder.Entity("OOP2.Domain.Writer", b =>
                {
                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
