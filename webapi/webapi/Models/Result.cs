﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public int? CandidaterId { get; set; }
        public int? Score { get; set; }
        public DateTime? AnswerTime { get; set; }
        public int? Result1 { get; set; }
        public string Type { get; set; }
        public string Analysis { get; set; }
        public string SuggestJob { get; set; }
    }
}