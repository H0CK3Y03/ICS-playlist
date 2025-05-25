using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Facades;

public interface IMovieFacade : IFacade<MovieEntity, MovieListModel, MovieDetailModel>
{
}
