using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using formationApi.data.Entities;
using Microsoft.EntityFrameworkCore;

namespace formationApi.data.Repositories.QuizsRepo
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IList<Question>> GetAll()
        {
            return await _dbContext.Questions
                .Where(x => x.Enable == true)
                .Include(q => q.Quiz)
                .ToListAsync();
        }
    }
}