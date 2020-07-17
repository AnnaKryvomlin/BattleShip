using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BattleShip.BusinessLogic.Interfaces;
using BattleShip.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BattleShip.WEB.Controllers
{
    [Authorize]
    public class PersonalAccountController : Controller
    {
        IGameService gameService;
        IPlayerService playerService;

        public PersonalAccountController(IGameService gameService, IPlayerService playerService)
        {
            this.gameService = gameService;
            this.playerService = playerService;
        }

        public IActionResult MyAccount()
        {
            int playerid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.PlayerId = playerid;
            var games = gameService.GetPlayerGames(Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier)));
            PersonalAccountViewModel personalAccountView = new PersonalAccountViewModel { UserName = playerService.FindPlayer(playerid).UserName, Games = games };
            return View(personalAccountView);
        }
    }
}
