using Volo.Abp.Domain.Entities;

namespace Listform_Manager.Entities;

public class Product: Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public override object[] GetKeys()
    {
        return new object[] { Id };
    }
}
