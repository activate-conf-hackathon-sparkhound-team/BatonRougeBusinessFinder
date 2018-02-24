using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BRBF.Core.Entities
{
    [Table(nameof(NotificationRegistration))]
    public class NotificationRegistration
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string SearchText { get; set; }
        public bool NotifyOnOpen { get; set; }
        public bool NotifyOnClose { get; set; }
        public bool NotifyOnModified { get; set; }
    }
}
