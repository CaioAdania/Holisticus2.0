namespace Holisticus2._0.Entities.Models
{
    public class Medicament
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? HealthProgramId { get; set; }
        public int? Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public int StateCode { get; set; }
        public int IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
    }
}
