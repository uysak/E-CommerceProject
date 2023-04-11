using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CargoFirmManager : ICargoFirmService
    {
        ICargoFirmDal _cargoFirmDal;

        public CargoFirmManager(ICargoFirmDal cargoFirmDal)
        {
            _cargoFirmDal = cargoFirmDal;
        }

        public IDataResult<List<CargoFirm>> GetAll()
        {
            var result = _cargoFirmDal.GetAll();
            if (result == null || result.Count == 0)
            {
                return new ErrorDataResult<List<CargoFirm>>("Veri yok");
            }
            return new SuccessDataResult<List<CargoFirm>>(result);
        }

        public IResult CreateCargoFirm(CargoFirm cargoFirm)
        {
            var result = BusinessRules.Run(CheckIfCargoFirmExists(cargoFirm.FirmName));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _cargoFirmDal.Add(cargoFirm);
            return new SuccessResult();
        }

        public IResult DeleteCargoFirm(int id)
        {
            var result = BusinessRules.Run(CheckIfCargoFirmNotExist(id));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            var deletedCargoFirm = _cargoFirmDal.Get(s => s.Id == id);

            _cargoFirmDal.Delete(deletedCargoFirm);
            return new SuccessResult();
        }
        public IResult UpdateCargoFirm(CargoFirm cargoFirm)
        {
            var result = BusinessRules.Run(CheckIfCargoFirmNotExist(cargoFirm.Id));

            var updatedCargoFirm = _cargoFirmDal.Get(s => s.Id == cargoFirm.Id);

            updatedCargoFirm.FirmName = cargoFirm.FirmName == default ? updatedCargoFirm.FirmName : cargoFirm.FirmName;
            updatedCargoFirm.Img = cargoFirm.Img == default ? updatedCargoFirm.Img : cargoFirm.Img;
            updatedCargoFirm.SiteUrl = cargoFirm.SiteUrl == default ? updatedCargoFirm.SiteUrl : cargoFirm.SiteUrl;

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _cargoFirmDal.Update(updatedCargoFirm);
            return new SuccessResult();
        }

        public IResult CheckIfCargoFirmExists(string firmName)
        {
            var result = _cargoFirmDal.Get(s => s.FirmName == firmName);

            if (result != null)
            {
                return new ErrorResult("Cargo Firm Already Exist");
            }
            return new SuccessResult("Cargo Firm Not Exist");
        }

        public IResult CheckIfCargoFirmNotExist(int id)
        {
            var result = _cargoFirmDal.Get(s => s.Id == id);

            if (result == null)
            {
                return new ErrorResult("Cargo Firm Not Exist");
            }
            return new SuccessResult("Cargo Firm Already Exist");
        }

    }

}
