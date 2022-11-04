﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {
        IRentDal _rentDal;

        public RentManager(IRentDal rentDal)
        {
            _rentDal = rentDal;
        }

        public IResult Add(Rent rent)
        {
            if (rent.ReturnDate == null && rent.RentDate >= DateTime.Now )
            {
                _rentDal.Add(rent);
                return new SuccessResult(Messages.RentAdded);
            }
            else
            {
                return new ErrorResult(Messages.RentInvalid);
            }
        }

        public IResult Delete(Rent rent)
        {
            _rentDal.Delete(rent);
            return new SuccessResult(Messages.RentDeleted);
        }

        public IDataResult<List<RentlDetailDTO>> GetRentDetails()
        {
            return new SuccessDataResult<List<RentlDetailDTO>>(_rentDal.GetRentDetails());
        }

        public IResult Update(Rent rent)
        {
            _rentDal.Update(rent);
            return new SuccessResult(Messages.RentUpdated);
        }
    }
}