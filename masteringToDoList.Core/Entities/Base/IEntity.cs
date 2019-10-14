using System;
using System.Collections.Generic;
using System.Text;

namespace masteringToDoList.Core.Entities.Base
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        Guid CreatedUser { get; set; }

        Guid? UpdatedUser { get; set; }

        DateTime? DeletedDate { get; set; }

        Enums.Enums.DataStatus DataStatus { get; set; }
    }
}
