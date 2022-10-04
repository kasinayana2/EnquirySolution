using EnquiryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnquiryProject.Controllers
{
    public class EnquiryController : Controller
    {
        EnquiryDb enDb = new EnquiryDb();
        public ActionResult Index()
        {
            List<Enquiry> lstEnquiry = new List<Enquiry>();
            lstEnquiry = enDb.ListAll();
            return View(lstEnquiry);
        }
        public ActionResult Create()
        {
            ViewBag.genderddl = enDb.GetGenderDropDown();
            ViewBag.Referenceddl = enDb.GetReferenceDropDown();

            return View();
        }
        public ActionResult Add(Enquiry en)
        {
            enDb.Add(en);
            List<Enquiry> lstEnquiry = new List<Enquiry>();
            lstEnquiry = enDb.ListAll();
            return View("Index", lstEnquiry);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.genderddl = enDb.GetGenderDropDown();
            ViewBag.Referenceddl = enDb.GetReferenceDropDown();
            Enquiry en = new Enquiry();
            en = enDb.GetEnquiryById(id);
            return View(en);
        }
        public ActionResult Update(Enquiry en)
        {
            enDb.Update(en);
            List<Enquiry> lstEnquiry = new List<Enquiry>();
            lstEnquiry = enDb.ListAll();
            return View("Index", lstEnquiry);
        }
    }
}