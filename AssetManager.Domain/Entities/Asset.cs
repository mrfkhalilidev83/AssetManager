namespace AssetManager.Domain.Entities;

public class Asset
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public decimal Gold { get; set; }

    public decimal Silver { get; set; }

    public decimal Toman { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User User { get; set; } = null!;
}