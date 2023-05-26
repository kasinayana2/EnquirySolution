using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnquiryProject.Models
{
    public class Enquiry
    {
        public int EnquiryId { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public int CompanyId { get; set; }
        public int SiteId { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string HomeAddress { get; set; }
        public string Tag { get; set; }
        public string Comments { get; set; }
        public bool DisplayOnWeb { get; set; }
        public int SortOrder { get; set; }
        public string IpAddress { get; set; }
        public bool IsPublished { get; set; }
        public string PublishedBy { get; set; }
        public DateTime DatePublished { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string UpDateBy { get; set; }
        public string LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DateDeleted { get; set; }
        public  int ReferenceId { get; set; }
        public string ReferenceName { get; set; }
    }
}