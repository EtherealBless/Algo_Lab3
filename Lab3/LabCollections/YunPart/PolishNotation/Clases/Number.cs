﻿using Lab3.LabCollections.YunPart.PolishNotation.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3.LabCollections.YunPart.PolishNotation.Clases
{

    public class Number : Token
    {
        public double Numbering { get; set; }

        public Number(double x)
        {
            Numbering = x;
        }
    }
}