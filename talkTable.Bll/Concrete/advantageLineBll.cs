﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class advantageLineBll: IadvantageLineBll
    {
        private IadvantageLineDal _advantageLineDal;
        public advantageLineBll(IadvantageLineDal advantageLineDal)
        {
            _advantageLineDal = advantageLineDal;
        }
    }
}
