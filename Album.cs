using System;

namespace Get_Rhythm
{
    class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Boolean IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }

        // EFCore gives us the ability to access the following info
        // Related object for the Album class
        public Band Band { get; set; }
    }
}