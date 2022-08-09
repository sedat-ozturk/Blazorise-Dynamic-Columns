using Listform_Manager.Services.AppService;
using Listform_Manager.Services.Common;
using Listform_Manager.Services.Dtos;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;

namespace Listform_Manager.Pages
{
    public partial class DataGridAbpExtensible
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IListformService ListFormService { get; set; }
        [Inject]
        private IListformFieldService ListFormFieldService { get; set; }

        [Parameter]
        public List<TableColumn> TableColumns { get; set; }

        [Parameter]
        public ListformDto Listform { get; set; }
        [Parameter]
        public IReadOnlyList<ListformFieldDto> ListformFields { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Listform = await ListFormService.GetAsync(Convert.ToInt32(Id));

            ListformFields = (await ListFormFieldService.GetListAsync(new ListformFieldFilteredRequestDto
            {
                FormId = Convert.ToInt32(Id),
                UserName = CurrentUser.UserName
            })).Items;

            TableColumns = new List<TableColumn>();

            foreach (var field in ListformFields.OrderBy(a=>a.RowNo))
            {
                TableColumns.Add(new TableColumn
                {
                    Title = L[field.Caption],
                    Data = field.FieldName,
                    Sortable = true,
                });
            }
            
            StateHasChanged();

            await base.OnInitializedAsync();
        }
    }
}
