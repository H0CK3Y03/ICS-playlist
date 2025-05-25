using Vued.BL.Mappers;
using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.DAL.Mappers;
using Vued.DAL.UnitOfWork;

namespace Vued.BL.Facades;

public class GenreFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    GenreModelMapper modelMapper)
    : FacadeBase<GenreEntity, GenreListModel, GenreDetailModel, GenreEntityMapper>(
            unitOfWorkFactory, modelMapper),
        IGenreFacade
{
}
