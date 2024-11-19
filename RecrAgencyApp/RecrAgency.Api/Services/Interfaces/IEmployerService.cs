using RecrAgency.Api.DTO;

namespace RecrAgency.Api.Services.Interfaces;

public interface IEmployerService
{
    IEnumerable<EmployerDto> GetAll();
    EmployerDto? GetById(int id);
    EmployerDto Create(EmployerCreateDto employerCreateDto);
    bool Update(int id, EmployerDto employerDto);
    bool Delete(int id);
}