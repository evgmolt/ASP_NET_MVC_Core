#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MessageService.Models;

namespace MessageService.Data
{
    public class MessageServiceContext : DbContext
    {
        public MessageServiceContext (DbContextOptions<MessageServiceContext> options)
            : base(options)
        {
        }

        public DbSet<MessageService.Models.User> User { get; set; }
    }
}
