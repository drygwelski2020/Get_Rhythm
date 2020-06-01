using System;

namespace Get_Rhythm
{
    class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AlbumId { get; set; }
        public int BandId { get; set; }

        // EFCore gives us the ability to access the following info
        // Related objects for the Song class
        public Album Album { get; set; }
        public Band Band { get; set; }

    }
}