using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainApp.Models
{
    public class WeightExercise
    {

        public List<String> ExerciseType { get; set; }

        [Required]
        [DisplayName("Exercise Name")]
        public string ExerciseName { get; set; }


        public int Weight { get; set; }

        [Required]
        public int Rep { get; set; }

        [Required]
        public int Set { get; set; }

        [Key]
        public int Id { get; set; }

        
    }
}