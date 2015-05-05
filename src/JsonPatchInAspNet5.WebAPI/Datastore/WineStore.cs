using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonPatchInAspNet5.DTO;

namespace JsonPatchInAspNet5.WebAPI.Datastore
{
    public static class WineStore
    {

        private static List<BottleOfWine> _bottlesOfWine;
        public static List<BottleOfWine> BottlesOfWine { get
            {
                if (_bottlesOfWine == null)
                {
                    _bottlesOfWine = InitializeWineCellar();
                }
                return _bottlesOfWine;
            } }

        private static List<BottleOfWine> InitializeWineCellar()
        {

            return new List<BottleOfWine>()
            {
                new BottleOfWine()
                {
                    Id = 1,
                    Grape = "Chardonnay",
                    Name = "Francesco, Napa Valley",
                    Year = 2013
                },
                 new BottleOfWine()
                {
                    Id = 2,
                    Grape = "Pinot Noir",
                    Name = "Napa Cellars, Napa Valley",
                    Year = 2013
                }
            };
        }

    }
}
