// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;

// namespace ApplicationAPI.Models
// {
//     public class UsersContext:IdentityDbContext<AppUser,AppRole, int>
//     {
//         public UsersContext(DbContextOptions<UsersContext> options): base(options){
            
//         }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             base.OnModelCreating(modelBuilder);
//             modelBuilder.Entity<User>().HasData(new User() { UserId = 1, Name = "Emre", LastName = "Yılmaz", Mail = "emre@hotmail.com", Phone = 55235485, IsActive = true });
//             modelBuilder.Entity<User>().HasData(new User() { UserId = 2, Name = "Ahmet", LastName = "Işık", Mail = "ahmet@hotmail.com", Phone = 55235485, IsActive = false });
//             modelBuilder.Entity<User>().HasData(new User() { UserId = 3, Name = "Betül", LastName = "Güler", Mail = "betul@hotmail.com", Phone = 55235485, IsActive = true });
//             modelBuilder.Entity<User>().HasData(new User() { UserId = 4, Name = "Nuriye", LastName = "Güzel", Mail = "nuriye@hotmail.com", Phone = 55235485, IsActive = false });
//             modelBuilder.Entity<User>().HasData(new User() { UserId = 5, Name = "Ferdi", LastName = "Kadıoğlu", Mail = "ferdi@hotmail.com", Phone = 55235485, IsActive = true });
//         }

//         public DbSet<User> Users { get; set; }
//     }
// }