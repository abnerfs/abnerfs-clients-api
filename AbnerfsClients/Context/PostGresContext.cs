using AbnerfsClients.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AbnerfsClients.Context
{
    public class PostGresContext : DbContext
    {
        public DbSet<Plugins> Plugins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Purchases> Purchases { get; set; }


        public PostGresContext(DbContextOptions<PostGresContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            #region Plugins
            var PluginBuilder = modelBuilder.Entity<Plugins>();
            PluginBuilder
                .HasKey(x => x.Id);

            PluginBuilder
                .Property(x => x.Id)
                .HasIdentityOptions();

            PluginBuilder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            PluginBuilder
                .Property(x => x.Description)
                .IsRequired();

            PluginBuilder
                .Property(x => x.Price)
                .IsRequired();

            PluginBuilder
                .Property(x => x.RegisterDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);
            #endregion


            #region Clients
            var ClientBulder = modelBuilder.Entity<Client>();
            ClientBulder
                .HasKey(x => x.Id);

            ClientBulder
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            ClientBulder
                .Property(x => x.Email)
                .HasMaxLength(200)
                .IsRequired();

            ClientBulder
                .Property(x => x.RegisterDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);
            #endregion

            #region Purchases
            var PurchaseBuilder = modelBuilder.Entity<Purchases>();
            PurchaseBuilder
                .Property(x => x.PurchasedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            PurchaseBuilder
                .HasKey(x => new { x.ClientID, x.PluginID });

            PurchaseBuilder
                .HasOne(x => x.Client)
                .WithMany(x => x.Purchases)
                .HasForeignKey(x => x.ClientID);

            PurchaseBuilder
                .HasOne(x => x.Plugin)
                .WithMany(x => x.Purchases)
                .HasForeignKey(x => x.PluginID);
            #endregion
        }


    }
}
