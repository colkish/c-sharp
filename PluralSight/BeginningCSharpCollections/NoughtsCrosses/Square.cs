using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsCrosses
{
    //=0 means it's the default
    public enum Player { Noone = 0, Noughts, Crosses }

    //A struct not a class, hence it's starts empty
    public struct Square
    {
        public Player Owner{ get; }

        public Square(Player owner)
        {
            this.Owner = owner;

        }

        public override string ToString()
        {

            switch (Owner)
            {
                case Player.Noone:
                    return ".";
                case Player.Crosses:
                    return "X";
                case Player.Noughts:
                    return "O";
                default:
                    throw new Exception("Invalid state");

            }

        }

    }


}
