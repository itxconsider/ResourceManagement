using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResourceManagement.Database;
using ResourceManagement.Models;
using ResourceManagement.Repositories.Interface;
using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Repositories.Implement
{
    public class WorkRepository : IWorkService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public WorkRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddUpdate(WorkRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var work = _mapper.Map<Work>(request);
            if (work.Id.Equals(Guid.Empty))
            {
                await _context.Works.AddAsync(work);
                await _context.SaveChangesAsync();
                return "record has been added.";
            }
            else
            {
                var data = await _context.Works.FindAsync(work.Id);
                if (data != null) throw new NotFoundException(string.Format($"record not found for {nameof(work)}"));
                _context.Works.Update(work);
                await _context.SaveChangesAsync();
                return "record has been updated.";
            }
        }

        public int Count()
        {
            return _context.Works.Count();
        }

        public async void Delete(Guid id)
        {
            if (id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
            var dep = await _context.Works.FindAsync(id);
            if (dep != null)
            {
                _context.Works.Remove(dep);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<WorkResponse?> Get(Guid id)
        {
            if (id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
            var res = await _context.Works.FindAsync(id);
            if (res != null)
            {
                var data = _mapper.Map<WorkResponse?>(res);
                return data;
            }
            return null;
        }

        public async Task<List<WorkResponse>> GetAll()
        {
            var works = await _context.Works.Include(e=>e.WorkGroup)
                .Include(e=>e.Resource)
                .Include(e=>e.Responsibility).ToListAsync();
            var map = _mapper.Map<List<WorkResponse>>(works);
            return map;
        }
    }
}
