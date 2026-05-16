using CommunityToolkit.Mvvm.Input;
using Core.Enums;
using Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Interfaces.Presentation
{
    public interface IMainViewModel
    {
        ObservableCollection<ITicTackToeCell> Cells { get; }
        IRelayCommand<TicTacToeAffectedCell> ChangeCellStateCommand { get; }
    }
}
