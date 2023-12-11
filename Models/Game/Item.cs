namespace TrinityAPI.Models.Game
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// This represent the general "family" of items this item should fall under.
        /// For example, an empty syringe and a pill would both be a "medical" item because they 
        /// both have "medical" uses even though one is consumable
        /// </summary>
        public int Group { get; set; }
    }
}
