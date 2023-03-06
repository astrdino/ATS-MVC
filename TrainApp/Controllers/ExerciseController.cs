using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainApp.Data_Access_Layer;
using TrainApp.Models;


namespace TrainApp.Controllers
{
    public class ExerciseController : Controller
    {

        Exercise_DAL _exerciseDAL = new Exercise_DAL();

        

        // GET: Exercise
        public ActionResult Index()
        {
            var exerciseList = _exerciseDAL.GetAllUpperBodyExercise();           

            if (exerciseList.Count > 0)
            {

                //TempData["InfoMessage"] = "Available in the database";

            }





            return View(exerciseList);
        }

 
        public ActionResult Fetch_UpBody()
        {
            var exerciseList = _exerciseDAL.GetAllUpperBodyExercise();
            return View(exerciseList);
        }

        public ActionResult Fetch_LowBody()
        {
            var exerciseList = _exerciseDAL.GetAllLowerBodyExercise();
            return View(exerciseList);
        }

        // GET: Exercise/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Exercise/Create
        //Access Page "Create"
        public ActionResult Create()
        {
            
            //Initialize Item list for Dropdown List
            List<SelectListItem> Exercise_Type_List = new List<SelectListItem>();
            Exercise_Type_List.Add(new SelectListItem() { Text = "Upper Body", Value = "Upper Body"});
            Exercise_Type_List.Add(new SelectListItem() { Text = "Lower Body", Value = "Lower Body" });


            ViewData["ExerciseType_ViewData"] = Exercise_Type_List;

            return View();
        }

  

        // POST: Exercise/Create
        [HttpPost]
        public ActionResult Create(WeightExercise weightExercise)
        {
            //System.Diagnostics.Debug.WriteLine("++++++++++++++{0}",weightExercise.ExerciseType.Any(x=> x.Equals("Upper Body")));



            try
            {
                bool isInserted = false;
                if (ModelState.IsValid)
                {
               
                    if(weightExercise.ExerciseType.Any(x => x.Equals("Upper Body")))
                    {   
                        //Add to Upper Body List
                        isInserted = _exerciseDAL.Add_Exercise(weightExercise);
                    }
                    else if (weightExercise.ExerciseType.Any(x => x.Equals("Lower Body")))
                    {
                        //Add to Lower Body List
                        isInserted = _exerciseDAL.Add_LB_Exercise(weightExercise);
                    }


                    //System.Diagnostics.Debug.WriteLine("++++++++++++++{0}",isInserted);

                    if (isInserted)
                    {
                        TempData["SuccessMessage"] = "Saved!";
                        
                    }
                    else
                    {
                        TempData["FailMessage"] = "Failed!";
                    }

                  

                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["FailMessage"] = ex.Message;
                return View();
            }
        }

      

        // GET: Exercise/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Exercise/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Exercise/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Exercise/Delete/5
        [HttpPost]
        public ActionResult Delete(WeightExercise weightExercise)
        {
            try
            {
                bool isDeleted = false;
                if (ModelState.IsValid)
                {
                    System.Diagnostics.Debug.WriteLine("++++++++++++++{0}", weightExercise.ExerciseType);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
