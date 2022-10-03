﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnquiryProject.Models
{
    public class EnquiryDb
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public List<Enquiry> ListAll()
        {
            List<Enquiry> lst = new List<Enquiry>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("uspGetEnquiry", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Enquiry
                    {
                        EnquiryId = Convert.ToInt32(rdr["EnquiryId"].ToString()),
                        FirstName = rdr["FirstName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        Email = rdr["Email"].ToString(),
                        MobileNumber = rdr["MobileNumber"].ToString(),
                        HomeAddress = rdr["HomeAddress"].ToString(),
                        GenderId = Convert.ToInt32(rdr["GenderId"]),

                    });
                }
                return lst;
            }
        }
        public int Add(Enquiry en)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("uspInsertEnquiry", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FirstName", en.FirstName);
                com.Parameters.AddWithValue("@LastName", en.LastName);
                com.Parameters.AddWithValue("@Email", en.Email);
                com.Parameters.AddWithValue("@MobileNumber", en.MobileNumber);
                com.Parameters.AddWithValue("@HomeAddress", en.HomeAddress);
                com.Parameters.AddWithValue("@GenderId", en.GenderId);
                com.Parameters.AddWithValue("@DatePublished", DateTime.Now);
                com.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public Enquiry GetEnquiryById(int id)
        {
            Enquiry en = new Enquiry();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("uspGetEnquiryByEnquiryId", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EnquiryId", id);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {


                    en.EnquiryId = Convert.ToInt32(rdr["EnquiryId"].ToString());
                    en.FirstName = rdr["FirstName"].ToString();
                    en.LastName = rdr["LastName"].ToString();
                    en.Email = rdr["Email"].ToString();
                    en.MobileNumber = rdr["MobileNumber"].ToString();
                    en.HomeAddress = rdr["HomeAddress"].ToString();
                    //en.GenderId = Convert.ToInt32(rdr["GenderId"]);
                }
                return en;
            }
        }
        public int Update(Enquiry en)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("uspUpdateEnquiryById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EnquiryId", en.EnquiryId);
                //com.Parameters.AddWithValue("@GenderId", en.GenderId);
                com.Parameters.AddWithValue("@FirstName", en.FirstName);
                com.Parameters.AddWithValue("@LastName", en.LastName);
                com.Parameters.AddWithValue("@Email", en.Email);
                com.Parameters.AddWithValue("@MobileNumber", en.MobileNumber);
                com.Parameters.AddWithValue("@HomeAddress", en.HomeAddress);
                com.Parameters.AddWithValue("@UpdatedBy","kasi");
                com.Parameters.AddWithValue("@LastUpdated",DateTime.Now);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        public List<SelectListItem> GetGenderDropDown()
        {
            List<SelectListItem> genderddl = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("uspGetGender", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    genderddl.Add(new SelectListItem
                    {

                        Value = rdr["GenderId"].ToString(),
                        Text = rdr["GenderName"].ToString()

                    });
                }
                return genderddl;
            }
        }
    }
}