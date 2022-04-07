using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResourceManagement.Database;
using ResourceManagement.Models;
using ResourceManagement.Repositories.Interface;
using Shared.Models.Request;
using Shared.Models.Response;

namespace ResourceManagement.Repositories.Implement
{
    public class WorkGroupRepository : IWorkGroupService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public WorkGroupRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddUpdate(WorkGroupRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var workGroup = _mapper.Map<WorkGroup>(request);
            if (workGroup.Id.Equals(Guid.Empty))
            {
                await _context.WorkGroups.AddAsync(workGroup);
                await _context.SaveChangesAsync();
                return "record has been added.";
            }
            else
            {
                var data = await _context.WorkGroups.FindAsync(workGroup.Id);
                if (data != null) throw new NotFoundException(string.Format($"record not found for {nameof(workGroup)}"));
                _context.WorkGroups.Update(workGroup);
                await _context.SaveChangesAsync();
                return "record has been updated.";
            }
        }

        public async void Delete(Guid id)
        {
            if (id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
            var dep = _context.Departments.Find(id);
            if (dep != null)
            {
                _context.Departments.Remove(dep);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<WorkGroupResponse?> Get(Guid id)
        {
            if (id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
            var workGroup = await _context.WorkGroups.FindAsync(id);
            if (workGroup != null)
            {
                var map = _mapper.Map<WorkGroupResponse?>(workGroup);
                return map;
            }
            return null;
        }

        public async Task<List<WorkGroupResponse>> GetAll()
        {
            var workGroup = await _context.WorkGroups.ToListAsync();
            var map = _mapper.Map<List<WorkGroupResponse>>(workGroup);
            return map;
        }
    }
}
