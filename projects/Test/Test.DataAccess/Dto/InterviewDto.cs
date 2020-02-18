using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Test.DataAccess.Dto
{
    public class InterviewDto
    {
        public string id { get; set; }
        public int type { get; set; }
        public ScheduledDto user { get; set; } 
        public string date { get; set; }
    }
}
