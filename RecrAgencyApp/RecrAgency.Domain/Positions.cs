namespace RecrAgency.Domain
{
    /// <summary>
    /// Представляет должность.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Уникальный идентификатор должности.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Раздел, к которому относится должность (IT, финансы, реклама и т.д.).
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Наименование должности.
        /// </summary>
        public string PositionName { get; set; }
    }
}