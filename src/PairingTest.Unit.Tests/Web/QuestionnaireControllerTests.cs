using Moq;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;
using System.Collections.Generic;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        private QuestionnaireController _questionnaireController;
        private Mock<IQuestionnaireRepository> _questionnaireMockRepository;

        [SetUp]
        public void SetUp()
        {
            _questionnaireMockRepository = new Mock<IQuestionnaireRepository>();
            _questionnaireController = new QuestionnaireController(_questionnaireMockRepository.Object);
        }

        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var questionnaire = new QuestionnaireViewModel()
            {
                QuestionnaireTitle = "My expected quesitons",
                QuestionsText = new List<string>() { "How are you?", "What is your name?" }
            };
            _questionnaireMockRepository.Setup(c => c.GetQuestionnaire()).Returns(questionnaire);

            //Act
            var result = (QuestionnaireViewModel)_questionnaireController.Index().ViewData.Model;

            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(questionnaire.QuestionnaireTitle));
        }
    }
}