using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public static class Category
    {
        public const string WIEDZAOGOLNA = "Wiedza ogólna";

        public const string SWIAT = "Świat";
        public const string PRZYRODA = "Przyroda";
        public const string ZWIERZETA = "Zwierzęta";
        public const string CZLOWIEK = "Człowiek";

        public const string GEOGRAFIA = "Geografia";
        public const string HISTORIA = "Historia";
        public const string MATEMATYKA = "Matematyka";

        public const string NAUKA = "Nauka";
        public const string TECHNIKA = "Technika";


        public const string FILMYSERIALE= "Filmy i seriale";
        public const string MUZYKA= "Muzyka";


        public const string JPOLSKI= "Język polski";
        public const string JANGIELSKI= "Język angielski";
        public const string JOBCE= "Inne języki obce";


        public const string ZAGADKI = "Zagadki";
        
        public const string DLADZIECI = "Dla dzieci";
        public const string WIEDZASZKOLNA = "Wiedza szkolna";

        public const string SPORT = "Sport";

        public const string INNE = "Inne";

        public static readonly string[] CATEGORIES = {

            WIEDZAOGOLNA,
            SWIAT,
            PRZYRODA,
            ZWIERZETA,
            CZLOWIEK,
            GEOGRAFIA,
            HISTORIA,
            MATEMATYKA,
            NAUKA,
            TECHNIKA,
            FILMYSERIALE,
            MUZYKA,
            JPOLSKI,
            JANGIELSKI,
            JOBCE,
            ZAGADKI,
            DLADZIECI,
            WIEDZASZKOLNA,
            SPORT,
            INNE   
        };



    }
}
