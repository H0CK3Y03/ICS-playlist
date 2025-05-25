using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vued.DAL.Seeds;

public static class GenreMediaSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity("GenreMediaFile").HasData(
            new Dictionary<string, object> { ["MediaFilesId"] = 1, ["GenresId"] = 1 },
            new Dictionary<string, object> { ["MediaFilesId"] = 1, ["GenresId"] = 5 },

            new Dictionary<string, object> { ["MediaFilesId"] = 2, ["GenresId"] = 3 },
            new Dictionary<string, object> { ["MediaFilesId"] = 2, ["GenresId"] = 8 },

            new Dictionary<string, object> { ["MediaFilesId"] = 3, ["GenresId"] = 4 },
            new Dictionary<string, object> { ["MediaFilesId"] = 3, ["GenresId"] = 9 },

            new Dictionary<string, object> { ["MediaFilesId"] = 4, ["GenresId"] = 5 },
            new Dictionary<string, object> { ["MediaFilesId"] = 4, ["GenresId"] = 9 },

            new Dictionary<string, object> { ["MediaFilesId"] = 5, ["GenresId"] = 11 },
            new Dictionary<string, object> { ["MediaFilesId"] = 5, ["GenresId"] = 3 },

            new Dictionary<string, object> { ["MediaFilesId"] = 6, ["GenresId"] = 6 },
            new Dictionary<string, object> { ["MediaFilesId"] = 6, ["GenresId"] = 18 },

            new Dictionary<string, object> { ["MediaFilesId"] = 7, ["GenresId"] = 1 },
            new Dictionary<string, object> { ["MediaFilesId"] = 7, ["GenresId"] = 26 },

            new Dictionary<string, object> { ["MediaFilesId"] = 8, ["GenresId"] = 5 },
            new Dictionary<string, object> { ["MediaFilesId"] = 8, ["GenresId"] = 3 },

            new Dictionary<string, object> { ["MediaFilesId"] = 9, ["GenresId"] = 8 },
            new Dictionary<string, object> { ["MediaFilesId"] = 9, ["GenresId"] = 47 },

            new Dictionary<string, object> { ["MediaFilesId"] = 10, ["GenresId"] = 3 },
            new Dictionary<string, object> { ["MediaFilesId"] = 10, ["GenresId"] = 25 },

            new Dictionary<string, object> { ["MediaFilesId"] = 11, ["GenresId"] = 9 },
            new Dictionary<string, object> { ["MediaFilesId"] = 11, ["GenresId"] = 23 },

            new Dictionary<string, object> { ["MediaFilesId"] = 12, ["GenresId"] = 1 },
            new Dictionary<string, object> { ["MediaFilesId"] = 12, ["GenresId"] = 13 },

            new Dictionary<string, object> { ["MediaFilesId"] = 13, ["GenresId"] = 5 },
            new Dictionary<string, object> { ["MediaFilesId"] = 13, ["GenresId"] = 6 },

            new Dictionary<string, object> { ["MediaFilesId"] = 14, ["GenresId"] = 14 },
            new Dictionary<string, object> { ["MediaFilesId"] = 14, ["GenresId"] = 16 }
        );
    }
}
