using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreBug
{
    public class Note
    {
        [Key]
        public Guid Id { get; set; }

        public string Text { get; set; }

        public User User { get; set; }

    }
}
