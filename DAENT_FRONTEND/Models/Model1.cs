namespace DAENT_FRONTEND.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<artikel> artikel { get; set; }
        public virtual DbSet<artikelgruppen> artikelgruppen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<artikel>()
                .Property(e => e.bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<artikel>()
                .Property(e => e.gruppe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<artikel>()
                .Property(e => e.vkpreis)
                .HasPrecision(10, 4);

            modelBuilder.Entity<artikel>()
                .Property(e => e.ekpreis)
                .HasPrecision(10, 4);

            modelBuilder.Entity<artikel>()
                .Property(e => e.hinweis)
                .IsUnicode(false);

            modelBuilder.Entity<artikel>()
                .Property(e => e.inaktivvon)
                .IsUnicode(false);

            modelBuilder.Entity<artikelgruppen>()
                .Property(e => e.artgr)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<artikelgruppen>()
                .Property(e => e.grtext)
                .IsUnicode(false);

            modelBuilder.Entity<artikelgruppen>()
                .HasMany(e => e.artikel)
                .WithRequired(e => e.artikelgruppen)
                .HasForeignKey(e => e.gruppe)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<DAENT_FRONTEND.Models.suche> artgrs { get; set; }
    }
}
