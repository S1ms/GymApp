using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GymApp.Models
{
    public partial class Sali
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Reps { get; set; }
        public int? Sets { get; set; }     
        public DateTime? Date { get; set; }
    }
}
