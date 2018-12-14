using Skillz.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Skillz.Models
{
    [Table("Formations")]
    public class Formation : IModel
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Titre du diplôme requis")]
        [DisplayName("titre du diplôme")]
        public string Etude { get; set; }

        [Required(ErrorMessage = "Type de diplçome requis")]
        [DisplayName("Niveau d'étude")]
        public string Niveau { get; set; }

        [Required(ErrorMessage = "Nom de l'etablissement requis")]
        [DisplayName("Etablissement")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Lieu de l'etablissement requis")]
        [DisplayName("Lieu")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Date de l'obtention requise")]
        [DisplayName("Année d'obtention")]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Details de l'experience requis")]
        [DisplayName("Details")]
        [StringLength(255)]
        public string Details { get; set; }


        public Formation() { }

        public void UpdateFrom(IModel source)
        {
            if (source is Formation forma && forma.Id == Id)
            {
                this.Niveau = forma.Niveau;
                this.Etude = forma.Etude;
                this.Date = forma.Date;
                this.Details = forma.Details;
                this.Location = forma.Location;
                this.Company = forma.Company;
            }
        }
    }
}