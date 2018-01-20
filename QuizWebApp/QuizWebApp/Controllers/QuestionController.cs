using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizWebApp.Data;
using QuizWebApp.Models;

namespace QuizWebApp.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IAnswerRepository _answerRepo;

        public QuestionController(IQuestionRepository questionRepo, IAnswerRepository answerRepo)
        {
            _questionRepo = questionRepo;
            _answerRepo = answerRepo;
        }

        // GET: Quiz
        public ActionResult Index()
        {
            var question = _questionRepo.ListAllQuestions();
            return View(question); 
        }

        // GET: Quiz/Details/5
        public ActionResult Details(int id)
        {
            Question question = _questionRepo.GetQuestionById(id);
            ViewBag.QuestionID = id;
            return View(question);
            
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quiz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question newQuestion,IFormCollection collection)
        {
            try
            {
                
                    if (ModelState.IsValid)
                    {
                        _questionRepo.AddQuestion(newQuestion);
                    // return RedirectToAction(nameof(Index));
                     ViewBag.QuestionID = newQuestion.Id;
                    return View(newQuestion);
                }

                return View(newQuestion);
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(int id)
        {
           Question question= _questionRepo.GetQuestionById(id);
            ViewBag.QuestionID = id;
            return View(question);
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Question changedQuestion, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _questionRepo.UpdateQuestion(changedQuestion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_questionRepo.GetQuestionById(id));
        }

        // POST: Quiz/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _questionRepo.DeleteQuestion(_questionRepo.GetQuestionById(id));
                return RedirectToAction(nameof(Index));

              //  return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}