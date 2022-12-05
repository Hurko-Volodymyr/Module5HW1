using Module5HW1.Services.Abstractions;
namespace Module5HW1
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;
        private readonly IAutorizeService _autorizeService;

        public App(IUserService userService, IResourceService resourceService, IAutorizeService autorizeService)
        {
            _userService = userService;
            _resourceService = resourceService;
            _autorizeService = autorizeService;
        }

        public async Task Start()
        {
            var user = await _userService.GetUserById(2);
            var userNotFound = await _userService.GetUserById(23);
            var userInfo = await _userService.CreateUser("morpheus", "leader");
            var users = await _userService.GetListUsersByPage(2);
            var usersDelay = await _userService.GetListUsersDelay(3);
            var userUpdate = await _userService.UpdateUser(2, "morpheus", "zion resident");

            var resource = await _resourceService.GetResourceById(2);
            var resourceNotFound = await _resourceService.GetResourceById(23);
            await _resourceService.GetListResoursesByPage(2);
            await _resourceService.GetListResoursesByPage(3);

            var register = await _autorizeService.Register("eve.holt@reqres.in", "pistol");
            var registerFailed = await _autorizeService.Register("eve.holt@reqres.in", string.Empty);

            var login = await _autorizeService.Login("eve.holt@reqres.in", "cityslicka");
            var loginFailed = await _autorizeService.Login("peter@klaven", string.Empty);
        }
    }
}