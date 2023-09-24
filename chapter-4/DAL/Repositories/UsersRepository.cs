using chapter_4.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace chapter_4.DAL.Repositories
{
    public class UsersRepository
    {
        TodoListDBContext _todoListDBContext;

        public UsersRepository(TodoListDBContext context)
        {
            _todoListDBContext = context;
        }

        public async Task<Guid?> GetUserByEmailAsync(string email)
        {
            var user = await _todoListDBContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
            if (user != null)
            {
                return user.UserId;
            }
            return null;
        }

        public async Task<Guid?> GetUserByUserIdAsync(Guid userId)
        {
            var user = await _todoListDBContext.Users.FirstOrDefaultAsync(user => user.UserId == userId);
            if (user != null)
            {
                return user.UserId;
            }
            return null;
        }
    }
}

