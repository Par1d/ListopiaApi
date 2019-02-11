using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web;

namespace ListopiaApi.Models
{
    public class List
    {
        public int Id { get; set; }
        
        [MaxLength(255)]
        public string Title { get; set; }

        public IdentityUser Owner { get; set; }
        public string OwnerId { get; set; }

    }
}