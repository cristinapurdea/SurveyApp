using System;
using System.Collections.Generic;

namespace SurveyApp.Business.Models
{
    public class Survey
    {
        public Survey()
        {
            Questions = new List<Question>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; }
    }
}
