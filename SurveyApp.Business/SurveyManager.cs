using System;
using SurveyApp.Business.Interface;
using SurveyApp.Business.Models;
using SurveyApp.DataAcess.Interface;

namespace SurveyApp.Business
{
    public class SurveyManager : ISurveyManager
    {
        private readonly ISurveyRepository surveyRepository;

        public SurveyManager(ISurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
        }

        public Survey LoadSurvey()
        {
            return surveyRepository.GetSurvey();
        }
    }
}
