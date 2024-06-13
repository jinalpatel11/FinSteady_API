using Microsoft.AspNetCore.Mvc;
using FinSteady_API.Infrastructure;
using FinSteady_API.Models.Request.Users;
using FinSteady_API.Models.Request;
using FinSteady_API.Models;
using FinSteady_API.Repositories.Interface;
using System.Net;

namespace FinSteady_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SavingGoalController : ControllerBase
    {
        private readonly ISavingGoalRepository savingGoalRepository;
        protected APIResponse _response;
        public SavingGoalController(ISavingGoalRepository savingGoal)
        {
            this.savingGoalRepository = savingGoal;
            _response = new();
        }


    }

}
