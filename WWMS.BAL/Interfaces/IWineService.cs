﻿using WWMS.BAL.Models.Wines;

namespace WWMS.BAL.Interfaces
{
    public interface IWineService
    {
        Task CreateWineAsync(CreateUpdateWineRequest createWineRequest);

        Task<List<GetWineResponse>> GetWineListAsync();

        Task<GetWineResponse?> GetWineByIdAsync(long id);

        Task UpdateWineAsync(CreateUpdateWineRequest updateWineRequest);

        Task DisableWineAsync(long id);
    }
}
