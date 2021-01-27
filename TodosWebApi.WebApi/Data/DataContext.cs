using Microsoft.EntityFrameworkCore;
using TodosWebApi.WebApi.Entities;

namespace TodosWebApi.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
       
        public DbSet<TodoItem> Items { get; set; }
        public object TodoItem { get; internal set; }
    }
}
