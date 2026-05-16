using Core.Enums;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing.Printing;
using System.Numerics;
using System.Text;

namespace Core.Game
{
    public sealed class GameEngine : IGameEngine
    {
        public const int FIELD_WIDTH = 3;

        private int _turnCount;

        public Player Me { get; private set; }

        private Player _player1;
        private Player _player2;

        private TicTacToeCellState?[,] _field = new TicTacToeCellState?[3, 3];

        public event Action<bool, int, int> FieldChanged;
        public event Action GameEndedWithFullField;
        public event Action<TicTacToeCellState> GameEndedWithWinner;
        public event Action GameEndedWithDraw;

        public GameEngine()
        {
            _turnCount = 0;
        }

        public void DefinePlayerForMe(string id)
        {
            if (_player1.Id.Equals(id))
            {
                Me = _player1;
            }
            else
            {
                Me = _player2;
            }
        }

        public bool IsMineTurnFirst() => Me.Type == TicTacToeCellState.Cross;

        public TicTacToeCellState DefineTurn() => _turnCount % 2 == 0 ? TicTacToeCellState.Cross : TicTacToeCellState.Circe;
        private TicTacToeCellState DefineWinnerTurn() => (_turnCount - 1) % 2 == 0 ? TicTacToeCellState.Cross : TicTacToeCellState.Circe;

        public bool MakeTurn(int posX, int posY, TicTacToeCellState cellState)
        {
            if (CheckForGameCompletion())
            {
                return false;
            }

            var turn = DefineTurn();

            bool result = false;

            if (_field[posY, posX] == null)
            {
                _field[posY, posX] = cellState;
                _turnCount++;
                result = true;

                var isCross = cellState == TicTacToeCellState.Cross;
                FieldChanged(isCross, posX, posY);
            }

            return result;
        }

        public bool MakeTurn()
        {
            if (CheckForGameCompletion())
            {
                return false;
            }

            var emptyCells = new List<(int x, int y)>();

            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    if (_field[i, j] == default)
                    {
                        emptyCells.Add((j, i));
                    }
                }
            }

            var chosen = emptyCells[Random.Shared.Next(emptyCells.Count)];

            return MakeTurn(chosen.x, chosen.y, DefineTurn());
        }

        private bool CheckIfFieldIsFull()
        {
            int counter = 0;

            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    if (_field[i, j] != null)
                    {
                        counter++;
                    }
                }
            }

            return counter == _field.Length;
        }

        private bool CheckForWinner()
        {
            bool thereIsAWinner = false;

            // y
            if ((_field[0, 0] == _field[0, 1]) && (_field[0, 1] == _field[0, 2]) && _field[0, 0] is not null)
            {
                thereIsAWinner = true;
            }
            else if ((_field[1, 0] == _field[1, 1]) && (_field[1, 1] == _field[1, 2]) && _field[1, 0] is not null)
            {
                thereIsAWinner = true;
            }
            else if ((_field[2, 0] == _field[2, 1]) && (_field[2, 1] == _field[2, 2]) && _field[2, 0] is not null)
            {
                thereIsAWinner = true;
            }
            // x
            else if ((_field[0, 0] == _field[1, 0]) && (_field[1, 0] == _field[2, 0]) && _field[0, 0] is not null)
            {
                thereIsAWinner = true;
            }
            else if ((_field[0, 1] == _field[1, 1]) && (_field[1, 1] == _field[2, 1]) && _field[0, 1] is not null)
            {
                thereIsAWinner = true;
            }
            else if ((_field[0, 2] == _field[1, 2]) && (_field[1, 2] == _field[2, 2]) && _field[0, 2] is not null)
            {
                thereIsAWinner = true;
            }
            // x + y
            else if ((_field[0, 0] == _field[1, 1]) && (_field[1, 1] == _field[2, 2]) && _field[0, 0] is not null)
            {
                thereIsAWinner = true;
            }
            else if ((_field[0, 2] == _field[1, 1]) && (_field[1, 1] == _field[2, 0]) && _field[0, 2] is not null)
            {
                thereIsAWinner = true;
            }

            if (thereIsAWinner)
            {
                return true;
            }

            return false;
        }

        public bool CheckForGameCompletion()
        {

            if (CheckForWinner())
            {
                var turn = DefineWinnerTurn();

                GameEndedWithWinner.Invoke(turn);

                return true;
            }
            else if (CheckIfFieldIsFull())
            {
                GameEndedWithFullField.Invoke();

                return true;
            }
            else if (_turnCount == _field.Length)
            {
                GameEndedWithDraw.Invoke();
            }

            return false;

        }

        public void ResetState()
        {
            _turnCount = 0;

            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    _field[i, j] = null;
                }
            }
        }

        public void AssignPlayers()
        {
            _player1 = new(TicTacToeCellState.Cross);
            _player2 = new(TicTacToeCellState.Circe);

            if ((TicTacToeCellState)Random.Shared.Next(1, 3) == TicTacToeCellState.Circe)
            {
                Me = _player1;
            }
            else
            {
                Me = _player2;
            }
        }
    }
}
