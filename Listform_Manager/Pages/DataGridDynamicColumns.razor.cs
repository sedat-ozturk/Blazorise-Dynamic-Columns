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

        private ProductDto selectedProduct;

        [Parameter]
        public ListformDto Listform { get; set; }
        [Parameter]
        public IReadOnlyList<ListformFieldDto> ListformFields { get; set; }

        public DataGridEditMode EditMode{ get; set; }

        public DataGridDynamicColumns()
        {
            ListformFields = new List<ListformFieldDto>();
        }

        protected override async Task OnInitializedAsync()
        {
            LoadList();
            
            await base.OnInitializedAsync();
        }

        private void OnRowStyling(ProductDto product, DataGridRowStyling styling)
        {
            if (product.Id > 10)
                styling.Style = "color: red;";
        }
                
        private async void LoadList()
        {
            Listform = await ListFormService.GetAsync(Convert.ToInt32(Id));
            EditMode = Listform.EditMode;

            ListformFields = (await ListFormFieldService.GetListAsync(new ListformFieldFilteredRequestDto {
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

        protected override Task OnDataGridReadAsync(DataGridReadDataEventArgs<ProductDto> e)
        {
            var Id = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "Id");
            if (Id != null) this.GetListInput.Id = Id.SearchValue.ToString() != "" ? Convert.ToInt32(Id.SearchValue) : null;

            var Name = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "Name");
            if (Name != null) this.GetListInput.Name = Name.SearchValue.ToString() != "" ? Name.SearchValue.ToString() : null;

            var Description = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "Description");
            if (Description != null) this.GetListInput.Description = Description.SearchValue.ToString() != "" ? Description.SearchValue.ToString() : null;

            var Price = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "Price");
            if (Price != null) this.GetListInput.Price = Price.SearchValue.ToString() != "" ? Convert.ToDecimal(Price.SearchValue) : null;

            var PublishDate = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "PublishDate");
            if (PublishDate != null) this.GetListInput.PublishDate = PublishDate.SearchValue.ToString() != "" ? Convert.ToDateTime(PublishDate.SearchValue) : null;

            return base.OnDataGridReadAsync(e);
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
