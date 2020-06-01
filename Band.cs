using System;
using System.Collections.Generic;

namespace Get_Rhythm
{
    class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public Boolean IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }

        // EFCore gives us the ability to access the following info
        // Band can have many albums
        public List<Album> Album { get; set; }
    }
}