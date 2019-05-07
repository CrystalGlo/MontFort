using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MontFort.Models
{
    public class Room
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name ="No de la chambre")]             // , AutoGenerateField = false
        public int RoomNbr { get; set; }

        [Display(Name = "Porte de la chambre ouverte")]
        public int IsRoomDoorOpen { get; set; }

        [Display(Name = "Porte de la salle de bain ouverte")]
        public int IsBathroomDoorOpen { get; set; }

        [Display(Name = "Détecteur de fumée actif")]
        public int IsSmokeDetectorActive { get; set; }

        [Display(Name = "Valeur maximale de la fumée")]
        public decimal MaxSmokeValue { get; set; }

        [Display(Name = "Valeur actuelle de la fumée")]
        public decimal ActualSmokeValue { get; set; }

        [Display(Name = "Niveau actuel d'humidité")]
        public decimal ActualHumidityLevel { get; set; }

        [Display(Name = "Valeur maximale d'humidité")]
        public decimal MaxHumidityValue { get; set; }

        [Display(Name = "Valeur actuelle de la température")]
        public decimal ActualTempreatureValue { get; set; }

        [Display(Name = "Valeur maximale de la température")]
        public decimal MaxTempreatureValue { get; set; }

        [Display(Name = "Position du rideau")]
        [Range(0, 10)]
        public int ActualBrightnessValue { get; set; }

        [Display(Name = "Alarme en cours")]
        public int AlarmInProgress { get; set; }

        [Display(Name = "Lumière 1 active")]
        public int IsLight1Active { get; set; }

        [Display(Name = "Lumière 2 active")]
        public int IsLight2Active { get; set; }

        [Display(Name = "Module 1 présent")]
        public int IsModule1Present { get; set; }

        [Display(Name = "Module 2 présent")]
        public int IsModule2Present { get; set; }

    }
}