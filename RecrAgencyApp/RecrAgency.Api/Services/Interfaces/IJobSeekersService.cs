using RecrAgency.Api.DTO;

namespace RecrAgency.Api.Services.Interfaces;

public interface IJobSeekersService
{
    IEnumerable<JobSeekersDto> GetAll();
    JobSeekersDto? GetById(int id);
    JobSeekersDto Create(JobSeekersCreateDto jobSeekersCreateDto);
    bool Update(int id, JobSeekersDto jobSeekersDto);
    bool Delete(int id);
}
