using System;
using SurveyApp.Business.Models;

namespace SurveyApp.Business.Interface
{
    public interface ISurveyManager
    {
        Survey LoadSurvey();
    }
}
