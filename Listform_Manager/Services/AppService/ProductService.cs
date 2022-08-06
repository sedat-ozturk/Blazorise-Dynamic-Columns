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
        public ProductService(IRepository<Product, int> repository) : base(repository)
        {
            GetPolicyName = Listform_ManagerPermissions.GroupName;
            GetListPolicyName = Listform_ManagerPermissions.Lists.Default;
            CreatePolicyName = Listform_ManagerPermissions.Lists.Create;
            UpdatePolicyName = Listform_ManagerPermissions.Lists.Edit;
            DeletePolicyName = Listform_ManagerPermissions.Lists.Delete;
        }
    }
}
