using RecrAgency.Domain;

namespace RecruitmentAgency.Tests;

public class RecruitmentAgencyTest : IClassFixture<RecruitmentAgencyFixture>
{
    private readonly RecruitmentAgencyFixture _fixture;

    public RecruitmentAgencyTest(RecruitmentAgencyFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void ReturnJobSeekersByPositionSortedByFullName()
    {
        var positionId = 0;
        var jobSeekers = _fixture.JobApplications
            .Where(ja => ja.PositionId == positionId)
            .Select(ja => _fixture.JobSeekers.First(js => js.Id == ja.SeekerId))
            .OrderBy(js => js.FullName)
            .ToList();

        Assert.NotEmpty(jobSeekers);
        Assert.Equal(jobSeekers, jobSeekers.OrderBy(js => js.FullName).ToList());
    }

    [Fact]
    public void ReturnJobSeekersWhoAppliedInDateRange()
    {
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 5, 31);
        var jobSeekers = _fixture.JobApplications
            .Where(ja => ja.ApplicationDate >= startDate && ja.ApplicationDate <= endDate)
            .Select(ja => _fixture.JobSeekers.First(js => js.Id == ja.SeekerId))
            .ToList();

        Assert.NotEmpty(jobSeekers);
    }

    [Fact]
    public void ReturnJobSeekersForSpecificEmployerApplication()
    {
        var employerApplicationId = 1; 
        var employerApplication = _fixture.EmployerApplications.First(ea => ea.Id == employerApplicationId);
        var jobSeekers = _fixture.JobApplications
            .Where(ja => ja.PositionId == employerApplication.PositionId)
            .Select(ja => _fixture.JobSeekers.First(js => js.Id == ja.SeekerId))
            .ToList();

        Assert.NotEmpty(jobSeekers);
    }

    [Fact]
    public void ReturnApplicationCountBySectionAndPosition()
    {
        var applicationCounts = _fixture.JobApplications
            .GroupBy(ja => ja.PositionId) 
            .Select(g => new
            {
                Position = _fixture.Positions.First(p => p.Id == g.Key),
                Count = g.Count()
            })
            .Select(x => new
            {
                Section = x.Position.Section,
                PositionName = x.Position.PositionName,
                Count = x.Count
            })
            .ToList();

        Assert.NotEmpty(applicationCounts);
    }

    [Fact]
    public void ReturnTop5EmployersByApplicationCount()
    {
        var topEmployers = _fixture.EmployerApplications
            .GroupBy(ea => ea.EmployerId)
            .Select(g => new
            {
                EmployerId = g.Key,
                ApplicationCount = g.Count()
            })
            .OrderByDescending(e => e.ApplicationCount)
            .Take(5)
            .ToList();

        Assert.NotEmpty(topEmployers);
    }

    [Fact]
    public void ReturnEmployersWithMaxSalaryApplications()
    {
        var maxSalaryApplications = _fixture.EmployerApplications
            .GroupBy(ea => ea.EmployerId)
            .Select(g => new
            {
                EmployerId = g.Key,
                MaxSalary = g.Max(ea => ea.OfferedSalary)
            })
            .OrderByDescending(e => e.MaxSalary)
            .ToList();

        Assert.NotEmpty(maxSalaryApplications);
    }
}