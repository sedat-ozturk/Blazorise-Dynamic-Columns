using Listform_Manager.Entities;
using Listform_Manager.Permissions;
using Listform_Manager.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Listform_Manager.Services.AppService
{
    public class BookAppService :
        CrudAppService<
            Book,
            BookDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBookDto>,
        IBookAppService
    {
        private readonly IRepository<Book, Guid> _repository;

        public BookAppService(
            IRepository<Book, Guid> repository
            ) : base(repository)
        {
            _repository = repository;

            GetPolicyName = Listform_ManagerPermissions.Book.Books;
            GetListPolicyName = Listform_ManagerPermissions.Book.Books;
            CreatePolicyName = Listform_ManagerPermissions.Book.Create;
            UpdatePolicyName = Listform_ManagerPermissions.Book.Edit;
            DeletePolicyName = Listform_ManagerPermissions.Book.Delete;
        }

        public override async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            await CheckGetListPolicyAsync();

            var query = await CreateFilteredQueryAsync(input);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncExecuter.ToListAsync(query);
            var entityDtos = await MapToGetListOutputDtosAsync(entities);

            return new PagedResultDto<BookDto>
                (
                    totalCount, 
                    entityDtos
                );
        }
    }
}