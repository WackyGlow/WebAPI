﻿using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance GetById(int id);
        Insurance CreateInsurance(Insurance insurance);
        List<Insurance> ReadAll();
        string DeleteInsuranceById(int id);
        Insurance UpdateInsurance(Insurance insurance);
    }
}