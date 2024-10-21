using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Models.Dashboard;
using WWMS.BAL.Models.IORequests;

namespace WWMS.BAL.Interfaces
{
    public interface IDashBoardService
    {
        Task<List<GettMonthQuantity>> GetQuantityPerMonthListAsync(int month, int year);
    }
}
