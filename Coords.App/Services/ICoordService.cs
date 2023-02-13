using Coords.Domain.ViewModels;

namespace Coords.App.Services
{
    public interface ICoordService
    {
        Task<CreateCoordResultViewModel> CreateCoord(CreateCoordViewModel request); 
    }
}
