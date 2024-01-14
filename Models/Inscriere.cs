using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterclassApp.Models
{
    public class Inscriere
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Required(ErrorMessage = "Clientul este obligatoriu.")]
        [Display(Name = "Client")]
        public int ClientID { get; set; }

        [Required(ErrorMessage = "Bilet este obligatorie.")]
        [Display(Name = "Bilet")]
        public int BiletID { get; set; }

        [Required(ErrorMessage = "Curs este obligatorie.")]
        [Display(Name = "Curs")]
        public int CursID { get; set; }
    }
}
