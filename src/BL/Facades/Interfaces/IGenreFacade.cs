using BL.Models;
using Domain.Entities;

namespace BL.Facades;

public interface IGenreFacade : IFacade<Genre, GenreListModel, GenreDetailModel>
{
    Task SaveAsync(GenreDetailModel model);
    Task SaveAsync(GenreListModel model);
}
