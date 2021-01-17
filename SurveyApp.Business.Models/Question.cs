using System;
using System.Collections.Generic;

namespace SurveyApp.Business.Models
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
        }

        public int Page { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }
        public bool Required { get; set; }
        public List<Answer> Answers { get; }
    }
}
