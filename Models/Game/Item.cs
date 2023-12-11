namespace TrinityAPI.Models.Game
{
    public class Item
    {
        /// <summary>
        /// SQL ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// String ID that will remain constant despite the SQL ID
        /// </summary>
        public string SID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category type { get; set; }
        /// <summary>
        /// This represent the general "family" of items this item should fall under.
        /// For example, an empty syringe and a pill would both be a "medical" item because they 
        /// both have "medical" uses even though one is consumable and the other is a component
        /// </summary>
        public int Group { get; set; }
    }
}
