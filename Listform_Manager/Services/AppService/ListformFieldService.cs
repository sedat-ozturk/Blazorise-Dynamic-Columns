using Listform_Manager.Entities;
using Listform_Manager.Services.Common;
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
            ListResultRequestDto,
            CreateUpdateListformFieldDto>,
        IListformFieldService
    {
        public ListformFieldService(IRepository<ListformField, int> repository) : base(repository)
        {

        }

        public override async Task<PagedResultDto<ListformFieldDto>> GetListAsync(ListResultRequestDto input)
        {
            await CheckGetListPolicyAsync();

            var query = await CreateFilteredQueryAsync(input);
            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncExecuter.ToListAsync(query);
            var entityDtos = await MapToGetListOutputDtosAsync(entities);

            return new PagedResultDto<ListformFieldDto>
                (
                    totalCount,
                    entityDtos
                );
        }

        protected override async Task<IQueryable<ListformField>> CreateFilteredQueryAsync(ListResultRequestDto input)
        {
            var query = await base.CreateFilteredQueryAsync(input);

            return query.Where(a =>
                                    (a.FormId == input.FormId) &&
                                    (a.UserName.ToLower().Contains(input.UserName))
                                ).OrderByDescending(a => a.Id);
        }
    }
}
