using Listform_Manager.Entities;
using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Listform_Manager.Services.AppService
{
    public class ListformService : 
        CrudAppService<
            Listform,
            ListformDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateListformDto>, 
        IListformService
    {
        public ListformService(IRepository<Listform, int> repository) : base(repository)
        {

        }
    }
}
