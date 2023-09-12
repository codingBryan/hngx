namespace backend_stage_one.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts):base(opts)
        {
            
        }
        public DbSet<Person> users { get; set; }
    }
}
