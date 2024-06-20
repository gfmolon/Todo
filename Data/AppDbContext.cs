using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data;

// import dotnet add package - EntityFrameWorkCoreSqlITE e EntityFrameWorkCoreDesign

// Database Representation in memory
public class AppDbContext : DbContext
{
    
    //DbSet import Table
    public DbSet<TodoModel> Todos { get; set; }

    //Connection String
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource=app.db;Cache=Shared");
}