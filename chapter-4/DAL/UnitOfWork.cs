using System;
using AutoMapper;
using chapter_4.DAL.Repositories;
using chapter_4.Data.Context;

namespace chapter_4.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly TodoListDBContext _context;
        private readonly ILogger<UnitOfWork> _logger;
        private TasksRepository _tasksRepository;

        private IMapper _mapper;

        public UnitOfWork(ILogger<UnitOfWork> logger, IMapper mapper)
        {
            _context = new TodoListDBContext();
            _mapper = mapper;
            _logger = logger;
        }

        public TasksRepository TasksRepository
        {
            get
            {
                if (_tasksRepository == null)
                {
                    _tasksRepository = new TasksRepository(_context, _mapper);
                }
                return _tasksRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Commit()
        {
            _logger.LogDebug("Saving changes in database");
            _context.SaveChanges();
        }
    }
}

