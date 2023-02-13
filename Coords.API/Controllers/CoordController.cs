using AutoMapper;
using Coords.App.Commands.CreateCoord;
using Coords.Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coords.API.Controllers
{
    [Route("[controller]")]
    public class CoordController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CoordController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
            //var httpClient = new HttpClient();
            //var resp = await httpClient.GetAsync("GitHub");
            //var content = resp.RequestMessage.RequestUri;

            //content.Query
            //return Content(content, )
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreateCoordResultViewModel>> CreateCoord([FromBody] CreateCoordViewModel request)
        {
            var result = await _mediator.Send(new CreateCoordsCommand(request));

            return Ok(_mapper.Map<CreateCoordResultViewModel>(result));
        }
    }
}
