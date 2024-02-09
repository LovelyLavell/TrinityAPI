namespace TrinityAPI.DTO
{
    /// <summary>
    /// A generic request DTO
    /// </summary>
    public class DTORequest
    {
        public int ID { get; set; }
        public string? Label { get; set; }
        public string? description { get; set; }
    }
}
