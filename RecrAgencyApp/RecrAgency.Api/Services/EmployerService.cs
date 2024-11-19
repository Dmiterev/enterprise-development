using RecrAgency.Api.DTO;
using RecrAgency.Api.Services.Interfaces;
using RecrAgency.Domain;

namespace RecrAgency.Api.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly RecrAgencyContext _context;

        public EmployerService(RecrAgencyContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployerDto> GetAll()
        {
            return _context.Employers
                .Select(e => new EmployerDto
                {
                    Id = e.Id,
                    CompanyName = e.CompanyName,
                    ContactPerson = e.ContactPerson,
                    Phone = e.Phone
                })
                .ToList();
        }

        public EmployerDto? GetById(int id)
        {
            var employer = _context.Employers.Find(id);
            return employer == null ? null : new EmployerDto
            {
                Id = employer.Id,
                CompanyName = employer.CompanyName,
                ContactPerson = employer.ContactPerson,
                Phone = employer.Phone
            };
        }

        public EmployerDto Create(EmployerCreateDto employerCreateDto)
        {
            var employer = new Employer
            {
                CompanyName = employerCreateDto.CompanyName,
                ContactPerson = employerCreateDto.ContactPerson,
                Phone = employerCreateDto.Phone
            };

            _context.Employers.Add(employer);
            _context.SaveChanges();

            return new EmployerDto
            {
                Id = employer.Id,
                CompanyName = employer.CompanyName,
                ContactPerson = employer.ContactPerson,
                Phone = employer.Phone
            };
        }

        public bool Update(int id, EmployerDto employerDto)
        {
            var employer = _context.Employers.Find(id);
            if (employer == null) return false;

            employer.CompanyName = employerDto.CompanyName;
            employer.ContactPerson = employerDto.ContactPerson;
            employer.Phone = employerDto.Phone;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var employer = _context.Employers.Find(id);
            if (employer == null) return false;

            _context.Employers.Remove(employer);
            _context.SaveChanges();
            return true;
        }
    }
}