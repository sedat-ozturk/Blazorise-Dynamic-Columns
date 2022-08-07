using Listform_Manager.Entities;
using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Listform_Manager.Services.AppService
{
    public class ListformFieldService : 
        CrudAppService<
            ListformField,
            ListformFieldDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateListformFieldDto>,
        IListformFieldService
    {
        public ListformFieldService(IRepository<ListformField, int> repository) : base(repository)
        {

        }
    }
}
