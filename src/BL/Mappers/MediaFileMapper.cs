using BL.Models;
using Domain.Entities;

namespace BL.Mappers;

public class MediaFileModelMapper : ModelMapperBase<MediaFile, MediaFileListModel, MediaFileDetailModel>

{
    // Entity → ListModel
    public static object? MapToListModel(MediaFile? entity)
    {
        return entity switch
        {
            Movie movie => MovieMapper.MapToListModel(movie),
            Series series => SeriesMapper.MapToListModel(series),
            _ => null
        };
    }

    // Entity → DetailModel
    public static object? MapToDetailModel(MediaFile? entity)
    {
        return entity switch
        {
            Movie movie => MovieMapper.MapToDetailModel(movie),
            Series series => SeriesMapper.MapToDetailModel(series),
            _ => null
        };
    }
}
