using Blazorise.DataGrid;
using Volo.Abp.Application.Dtos;

namespace Listform_Manager.Services.Dtos
{
    public class ListformDto : EntityDto<int>
    {
        public string UserName { get; set; }
        public string RecordSource { get; set; }
        public string Caption { get; set; }
        public DataGridEditMode EditMode { get; set; }
        public string KeyFieldName { get; set; }
    }
}
