using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Listform_Manager.Services.AppService
{
    public interface IBookAppService :
        ICrudAppService<
            BookDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBookDto>
    {

    }
}