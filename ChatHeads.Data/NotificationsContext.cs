using Microsoft.EntityFrameworkCore;

namespace ChatHeads.Data
{
    public class NotificationsContext : DbContext
    {
        public DbSet<Notification> Notification { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=C:\Users\dan_c\AppData\Local\Microsoft\Windows\Notifications\wpndatabase.db");
    }
}