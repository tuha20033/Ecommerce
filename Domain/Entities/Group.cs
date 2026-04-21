using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities;

public class Group : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public Guid? ParentId { get; set; }
    public Group? Parent { get; set; }

    public ICollection<Group> SubGroups { get; set; } = new List<Group>();

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
