using Listform_Manager.Services.AppService;
using Listform_Manager.Services.Common;
using Listform_Manager.Services.Dtos;
using Microsoft.AspNetCore.Components;

namespace Listform_Manager.Pages
{
    public partial class DevExpressDataGrid
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IProductAppService ProductAppService { get; set; }

        [Inject]
        private IListformService ListFormService { get; set; }
        [Inject]
        private IListformFieldService ListFormFieldService { get; set; }

        private IReadOnlyList<ProductDto> ProductList { get; set; }
        private int TotalCount { get; set; }
        private CreateUpdateProductDto NewProductDto { get; set; }
        private CreateUpdateProductDto EditingProductDto { get; set; }

        [Parameter]
        public ListformDto Listform { get; set; }
        [Parameter]
        public IReadOnlyList<ListformFieldDto> ListformFields { get; set; }

        public DevExpressDataGrid()
        {
            ProductList = new List<ProductDto>();
            NewProductDto = new CreateUpdateProductDto();
            EditingProductDto = new CreateUpdateProductDto();

            ListformFields = new List<ListformFieldDto>();
        }

        protected override async Task OnInitializedAsync()
        {
            await GetProductsAsync();

            Listform = await ListFormService.GetAsync(Convert.ToInt32(Id));

            ListformFields = (await ListFormFieldService.GetListAsync(new ListformFieldFilteredRequestDto
            {
                FormId = Convert.ToInt32(Id),
                UserName = CurrentUser.UserName
            })).Items;

            StateHasChanged();
        }

        private async Task GetProductsAsync()
        {
            ProductList = (await ProductAppService.GetListAsync(new ProductFilteredRequestDto())).Items;

            StateHasChanged();
        }
        
        private async Task CreateProductAsync(IDictionary<string, object> input)
        {
            NewProductDto.Name = input.GetOrDefault("Name").ToString();
            NewProductDto.Description = input.GetOrDefault("Description").ToString();
            NewProductDto.PublishDate = (DateTime) input.GetOrDefault("PublishDate");
            NewProductDto.Price = (Decimal) input.GetOrDefault("Price");
            await ProductAppService.CreateAsync(NewProductDto);
            
            await GetProductsAsync();
        }
        
        private async Task UpdateProductAsync(ProductDto Product, IDictionary<string, object> input)
        {
            EditingProductDto.Id = input.GetOrDefault("Id") == null ? Product.Id : Convert.ToInt32(input.GetOrDefault("Id"));
            EditingProductDto.Name = input.GetOrDefault("Name") == null ? Product.Name : input.GetOrDefault("Name").ToString();
            EditingProductDto.Description = input.GetOrDefault("Description") == null ? Product.Description : input.GetOrDefault("Description").ToString();
            EditingProductDto.PublishDate = input.GetOrDefault("PublishDate") == null ? Product.PublishDate : Convert.ToDateTime(input.GetOrDefault("PublishDate"));
            EditingProductDto.Price = input.GetOrDefault("Price") == null ? Product.Price : Convert.ToDecimal(input.GetOrDefault("Price"));
            await ProductAppService.UpdateAsync(Product.Id, EditingProductDto);
           
            await GetProductsAsync();
        }
        
        private async Task DeleteProductAsync(ProductDto Product)
        {
            var confirmMessage = L["ProductDeletionConfirmationMessage", Product.Name];
            if (!await Message.Confirm(confirmMessage))
            {
                return;
            }

            await ProductAppService.DeleteAsync(Product.Id);
            await GetProductsAsync();
        }
    }
}
