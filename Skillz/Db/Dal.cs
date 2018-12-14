using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Skillz.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Skillz.Db;
using System.Web.Mvc;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Skillz.Db
{
   
    public class Dal : DbContext
    {
        public DbSet<User> DbUsers { get; set; }// Déclaration de la table User dans le DAL

        public DbSet<Experience> DbExperience { get; set; } //declaration de la table Experience dans le DAL

        public DbSet<Formation> DbFormation { get; set; }

        protected static Dal _context;

        //Creation d'une nouvelle instance de repository qui prendre User comme type
        public static Repository<User> Users { get; protected set; } = new Repository<User>(DatabaseContext);
        
        //Creation d'une nouvelle instance de repository qui prendra Experience comme type
        public static Repository<Experience> Experiences { get; protected set; } = new Repository<Experience>(DatabaseContext);

        public static Repository<Formation> forma { get; protected set; } = new Repository<Formation>(DatabaseContext);

        public static Dal DatabaseContext //fournit le chemin d'accés
        {
            get
            {
                if (_context == null)
                {
                    _context = new Dal("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=SkillzDb;integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFrameworkMUE");
                        
                }
                return _context;
            }
        }

        public static void Save()
        {
            DatabaseContext.SaveChanges();
        }

        protected Dal(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Dal>());
        }

    }
}