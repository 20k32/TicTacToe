using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Game
{
    public sealed class Player
    {
        public TicTacToeCellState Type { get; init; }
        public Guid Id { get; init; }

        public Player(TicTacToeCellState type)
        {
            Type = type;
        }
    }
}
