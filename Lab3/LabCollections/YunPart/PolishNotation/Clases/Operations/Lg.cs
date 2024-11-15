﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.LabCollections.YunPart.PolishNotation.Clases.Operations
{
    internal class Lg : Operation
    {
        public override string Name => "lg";
        public override int Priority => 4;
        public override bool IsFunction => true;
        public override int ArgsCount => 1;
        public override Number Execute(params Number[] numbers)
        {
            double firstNum = numbers[0].Numbering;
            return new Number(Math.Log10(firstNum));
        }
    }

}
