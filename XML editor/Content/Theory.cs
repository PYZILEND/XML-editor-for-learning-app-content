﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor.Content
{
    public class Theory : Entry
    {
        public Theory(int id, string text)
        {
            this.id = id;
            this.text = text;
        }
    }
}
