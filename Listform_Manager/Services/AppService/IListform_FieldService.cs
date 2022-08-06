using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Listform_Manager.Services.AppService
{
    public interface IListform_FieldService :
        ICrudAppService<
            Listform_FieldDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateListform_FieldDto>
    {

    }
}
