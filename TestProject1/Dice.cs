﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{

    public static class Dice
    {
        public static decimal Roll(int sides)
        {
            //This code is so pog omg so me bestieeeeeee slay
            if (sides <= 0) { return 0; } 
            var rand = new Random();
            return Convert.ToDecimal(rand.Next(1, sides+1));
        }
    }
}
