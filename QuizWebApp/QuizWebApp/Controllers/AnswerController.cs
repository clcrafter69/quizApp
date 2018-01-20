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
            Answer answer = _answerRepo.GetAnswerById(id);
            AnswerViewModel answerViewModel = new AnswerViewModel();
            answerViewModel.currentQuestionId = answer.QuestionId;
            answerViewModel.Answers = answer;
            //answerViewModel.Answers.Response = answer.Response;
            //answerViewModel.Answers.Correct = answer.Correct;
            return View(answerViewModel);
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
            
            Answer answer = _answerRepo.GetAnswerById(id);
            AnswerViewModel answerViewModel = new AnswerViewModel();
            answerViewModel.currentQuestionId = answer.QuestionId;
            answerViewModel.Answers = answer;
            //answerViewModel.Answers.Response = answer.Response;
            //answerViewModel.Answers.Correct = answer.Correct;
            return View(answerViewModel);
        }

        // POST: Answer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AnswerViewModel changedAnswer, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _answerRepo.UpdateAnswer(changedAnswer.Answers);
                AnswerViewModel answerViewModel = new AnswerViewModel();
                answerViewModel.currentQuestionId = changedAnswer.Answers.QuestionId;
                answerViewModel.Answers = changedAnswer.Answers;
                return View(answerViewModel);
             //   return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Answer/Delete/5
        public ActionResult Delete(int id)
        {
            Answer answer = _answerRepo.GetAnswerById(id);
            AnswerViewModel answerViewModel = new AnswerViewModel();
            answerViewModel.currentQuestionId = answer.QuestionId;
            answerViewModel.Answers = answer;
            return View(answerViewModel);
        }

        // POST: Answer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Answer answer = _answerRepo.GetAnswerById(id);
                _answerRepo.DeleteAnswer(answer);
                AnswerViewModel answerViewModel = new AnswerViewModel();
                answerViewModel.currentQuestionId = answer.QuestionId;
                answerViewModel.Answers = answer;
                return RedirectToAction(nameof(EditedList));
            }
            catch
            {
                return View();
            }
        }
    }
}