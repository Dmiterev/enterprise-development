namespace RecrAgency.Domain
{
    /// <summary>
    /// Представляет заявку работодателя.
    /// </summary>
    public class EmployerApplication
    {
        /// <summary>
        /// Уникальный идентификатор заявки.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор работодателя.
        /// </summary>
        public int EmployerId { get; set; }

        /// <summary>
        /// Идентификатор должности.
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Набор требований к соискателю.
        /// </summary>
        public string Requirements { get; set; }

        /// <summary>
        /// Предлагаемый уровень зарплаты.
        /// </summary>
        public decimal OfferedSalary { get; set; }

        /// <summary>
        /// Дата подачи заявки.
        /// </summary>
        public DateTime ApplicationDate { get; set; }
    }
}