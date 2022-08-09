using Blazorise;
using Volo.Abp.Application.Dtos;

namespace Listform_Manager.Services.Dtos
{
    public class ListformFieldDto : EntityDto<int>
    {
        public int FormId { get; set; }
        public string UserName { get; set; }
        public string FieldName { get; set; }
        public string Caption { get; set; }
        public int RowNo { get; set; }
        public string DbType { get; set; }
        public string ColumnType { get; set; }
        public bool IsEdit { get; set; }
        public int EditRowNo { get; set; }
        public bool IsReadonly { get; set; }
        public string? DisplayFormat { get; set; }
        public TextAlignment TextAlignment { get; set; }
    }
}
