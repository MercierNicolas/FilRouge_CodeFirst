using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;

namespace FilRouge_Test_CodeFirst.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ILevelRepository levelRepo;
        private readonly ISujetRepository sujetRepo;
        private readonly IQuestionRepository questionRepo;

        // Permet d'apeller les Interface ou ce trouve les methodes qui permet le CRUD
        public QuestionsController(ILevelRepository levelRepo, ISujetRepository sujetRepo , IQuestionRepository questionRepo)
        {
            // Permet d'affecter à la variable l'interface afin de pouvoir utiliser les méthode
            this.levelRepo = levelRepo;
            this.sujetRepo = sujetRepo;
            this.questionRepo = questionRepo;
        }

   

        // GET: Questions
        public IActionResult Index()
        {
            var listQuestion = questionRepo.GetAllQuestions();

            return View(listQuestion);
        }

        // GET: Questions/Details/5
        public IActionResult Details(int? id)
        {
            return View();
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            // On crée un QuizViewModel qui comprend les contenue d'un quiz
            QuestionViewModel QuestionViewModel = new QuestionViewModel();
            QuestionViewModel.question = new Question();
            // Recuper tout les sujet et level 
            var allLvl = levelRepo.GetAllLevel();
            var allSujet = sujetRepo.GetAllSujet();

            List<SelectListItem> Listlevel = allLvl.OrderBy(n => n.LevelName)
                .Select(n =>
                    new SelectListItem
                    {
                        // Permet de crée une liste d'item afin de les afficher dans la vue dans un select
                        Text = n.LevelName,
                        Value = n.Id.ToString()
                    }).ToList();

            List<SelectListItem> ListSujet = allSujet.OrderBy(n => n.SujetName)
                .Select(n =>
                    new SelectListItem
                    {
                        // Permet de crée une liste d'item afin de les afficher dans la vue dans un select
                        Text = n.SujetName,
                        Value = n.id.ToString()
                    }).ToList();

            QuestionViewModel.AllLevel = Listlevel;
            QuestionViewModel.AllSujet = ListSujet;
            return View(QuestionViewModel);
        }

        [HttpPost]
        public IActionResult Create(QuestionViewModel model)
        {
            var questionAdd = new Question()
            {
                ContentQuestion = model.question.ContentQuestion,
                Choix1= model.question.Choix1,
                Choix2= model.question.Choix2,
                Choix3= model.question.Choix3,
                Choix4= model.question.Choix4,                                
            };
            questionRepo.CreateQuestion(questionAdd, model.LevelId, model.sujetId);
            return RedirectToAction("Index");
        }

    }
}
