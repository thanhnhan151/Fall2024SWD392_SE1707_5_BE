using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Mappings;
using WWMS.BAL.Models.Users;
using WWMS.BAL.Models.Wines;
using WWMS.BAL.Services;
using WWMS.BAL.Services.BackgroundJob;
using WWMS.BAL.Validators.Users;
using WWMS.BAL.Validators.Wines;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Persistences;

namespace WWMS.BAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureBALServices(this IServiceCollection services)
        {
            #region DbContext
            services.AddDbContext<WineWarehouseDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            #endregion

            #region AutoMapper
            services.AddAutoMapper(typeof(MappingProfiles));
            #endregion

            #region Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IWineService, WineService>();

            services.AddScoped<IRoomService, RoomService>();

            services.AddScoped<IWineCategoryService, WineCategoryService>();

            services.AddScoped<IIORequestService, IORequestService>();

            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IVnPayService, VnPayService>();

            services.AddScoped<IUploadFileService, UploadFileService>();

            services.AddScoped<ICountryService, CountryService>();

            services.AddScoped<ITasteService, TasteService>();

            services.AddScoped<IClassService, ClassService>();

            services.AddScoped<IQualificationService, QualificationService>();

            services.AddScoped<ICorkService, CorkService>();

            services.AddScoped<IBrandService, BrandService>();

            services.AddScoped<IBottleSizeService, BottleSizeService>();

            services.AddScoped<IAlcoholByVolumeService, AlcoholByVolumeService>();

            services.AddScoped<ISuplierService, SuplierService>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IReportIORequestService, ReportIORequestService>();

            services.AddScoped<ICheckRequestService, CheckRequestService>();

            services.AddScoped<ICheckRequestDetailService, CheckRequestDetailService>();

            services.AddScoped<IReportCheckRequestService, ReportCheckRequestService>();

            services.AddScoped<IDashBoardService, DashBoardService>();

            services.AddScoped<IWineRoomService, WineRoomService>();

            services.AddHostedService<CheckRequestWorkerService>();

            #endregion

            #region Validators
            services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();

            services.AddScoped<IValidator<CreateUpdateWineRequest>, CreateUpdateWineRequestValidator>();
            #endregion

            return services;
        }
    }
}
