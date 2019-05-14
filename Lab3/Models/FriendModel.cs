using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class FriendModel
    {
        [Required]
        [Range(0, 200, ErrorMessage = "ID treba da e broj pomegju 0 i 200")]
        [Display (Name ="Friend ID")]
        public int id { set; get; } // ZA DA FUNKCIONIRA EDITFRIEND MORA ID-TO NA OBJEKTOT DA E UNIKATNO
        [Required]
        [Display(Name = "Friend Name")]
        public String ime { get; set; }
        [Required]
        [Display(Name = "Place")]
        public String mestoNaZiveenje { get; set; }
    }
}