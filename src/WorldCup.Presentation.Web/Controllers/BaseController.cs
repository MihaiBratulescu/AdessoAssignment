using Microsoft.AspNetCore.Mvc;

namespace WorldCup.Presentation.Web.Controllers
{
    [ApiController, Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IHandler handler;

        protected BaseController(IHandler handler)
        {
            this.handler = handler;
        }
    }
}
