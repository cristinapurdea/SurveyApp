using System.Collections.Generic;
using SurveyApp.Business.Models;
using SurveyApp.DataAcess.Interface;

namespace SurveyApp.DataAccess
{
    public class SurveyRepository : ISurveyRepository
    { 
        public SurveyRepository()
        {
        }

        public Survey GetSurvey()
        {
            return ReadSurveyFromDb();
        }

        private Survey ReadSurveyFromDb()
        {
            Survey survey = new Survey();

            survey.Description = "Welcome to the Coffee Survey! This survey will ask you a few questions about your coffee habits.";
            survey.Name = "Coffee Survey";

            Question question1 = new Question()
            {
                Name = "How many coffees did you take today?",
                Order = 1,
                Page = 1,
                Required = true,
                Type = InputType.Radio,
            };

            question1.Answers.AddRange(new List<Answer>()
            {
                new Answer() {  Name = "Only one, I swear", Order = 1 },
                new Answer() {  Name = "Two", Order = 2 },
                new Answer() {  Name = "I stopped counting at three", Order = 3 },
                new Answer() {  Name = "I don't drink coffee", Order = 4 }
            });

            Question question2 = new Question()
            {
                Name = "What do you put in your coffee?",
                Order = 2,
                Page = 1,
                Required = true,
                Type = InputType.Checkbox,
            };

            question2.Answers.AddRange(new List<Answer>()
            {
                new Answer() {  Name = "Sugar", Order = 1 },
                new Answer() {  Name = "Milk", Order = 2 },
                new Answer() {  Name = "Cream", Order = 3 },
                new Answer() {  Name = "Maple Syrup", Order = 4 },
                new Answer() {  Name = "Salt", Order = 5 }
            });

            Question question3 = new Question()
            {
                Name = "From which country does your coffee come from?",
                Order = 3,
                Page = 2,
                Required = true,
                Type = InputType.Select,
            };
            question3.Answers.AddRange(new List<Answer>()
            {
                new Answer() {  Name = "Brazil", Order = 1 },
                new Answer() {  Name = "Columbia", Order = 2 },
                new Answer() {  Name = "Italy", Order = 3 }
            });

            Question question4 = new Question()
            {
                Name = "What's your maximum number of cups of coffee per day?",
                Order = 4,
                Page = 2,
                Required = true,
                Type = InputType.Number,
            };

            Question question5 = new Question()
            {
                Name = "Rate the following types of coffee.",
                Order = 5,
                Page = 2,
                Required = true,
                Type = InputType.StarRating,
            };
            question5.Answers.AddRange(new List<Answer>()
            {
                new Answer() {  Name = "Cappuccino", Order = 1 },
                new Answer() {  Name = "Espresso", Order = 2 },
                new Answer() {  Name = "Café Latte", Order = 3 },
                new Answer() {  Name = "Americano", Order = 4 },
                new Answer() {  Name = "Irish", Order = 5 }
            });

            Question question6 = new Question()
            {
                Name = "Do you have suggestions to improve this survey?",
                Order = 6,
                Page = 3,
                Required = false,
                Type = InputType.TextArea,
            };

            survey.Questions.Add(question1);
            survey.Questions.Add(question2);
            survey.Questions.Add(question3);
            survey.Questions.Add(question4);
            survey.Questions.Add(question5);
            survey.Questions.Add(question6);

            return survey;
        }
    }
}
