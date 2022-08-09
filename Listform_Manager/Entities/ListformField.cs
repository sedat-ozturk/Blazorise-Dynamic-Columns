﻿using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Listform_Manager.Entities;

public class ListformField: Entity<int>
{
    public int FormId { get; set; }
    public string UserName { get; set; }
    public string FieldName { get; set; }
    public string Caption { get; set; }
    public int Order { get; set; }

    public Listform Listform { get; set; }

    public override object[] GetKeys()
    {
        return new object[] { Id };
    }
}
