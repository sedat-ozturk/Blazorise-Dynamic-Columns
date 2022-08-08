using Volo.Abp.Application.Dtos;

namespace Listform_Manager.Services.Common
{
    public class FilteredRequestDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

    }
}
