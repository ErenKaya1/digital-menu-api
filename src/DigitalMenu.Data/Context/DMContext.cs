using System;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenu.Data.Context
{
    public class DMContext : DbContext
    {
        public DMContext(DbContextOptions<DMContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}