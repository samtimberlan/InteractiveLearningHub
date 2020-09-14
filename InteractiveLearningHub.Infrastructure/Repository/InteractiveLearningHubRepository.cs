using InteractiveLearningHub.Core;
using InteractiveLearningHub.Core.Abstractions;
using InteractiveLearningHub.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveLearningHub.Infrastructure.Repository
{
    public class InteractiveLearningHubRepository : IInteractiveLearningHubRepository
    {
        private readonly InteractiveLearningHubDbContext _context;
        private readonly ILogger<InteractiveLearningHubRepository> _logger;
        private readonly IUserService _user;
        private readonly string _identityUserId;
        private readonly Guid _localUserId;
        private readonly string _fullName;

        public InteractiveLearningHubRepository(InteractiveLearningHubDbContext context, ILogger<InteractiveLearningHubRepository> logger, IUserService user)
        {
            _context = context;
            _logger = logger;
            _user = user;
            _identityUserId = _user.GetIdentityUserId();
            _localUserId = _user.GetLocalUserIdByIdentityId(_identityUserId);
            _fullName = _user.GetIdentityUserFullName();
        }
        public DateTime GetDate() => DateTime.UtcNow.AddHours(1);

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        #region Courses
        public async Task<IEnumerable<Course>> GetAllCoursesAsync() => await _context.Courses.ToListAsync<Course>();

        public async Task<Course> GetCourseByIdAsync(Guid? courseId)
        {
            _logger.LogInformation($"Retrieving course with id: {courseId}");

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == courseId);
            return course;
        }

        public async Task<Course> CreateCourseAync(Course course)
        {
            course.Id = Guid.NewGuid();
            course.DateCreated = DateTime.UtcNow.AddHours(1);
            course.Author = new ApplicationUser()
            {
                IdentityUserId = _user.GetIdentityUserId(),
                FullName = _user.GetIdentityUserFullName()
            };
            _logger.LogInformation($"Creating course with id: {course.Id}");
            await _context.AddAsync<Course>(course);
            return course;
        }

        public async Task<Course> EditCourseAync(Course course)
        {
            Course outdatedCourse = await _context.Courses.FindAsync(course.Id);
            outdatedCourse.Content = course.Content;
            outdatedCourse.DateModified = this.GetDate();
            outdatedCourse.ModifiedBy = _localUserId;
            _logger.LogInformation($"Editing course with id: {course.Id}.");
            _context.Update(course);
            return course;
        }

        public async Task DeleteCourseAsync(Guid? id)
        {
            _logger.LogInformation($"Deleting course with id: {id}");
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
        }

        public bool CourseExists(Guid id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
        //await _context.Courses.FindAsync(id);
        #endregion

        #region Certificate
        public async Task<Certificate> CreateCourseCertificate(Course course)
        {
            Certificate certificate = new Certificate
            {
                CertificateOwner = new ApplicationUser() {
                    Id = _localUserId,
                    IdentityUserId = _identityUserId,
                    FullName = _user.GetIdentityUserFullName()
                },
                Course = course,
                Id = Guid.NewGuid()
            };
            await _context.AddAsync<Certificate>(certificate);
            return certificate;
        }
        #endregion

        #region Exam
        public async Task<Exam> CreateCourseExam(Course course)
        {
            Exam exam = new Exam
            {
                UserId = _localUserId,
                Course = course,
                Id = Guid.NewGuid()
            };
            await _context.AddAsync<Exam>(exam);
            return exam;
        }
        #endregion

        #region Exam
        public async Task<Exam> GetAllCourseExamQuestionsAsync(Guid? courseId)
        {
            return await _context.Exams
                .Include(exam => exam.Course)
                .Include(exam => exam.Questions)
                .FirstOrDefaultAsync(exam => exam.Course.Id == courseId);
        }
        #endregion
    }
}
