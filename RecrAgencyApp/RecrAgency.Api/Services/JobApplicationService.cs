using RecrAgency.Api.DTO;
using RecrAgency.Api.Services.Interfaces;
using RecrAgency.Domain;

namespace RecrAgency.Api.Services;

public class JobApplicationService : IJobApplicationService
{
    private readonly RecrAgencyContext _context;

    public JobApplicationService(RecrAgencyContext context)
    {
        _context = context;
    }

    public IEnumerable<JobApplicationDto> GetAll()
    {
        return _context.JobApplications
            .Select(ja => new JobApplicationDto
            {
                Id = ja.Id,
                SeekerId = ja.SeekerId,
                PositionId = ja.PositionId,
                ApplicationDate = ja.ApplicationDate
            })
            .ToList();
    }

    public JobApplicationDto? GetById(int id)
    {
        var jobApplication = _context.JobApplications.Find(id);
        return jobApplication == null ? null : new JobApplicationDto
        {
            Id = jobApplication.Id,
            SeekerId = jobApplication.SeekerId,
            PositionId = jobApplication.PositionId,
            ApplicationDate = jobApplication.ApplicationDate
        };
    }

    public JobApplicationDto Create(JobApplicationCreateDto jobApplicationCreateDto)
    {
        var jobApplication = new JobApplication
        {
            SeekerId = jobApplicationCreateDto.SeekerId,
            PositionId = jobApplicationCreateDto.PositionId,
            ApplicationDate = DateTime.Now 
        };

        _context.JobApplications.Add(jobApplication);
        _context.SaveChanges();

        return new JobApplicationDto
        {
            Id = jobApplication.Id,
            SeekerId = jobApplication.SeekerId,
            PositionId = jobApplication.PositionId,
            ApplicationDate = jobApplication.ApplicationDate
        };
    }

    public bool Update(int id, JobApplicationDto jobApplicationDto)
    {
        var jobApplication = _context.JobApplications.Find(id);
        if (jobApplication == null) return false;

        jobApplication.SeekerId = jobApplicationDto.SeekerId;
        jobApplication.PositionId = jobApplicationDto.PositionId;
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var jobApplication = _context.JobApplications.Find(id);
        if (jobApplication == null) return false;

        _context.JobApplications.Remove(jobApplication);
        _context.SaveChanges();
        return true;
    }
}