
﻿using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace FilRouge_Test_CodeFirst.Controllers
{
    public class PassageController : Controller
    {
        private readonly IQuestionRepository questionRepo;

        private readonly IAnswerRepository passageRepo;
        private readonly IAnswerRepository answerRepo;

        public PassageController(IQuestionRepository questionRepo, IAnswerRepository passageRepo, IAnswerRepository answerRepo)
        {
            this.questionRepo = questionRepo;
            this.passageRepo = passageRepo;

            this.answerRepo = answerRepo;
        }

        public IActionResult Index()
        {
            return View();
        }




        [HttpGet]
        [Route("/Passage/{id:int}")]
        public IActionResult Welcome(int id, int? questionId)
        {
            var dataId = passageRepo.GetAllId(id, questionId).Where(q => q.QuizzId == id);

            return View(dataId.FirstOrDefault());
        }


        [HttpGet]
        [Route("/Passage/{id:int}/{questionId:int}")]
        public IActionResult PassageQuiz(int id, int? questionId)
        {
            
             var dataAnswers = passageRepo.GetQuizPassage(id, questionId);


            return View(dataAnswers);
        }



        [HttpPost]
        [Route("/Passage/{id}/{questionId?}")]
        public IActionResult PassageQuiz(int id, int? questionId, IFormCollection input , QuizPassageViewModel model)
        {
           
            var dataAnswers = passageRepo.GetQuizPassage(id, questionId);

           // var responseIds = dataAnswers.AnswerChoice.Where(responseId => input.ContainsKey(responseId.CorrectionId.ToString())).Select(i => i.CorrectionId);

            if (dataAnswers.NextQuestionId == -1)
            {
                return View("Thank");
            }

            return RedirectToAction("PassageQuiz", new { id, questionId = dataAnswers.NextQuestionId });
        }

        public IActionResult Thank()
        {
            return View();
        }

    }
}
