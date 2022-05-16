// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using BTSolution.API.Data;
using BTSolution.API.Models;
using BTSolution.API.Services;

using Microsoft.AspNetCore.Mvc;


namespace BTSolution.API.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class AccessTokenController : ControllerBase
{
    #region Static Members

    private const int MaxDurationInSeconds = 60;

    private const int MinDurationInSeconds = 1;

    #endregion

    #region Members

    private readonly AccessTokenService _service;

    #endregion

    #region Constructors

    public AccessTokenController(AccessTokenService service)
    {
        _service = service;
    }

    #endregion

    #region Methods - Public

    /// <summary>
    ///     Asks the AccessTokenService to generate an AccessToken with the provided parameters
    /// </summary>
    /// <param name="userId">userId to assign the token to</param>
    /// <param name="durationInSeconds">duration of the token</param>
    [HttpPost("{userId}/{durationInSeconds}")]
    public async Task<IActionResult> GenerateAccessToken(int userId, int durationInSeconds)
    {
        if (userId < 0)
            return BadRequest();

        switch (durationInSeconds) {
            case < MinDurationInSeconds:
                return BadRequest($@"Duration smaller than {MinDurationInSeconds}, this is not permitted under current policy.");
            case > MaxDurationInSeconds:
                return BadRequest($@"Duration greater than {MaxDurationInSeconds}, this is not permitted under current policy.");
        }

        try {
            _service.GenerateAccessToken(userId, durationInSeconds);
            return Ok();
        } catch {
            return BadRequest();
        }
    }

    /// <summary>
    ///     Asks the AccessTokenService for all the AccessTokens in the db (NOT expired)
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<AccessTokenForTransfer>>> GetValidAccessTokens()
    {
        return Ok(await _service.GetValidAccessTokens());
    }

    #endregion
}