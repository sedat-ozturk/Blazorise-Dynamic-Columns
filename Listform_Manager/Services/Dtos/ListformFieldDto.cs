using Volo.Abp.Application.Dtos;

namespace Listform_Manager.Services.Dtos
{
    public class ListformFieldDto : EntityDto<int>
    {
        public int FormId { get; set; }
        public string UserName { get; set; }
        public string FieldName { get; set; }
        public string Caption { get; set; }
        public int Order { get; set; }
    }
}
