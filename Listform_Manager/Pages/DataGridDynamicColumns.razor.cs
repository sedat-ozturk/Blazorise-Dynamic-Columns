using Blazorise.DataGrid;
using Listform_Manager.Services.AppService;
using Listform_Manager.Services.Common;
using Listform_Manager.Services.Dtos;
using Microsoft.AspNetCore.Components;

namespace Listform_Manager.Pages
{
    public partial class DataGridDynamicColumns
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IListformService ListFormService { get; set; }
        [Inject]
        private IListformFieldService ListFormFieldService { get; set; }    
        [Inject]
        private IProductService ProductService { get; set; }    

        [Parameter]
        public ListformDto Listform { get; set; }
        [Parameter]
        public IReadOnlyList<ListformFieldDto> ListformFields { get; set; }
        [Parameter]
        public IReadOnlyList<ProductDto> Rows { get; set; }

        protected override async Task OnInitializedAsync()
        {
            LoadList();

            await base.OnInitializedAsync();
        }

        public DataGridDynamicColumns()
        {
            ListformFields = new List<ListformFieldDto>();
            Rows = new List<ProductDto>();
        }

        private async void LoadList()
        {
            Listform = await ListFormService.GetAsync(Convert.ToInt32(Id));

            ListformFields = (await ListFormFieldService.GetListAsync(new ListResultRequestDto {
                FormId = Convert.ToInt32(Id),
                UserName = CurrentUser.UserName
            })).Items;

            StateHasChanged();
        }

        protected override Task OnParametersSetAsync()
        {
            LoadList();

            return base.OnParametersSetAsync();
        }

        //private async Task OnReadData(DataGridReadDataEventArgs<ProductDto> e)
        //{
        //    if (!e.CancellationToken.IsCancellationRequested)
        //    {
        //        IReadOnlyList<ProductDto> response = null;

        //        if (e.ReadDataMode is DataGridReadDataMode.Virtualize)
        //            response = (await ProductService.GetListAsync(new FilteredRequestDto())).Skip(e.VirtualizeOffset).Take(e.VirtualizeCount).ToList();
        //        else if (e.ReadDataMode is DataGridReadDataMode.Paging)
        //            response = (await ProductService.GetListAsync(new FilteredRequestDto())).Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();
        //        else
        //            throw new Exception("Unhandled ReadDataMode");

        //        if (!e.CancellationToken.IsCancellationRequested)
        //        {
        //            Rows = new List<ProductDto>(response);
        //        }
        //    }

        //    StateHasChanged();
        //}

    }
}
