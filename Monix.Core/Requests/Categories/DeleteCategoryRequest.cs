﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Core.Requests.Categories
{
    public class DeleteCategoryRequest : Request
    {
        public long Id { get; set; }
    }
}
