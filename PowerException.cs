﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class PowerException : Exception
    {
        PowerException(string message) : base(message)
        {

        }

    }
}
