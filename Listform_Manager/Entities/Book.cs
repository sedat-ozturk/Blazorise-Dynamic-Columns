using Volo.Abp.Domain.Entities.Auditing;

namespace Listform_Manager.Entities
{
    public class Book : AuditedEntity<Guid>
    {
        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}