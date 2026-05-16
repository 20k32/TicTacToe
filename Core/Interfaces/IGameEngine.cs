using Core.Enums;
using Core.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IGameEngine
    {
        void AssignPlayers();
        Player Me { get; }
        bool IsMineTurnFirst();
        bool MakeTurn(int posX, int posY, TicTacToeCellState state);
        bool CheckForGameCompletion();
        void ResetState();
    }
}
