using BL.Models;

namespace BL.Facades;

public interface IMovieFacade
{
    Task SaveAsync(MovieDetailModel model);
    Task SaveAsync(MovieListModel model);
    Task DeleteAsync(Guid id);
}
