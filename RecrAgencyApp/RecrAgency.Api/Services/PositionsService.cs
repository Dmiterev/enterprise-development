using RecrAgency.Api.DTO;
using RecrAgency.Api.Services.Interfaces;
using RecrAgency.Domain;

namespace RecrAgency.Api.Services;

public class PositionService : IPositionsService
{
    private readonly RecrAgencyContext _context;

    public PositionService(RecrAgencyContext context)
    {
        _context = context;
    }

    public IEnumerable<PositionsDto> GetAll()
    {
        return _context.Positions
            .Select(p => new PositionsDto
            {
                Id = p.Id,
                Section = p.Section,
                PositionName = p.PositionName
            })
        .ToList();
    }

    public PositionsDto? GetById(int id)
    {
        var position = _context.Positions.Find(id);
        return position == null ? null : new PositionsDto
        {
            Id = position.Id,
            Section = position.Section,
            PositionName = position.PositionName
        };
    }

    public PositionsDto Create(PositionsCreateDto positionCreateDto)
    {
        var position = new Position
        {
            Section = positionCreateDto.Section,
            PositionName = positionCreateDto.PositionName
        };

        _context.Positions.Add(position);
        _context.SaveChanges();

        return new PositionsDto
        {
            Id = position.Id,
            Section = position.Section,
            PositionName = position.PositionName
        };
    }

    public bool Update(int id, PositionsDto positionDto)
    {
        var position = _context.Positions.Find(id);
        if (position == null) return false;

        position.Section = positionDto.Section;
        position.PositionName = positionDto.PositionName;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var position = _context.Positions.Find(id);
        if (position == null) return false;

        _context.Positions.Remove(position);
        _context.SaveChanges();
        return true;
    }
}