using System;
using System.Collections.Generic;

namespace SamuraiApp.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; } = new List<Quote>(); //fk referenc to quotes
        public List<Battle> Battles { get; set; } = new List<Battle>(); //fk many to many reference to battle
        public Horse Horse { get; set; } //navigation property, has FK in the Horse class

    }
}
