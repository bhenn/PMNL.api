using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PMNL.api;

namespace PMNL.api.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20171118164901_doublepoints22")]
    partial class doublepoints22
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PMNL.api.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Buyinns");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<bool>("DoublePoints");

                    b.Property<int>("Rebuys");

                    b.Property<int>("TournamentId");

                    b.Property<decimal>("ValueTotal");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("PMNL.api.Models.GameResults", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<int>("Order");

                    b.Property<int>("Points");

                    b.Property<int>("Rebuys");

                    b.Property<int>("TournamentPlayerId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("TournamentPlayerId");

                    b.ToTable("GameResults");
                });

            modelBuilder.Entity("PMNL.api.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("PMNL.api.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("PMNL.api.Models.TournamentPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerId");

                    b.Property<int>("Points");

                    b.Property<int>("TournamentId");

                    b.Property<int>("Wins");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentsPlayers");
                });

            modelBuilder.Entity("PMNL.api.Models.Game", b =>
                {
                    b.HasOne("PMNL.api.Models.Tournament", "Tournament")
                        .WithMany("Games")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMNL.api.Models.GameResults", b =>
                {
                    b.HasOne("PMNL.api.Models.Game", "Game")
                        .WithMany("GamesResults")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMNL.api.Models.TournamentPlayer", "TournamentPlayer")
                        .WithMany()
                        .HasForeignKey("TournamentPlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMNL.api.Models.TournamentPlayer", b =>
                {
                    b.HasOne("PMNL.api.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMNL.api.Models.Tournament", "Tournament")
                        .WithMany("TournamentPlayers")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
