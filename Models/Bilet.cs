using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterclassApp.Auth;
using SQLiteNetExtensions.Attributes;

namespace MasterclassApp.Models
{
    public class Bilet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Tip { get; set; }
        public int Pret { get; set; }    
    }
}
