using Microsoft.AspNetCore.Mvc;
using PairingTest.Web.Interfaces;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireRepository _questionnaireRepository;
        public QuestionnaireController(IQuestionnaireRepository questionnaireRepository)
        {
            _questionnaireRepository = questionnaireRepository;
        }

        public ViewResult Index()
        {
            var vm = _questionnaireRepository.GetQuestionnaire();
            return View(vm);
        }

        /* ASYNC ACTION METHOD... IF REQUIRED... */
        //public async Task<ViewResult> Index()
        //{
        //}
    }
}
