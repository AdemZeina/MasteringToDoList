using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace masteringToDoList.Core.Entities.Base
{
   public class Entity:IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid CreatedUser { get; set; }

        public Guid? UpdatedUser { get; set; }

        public DateTime? DeletedDate { get; set; }

        public Enums.Enums.DataStatus DataStatus { get; set; }
    }
}
