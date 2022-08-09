using Volo.Abp.Application.Dtos;

namespace Listform_Manager.Services.Common
{
    public class ListResultRequestDto : PagedAndSortedResultRequestDto
    {
        public int? FormId { get; set; }
        public string UserName { get; set; }
    }
}
