﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillz.Db
{
   public interface IModel
    {
       int Id { get; set; }

        void UpdateFrom(IModel source);

    }
}