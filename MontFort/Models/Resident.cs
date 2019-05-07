using MontFort.Migrations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Web.Mvc;

namespace MontFort.Models
{
    public class Resident
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de naissance")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "No de dossier")]
        public int FolderNbr { get; set; }

        [Required]
        [Index("RoomIndex", IsUnique = true)]
        /*[Remote("IsRoomAvailable", "Room", AdditionalFields = "ID", 
            ErrorMessage = "Cette chambre contient déjà un résident, veuillez choisir une autre.")]*/
        [Display(Name = "No de la chambre")]
        public int RoomNbr { get; set; }

        [ForeignKey("RoomNbr")]
        public virtual Room Room { get; set; }

        [Range(0, 2)]
        [Display(Name = "En mouvement")]
        public int InMotion { get; set; }

        [Display(Name = "Lieu")]
        public string Place { get; set; }

        [Display(Name = "Mandataire")]
        public string Mandatary { get; set; }

        [Display(Name = "Membres de la famille")]
        public string FamilyMember { get; set; }

        public int getAge()
        {
            int age = @DateTime.Now.Year - BirthDate.Year;
            return age;
        }

        public int Age
        {
            get { return getAge(); }
        }
    }
}