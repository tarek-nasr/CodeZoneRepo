using System.ComponentModel.DataAnnotations;

namespace CodeZoneTask.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public string? ItemName { get; set; }
        public ICollection<StoreItem>? StoreItems { get; set; }
    }
}
