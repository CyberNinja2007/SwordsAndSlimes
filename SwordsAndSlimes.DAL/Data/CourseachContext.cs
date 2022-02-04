using Microsoft.EntityFrameworkCore;
using SwordsAndSlimes.DAL.Models;

#nullable disable

namespace SwordsAndSlimes.DAL.Data
{
    public class CourseachContext : DbContext
    {
        public CourseachContext(DbContextOptions<CourseachContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Battle> Battles { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharactersInDungeon> CharactersInDungeons { get; set; }
        public DbSet<CharactersWeapon> CharactersWeapons { get; set; }
        public DbSet<Dungeon> Dungeons { get; set; }
        public DbSet<DungeonMonster> DungeonMonsters { get; set; }
        public DbSet<DungeonWeapon> DungeonWeapons { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Attack).HasDefaultValueSql("((0))");

                entity.Property(e => e.Class)
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.Property(e => e.Health).HasDefaultValueSql("((0))");

                entity.Property(e => e.Level).HasDefaultValueSql("((0))");

                entity.ToTable("Characters");
            });

            modelBuilder.Entity<Dungeon>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsFixedLength(true);
                
                entity.ToTable("Dungeons");
            });
            
            modelBuilder.Entity<Monster>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Attack).HasDefaultValueSql("((0))");

                entity.Property(e => e.Class)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Health).HasDefaultValueSql("((0))");

                entity.Property(e => e.Level).HasDefaultValueSql("((0))");
                
                entity.ToTable("Monsters");
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Attack).HasDefaultValueSql("((0))");

                entity.Property(e => e.Class)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Level).HasDefaultValueSql("((0))");
                
                entity.ToTable("Weapons");
            });

            modelBuilder.Entity<Battle>(entity =>
            {
                entity.HasKey(e => new { e.CharacterName, e.MonsterName, e.WeaponName });

                entity.Property(e => e.CharacterName).HasMaxLength(255);

                entity.Property(e => e.MonsterName).HasMaxLength(255);

                entity.Property(e => e.WeaponName).HasMaxLength(255);

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Battles)
                    .HasForeignKey(d => d.CharacterName)
                    .HasPrincipalKey(c => c.Name)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(true);

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.Battles)
                    .HasForeignKey(d => d.MonsterName)
                    .HasPrincipalKey(m => m.Name)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(true);

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.Battles)
                    .HasForeignKey(d => d.WeaponName)
                    .HasPrincipalKey(w => w.Name)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(true);
                
                entity.ToTable("Battles");
            });

            modelBuilder.Entity<CharactersInDungeon>(entity =>
            {
                entity.HasKey(e => new { e.DungeonName, e.CharacterName });

                entity.Property(e => e.DungeonName).HasMaxLength(255);

                entity.Property(e => e.CharacterName).HasMaxLength(255);

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharactersInDungeons)
                    .HasForeignKey(d => d.CharacterName)
                    .HasPrincipalKey(c => c.Name)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(true);

                entity.HasOne(d => d.Dungeon)
                    .WithMany(p => p.CharactersInDungeons)
                    .HasForeignKey(d => d.DungeonName)
                    .HasPrincipalKey(d => d.Name)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(true);
                
                entity.ToTable("CharactersInDungeons");
            });

            modelBuilder.Entity<CharactersWeapon>(entity =>
            {
                entity.HasKey(e => new { e.CharacterName, e.WeaponName });

                entity.Property(e => e.CharacterName).HasMaxLength(255);

                entity.Property(e => e.WeaponName).HasMaxLength(255);

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharactersWeapons)
                    .HasForeignKey(d => d.CharacterName)
                    .HasPrincipalKey(c => c.Name)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(true);

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.CharactersWeapons)
                    .HasForeignKey(d => d.WeaponName)
                    .HasPrincipalKey(w => w.Name)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(true);
                
                entity.ToTable("CharactersWeapon");
            });

            modelBuilder.Entity<DungeonMonster>(entity =>
            {
                entity.HasKey(e => new { e.DungeonName, e.MonsterName });

                entity.Property(e => e.DungeonName).HasMaxLength(255);

                entity.Property(e => e.MonsterName).HasMaxLength(255);

                entity.HasOne(d => d.Dungeon)
                    .WithMany(p => p.DungeonMonsters)
                    .HasForeignKey(d => d.DungeonName)
                    .HasPrincipalKey(d => d.Name)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(true);
                
                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.DungeonMonsters)
                    .HasForeignKey(d => d.MonsterName)
                    .HasPrincipalKey(m => m.Name)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(true);
                
                entity.ToTable("DungeonMonsters");
            });

            modelBuilder.Entity<DungeonWeapon>(entity =>
            {
                entity.HasKey(e => new {e.DungeonName, e.WeaponName});

                entity.Property(e => e.DungeonName).HasMaxLength(255);

                entity.Property(e => e.WeaponName).HasMaxLength(255);

                entity.HasOne(d => d.Dungeon)
                    .WithMany(p => p.DungeonWeapons)
                    .HasForeignKey(d => d.DungeonName)
                    .HasPrincipalKey(d => d.Name)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(true);

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.DungeonWeapons)
                    .HasForeignKey(d => d.WeaponName)
                    .HasPrincipalKey(w => w.Name)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(true);
                
                entity.ToTable("DungeonWeapons");
            });
        }
    }
}
