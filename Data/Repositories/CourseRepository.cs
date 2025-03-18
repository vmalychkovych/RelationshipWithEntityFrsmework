using Microsoft.EntityFrameworkCore;
using RelationshipEF.Model;

namespace RelationshipEF.Data.Repositories
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<List<CourseEntity>> GetAll()
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<CourseEntity>> GetWithLesson()
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .Include(c => c.Lessons)
                .ToListAsync();
        }

        public async Task<CourseEntity?> FirstOrDefault(Guid id)
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CourseEntity>> GetByFilter(string title, decimal price)
        {
            var query = _dbContext.Courses.AsNoTracking();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(c => c.Title.Contains(title));
            }
            if (price > 0)
            {
                query = query.Where(c => c.Price > 0);
            }

            return await query.ToListAsync();

        }

        public async Task<List<CourseEntity>> GetByPage(int page, int pageSize)
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task Update(Guid id, CourseEntity courseEntity)
        {
            await _dbContext.Courses
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Title, courseEntity.Title)
                    .SetProperty(c => c.Description, courseEntity.Description)
                    .SetProperty(c => c.Price, courseEntity.Price));
        }

        public async Task Delete(Guid id)
        {
            await _dbContext.Courses
                .Where (c => c.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
