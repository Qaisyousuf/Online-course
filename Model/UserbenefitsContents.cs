﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserbenefitsContents:EntityBase
    {
        public string Maintitle { get; set; }
        public string Content { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }

    }
}
