using Listform_Manager.Entities;
using Listform_Manager.Permissions;
using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Listform_Manager.Services.AppService
{
    public class ProductService : 
        CrudAppService<
            Product,
            ProductDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateProductDto>, 
        IProductService
    {
        private readonly IRepository<Product, int> _repository;

        public ProductService(IRepository<Product, int> repository) : base(repository)
        {
            _repository = repository;

            GetPolicyName = Listform_ManagerPermissions.Product.Products;
            GetListPolicyName = Listform_ManagerPermissions.Product.Products;
            CreatePolicyName = Listform_ManagerPermissions.Product.Create;
            UpdatePolicyName = Listform_ManagerPermissions.Product.Edit;
            DeletePolicyName = Listform_ManagerPermissions.Product.Delete;
        }

        public override async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            await CheckGetListPolicyAsync();

            var query = await CreateFilteredQueryAsync(input);
            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            //query = ApplyPaging(query, input);

            var entities = await AsyncExecuter.ToListAsync(query);
            var entityDtos = await MapToGetListOutputDtosAsync(entities);

            return new PagedResultDto<ProductDto>
                (
                    totalCount,
                    entityDtos
                );
        }
    }
}
