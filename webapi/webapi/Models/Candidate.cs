﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Candidate
    {
        public int CandidateId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string IdCard { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public DateTime? Birth { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public int? Seniority { get; set; }
        public int? Status { get; set; }
        public string Img { get; set; }
        public string Autobiography { get; set; }
    }
}