using Volo.Abp.Application.Dtos;

namespace Listform_Manager.Services.Dtos
{
    public class ProductDto: EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
