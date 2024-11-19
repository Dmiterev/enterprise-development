using RecrAgency.Api.DTO;
using RecrAgency.Api.Services.Interfaces;
using RecrAgency.Domain;

namespace RecrAgency.Api.Services
{
    public class JobSeekerService : IJobSeekersService
    {
        private readonly RecrAgencyContext _context;

        public JobSeekerService(RecrAgencyContext context)
        {
            _context = context;
        }

        public IEnumerable<JobSeekersDto> GetAll()
        {
            return _context.JobSeekers
                .Select(js => new JobSeekersDto
                {
                    Id = js.Id,
                    FullName = js.FullName,
                    Phone = js.Phone,
                    WorkExperience = js.WorkExperience,
                    Education = js.Education,
                    DesiredSalary = js.DesiredSalary
                })
            .ToList();
        }

        public JobSeekersDto? GetById(int id)
        {
            var jobSeeker = _context.JobSeekers.Find(id);
            return jobSeeker == null ? null : new JobSeekersDto
            {
                Id = jobSeeker.Id,
                FullName = jobSeeker.FullName,
                Phone = jobSeeker.Phone,
                WorkExperience = jobSeeker.WorkExperience,
                Education = jobSeeker.Education,
                DesiredSalary = jobSeeker.DesiredSalary
            };
        }

        public JobSeekersDto Create(JobSeekersCreateDto jobSeekerCreateDto)
        {
            var jobSeeker = new JobSeeker
            {
                FullName = jobSeekerCreateDto.FullName,
                Phone = jobSeekerCreateDto.Phone,
                WorkExperience = jobSeekerCreateDto.WorkExperience,
                Education = jobSeekerCreateDto.Education,
                DesiredSalary = jobSeekerCreateDto.DesiredSalary
            };

            _context.JobSeekers.Add(jobSeeker);
            _context.SaveChanges();

            return new JobSeekersDto
            {
                Id = jobSeeker.Id,
                FullName = jobSeeker.FullName,
                Phone = jobSeeker.Phone,
                WorkExperience = jobSeeker.WorkExperience,
                Education = jobSeeker.Education,
                DesiredSalary = jobSeeker.DesiredSalary
            };
        }

        public bool Update(int id, JobSeekersDto jobSeekerDto)
        {
            var jobSeeker = _context.JobSeekers.Find(id);
            if (jobSeeker == null) return false;

            jobSeeker.FullName = jobSeekerDto.FullName;
            jobSeeker.Phone = jobSeekerDto.Phone;
            jobSeeker.WorkExperience = jobSeekerDto.WorkExperience;
            jobSeeker.Education = jobSeekerDto.Education;
            jobSeeker.DesiredSalary = jobSeekerDto.DesiredSalary;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var jobSeeker = _context.JobSeekers.Find(id);
            if (jobSeeker == null) return false;

            _context.JobSeekers.Remove(jobSeeker);
            _context.SaveChanges();
            return true;
        }
    }
}