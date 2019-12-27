using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Concrete
{
    public class howIsWorkStepBll: IhowIsWorkStepBll
    {
        private IhowIsWorkStepDal _howIsWorkStepDal;
        public howIsWorkStepBll(IhowIsWorkStepDal howIsWorkStepDal)
        {
            _howIsWorkStepDal = howIsWorkStepDal;
        }
        public bool add(howIsWorkStep howIsWorkStep)
        {
            return _howIsWorkStepDal.Add(howIsWorkStep);
        }

        public bool delete(howIsWorkStep howIsWorkStep)
        {
            return _howIsWorkStepDal.Delete(_howIsWorkStepDal.getOne(x => x.id == howIsWorkStep.id));
        }

        public List<howIsWorkStep> getAll()
        {
            return _howIsWorkStepDal.listAll();
        }

        public howIsWorkStep getOne(int id)
        {
            return _howIsWorkStepDal.getOne(x => x.id == id);
        }

        public bool update(howIsWorkStep howIsWorkStep)
        {
            return _howIsWorkStepDal.Update(howIsWorkStep);
        }
    }
}
