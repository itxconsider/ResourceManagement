using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResourceManagement.Database;
using ResourceManagement.Models;
using ResourceManagement.Repositories.Interface;
using Shared.Models.Request;
using Shared.Models.Response;

namespace ResourceManagement.Repositories.Implement
{
    public class ResourceReposity : IResourceService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ResourceReposity(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddUpdate(ResourceRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var department = _mapper.Map<Resource>(request);
            if (department.Id.Equals(Guid.Empty))
            {
                await _context.Resources.AddAsync(department);
                await _context.SaveChangesAsync();
                return "record has been added.";
            }
            else 
            {
                var data = await _context.Resources.FindAsync(department.Id);
                if (data != null) throw new NotFoundException(string.Format($"record not found for {nameof(department)}"));
                _context.Resources.Update(department);
                await _context.SaveChangesAsync();
                return "record has been updated.";
            }
        }

        public async void Delete(Guid id)
        {
            if (id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
            var dep = await _context.Resources.FindAsync(id);
            if (dep != null)
            {
                _context.Resources.Remove(dep);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ResourceResponse?> Get(Guid id)
        {
            if (id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
            var res = await _context.Resources.FindAsync(id);
            if (res != null)
            {
                var data = _mapper.Map<ResourceResponse?>(res);
                return data;
            }
            return null;
        
        }

        public async Task<List<ResourceResponse>> GetAll()
        {
            var dep = await _context.Resources.ToListAsync();
            var map = _mapper.Map<List<ResourceResponse>>(dep);
            return map;
        }
    }
}
