<<<<<<< HEAD
﻿using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
=======
﻿using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
>>>>>>> 80a4d066103dc3f0d8cf1b71c1308f80b5b8eaf7

namespace FilRouge_Test_CodeFirst.Controllers
{
    public class PassageController : Controller
    {
        private readonly IQuestionRepository questionRepo;
<<<<<<< HEAD
        private readonly IAnswerRepository answerRepo;

        public PassageController(IQuestionRepository questionRepo, IAnswerRepository answerRepo)
        {
            this.questionRepo = questionRepo;
=======
        private readonly IAnswerRepository passageRepo;
        private readonly IAnswerRepository answerRepo;

        public PassageController(IQuestionRepository questionRepo, IAnswerRepository passageRepo, IAnswerRepository answerRepo)
        {
            this.questionRepo = questionRepo;
            this.passageRepo = passageRepo;
>>>>>>> 80a4d066103dc3f0d8cf1b71c1308f80b5b8eaf7
            this.answerRepo = answerRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

<<<<<<< HEAD
        public IActionResult PassageQuiz()
        {
            var fourAnswers = questionRepo.GetAllQuestions();


            return View(fourAnswers);
        }

        [HttpPost]
        public IActionResult PassageQuiz(Question model)
        {
            var resultat = new QuizPassageViewModel
            {
                ContentQuestion = model.ContentQuestion,
                AnswerChoice= model.AnswerChoice,
                
            };

            answerRepo.CreateResalt(resultat);

            return RedirectToAction("Index");
        }

=======

        [HttpGet]
        [Route("/Passage/{id:int}")]
        public IActionResult Welcome(int id, int? questionId)
        {
            var dataId = passageRepo.GetAllId(id, questionId);

            return View(dataId.FirstOrDefault());
        }


        [HttpGet]
        [Route("/Passage/{id:int}/{questionId:int}")]
        public IActionResult PassageQuiz(int id, int? questionId)
        {

            

            var dataAnswers = passageRepo.GetQuizPassage(id, questionId);


            return View(dataAnswers);
        }


        //var questionViewModel = new QuizPassageViewModel();

        //foreach (var dataAnswer in dataAnswers.Question)
        //{
        //    questionViewModel.QuizzId = id;
        //    questionViewModel.QuestionId = questionId;
        //    questionViewModel.ContentQuestion = dataAnswer.ContentQuestion;
        //    questionViewModel.AnswerChoice = dataAnswer.AnswerChoice.ToList();
        //}


        //public IActionResult PassageQuiz()
        //{
        //    var fourAnswers = questionRepo.GetAllQuestions();

        //    List<QuizPassageViewModel> listViewModel = new List<QuizPassageViewModel>();

        //    foreach (Question questions in fourAnswers)
        //    {
        //        var questionViewModel = new QuizPassageViewModel
        //        {
        //            ContentQuestion = questions.ContentQuestion,
        //            QuestionId = questions.QuestionId,
        //            AnswerChoice= questions.AnswerChoice.ToList(),
        //        };

        //        listViewModel.Add(questionViewModel);
        //    }
        //    return View(listViewModel);
        //}

        [HttpPost]
        [Route("/Passage/{id}/{questionId?}")]
        public IActionResult PassageQuiz(int id, int? questionId, IFormCollection input)
        {

            var dataAnswers = passageRepo.GetQuizPassage(id, questionId);

            var responseIds = dataAnswers.AnswerChoice.Where(responseId => input.ContainsKey(responseId.CorrectionId.ToString())).Select(i => i.CorrectionId);

            if (dataAnswers.NextQuestionId == null)
            {
                return View("Thank");
            }

            return RedirectToAction("PassageQuiz", new { id, questionId = dataAnswers.NextQuestionId });
        }


        //public IActionResult PassageQuiz(QuizPassageViewModel model)
        // {
        //    var resultat = new TheAnswer
        //    {

        //    Answers = model.AnswerChoice.Where(x => x.IsCorrect).ToString(),

        //    };

        //    return Content($"{resultat.Answers}");

        //    answerRepo.CreateResalt(resultat);

        //    return RedirectToAction("Index");
        //}

        public IActionResult Thank()
        {
            return View();
        }
>>>>>>> 80a4d066103dc3f0d8cf1b71c1308f80b5b8eaf7
    }
}
