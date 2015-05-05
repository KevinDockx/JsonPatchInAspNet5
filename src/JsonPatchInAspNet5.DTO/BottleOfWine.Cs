using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonPatchInAspNet5.DTO
{
    public class BottleOfWine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Grape { get; set; }

    }
}
