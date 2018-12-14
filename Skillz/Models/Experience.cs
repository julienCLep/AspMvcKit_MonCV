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

    [Table("Experience")]
    public class Experience : IModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nom de Profession requis")]
        [DisplayName("Profession")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "Nom de l'entreprise requis")]
        [DisplayName("Entreprise")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Lieu de l'entreprise requis")]
        [DisplayName("Lieu")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Date de début requise")]
        [DisplayName("Date de début")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yy}")]
            public DateTime StartDate { get; set; }

            [Required(ErrorMessage = "Date de fin requise")]
            [DisplayName("Date de fin")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime EndDate { get; set; }

            [Required(ErrorMessage = "Details de l'experience requis")]
            [DisplayName("Details")]
            [StringLength(255)]
            public string Details { get; set; }


            public Experience(){}

            public void UpdateFrom(IModel source)
            {
                if (source is Experience exp && exp.Id == Id)
                {
                    this.Profession = exp.Profession;
                    this.StartDate = exp.StartDate;
                    this.EndDate = exp.EndDate;
                    this.Details = exp.Details;
                this.Location = exp.Location;
                this.Company = exp.Company;
                }
            }

            public double Duration()
            {
                TimeSpan t = StartDate.Subtract(EndDate);
                return t.TotalDays / 365;
            }
        }
    }
