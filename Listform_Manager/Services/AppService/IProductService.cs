using Listform_Manager.Entities;
using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Listform_Manager.Services.AppService
{
    public interface IProductService :
        ICrudAppService<
            ProductDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateProductDto>
    {

    }
}
