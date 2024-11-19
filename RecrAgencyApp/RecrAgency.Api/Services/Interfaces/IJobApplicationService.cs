using RecrAgency.Api.DTO;

namespace RecrAgency.Api.Services.Interfaces;

public interface IJobApplicationService
{
    IEnumerable<JobApplicationDto> GetAll();
    JobApplicationDto? GetById(int id);
    JobApplicationDto Create(JobApplicationCreateDto jobApplicationCreateDto);
    bool Update(int id, JobApplicationDto jobApplicationDto);
    bool Delete(int id);
}
