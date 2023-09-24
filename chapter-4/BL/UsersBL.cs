using chapter_4.DAL;
using chapter_4.DTO;

namespace chapter_4.BL
{
    public class UsersBL
    {
        private UnitOfWork _uow;
        private readonly ILogger<UsersBL> _logger;


        public UsersBL(UnitOfWork uow, ILogger<UsersBL> logger)
        {
            _uow = uow;
            _logger = logger;
        }

        public async Task<Guid?> GetUserWithEmailAsync(string email)
        {
            _logger.LogInformation("[UsersBL][GetUserWithEmailAsync()] entered function");
            return await _uow.UsersRepository.GetUserByEmailAsync(email);
        }

        public async Task<Guid?> GetUserByIdAsync(Guid userId)
        {
            _logger.LogInformation("[UsersBL][GetUserByIdAsync()] entered function");
            return await _uow.UsersRepository.GetUserByUserIdAsync(userId);
        }
    }
}

