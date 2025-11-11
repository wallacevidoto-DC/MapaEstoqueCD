using MapaEstoqueCD.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace MapaEstoqueCD.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db_dc.db").EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // -------------------- ENDERECO --------------------
            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.EnderecoId).IsUnique();

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.EnderecoId)
                      .HasColumnName("enderecoId")
                      .IsRequired();

                entity.Property(e => e.Rua).HasColumnName("rua");
                entity.Property(e => e.Coluna).HasColumnName("coluna");
                entity.Property(e => e.Palete).HasColumnName("palete");
            });


            // -------------------- PRODUTOS --------------------
            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(p => p.ProdutoId);

                entity.Property(p => p.CreateAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasMany(p => p.Estoque)
                      .WithOne(e => e.Produto)
                      .HasForeignKey(e => e.ProdutoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.Movimentacao)
                      .WithOne(m => m.Produto)
                      .HasForeignKey(m => m.ProdutoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // -------------------- USERS --------------------
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

                entity.Property(u => u.CreateAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasMany(u => u.Movimentacoes)
                      .WithOne(m => m.User)
                      .HasForeignKey(m => m.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // -------------------- ESTOQUE --------------------
            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.HasKey(e => e.EstoqueId);

                entity.Property(e => e.CreateAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdateAt);

                entity.HasOne(e => e.Endereco)
                       .WithMany(end => end.Estoque)
                       .HasForeignKey(e => e.EnderecoId)
                       .HasPrincipalKey(end => end.EnderecoId);


                entity.HasOne(e => e.Produto)
                      .WithMany(p => p.Estoque)
                      .HasForeignKey(e => e.ProdutoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Movimentacoes)
                      .WithOne(m => m.Estoque)
                      .HasForeignKey(m => m.EstoqueId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // -------------------- MOVIMENTACOES --------------------
            modelBuilder.Entity<Movimentacao>(entity =>
            {
                entity.HasKey(m => m.MovimentacaoId);

                entity.Property(m => m.CreateAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(m => m.Estoque)
                      .WithMany(e => e.Movimentacoes)
                      .HasForeignKey(m => m.EstoqueId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Produto)
                      .WithMany(p => p.Movimentacao)
                      .HasForeignKey(m => m.ProdutoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.User)
                      .WithMany(u => u.Movimentacoes)
                      .HasForeignKey(m => m.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }


       


    }
}
