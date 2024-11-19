using RecrAgency.Api.DTO;

namespace RecrAgency.Api.Services.Interfaces;

public interface IPositionsService
{
    IEnumerable<PositionsDto> GetAll();
    PositionsDto? GetById(int id);
    PositionsDto Create(PositionsCreateDto positionsCreateDto);
    bool Update(int id, PositionsDto positionsDto);
    bool Delete(int id);
}
