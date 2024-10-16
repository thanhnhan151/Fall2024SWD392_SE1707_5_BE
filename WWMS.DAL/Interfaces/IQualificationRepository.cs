﻿using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IQualificationRepository : IGenericRepository<Qualification>
    {
        Task<bool> CheckExistAsync(string request);
    }
}
