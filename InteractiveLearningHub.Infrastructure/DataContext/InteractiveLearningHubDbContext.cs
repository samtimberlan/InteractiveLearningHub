using InteractiveLearningHub.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteractiveLearningHub.Infrastructure.DataContext
{
    public class InteractiveLearningHubDbContext : DbContext
    {
        public InteractiveLearningHubDbContext(DbContextOptions<InteractiveLearningHubDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
    }
}
