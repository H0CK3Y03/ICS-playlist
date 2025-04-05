using BL.Models;

namespace BL.Facades;

public interface IMediaFileFacade
{
    Task SaveAsync(MediaDetailModel model);
    Task SaveAsync(MediaListModel model);
    Task DeleteAsync(Guid id);
}
