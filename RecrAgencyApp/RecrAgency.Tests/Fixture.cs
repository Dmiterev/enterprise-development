using RecrAgency.Domain;
using System;
using System.Collections.Generic;

namespace RecruitmentAgency.Tests
{
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
            JobSeekers = new List<JobSeeker>
            {
                new() { Id = 0, FullName = "Иван Иванов", Phone = "123456789", WorkExperience = "2 года в IT", Education = "Бакалавр информатики", DesiredSalary = 60000 },
                new() { Id = 1, FullName = "Петр Петров", Phone = "987654321", WorkExperience = "3 года в финансах", Education = "Магистр экономики", DesiredSalary = 70000 },
                new() { Id = 2, FullName = "Светлана Сидорова", Phone = "555555555", WorkExperience = "1 год в рекламе", Education = "Бакалавр маркетинга", DesiredSalary = 50000 },
                new() { Id = 3, FullName = "Алексей Алексеев", Phone = "444444444", WorkExperience = "5 лет в IT", Education = "Магистр информатики", DesiredSalary = 90000 }
            };

            // Инициализация должностей
            Positions = new List<Position>
            {
                new() { Id = 0, Section = "IT", PositionName = "Разработчик" },
                new() { Id = 1, Section = "Финансы", PositionName = "Финансовый аналитик" },
                new() { Id = 2, Section = "Реклама", PositionName = "Маркетолог" }
            };

            // Инициализация заявок соискателей
            JobApplications = new List<JobApplication>
            {
                new() { Id = 0, SeekerId = 0, PositionId = 0, ApplicationDate = new DateTime(2024, 1, 15) },
                new() { Id = 1, SeekerId = 1, PositionId = 1, ApplicationDate = new DateTime(2024, 2, 20) },
                new() { Id = 2, SeekerId = 2, PositionId = 2, ApplicationDate = new DateTime(2023, 3, 10) },
                new() { Id = 3, SeekerId = 3, PositionId = 0, ApplicationDate = new DateTime(2024, 4, 5) }
            };

            // Инициализация работодателей
            Employers = new List<Employer>
            {
                new() { Id = 0, CompanyName = "Компания A", ContactPerson = "Анна Антонова", Phone = "111222333" },
                new() { Id = 1, CompanyName = "Компания B", ContactPerson = "Игорь Игорев", Phone = "222333444" }
            };

            // Инициализация заявок работодателей
            EmployerApplications = new List<EmployerApplication>
            {
                new() { Id = 0, EmployerId = 0, PositionId = 0, Requirements = "Знание C#", OfferedSalary = 80000, ApplicationDate = new DateTime(2024, 1, 10) },
                new() { Id = 1, EmployerId = 1, PositionId = 1, Requirements = "Опыт работы в финансах", OfferedSalary = 75000, ApplicationDate = new DateTime(2024, 2, 15) }
            };
        }
    }
}