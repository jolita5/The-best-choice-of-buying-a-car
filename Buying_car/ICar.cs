﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public interface ICar
    {

        void LaunchWeblink(string url);
        bool MakeUrlActive(string url);

        void Start();
    }
}
