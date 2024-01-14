using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MasterclassApp.Models
{
    public class Curs
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Locatie { get; set; }
        public DateTime Date { get; set; }
    }
}
