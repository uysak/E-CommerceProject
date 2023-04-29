using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class CargoFirmValidationHelper
    {
        ICargoFirmService _cargoFirmService;
        public CargoFirmValidationHelper(ICargoFirmService cargoFirmService)
        {
            _cargoFirmService = cargoFirmService;
        }

        public IResult CheckIfCargoFirmExists(string firmName)
        {
            var result = _cargoFirmService.GetByFirmName(firmName);

            if (result.Success)
            {
                return new ErrorResult("Cargo Firm Already Exist");
            }
            return new SuccessResult("Cargo Firm Not Exist");
        }

        public IResult CheckIfCargoFirmNotExist(int id)
        {
            var result = _cargoFirmService.GetById(id);

            if (!result.Success)
            {
                return new ErrorResult("Cargo Firm Not Exist");
            }
            return new SuccessResult("Cargo Firm Already Exist");
        }

    }
}
