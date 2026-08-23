namespace AssetManager.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public Asset? Asset { get; set; }

    public ICollection<AssetTransaction> Transactions { get; set; }
        = new List<AssetTransaction>();
}