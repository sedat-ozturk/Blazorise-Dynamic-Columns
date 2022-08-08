using System;
using Volo.Abp.Application.Dtos;

namespace Listform_Manager.Services.Dtos
{
    public class BookDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        
        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}