using Listform_Manager.Entities;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Listform_Manager.Pages
{
    public partial class List
    {
        [Parameter]
        public string Id { get; set; }
        
        [Inject]
        public IRepository<Listform> RepoFormlist { get; set; }
        public IRepository<Listform_Field> RepoFormlist_Fields { get; set; }

        public IRepository<Product> Repo { get; set; }

        [Parameter]
        public Listform Listform { get; set; }
        public List<Listform_Field> Listform_Fields { get; set; }
        public List<Product> Rows { get; set; }

        protected override Task OnParametersSetAsync()
        {
            ChangeFormProp();
        
            return base.OnParametersSetAsync();
        }

        protected override async Task OnInitializedAsync()
        {
            ChangeFormProp();

            await base.OnInitializedAsync();
        }

        private async void ChangeFormProp()
        {
            Listform = await RepoFormlist.GetAsync(a => a.Id.ToString() == Id && a.UserName == CurrentUser.UserName);
            Listform_Fields = await RepoFormlist_Fields.GetListAsync(a => a.FormId.ToString() == Id && a.UserName == CurrentUser.UserName);

            Rows = await Repo.GetListAsync();

            StateHasChanged();
        }
    }

}
