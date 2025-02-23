namespace SEARCHAPI.BackEnd.Models;

public class Customer {
    public required String AccountNumber  { get; set; }
    public List<String> SubscribedChannels { get; set; } = new List<String>();
}