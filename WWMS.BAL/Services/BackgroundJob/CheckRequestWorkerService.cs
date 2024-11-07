using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services.BackgroundJob
{
    public class CheckRequestWorkerService : BackgroundService
    {

        #region init + di

        private readonly ILogger<CheckRequestWorkerService> _logger;

        private readonly IServiceProvider _serviceProvider;

        public CheckRequestWorkerService(IServiceProvider serviceProvider, ILogger<CheckRequestWorkerService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        #endregion

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("CR Worker Service running at: {time}", DateTimeOffset.Now);

                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                        #region main check request
                        List<CheckRequest> checkRequests = (List<CheckRequest>)await _unitOfWork.CheckRequests.GetAllEntitiesActiveAsync();

                        //handle overdue
                        List<CheckRequest> overdueCheckRequests = checkRequests.Where(c => DateTime.Now > c.DueDate).ToList();

                        //overdue + active = disabled

                        foreach (var checkRequest in overdueCheckRequests)
                        {
                            checkRequest.Status = "DISABLED";
                            _unitOfWork.CheckRequests.UpdateEntity(checkRequest);

                        }
                        await _unitOfWork.CompleteAsync();

                        //handle non overdue
                        List<CheckRequest> nonOverdueCheckRequests = checkRequests.Where(c => DateTime.Now < c.DueDate).ToList();

                        //non overdue + active + all sub completed = completed
                        foreach (var checkRequest in nonOverdueCheckRequests)
                        {
                            if (checkRequest.CheckRequestDetails.All(d => d.Status == "COMPLETED"))
                            {
                                checkRequest.Status = "COMPLETED";
                                _unitOfWork.CheckRequests.UpdateEntity(checkRequest);
                            }
                        }
                        await _unitOfWork.CompleteAsync();



                        #endregion

                        #region check request details
                        List<CheckRequestDetail> checkRequestDetails = (List<CheckRequestDetail>)await _unitOfWork.CheckRequestDetails.GetAllActiveAsync();

                        //handle overdue
                        List<CheckRequestDetail> overdueCheckRequestDetails = checkRequestDetails.Where(d => DateTime.Now > d.DueDate).ToList();
                        foreach (var checkRequestDetail in overdueCheckRequestDetails)
                        {
                            checkRequestDetail.Status = "DISABLED";
                            _unitOfWork.CheckRequestDetails.UpdateEntity(checkRequestDetail);

                        }
                        await _unitOfWork.CompleteAsync();

                        //handle non overdue
                        List<CheckRequestDetail> nonOverdueCheckRequestDetails = checkRequestDetails.Where(d => DateTime.Now < d.DueDate).ToList();
                        foreach (var checkRequestDetail in nonOverdueCheckRequestDetails)
                        {
                            if (checkRequestDetail.CheckRequest.Status == "DISABLED")
                            {
                                checkRequestDetail.Status = "DISABLED";
                                _unitOfWork.CheckRequestDetails.UpdateEntity(checkRequestDetail);

                            }
                        }
                        await _unitOfWork.CompleteAsync();



                        #endregion

                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, ">>>>> Error occurred while scanning check request data.");
                }

                await Task.Delay(60000, stoppingToken); // Delay 1 min
            }
        }
    }
}