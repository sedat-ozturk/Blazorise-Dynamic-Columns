using Listform_Manager.Entities;
using Listform_Manager.Permissions;
using Listform_Manager.Services.Common;
using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Listform_Manager.Services.AppService
{
    public class ProductAppService : 
        CrudAppService<
            Product,
            ProductDto,
            int,
            ProductFilteredRequestDto,
            CreateUpdateProductDto>, 
        IProductAppService
    {
        private readonly IRepository<Product, int> _repository;

        public ProductAppService(IRepository<Product, int> repository) : base(repository)
        {
            _repository = repository;

            GetPolicyName = Listform_ManagerPermissions.Product.Products;
            GetListPolicyName = Listform_ManagerPermissions.Product.Products;
            CreatePolicyName = Listform_ManagerPermissions.Product.Create;
            UpdatePolicyName = Listform_ManagerPermissions.Product.Edit;
            DeletePolicyName = Listform_ManagerPermissions.Product.Delete;
        }

        public override async Task<PagedResultDto<ProductDto>> GetListAsync(ProductFilteredRequestDto input)
        {
            await CheckGetListPolicyAsync();

            var query = await CreateFilteredQueryAsync(input);
            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncExecuter.ToListAsync(query);
            var entityDtos = await MapToGetListOutputDtosAsync(entities);

            return new PagedResultDto<ProductDto>
                (
                    totalCount,
                    entityDtos
                );
        }

        protected override async Task<IQueryable<Product>> CreateFilteredQueryAsync(ProductFilteredRequestDto input)
        {
            var query = await base.CreateFilteredQueryAsync(input);
            
            return query
                .WhereIf(input.Id > 0 , a => a.Id == input.Id)
                .WhereIf(!input.Name.IsNullOrEmpty(), a => a.Name.Contains(input.Name))
                .WhereIf(!input.Description.IsNullOrEmpty(), a => a.Description.Contains(input.Description))
                .WhereIf(input.Price > 0, a => a.Price == input.Price)
                .WhereIf(input.PublishDate != null, a => a.PublishDate == input.PublishDate);
        }
    }
}
