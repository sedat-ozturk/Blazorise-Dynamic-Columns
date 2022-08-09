using Volo.Abp.Application.Dtos;

namespace Listform_Manager.Services.Common
{
    public class ProductFilteredRequestDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
