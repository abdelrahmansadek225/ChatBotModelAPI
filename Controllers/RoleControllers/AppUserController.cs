using ChatBotModelAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatBotModelAPI.Controllers.RoleControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppUserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
