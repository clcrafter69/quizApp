using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizWebApp.Data;
using QuizWebApp.Models;

namespace QuizWebApp.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IAnswerRepository _answerRepo;

        public AnswerController(IQuestionRepository questionRepo, IAnswerRepository answerRepo)
        {
            _questionRepo = questionRepo;
            _answerRepo = answerRepo;
        }

        // GET: Answer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Answer
        public ActionResult EditedList(int QuestionId)
        {
            var answer =  _answerRepo.ListEditAnswers(QuestionId);           
            return View(answer);
        }

        // GET: Answer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Answer/Create
        public ActionResult Create(int QuestionId)
        {
            AnswerViewModel answerViewModel = new AnswerViewModel();
            answerViewModel.currentQuestionId = QuestionId;
            //ViewBag.AnswerQuestionId = QuestionId;
            return View(answerViewModel);
        }

        // POST: Answer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnswerViewModel newAnswer,IFormCollection collection)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    _answerRepo.AddAnswer(newAnswer.Answers);
                    ModelState.Clear();

                    //newViewModel.Answers = null;
                    //return RedirectToAction(nameof(Index));
                   
                }
                AnswerViewModel newViewModel = new AnswerViewModel();
                newViewModel.currentQuestionId = newAnswer.Answers.QuestionId;
                return View(newViewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Answer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Answer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Answer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Answer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}