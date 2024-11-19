using RecrAgency.Api.DTO;

namespace RecrAgency.Api.Services.Interfaces;

public interface IEmployerApplicationService
{
    IEnumerable<EmployerApplicationDto> GetAll();
    EmployerApplicationDto? GetById(int id);
    EmployerApplicationDto Create(EmployerApplicationCreateDto employerApplicationCreateDto);
    bool Update(int id, EmployerApplicationDto employerApplicationDto);
    bool Delete(int id);
}
