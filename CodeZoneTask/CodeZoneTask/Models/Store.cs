using System.ComponentModel.DataAnnotations;

namespace CodeZoneTask.Models
{
    public class Store
    {
        [Key]
        public int? StoreID { get; set; }
        public string? StoreName { get; set; }
        public ICollection<StoreItem>? StoreItems { get; set; }
    }
}
