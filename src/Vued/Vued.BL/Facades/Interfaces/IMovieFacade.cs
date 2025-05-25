using Vued.BL.Models;

namespace Vude.BL.Facades;

public interface IMovieFacade
{
    Task SaveAsync(MovieModel model);
    Task SaveAsync(MovieListModel model);
    Task DeleteAsync(Guid id);
}
