using Microsoft.EntityFrameworkCore;
using MmcBot.Data.Model;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MmcBot.Data.Context;

public class AppDbContext : DbContext
{
    public DbSet<CommandMacro> CommandMacros { get; init; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CommandMacro>().ToCollection("command_macros");
    }
}