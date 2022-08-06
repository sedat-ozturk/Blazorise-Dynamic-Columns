using Listform_Manager.Entities;
using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Listform_Manager.Services.AppService
{
    public class Listform_FieldService : 
        CrudAppService<
            Listform_Field,
            Listform_FieldDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateListform_FieldDto>,
        IListform_FieldService
    {
        public Listform_FieldService(IRepository<Listform_Field, int> repository) : base(repository)
        {

        }
    }
}
