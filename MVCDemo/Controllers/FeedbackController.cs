using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MVCDemo.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexBoostrap()
        {
            return View();
        }

        public ActionResult DetailIndex(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        
        public ActionResult SaveFeedback(FeedbackModel model)
        {
            try
            {
                return Json(new { Message = new FeedbackModel().SaveFeedback(model) }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ListFeedback()
        {
            try
            {
                return Json(new { Message = new FeedbackModel().Feedbacklist() }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteFeedback(int Id)
        {
            try
            {
                return Json(new { model = new FeedbackModel().DeleteFeedbackData(Id) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult GetbyIdFeedback(int Id)
        {
            try
            {
                return Json(new { model = (new FeedbackModel().GetbyIdFeedback(Id)) },JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetDetails(int Id)
        {
            try
            {
                return Json(new { model = (new FeedbackModel().GetbyIdFeedback(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}