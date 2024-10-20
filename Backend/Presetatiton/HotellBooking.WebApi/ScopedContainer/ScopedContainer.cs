using HotellBooking.Application.Interfaces;
using HotellBooking.Persitence.EfRepositories;

namespace HotellBooking.WebApi.ScopedContainer;

public static class ScopedContainer
{
    public static void RegisterScopedServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IEfGenericRepository<>), typeof(EfGenericRepository<>));
        services.AddScoped<IEfHotelRepository, EfHotelRepository>();
        services.AddScoped<IEfRoomRepository, EfRoomRepository>();
        services.AddScoped<IEfRoomTypeRepository, EfRoomTypeRepository>();
        services.AddScoped<IEfReservationRepository, EfReservationRepository>();
        services.AddScoped<IEfRoomStatusRepository, EfRoomStatusRepository>();
        services.AddScoped<IEfAddressRepository, EfAddressRepository>();
        services.AddScoped<IEfOrderRepository,EfOrderRepository>();
        services.AddScoped<IEfOwnerRepository,EfOwnerRepository>();
        services.AddScoped<IEfRoomImageRepository,EfRoomImageRepository>();
        services.AddScoped<IEfRoomFacilityRepository, EfRoomFacilityRepository>();
        services.AddScoped<IEfFacilityRepository, EfFacilityRepository>();
        services.AddScoped<IEfEmployeeRepository, EfEmployeeRepository>();
        services.AddScoped<IEfGuestRepository, EfGuestRepository>();
        services.AddScoped<IEfHotelImageRepository, EfHotelImageRepository>();
        services.AddScoped<IEfInformationRepository, EfInformationRepository>();
        services.AddScoped<IEfApplicationUserRepository, EfApplicationUserRepository>();
        services.AddScoped<IEfGuestListRepository, EfGuestListRepository>();
        


    }
}