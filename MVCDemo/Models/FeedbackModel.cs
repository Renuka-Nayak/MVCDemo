using MVCDemo.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class FeedbackModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int IDANumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Grade { get; set; }

        public string SaveFeedback(FeedbackModel model)
        {
            string msg = "Add details";
            MVCDemoEntities db = new MVCDemoEntities();
            if (model.Id == 0)
            {
                var FeedbackData = new tblFeedback()
                {
                    Id= model.Id,
                    Name = model.Name,
                    Number = model.Number,
                    IDANumber = model.IDANumber,
                    Address = model.Address,
                    Email = model.Email,
                    Grade = model.Grade,

                };
                db.tblFeedbacks.Add(FeedbackData);
                db.SaveChanges();
                msg = "Data Saved";
            }
            else
            {
                var FeedbackData = db.tblFeedbacks.Where(p => p.Id == model.Id).FirstOrDefault();
                if (FeedbackData != null)
                {
                    FeedbackData.Id = model.Id;
                    FeedbackData.Name = model.Name;
                    FeedbackData.Number = model.Number;
                    FeedbackData.IDANumber = model.IDANumber;
                    FeedbackData.Address = model.Address;
                    FeedbackData.Email = model.Email;
                    FeedbackData.Grade = model.Grade;
                };
                db.SaveChanges();
                msg = "Updated Successfully";

            }

            return msg;
            

        }
        public List<FeedbackModel> Feedbacklist()
        {
            MVCDemoEntities db = new MVCDemoEntities();
            List<FeedbackModel> LstFeedback = new List<FeedbackModel>();
            var FeedbackData = db.tblFeedbacks.ToList();
            {
                if (FeedbackData != null)
                {
                    foreach (var Feedback in FeedbackData)
                    {
                        LstFeedback.Add(new FeedbackModel()
                        {
                            Id = Feedback.Id,
                            Name = Feedback.Name,
                            Number = Feedback.Number,
                            IDANumber = Feedback.IDANumber,
                            Address = Feedback.Address,
                            Email = Feedback.Email,
                            Grade = Feedback.Grade,
                        });
                    }

                }
                return LstFeedback;

            }
        }

        //List using store procedure select query

        //public List<FeedbackModel> Feedbacklist(string search)
        //{
        //    List<FeedbackModel> lstFeedback = new List<FeedbackModel>();

        //    string connstring = ConfigurationManager.ConnectionStrings["dbConnection"].ToString();
        //    SqlConnection sqlConnection = new SqlConnection();
        //    sqlConnection = new SqlConnection(connstring);
        //    SqlCommand cmd = sqlConnection.CreateCommand();
        //    cmd.CommandText = "usp_Feedback";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        lstFeedback.Add(new FeedbackModel()
        //        {

        //            Id = Convert.ToInt32(rdr["ID"]),
        //            Name = Convert.ToString(rdr["Name"]),
        //            Number = Convert.ToInt32(rdr["Number"]),
        //            IDANumber = Convert.ToInt32(rdr["IDANumber"]),
        //            Address = Convert.ToString(rdr["Address"]),
        //            Email = Convert.ToString(rdr["Email"]),
        //            Grade = Convert.ToInt32(rdr["Grade"]),
        //        });
        //    }
        //    return lstFeedback;
        //}


        public string DeleteFeedbackData(int Id)
        {
            string msg = "";
            MVCDemoEntities db = new MVCDemoEntities();
            var FeedbackData = db.tblFeedbacks.Where(p => p.Id == Id).FirstOrDefault();
            if (FeedbackData != null)
            {
                db.tblFeedbacks.Remove(FeedbackData);

            };
            db.SaveChanges();
            msg = "Feedback Deleted";
            return msg;
        }

        public FeedbackModel GetbyIdFeedback(int Id)
        {
            string msg = "";
            FeedbackModel model = new FeedbackModel();
            MVCDemoEntities db = new MVCDemoEntities();
            var FeedbackData = db.tblFeedbacks.Where(p => p.Id == Id).FirstOrDefault();
            if (FeedbackData != null)
            {
                model.Id = FeedbackData.Id;
                model.Name = FeedbackData.Name;
                model.Number = FeedbackData.Number;
                model.IDANumber = FeedbackData.IDANumber;
                model.Address = FeedbackData.Address;
                model.Email = FeedbackData.Email;
                model.Grade = FeedbackData.Grade;



            }
            return model;
        }
    }
}