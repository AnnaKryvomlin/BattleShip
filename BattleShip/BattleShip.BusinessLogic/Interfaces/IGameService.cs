using BattleShip.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        int CreateGame(int playerId);
        int CreateField(int playerId, int? gameId);
        void AddShipsToField(int fieldId, List<Ship> ships);
        List<Game> GetPlayerGames(int playerId);
        Game GetGame(int gameId);
        public int MarkCell(Coordinate coordinate, int gameId, int playerId);
        public List<Coordinate> GetCoordinatesForGame(int playerId, int gameId, bool isMine = true);
        public Coordinate GetCoordinate(int playerId, int gameId, int x, int y);
        public bool IsGameCanContinues(int gameId, int playerId);
        public string MoveRecord(int playerId, int gameId, int x, int y);
        public List<Move> GetAllRecords(int gameId);
        public void TrowUpTheTowel(int gameId);
    }
}
