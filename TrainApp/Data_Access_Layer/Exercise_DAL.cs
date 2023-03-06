using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TrainApp.Models;

namespace TrainApp.Data_Access_Layer
{
    public class Exercise_DAL
    {

        string conString = ConfigurationManager.ConnectionStrings["ecs"].ToString();

        //Get All Upper Body Exercise
        public List<WeightExercise> GetAllUpperBodyExercise()
        {
            List<WeightExercise> we_List = new List<WeightExercise>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc_GetAllUpperExercise"; //Sql stored procedure name
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtExercises = new DataTable();

                con.Open();
                sqlDA.Fill(dtExercises);
                con.Close();

                //Mapping Fetch Table to the instance
                foreach (DataRow dr in dtExercises.Rows)
                {
                    we_List.Add(new WeightExercise
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        ExerciseName = dr["Name"].ToString(),
                        Weight = Convert.ToInt32(dr["Weight"]),
                        Rep = Convert.ToInt32(dr["Repe"]),
                        Set = Convert.ToInt32(dr["Sets"])

                    });

                }


            }

            return we_List;
        }

        public List<WeightExercise> GetAllLowerBodyExercise()
        {
            List<WeightExercise> we_List = new List<WeightExercise>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc_GetAllLowerExercise"; //Sql stored procedure name
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtExercises = new DataTable();

                con.Open();
                sqlDA.Fill(dtExercises);
                con.Close();

                //Mapping Fetch Table to the instance
                foreach (DataRow dr in dtExercises.Rows)
                {
                    we_List.Add(new WeightExercise
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        ExerciseName = dr["Name"].ToString(),
                        Weight = Convert.ToInt32(dr["Weight"]),
                        Rep = Convert.ToInt32(dr["Repe"]),
                        Set = Convert.ToInt32(dr["Sets"])

                    });

                }


            }

            return we_List;
        }



        public List<WeightExercise> GetSingleExercise(WeightExercise exercise)
        {
            List<WeightExercise> we_List = new List<WeightExercise>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc_Find_Single_Exercise"; //Sql stored procedure name

                cmd.Parameters.AddWithValue("@Name", exercise.ExerciseName);

                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtExercises = new DataTable();


                

                con.Open();
                sqlDA.Fill(dtExercises);
                con.Close();

                //Mapping Fetch Table to the instance
                foreach (DataRow dr in dtExercises.Rows)
                {
                    we_List.Add(new WeightExercise
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        ExerciseName = dr["Name"].ToString(),
                        Weight = Convert.ToInt32(dr["Weight"]),
                        Rep = Convert.ToInt32(dr["Repe"]),
                        Set = Convert.ToInt32(dr["Sets"])

                    });

                }


            }

            return we_List;
        }




        public bool Add_Exercise(WeightExercise exercise)
        {
            int check = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("proc_InsertExercise"); //Sql stored procedure name
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = con;
               
               

                //Insert
                cmd.Parameters.AddWithValue("@Name", exercise.ExerciseName);
                cmd.Parameters.AddWithValue("@Repe", exercise.Rep);
                cmd.Parameters.AddWithValue("@Sets", exercise.Set);
                cmd.Parameters.AddWithValue("@Weight", exercise.Weight);
                cmd.Parameters.AddWithValue("@ID", exercise.Id);



                try
                {
                    con.Open();

                    check = cmd.ExecuteNonQuery(); 
                }
                catch(SqlException ex)
                {
                   
                }

               
                con.Close();

                

                if (check >= 0)
                {
                   
                    return true;
                }
                else
                {
                    return false;
                }



                







            }
           
        }

        public bool Add_LB_Exercise(WeightExercise exercise)
        {
            int check = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("proc_Insert_LB_Exercise"); //Sql stored procedure name
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = con;



                //Insert
                cmd.Parameters.AddWithValue("@Name", exercise.ExerciseName);
                cmd.Parameters.AddWithValue("@Repe", exercise.Rep);
                cmd.Parameters.AddWithValue("@Sets", exercise.Set);
                cmd.Parameters.AddWithValue("@Weight", exercise.Weight);
                cmd.Parameters.AddWithValue("@ID", exercise.Id);



                try
                {
                    con.Open();

                    check = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {

                }


                con.Close();



                if (check >= 0)
                {

                    return true;
                }
                else
                {
                    return false;
                }











            }

        }

        public bool Delete_UB_Exercise(WeightExercise exercise)
        {
            int check = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("proc_delete_UB_Exercise"); //Sql stored procedure name
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = con;



                //Insert Value into Command
                cmd.Parameters.AddWithValue("@Name", exercise.ExerciseName);

                try
                {
                    con.Open();

                    check = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {

                }


                con.Close();



                if (check >= 0)
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
    }
}