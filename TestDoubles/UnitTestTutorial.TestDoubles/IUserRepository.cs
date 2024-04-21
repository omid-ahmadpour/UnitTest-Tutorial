namespace UnitTestTutorial.TestDoubles
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
    }

    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string GetUserNameById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            return user != null ? user.Name : null;
        }
    }

    public class User
    {
        public string Name { get; set; }
    }
}
