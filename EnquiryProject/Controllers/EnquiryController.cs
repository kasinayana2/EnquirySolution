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
            var genderddl = enDb.GetGenderDropDown();
            List<SelectListItem> gnddl = new List<SelectListItem>(); 
            var Referenceddl = enDb.GetReferenceDropDown();
            List<SelectListItem> refddl = new List<SelectListItem>();
            Enquiry en = enDb.GetEnquiryById(id);
            List<EnquiryReference> erList = enDb.GetEnquiryReferenceList();
            var er = erList.Find(e => e.EnquiryId == en.EnquiryId);
            foreach (var gen in genderddl)
            {
                SelectListItem gn = new SelectListItem();
                gn.Text = gen.Text;
                gn.Value = gen.Value;
                if (gen.Value == Convert.ToString(en.GenderId))
                {
                    gn.Selected = true;
                }
                else
                {
                    gn.Selected = false;
                }
                gnddl.Add(gn);
            }

            foreach (var reference in Referenceddl)
            {
                SelectListItem rf = new SelectListItem();
                rf.Text = reference.Text;
                rf.Value = reference.Value;
                if (reference.Value == Convert.ToString(er.ReferenceId))
                {
                    rf.Selected = true;
                }
                else
                {
                    rf.Selected = false;
                }
                refddl.Add(rf);
            }
            ViewBag.genderddl = gnddl;
            ViewBag.Referenceddl = refddl;
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