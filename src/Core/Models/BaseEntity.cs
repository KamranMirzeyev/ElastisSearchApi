using System;

namespace Core.Models
{
    public class BaseEntity
    {
       
        public long Id { get; set; }

        public bool Status { get; set; }

        public Nullable<DateTime> AddedAt { get; set; }
        public Nullable<DateTime>  ModifiedAt { get; set; }
    }
}