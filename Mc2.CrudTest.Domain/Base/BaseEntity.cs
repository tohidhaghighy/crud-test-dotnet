﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Base
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
