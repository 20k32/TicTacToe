using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Enums;
using Core.Game;
using Core.Interfaces.Models;
using Core.Interfaces.Presentation;
using Models;
using Presentation.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Reflection;
using System.Text;
using System.Windows;

namespace Presentation.ViewModels.MainPage
{
    public sealed partial class MainViewModel : ObservableObject, IMainViewModel
    {
        private readonly GameEngine _game;

        private readonly ObservableCollection<ITicTackToeCell> _cells;
        public ObservableCollection<ITicTackToeCell> Cells => _cells;

        public MainViewModel()
        {
            _cells =
           [
               new TicTacCell(),
                new TicTacCell(),
                new TicTacCell(),
                new TicTacCell(),
                new TicTacCell(),
                new TicTacCell(),
                new TicTacCell(),
                new TicTacCell(),
                new TicTacCell()
           ];

            _game = new GameEngine();
            _game.FieldChanged += OnGameFiledChanged;
            _game.AssignPlayers();

            if (!_game.IsMineTurnFirst())
            {
                _game.MakeTurn();
            }

            _game.GameEndedWithWinner += OnGameEndedWithWinner;
            _game.GameEndedWithDraw += OnGameEndedWithDraw;
            _game.GameEndedWithFullField += OnGameEndedWithFullField;
        }

        private void OnGameEndedWithWinner(TicTacToeCellState state)
        {
            MessageBox.Show($"Winner is: {state.ToString()}");
        }

        private void OnGameEndedWithDraw()
        {
            MessageBox.Show("Draw");
        }

        private void OnGameEndedWithFullField()
        {
            MessageBox.Show("Field is full!");
        }

        private void OnGameFiledChanged(bool isCross, int posX, int posY)
        {
            var index = posX * GameEngine.FIELD_WIDTH + posY;
            Cells[index].State = isCross ? TicTacToeCellState.Cross : TicTacToeCellState.Circe;
        }

        [RelayCommand]
        private void ChangeCellState(TicTacToeAffectedCell cell)
        {
            if (!_game.CheckForGameCompletion())
            {
                var cellIndex = (int)cell;

                var row = cellIndex / GameEngine.FIELD_WIDTH;
                var column = cellIndex % GameEngine.FIELD_WIDTH;

                if (_game.MakeTurn(row, column, _game.Me.Type) 
                    && !_game.CheckForGameCompletion() 
                    && _game.MakeTurn())
                {
                    _game.CheckForGameCompletion();
                }
            }
        }
    }
}
