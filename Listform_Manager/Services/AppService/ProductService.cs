using Listform_Manager.Entities;
using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Listform_Manager.Services.AppService
{
    public class ProductService : 
        CrudAppService<
            Product,
            ProductDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateProductDto>, 
        IProductService
    {
        public ProductService(IRepository<Product, int> repository) : base(repository)
        {

        }
    }
}
