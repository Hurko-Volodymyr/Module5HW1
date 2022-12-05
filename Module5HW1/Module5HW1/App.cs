using Module5HW1.Services.Abstractions;
namespace Module5HW1
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;

        public App(IUserService userService, IResourceService resourceService)
        {
            _userService = userService;
            _resourceService = resourceService;
        }

        public async Task Start()
        {
            var user = await _userService.GetUserById(2);
            var userNotFound = await _userService.GetUserById(23);
            var userInfo = await _userService.CreateUser("morpheus", "leader");
            var users = await _userService.GetListUsersByPage(2);
            var userUpdate = await _userService.UpdateUser(2, "morpheus", "zion resident");
            Console.WriteLine($"{userUpdate.Job}");

            var resource = await _resourceService.GetResourceById(2);
            var resourceNotFound = await _resourceService.GetResourceById(23);
            await _resourceService.GetListResoursesByPage(2);
        }
    }
}