using Listform_Manager.Entities;
using Listform_Manager.Services.AppService;
using Listform_Manager.Services.Common;
using Listform_Manager.Services.Dtos;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Domain.Repositories;

namespace Listform_Manager.Pages
{
    public partial class Books
    {
        [Inject]
        private IBookAppService BookAppService { get; set; }

        private IReadOnlyList<BookDto> BookList { get; set; }
        private int TotalCount { get; set; }
        private CreateUpdateBookDto NewBookDto { get; set; }
        private CreateUpdateBookDto EditingBookDto { get; set; }

        public Books()
        {
            BookList = new List<BookDto>();
            NewBookDto = new CreateUpdateBookDto();
            EditingBookDto = new CreateUpdateBookDto();
        }

        protected override async Task OnInitializedAsync()
        {
            await GetBooksAsync();
        }

        private async Task GetBooksAsync()
        {
            BookList = (await BookAppService.GetListAsync(new FilteredRequestDto())).Items;

            StateHasChanged();
        }
        
        private async Task CreateBookAsync(IDictionary<string, object> input)
        {
            NewBookDto.Name = input.GetOrDefault("Name").ToString();
            NewBookDto.Price = (float) input.GetOrDefault("Price");
            NewBookDto.PublishDate = (DateTime) input.GetOrDefault("PublishDate");
            Console.WriteLine(input.GetOrDefault("Type") == null ? "null" : input.GetOrDefault("Type") );
            await BookAppService.CreateAsync(NewBookDto);
            
            await GetBooksAsync();
        }
        
        private async Task UpdateBookAsync(BookDto book, IDictionary<string, object> input)
        {
            EditingBookDto.Name = input.GetOrDefault("Name") == null ? book.Name : input.GetOrDefault("Name").ToString();
            EditingBookDto.Price = input.GetOrDefault("Price") == null ? book.Price : (float) input.GetOrDefault("Price");
            EditingBookDto.PublishDate = input.GetOrDefault("PublishDate") == null ? book.PublishDate : (DateTime)  input.GetOrDefault("PublishDate");
            await BookAppService.UpdateAsync(book.Id, EditingBookDto);
           
            await GetBooksAsync();
        }
        
        private async Task DeleteBookAsync(BookDto book)
        {
            var confirmMessage = L["BookDeletionConfirmationMessage", book.Name];
            if (!await Message.Confirm(confirmMessage))
            {
                return;
            }

            await BookAppService.DeleteAsync(book.Id);
            await GetBooksAsync();
        }
    }
}
