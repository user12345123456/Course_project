using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Services.Contract
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);
        Task<List<UserDto>> GetAll();

        Task<int> Create(UserDto user);

        Task<int> Update(UserDto user);
        Task<int> Delete(int id);
    }
}