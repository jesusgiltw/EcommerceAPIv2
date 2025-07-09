namespace EcommerceAPI.Entities;

public class Customer
{
    public string CustomerId { get; set; } = Guid.NewGuid().ToString(); // System-generated unique ID
    public string CustomerUniqueId { get; set; } = string.Empty; // Unique ID provided by the user
    public int CustomerZipCodePrefix { get; set; } // Zip code prefix
    public string CustomerCity { get; set; } = string.Empty; // City
    public string CustomerState { get; set; } = string.Empty; // State
}