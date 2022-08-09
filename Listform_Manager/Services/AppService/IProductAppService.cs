using Listform_Manager.Services.Common;
using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Services;

namespace Listform_Manager.Services.AppService
{
    public interface IProductAppService :
        ICrudAppService<
            ProductDto,
            int,
            ProductFilteredRequestDto,
            CreateUpdateProductDto>
    {

    }
}
