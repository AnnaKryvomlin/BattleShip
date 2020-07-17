using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShip.Models.Entities;
using BattleShip.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BattleShip.BusinessLogic.Interfaces;
using AutoMapper;

namespace BattleShip.WEB.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private IGameService gameService;

        public GameController(IGameService service)
        {
            this.gameService = service;
        }

        public IActionResult CreateGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGame([FromBody] ShipViewModel[] shipsView)
        {
            int playerid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShipViewModel, Ship>()).CreateMapper();
            var ships = mapper.Map <IEnumerable<ShipViewModel>, List<Ship>>(shipsView);
            int gameId = gameService.CreateGame(playerid);
            int fieldId = gameService.CreateField(playerid, gameId);
            gameService.AddShipsToField(fieldId, ships);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult FindGame([FromBody] ShipViewModel[] shipsView)
        {
            int playerid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShipViewModel, Ship>()).CreateMapper();
            var ships = mapper.Map<IEnumerable<ShipViewModel>, List<Ship>>(shipsView);
            int fieldId = gameService.CreateField(playerid, null);
            gameService.AddShipsToField(fieldId, ships);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Game(int id)
        {
            int playerid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.PlayerId = playerid;
            ViewBag.GameId = id;
            var game = gameService.GetGame(id);
            ViewBag.CurrentMove = game.CurrentMovePlayerId;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Move, RecordsView>()).CreateMapper();
            var records = mapper.Map<IEnumerable<Move>, List<RecordsView>>(gameService.GetAllRecords(id));
            return View(records);
        }

        [HttpGet]
        public JsonResult GetMyCoordinates(int id)
        {
            int playerid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Coordinate, CoordinateView>()
            .ForMember("HaveShip", opt => opt.MapFrom(c => c.Ship != null))).CreateMapper();
            var coord = gameService.GetCoordinatesForGame(playerid, id);
            var coordinates = mapper.Map<IEnumerable<Coordinate>, List<CoordinateView>>(coord);
            return Json(coordinates);
        }

        [HttpGet]
        public JsonResult GetEnemyCoordinates(int id)
        {
            int playerid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));            
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Coordinate, CoordinateView>()
            .ForMember("HaveShip", opt => opt.MapFrom(c => c.Ship != null))).CreateMapper();
            var coord = gameService.GetCoordinatesForGame(playerid, id, false);
            var coordinates = mapper.Map<IEnumerable<Coordinate>, List<CoordinateView>>(coord);
            return Json(coordinates);
        }
    }
}
