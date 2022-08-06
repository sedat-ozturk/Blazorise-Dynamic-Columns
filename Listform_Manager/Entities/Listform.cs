using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Listform_Manager.Entities
{
    public class Listform : Entity<int>
    {
        [Key]
        public string UserName { get; set; }
        public string RecordSource { get; set; }
        public string Caption { get; set; }

        public ICollection<Listform_Field> Listform_Field { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { Id, UserName }; 
        }
    }
}
