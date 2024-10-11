namespace RecrAgency.Domain
{
    /// <summary>
    /// Представляет работодателя.
    /// </summary>
    public class Employer
    {
        /// <summary>
        /// Уникальный идентификатор работодателя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название компании.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// ФИО контактного лица.
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// Контактный телефон работодателя.
        /// </summary>
        public string Phone { get; set; }
    }
}