using RecrAgency.Api.DTO;
using RecrAgency.Api.Services.Interfaces;
using RecrAgency.Domain;

namespace RecrAgency.Api.Services
{
    public class EmployerApplicationService : IEmployerApplicationService
    {
        private readonly RecrAgencyContext _context;

        public EmployerApplicationService(RecrAgencyContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployerApplicationDto> GetAll()
        {
            return _context.EmployerApplications
                .Select(ea => new EmployerApplicationDto
                {
                    Id = ea.Id,
                    EmployerId = ea.EmployerId,
                    PositionId = ea.PositionId,
                    Requirements = ea.Requirements,
                    OfferedSalary = ea.OfferedSalary,
                    ApplicationDate = ea.ApplicationDate
                })
                .ToList();
        }

        public EmployerApplicationDto? GetById(int id)
        {
            var employerApplication = _context.EmployerApplications.Find(id);
            return employerApplication == null ? null : new EmployerApplicationDto
            {
                Id = employerApplication.Id,
                EmployerId = employerApplication.EmployerId,
                PositionId = employerApplication.PositionId,
                Requirements = employerApplication.Requirements,
                OfferedSalary = employerApplication.OfferedSalary,
                ApplicationDate = employerApplication.ApplicationDate
            };
        }

        public EmployerApplicationDto Create(EmployerApplicationCreateDto employerApplicationCreateDto)
        {
            var employerApplication = new EmployerApplication
            {
                EmployerId = employerApplicationCreateDto.EmployerId,
                PositionId = employerApplicationCreateDto.PositionId,
                Requirements = employerApplicationCreateDto.Requirements,
                OfferedSalary = employerApplicationCreateDto.OfferedSalary,
                ApplicationDate = DateTime.Now 
            };

            _context.EmployerApplications.Add(employerApplication);
            _context.SaveChanges();

            return new EmployerApplicationDto
            {
                Id = employerApplication.Id,
                EmployerId = employerApplication.EmployerId,
                PositionId = employerApplication.PositionId,
                Requirements = employerApplication.Requirements,
                OfferedSalary = employerApplication.OfferedSalary,
                ApplicationDate = employerApplication.ApplicationDate
            };
        }

        public bool Update(int id, EmployerApplicationDto employerApplicationDto)
        {
            var employerApplication = _context.EmployerApplications.Find(id);
            if (employerApplication == null) return false;

            employerApplication.Requirements = employerApplicationDto.Requirements;
            employerApplication.OfferedSalary = employerApplicationDto.OfferedSalary;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var employerApplication = _context.EmployerApplications.Find(id);
            if (employerApplication == null) return false;

            _context.EmployerApplications.Remove(employerApplication);
            _context.SaveChanges();
            return true;
        }
    }
}