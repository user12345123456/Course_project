using AutoMapper;
using ZakazObedov1.DataAccess.Repository.Contracts;
using ZakazObedov1.Entities;
using ZakazObedov1.Services.Contract;
using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(UserDto user)
        {
            var existedUser = await _userRepository.GetByName(user.Name);

            if (existedUser != null)
            {
                throw new Exception("User exist");
            }

            var userToAdd = _mapper.Map<User>(user);
            return await _userRepository.Create(userToAdd);
        }
        
        public async Task<List<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<int> Update(UserDto user)
        {
            var userToUpdate = await _userRepository.GetById(user.Id)
                ?? throw new Exception("User not exist");

            userToUpdate = _mapper.Map(user, userToUpdate);
            return await _userRepository.Update(userToUpdate);
        }
    }
}