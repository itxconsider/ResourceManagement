using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResourceManagement.Database;
using ResourceManagement.Models;
using ResourceManagement.Repositories.Interface;
using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Repositories.Implement
{
    public class DepartmentRepository : IDepartmentService
    {

        public DataContext _context;
        public IMapper _mapper;

        public DepartmentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }      
     
        public async Task<string> AddUpdate(DepartmentRequest request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));
            var department = _mapper.Map<Department>(request);
            if(department.Id.Equals(Guid.Empty))
            {
                await _context.Departments.AddAsync(department);
                await _context.SaveChangesAsync();
                return "record has been added.";
            }
            else
            {
                var data = await _context.Departments.FindAsync(department.Id);
                if (data != null) throw new NotFoundException(string.Format($"record not found for {nameof(department)}"));
                _context.Departments.Update(department);
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

        public async Task<DepartmentResponse?> Get(Guid id)
        {
            if(id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
            var dep = await _context.Departments.FindAsync(id);
            if(dep != null)
            {
                var map = _mapper.Map<DepartmentResponse>(dep);
                return map;
            }
            return null;            
        }

        public async Task<List<DepartmentResponse>> GetAll()
        {
            var dep = await _context.Departments.ToListAsync();
            var map = _mapper.Map<List<DepartmentResponse>>(dep);
            return map;
        }
    }
}
