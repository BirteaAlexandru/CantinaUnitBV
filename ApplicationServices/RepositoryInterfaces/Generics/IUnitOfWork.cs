namespace ApplicationServices.RepositoryInterfaces.Generics
{
    public interface IUnitOfWork
    {
        Task<IScopedUnitOfWork> CreateScopeAsync();
    }
}
