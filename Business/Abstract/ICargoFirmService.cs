using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICargoFirmService
    {
        public IDataResult<List<CargoFirm>> GetAll();
        public IResult CreateCargoFirm(CargoFirm cargoFirm);
        public IResult DeleteCargoFirm(int id);
        public IResult UpdateCargoFirm(CargoFirm cargoFirm);
    }
}
