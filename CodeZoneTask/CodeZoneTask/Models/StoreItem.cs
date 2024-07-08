namespace CodeZoneTask.Models
{
    public class StoreItem
    {
        public int? StoreID { get; set; }
        public Store? Store { get; set; }
        public int? ItemID { get; set; }
        public Item? Item { get; set; }
        public int? Quantity { get; set; }

    }
}
