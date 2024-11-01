using AutoMapper;
using WWMS.BAL.Models.AlcoholByVolumes;
using WWMS.BAL.Models.BottleSizes;
using WWMS.BAL.Models.Brands;
using WWMS.BAL.Models.CheckRequests;
using WWMS.BAL.Models.Classes;
using WWMS.BAL.Models.Corks;
using WWMS.BAL.Models.Countries;
using WWMS.BAL.Models.Customers;
using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Models.IORequests.IOrequestdetails;
using WWMS.BAL.Models.Qualifications;
using WWMS.BAL.Models.ReportIORequest;
using WWMS.BAL.Models.Roles;
using WWMS.BAL.Models.Rooms;
using WWMS.BAL.Models.Supliers;
using WWMS.BAL.Models.Tastes;
using WWMS.BAL.Models.Users;
using WWMS.BAL.Models.WineCategories;
using WWMS.BAL.Models.WineRoom;
using WWMS.BAL.Models.Wines;
using WWMS.DAL.Entities;

namespace WWMS.BAL.Mappings
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region User
            CreateMap<User, GetUserResponse>()
                .ForMember(w => w.Role, w => w.MapFrom(w => w.Role.RoleName))
                .ForMember(w => w.Avatar, w => w.MapFrom(w => w.ProfileImageUrl));
            #endregion

            #region Wine
            CreateMap<Wine, GetWineResponse>();

            CreateMap<Wine, GetWineDetailResponse>();
            #endregion

            #region Wine Category
            CreateMap<WineCategory, GetWineCategoryResponse>();

            CreateMap<WineCategory, GetWineCategoryWithList>();

            CreateMap<CreateWineCategoryRequest, WineCategory>();
            #endregion

            #region Room
            CreateMap<WineRoom, RoomItem>()
                .ForMember(w => w.WineName, w => w.MapFrom(w => w.Wine.WineName));

            CreateMap<Room, GetRoomResponse>();

            CreateMap<Room, GetAvailableRoomResponse>()
                .ForMember(r => r.RoomName, r => r.MapFrom(r => r.RoomName + $" (Available: {r.Capacity - r.CurrentOccupancy} bottles)"));

            CreateMap<Room, GetRoomDetailResponse>();

            CreateMap<CreateRoomRequest, Room>();

            CreateMap<UpdateRoomRequest, Room>();

            CreateMap<Room, GetRoom>();

            CreateMap<WineRoom, GetRoomItemDetails>();
            #endregion

            #region IORequest


            CreateMap<IORequest, GetIORequest>();
            CreateMap<GetIORequest, IORequest>();

            CreateMap<CreateIORequest, IORequest>();
            ///
            CreateMap<CreateDetailsById, IORequest>();
            /// report
            CreateMap<CreateReport, IORequest>();
            CreateMap<CreateReportIORequest, IORequestDetail>();

            CreateMap<GetIorequestForReport, IORequest>();
            CreateMap<IORequest, GetIorequestForReport>();
            //



            CreateMap<GetReportIORequest, IORequestDetail>();
            CreateMap<IORequestDetail, GetReportIORequest>();
            ///

            ///
            CreateMap<IORequestDetail, GetIORequestDetail>();
            CreateMap<GetIORequestDetail, IORequestDetail>();

            CreateMap<CreateIORequestDetail, IORequestDetail>();
            CreateMap<UpdateIORequestDetail, IORequestDetail>();

            CreateMap<UpdateIORequest, IORequest>();

            // create for details 

            #endregion

            #region Report
            CreateMap<IORequestDetail, GetReportIORequest>();
            CreateMap<UpdateReportIORequest, GetReportIORequest>();

            #endregion

            #region Country
            CreateMap<Country, GetCountryResponse>();
            #endregion

            #region Taste
            CreateMap<Taste, GetTasteResponse>();
            #endregion

            #region Class
            CreateMap<Class, GetClassResponse>();
            #endregion

            #region Qualification
            CreateMap<Qualification, GetQualificationResponse>();
            #endregion

            #region Cork
            CreateMap<Cork, GetCorkResponse>();
            #endregion

            #region Brand
            CreateMap<Brand, GetBrandResponse>();
            #endregion

            #region BottleSize
            CreateMap<BottleSize, GetBottleSizeResponse>();
            #endregion

            #region AlcoholByVolume
            CreateMap<AlcoholByVolume, GetVolumeResponse>();
            #endregion

            #region Role
            CreateMap<Role, GetRoleResponse>();
            #endregion

            #region Suplier
            CreateMap<Suplier, GetSuplierResponse>();
            #endregion

            #region Customer
            CreateMap<Customer, GetCustomerResponse>();
            #endregion

            #region Check Request
            // Mapping  CreateCheckRequestRequest to CheckRequest

            CreateMap<CreateCheckRequestRequest, CheckRequest>()
                        .ForMember(dest => dest.CheckRequestDetails, opt => opt.MapFrom(src => src.CreateCheckRequestDetailRequests));

            // Map CreateCheckRequestDetailRequest to CheckRequestDetail entity
            CreateMap<CreateCheckRequestDetailRequest, CheckRequestDetail>()
                .ForMember(dest => dest.WineRoomId, opt => opt.MapFrom(src => src.WineRoomId))
                .ForMember(dest => dest.CheckerId, opt => opt.MapFrom(src => src.CheckerId))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));


            // Mapping from CheckRequest to GetCheckRequestResponse
            CreateMap<CheckRequest, GetCheckRequestResponse>()
                .ForMember(dest => dest.NoOfDetails, opt => opt.MapFrom(src => src.CheckRequestDetails.Count))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));



            // Mapping from CheckRequest to GetCheckRequestWithDetailsResponse

            CreateMap<CheckRequest, GetCheckRequestWithDetailsResponse>()
                .ForMember(dest => dest.CheckRequestDetails, opt => opt.MapFrom(src => src.CheckRequestDetails));

            CreateMap<CheckRequestDetail, GetCheckRequestDetailListItemResponse>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            #endregion

            #region staff 

            CreateMap<User, GetStaffResponse>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
           .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            #endregion

            #region Wine Room region
            CreateMap<WineRoom, GetActiveWineRoomNameResponse>()
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room.RoomName))
                .ForMember(dest => dest.WineName, opt => opt.MapFrom(src => src.Wine.WineName));
            #endregion

            #region CheckRequest Detail

            CreateMap<CheckRequestDetail, GetCheckRequestDetailViewDetailResponse>()
                .ForMember(dest => dest.CheckRequestCode, opt => opt.MapFrom(src => src.CheckRequestCode))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.CheckRequestId, opt => opt.MapFrom(src => src.CheckRequestId))
                .ForMember(dest => dest.WineId, opt => opt.MapFrom(src => src.WineId))
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier))
                .ForMember(dest => dest.WineName, opt => opt.MapFrom(src => src.WineName))
                .ForMember(dest => dest.MFD, opt => opt.MapFrom(src => src.MFD))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.RoomName))
                .ForMember(dest => dest.RoomCapacity, opt => opt.MapFrom(src => src.RoomCapacity))
                .ForMember(dest => dest.CheckerId, opt => opt.MapFrom(src => src.CheckerId))
                .ForMember(dest => dest.CheckerName, opt => opt.MapFrom(src => src.CheckerName))
                .ForMember(dest => dest.WineRoomId, opt => opt.MapFrom(src => src.WineRoomId))
                .ForMember(dest => dest.ExpectedCurrQuantity, opt => opt.MapFrom(src => src.ExpectedCurrQuantity))
                .ForMember(dest => dest.ReportCode, opt => opt.MapFrom(src => src.ReportCode))
                .ForMember(dest => dest.ReportDescription, opt => opt.MapFrom(src => src.ReportDescription))
                .ForMember(dest => dest.ReporterAssigned, opt => opt.MapFrom(src => src.ReporterAssigned))
                .ForMember(dest => dest.DiscrepanciesFound, opt => opt.MapFrom(src => src.DiscrepanciesFound))
                .ForMember(dest => dest.ActualQuantity, opt => opt.MapFrom(src => src.ActualQuantity))
                .ForMember(dest => dest.ReportFile, opt => opt.MapFrom(src => src.ReportFile))
                //.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.RequesterId, opt => opt.MapFrom(src => src.CheckRequest.RequesterId))
                .ForMember(dest => dest.RequesterName, opt => opt.MapFrom(src => src.CheckRequest.RequesterName));


            CreateMap<CreateAdditionalCheckRequestDetailRequest, CheckRequestDetail>()
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.CheckRequestId, opt => opt.MapFrom(src => src.CheckRequestId))
                .ForMember(dest => dest.CheckerId, opt => opt.MapFrom(src => src.CheckerId))
                .ForMember(dest => dest.WineRoomId, opt => opt.MapFrom(src => src.WineRoomId))

                // Set defaults for other entity fields that aren't part of the request
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id (auto-generated)
                .ForMember(dest => dest.WineId, opt => opt.Ignore())
                .ForMember(dest => dest.Supplier, opt => opt.Ignore())
                .ForMember(dest => dest.WineName, opt => opt.Ignore())
                .ForMember(dest => dest.MFD, opt => opt.Ignore())
                .ForMember(dest => dest.RoomId, opt => opt.Ignore())
                .ForMember(dest => dest.RoomName, opt => opt.Ignore())
                .ForMember(dest => dest.RoomCapacity, opt => opt.Ignore())
                .ForMember(dest => dest.ExpectedCurrQuantity, opt => opt.Ignore())
                .ForMember(dest => dest.CheckRequest, opt => opt.Ignore())
                .ForMember(dest => dest.ReportCode, opt => opt.Ignore())
                .ForMember(dest => dest.ReportDescription, opt => opt.Ignore())
                .ForMember(dest => dest.ReporterAssigned, opt => opt.Ignore())
                .ForMember(dest => dest.DiscrepanciesFound, opt => opt.Ignore())
                .ForMember(dest => dest.ActualQuantity, opt => opt.Ignore())
                .ForMember(dest => dest.ReportFile, opt => opt.Ignore());
            #endregion
        }
    }
}
