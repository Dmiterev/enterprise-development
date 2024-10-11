namespace RecrAgency.Domain
{
    /// <summary>
    /// Представляет соискателя.
    /// </summary>
    public class JobSeeker
    {
        /// <summary>
        /// Уникальный идентификатор соискателя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Полное имя соискателя.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Контактный телефон соискателя.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Описание опыта работы соискателя.
        /// </summary>
        public string WorkExperience { get; set; }

        /// <summary>
        /// Образование соискателя.
        /// </summary>
        public string Education { get; set; }

        /// <summary>
        /// Желаемый уровень зарплаты соискателя.
        /// </summary>
        public decimal DesiredSalary { get; set; }
    }
}