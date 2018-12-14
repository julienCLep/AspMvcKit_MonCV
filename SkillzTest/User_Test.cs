using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skillz.Db;
using Skillz.Models;

namespace SkillzTest
{
    [TestClass]
    public class User_Test
    {
        [TestMethod]
        public void Test_Connexion_DB()
        {
            Dal db = Dal.DatabaseContext;

            Assert.IsNotNull(db);
        }

        [TestMethod]
        public void Test_DbSet_Users()
        {

            Dal db = Dal.DatabaseContext;
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Users");

            User UserTest = new User()
            {
                Username = "guizmo",
                Email = "bbb@bbb.fr",
                Password = "123445678910"
            };

            db.DbUsers.Add(UserTest);
            Dal.Save();
            User userDB = db.DbUsers.Find(1);
            Assert.IsNotNull(userDB);
            Assert.AreEqual("guizmo", userDB.Username);
        }  
        [TestMethod]
            public void Test_Repository()
            {

            // Dal.DatabaseContext.Database.ExecuteSqlCommand("TRUNCATE TABLE Users");

            //    User userTest = new User()
            //    {
            //        Username = "tonton",
            //        Email = "bbb@bbb.fr",
            //        Password = "123445678910"
            //    };

            //Dal.Users.Insert(userTest);
            //Dal.Save();
            Experience e = new Experience()
            {
                Profession = "Eboueur",
                Company = "CacaRudyCorporation",
                Location = "Crepy",
                StartDate = new DateTime(1995, 04, 15),
                EndDate = new DateTime(2018, 03, 15),
                Details = "Enculeur de mouches"
            };
            Dal.Experiences.Insert(e);
            Dal.Save();
            }


    }
}
