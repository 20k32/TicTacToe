using CommunityToolkit.Mvvm.ComponentModel;
using Core.Enums;
using Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public sealed partial class TicTacCell : ObservableObject, ITicTackToeCell
    {
        [ObservableProperty]
        private TicTacToeCellState state;
    }
}
