using AutoMapper;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Chocolate.DataAccess.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidateViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
            CreateMap<Discount, DiscountViewModel>().ReverseMap();
            CreateMap<DiscountLevel, DiscountLevelViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<IdentityUser, UsersDetailsViewModel>().ReverseMap();
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
            CreateMap<Interview, InterviewViewModel>().ReverseMap();
            CreateMap<Leave, LeaveViewModel>().ReverseMap();
            CreateMap<Offer, OfferViewModel>().ReverseMap();
            CreateMap<OfferItem, OfferItemViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Position, PositionViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Purchase, PurchaseViewModel>().ReverseMap();
            CreateMap<RawMaterial, RawMaterialViewModel>().ReverseMap();
            CreateMap<Sector, SectorViewModel>().ReverseMap();
            CreateMap<Shelf, ShelfViewModel>().ReverseMap();
            CreateMap<StorageUnit, StorageUnitViewModel>().ReverseMap();
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<Warehouse, WarehouseViewModel>().ReverseMap();
        }
    }
}
