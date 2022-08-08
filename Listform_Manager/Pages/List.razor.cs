using Blazorise.DataGrid;
using Dapper;
using Listform_Manager.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using System.Linq;
using Volo.Abp.Domain.Repositories;

namespace Listform_Manager.Pages
{
    public partial class List
    {
        [Parameter]
        public string Id { get; set; }
        private int totalRowsCount;

        [Inject]
        public IRepository<Listform> RepoFormlist { get; set; }
        public IRepository<ListformField> RepoFormlist_Fields { get; set; }
        public IRepository<Product> RepoProduct { get; set; }
        public IConfiguration configuration { get; set; }

        [Parameter]
        public Listform Listform { get; set; }
        public List<ListformField> ListformFields { get; set; }
        public List<Product> Rows { get; set; }
        public List<Product> Rows2 { get; set; }

        IEnumerable<Product> Data { get; set; }

        private async void LoadList()
        {
            Listform = await RepoFormlist.GetAsync(a => a.Id.ToString() == Id && a.UserName == CurrentUser.UserName);
            ListformFields = await RepoFormlist_Fields.GetListAsync(a => a.FormId.ToString() == Id && a.UserName == CurrentUser.UserName);

            //Ef ile verileri çağırma
            Rows = await RepoProduct.GetListAsync();
            totalRowsCount = Rows.Count;

            //Dapper ile verileri çağırma
            var sql = "SELECT * FROM " + Listform.RecordSource;
            using (var connection = new SqlConnection(configuration.GetConnectionString("Default")))
            {
                Rows2 = (await connection.QueryAsync<Product>(sql)).ToList();
            }
        }

        private async Task OnReadData(DataGridReadDataEventArgs<Product> e)
        {
            if (!e.CancellationToken.IsCancellationRequested)
            {
                List<Product> response = null;

                if (e.ReadDataMode is DataGridReadDataMode.Virtualize)
                    response = (await RepoProduct.GetListAsync()).Skip(e.VirtualizeOffset).Take(e.VirtualizeCount).ToList();
                else if (e.ReadDataMode is DataGridReadDataMode.Paging)
                    response = (await RepoProduct.GetListAsync()).Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();
                else
                    throw new Exception("Unhandled ReadDataMode");

                if (!e.CancellationToken.IsCancellationRequested)
                {
                    Rows = new List<Product>(response);
                }
            }

            StateHasChanged();
        }

        protected override Task OnParametersSetAsync()
        {
            LoadList();

            return base.OnParametersSetAsync();
        }

        protected override async Task OnInitializedAsync()
        {
            LoadList();

            var suppliers = await RepoProduct.GetListAsync();
            Data = suppliers.Select(s => {
                return new
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Price = s.Price
                };
            }) as IEnumerable<Product>;
                
            await base.OnInitializedAsync();
        }
    }
}
