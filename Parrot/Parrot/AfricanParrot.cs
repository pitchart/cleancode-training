﻿using System;

namespace Parrot
{
    public class AfricanParrot : Parrot
    {
        private readonly int _numberOfCoconuts;
        private const double BaseSpeed = 12.0;
        private const double LoadFactor = 9.0;


        public AfricanParrot(int numberOfCoconuts)
        {
            _numberOfCoconuts = numberOfCoconuts;
        }

        public double GetSpeed()
        {
            return Math.Max(0, BaseSpeed - LoadFactor * _numberOfCoconuts);
        }
    }
}
