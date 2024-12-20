﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.LabCollections.YunPart.PolishNotation.Clases.Operations
{
    internal class Power : Operation
    {
        public override string Name => "^";
        public override int Priority => 3;
        public override bool IsFunction => false;
        public override int ArgsCount => 2;
        public override Number Execute(params Number[] numbers)
        {
            double firstNum = numbers[0].Numbering;
            double secondNum = numbers[1].Numbering;
            return new Number(Math.Pow(firstNum, secondNum));

        }
    }
}
