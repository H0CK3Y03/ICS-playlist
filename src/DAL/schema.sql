CREATE TABLE IF NOT EXISTS "__EFMigrationsLock" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK___EFMigrationsLock" PRIMARY KEY,
    "Timestamp" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "Genres" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Genres" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL
);
CREATE TABLE sqlite_sequence(name,seq);
CREATE TABLE IF NOT EXISTS "MediaFile" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_MediaFile" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "Status" INTEGER NOT NULL,
    "Description" TEXT NULL,
    "Duration" INTEGER NOT NULL,
    "Director" TEXT NULL,
    "ReleaseDate" INTEGER NOT NULL,
    "Rating" TEXT NULL,
    "URL" TEXT NULL,
    "Favourite" INTEGER NOT NULL,
    "Discriminator" TEXT NOT NULL,
    "Length" INTEGER NULL,
    "NumberOfEpisodes" INTEGER NULL
);
CREATE TABLE IF NOT EXISTS "Watchlists" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Watchlists" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "Description" TEXT NULL
);
CREATE TABLE IF NOT EXISTS "GenreMediaFile" (
    "GenresId" INTEGER NOT NULL,
    "MediaFilesId" INTEGER NOT NULL,
    CONSTRAINT "PK_GenreMediaFile" PRIMARY KEY ("GenresId", "MediaFilesId"),
    CONSTRAINT "FK_GenreMediaFile_Genres_GenresId" FOREIGN KEY ("GenresId") REFERENCES "Genres" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_GenreMediaFile_MediaFile_MediaFilesId" FOREIGN KEY ("MediaFilesId") REFERENCES "MediaFile" ("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "MediaFileWatchlist" (
    "MediaFilesId" INTEGER NOT NULL,
    "WatchlistsId" INTEGER NOT NULL,
    CONSTRAINT "PK_MediaFileWatchlist" PRIMARY KEY ("MediaFilesId", "WatchlistsId"),
    CONSTRAINT "FK_MediaFileWatchlist_MediaFile_MediaFilesId" FOREIGN KEY ("MediaFilesId") REFERENCES "MediaFile" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_MediaFileWatchlist_Watchlists_WatchlistsId" FOREIGN KEY ("WatchlistsId") REFERENCES "Watchlists" ("Id") ON DELETE CASCADE
);
CREATE INDEX "IX_GenreMediaFile_MediaFilesId" ON "GenreMediaFile" ("MediaFilesId");
CREATE INDEX "IX_MediaFileWatchlist_WatchlistsId" ON "MediaFileWatchlist" ("WatchlistsId");
