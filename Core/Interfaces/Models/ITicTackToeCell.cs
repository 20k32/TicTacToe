using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Models
{
    public interface ITicTackToeCell
    {
        TicTacToeCellState State { get; set; }
    }
}
