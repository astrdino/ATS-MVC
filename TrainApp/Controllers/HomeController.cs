using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainApp.Models;

namespace TrainApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.test = "Global Home Page Login Please";

            return View();
        }


        public ActionResult GetWeightExercise()
        {

            List<WeightExercise> weightExerciseList = new List<WeightExercise>()
            {


                new WeightExercise()
                {
                    ExerciseName = "Bench Press",
                    Weight = 35,
                    Rep = 8,
                    Set = 4
                },

                new WeightExercise()
                {
                    ExerciseName = "Incline Bench Press",
                    Weight = 35,
                    Rep = 8,
                    Set = 4
                }

                

            };


            ViewBag.weightExerciseList = weightExerciseList;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}