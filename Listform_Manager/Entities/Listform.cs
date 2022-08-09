using Blazorise.DataGrid;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Listform_Manager.Entities
{
    public class Listform : Entity<int>
    {
        [Key]
        public string UserName { get; set; }
        public string RecordSource { get; set; }
        public string Caption { get; set; }
        public DataGridEditMode EditMode { get; set; }
        
        public ICollection<ListformField> Listform_Field { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { Id, UserName }; 
        }
    }
}
