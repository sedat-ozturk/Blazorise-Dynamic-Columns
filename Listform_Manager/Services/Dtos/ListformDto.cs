using Volo.Abp.Application.Dtos;

namespace Listform_Manager.Services.Dtos
{
    public class ListformDto : EntityDto<int>
    {
        public string UserName { get; set; }
        public string RecordSource { get; set; }
    }
}
