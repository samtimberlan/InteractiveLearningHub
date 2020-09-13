using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InteractiveLearningHub.Core;
using InteractiveLearningHub.Infrastructure.DataContext;
using InteractiveLearningHub.Core.Abstractions;

namespace InteractiveLearningHub.Controllers
{
    public class CoursesController : Controller
    {
        private readonly InteractiveLearningHubDbContext _context;
        private readonly IInteractiveLearningHubRepository _repository;

        public CoursesController(InteractiveLearningHubDbContext context, IInteractiveLearningHubRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllCoursesAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _repository.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content")] Course course)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateCourseAync(course);
                await _repository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _repository.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Content")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.EditCourseAync(course);
                    await _repository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_repository.CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _repository.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _repository.DeleteCourseAsync(id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Courses/{id}/BeginPracticeExam
        [ActionName("Exam")]
        public async Task<IActionResult> BeginPracticeExam(Guid id)
        {
            return View();
        }
    }
}
