using System.ComponentModel.DataAnnotations;

namespace Listform_Manager.Services.Dtos
{
    public class CreateUpdateListform_FieldDto
    {
        public int FormId { get; set; }

        [Required]
        [StringLength(128)]
        public string UserName { get; set; }

        [Required]
        public string FieldName { get; set; }
     
        [Required]
        public string Caption { get; set; }
    }
}
