using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveLearningHub.Core.Abstractions
{
    public interface IInteractiveLearningHubRepository
    {
        DateTime GetDate();
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(Guid? courseId);
        Task<Course> CreateCourseAync(Course course);
        Task<Course> EditCourseAync(Course course);
        Task DeleteCourseAsync(Guid? id);
        bool CourseExists(Guid id);
        Task<bool> SaveChangesAsync();
        //Task<IEnumerable<Course>> GetAllCourses();
    }
}
