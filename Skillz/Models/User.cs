using Skillz.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skillz.Models
{

        [Table("Users")]
        public class User : IModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Nom d'utilisation requis")]
            [DisplayName("Nom d'utilisateur")]

            public string Username { get; set; }

            [Required(ErrorMessage = "Adresse email requise")]
            [DisplayName("Adresse Email")]
            [StringLength(64, ErrorMessage ="dépassement non autorisé")]
            [EmailAddress(ErrorMessage ="invalide")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Mot de passe")]
            [DisplayName("mot de passe")]
            [MinLength(8)]
            [MaxLength(64)]
            [PasswordPropertyText]
            public string Password { get; set; }

            [NotMapped]
            [HiddenInput(DisplayValue = false)]
            public bool IsAuthenticated { get; set; } = false;

            public User()
            { }

            public void UpdateFrom(IModel source)
            {
                if (source is User user && user.Id == Id)
                {
                    this.Username = user.Username;
                    this.Email = user.Email;
                }

            }
            //}
            //public int Id { get; set; }

            //public string Username { get; set; }

            //public string Lastname { get; set; }

            //public string Email { get; set; }

            //public string Firstname { get; set; }

            //public string Password { get; set; }



            //public void Copy(User user)
            //{
            //    this.Username = user.Username;
            //    this.Email = user.Email;
            //    this.Password = user.Password;
            //    this.Lastname = user.Lastname;
            //    this.Firstname = user.Firstname;
            //}
        }
    
}