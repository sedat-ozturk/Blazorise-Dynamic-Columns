using System.ComponentModel.DataAnnotations;

namespace Listform_Manager.Services.Dtos
{
    public class CreateUpdateListformDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserName { get; set; }

        [Required]
        public string RecordSource { get; set; }

        [Required]
        public string Caption { get; set; }
    }
}
