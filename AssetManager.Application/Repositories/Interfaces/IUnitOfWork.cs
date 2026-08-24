namespace AssetManager.Application.Repositories.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}