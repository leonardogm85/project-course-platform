using System.Net.Mime;

using Asp.Versioning;

using CoursePlatform.Api.Controllers.Base;
using CoursePlatform.Core.Mediator.Interfaces;
using CoursePlatform.Core.Messages.DomainNotifications.Interfaces;
using CoursePlatform.Identity.Application.Commands.Roles;
using CoursePlatform.Identity.Domain.DataTransferObjects.Roles;

using Microsoft.AspNetCore.Mvc;

namespace CoursePlatform.Api.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/roles")]
[Produces(MediaTypeNames.Application.Json)]
public class RolesController : BaseController
{
    public RolesController(IMediatorHandler mediatorHandler, IDomainNotificationQuery domainNotificationQuery)
        : base(mediatorHandler, domainNotificationQuery)
    {
    }

    /// <summary>
    /// Get role by id
    /// </summary>
    /// <param name="id">The role id</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>Returns the role</returns>
    [HttpGet("get-role/{id:guid}")]
    [ProducesResponseType<GetRoleById>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRoleByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Create a role
    /// </summary>
    /// <param name="command">The role to be created</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>Returns the created role</returns>
    [HttpPost("add-role")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType<GetRoleById>(StatusCodes.Status201Created)]
    [ProducesResponseType<List<string>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
