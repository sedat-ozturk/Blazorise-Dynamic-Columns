using Listform_Manager.Services.Common;
using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Listform_Manager.Services.AppService
{
    public interface IListformFieldService :
        ICrudAppService<
            ListformFieldDto,
            int,
            ListResultRequestDto,
            CreateUpdateListformFieldDto>
    {
        
    }
}
