using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;
        protected async Task<TResponse> SendRequestAsync<TResponse>(IRequest<TResponse> request)
        {
            if (Mediator is null)
                throw new Exception("Mediator is null");
            return await Mediator.Send(request);
        }
    }
}
