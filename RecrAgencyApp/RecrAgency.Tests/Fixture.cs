using RecrAgency.Domain;

namespace RecruitmentAgency.Tests;

public class RecruitmentAgencyFixture
{
    public List<JobSeeker> JobSeekers { get; set; }
    public List<Position> Positions { get; set; }
    public List<JobApplication> JobApplications { get; set; }
    public List<Employer> Employers { get; set; }
    public List<EmployerApplication> EmployerApplications { get; set; }

    public RecruitmentAgencyFixture()
    {
        // Инициализация соискателей
        JobSeekers =
        [
            new JobSeeker
            {
                Id = 0,
                FullName = "Иван Иванов",
                Phone = "123456789",
                WorkExperience = "2 года в IT",
                Education = "Бакалавр информатики",
                DesiredSalary = 60000
            },
            new JobSeeker
            {
                Id = 1,
                FullName = "Петр Петров",
                Phone = "987654321",
                WorkExperience = "3 года в финансах",
                Education = "Магистр экономики",
                DesiredSalary = 70000
            },
            new JobSeeker
            {
                Id = 2,
                FullName = "Светлана Сидорова",
                Phone = "555555555",
                WorkExperience = "1 год в рекламе",
                Education = "Бакалавр маркетинга",
                DesiredSalary = 50000
            },
            new JobSeeker
            {
                Id = 3,
                FullName = "Алексей Алексеев",
                Phone = "444444444",
                WorkExperience = "5 лет в IT",
                Education = "Магистр информатики",
                DesiredSalary = 90000
            }
         ];

        // Инициализация должностей
        Positions = 
        [
            new Position
            {
                Id = 0,
                Section = "IT",
                PositionName = "Разработчик"
            },
            new Position
            {
                Id = 1,
                Section = "Финансы",
                PositionName = "Финансовый аналитик"
            },
            new Position
            {
                Id = 2,
                Section = "Реклама",
                PositionName = "Маркетолог"
            }
        ];

        // Инициализация заявок соискателей
        JobApplications =
        [
            new JobApplication
            {
                Id = 0,
                SeekerId = 0,
                PositionId = 0,
                ApplicationDate = new DateTime(2024, 1, 15)
            },
            new JobApplication
            {
                Id = 1,
                SeekerId = 1,
                PositionId = 1,
                ApplicationDate = new DateTime(2024, 2, 20)
            },
            new JobApplication
            {
                Id = 2,
                SeekerId = 2,
                PositionId = 2,
                ApplicationDate = new DateTime(2023, 3, 10)
            },
            new JobApplication
            {
                Id = 3,
                SeekerId = 3,
                PositionId = 0,
                ApplicationDate = new DateTime(2024, 4, 5)
            }
        ];

        // Инициализация работодателей
        Employers =
        [
            new Employer
            {
                Id = 0,
                CompanyName = "Компания A",
                ContactPerson = "Анна Антонова",
                Phone = "111222333"
            },
            new Employer
            {
                Id = 1,
                CompanyName = "Компания B",
                ContactPerson = "Игорь Игорев",
                Phone = "222333444"
            }
        ];

        // Инициализация заявок работодателей
        EmployerApplications =
        [
            new EmployerApplication
            {
                Id = 0,
                EmployerId = 0,
                PositionId = 0,
                Requirements = "Знание C#",
                OfferedSalary = 80000,
                ApplicationDate = new DateTime(2024, 1, 10)
            },
            new EmployerApplication
            {
                Id = 1,
                EmployerId = 1,
                PositionId = 1,
                Requirements = "Опыт работы в финансах",
                OfferedSalary = 75000,
                ApplicationDate = new DateTime(2024, 2, 15)
            }
        ];
    }
}