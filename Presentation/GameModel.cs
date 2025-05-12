using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Cell = PongFight.Models.Cell;

namespace PongFight.Presentation;

public class GameViewModel : INotifyPropertyChanged
{
    private readonly Game _game;
    private readonly CancellationTokenSource _cts = new();

    private int _speed;
    private string _score = string.Empty;

    public GameViewModel()
    {
        Title = "Game";
        _game = new Game(16, 16);
        _speed = _game.Speed;

        Cells = new ObservableCollection<Cell>();

        StartGameLoop();
        UpdateScore();
    }

    public string Title { get; }

    public ObservableCollection<Cell> Cells { get; }

    public string Score
    {
        get => _score;
        private set
        {
            if (_score != value)
            {
                _score = value;
                OnPropertyChanged();
            }
        }
    }

    public int Speed
    {
        get => _speed;
        set
        {
            if (_speed != value)
            {
                _speed = value;
                _game.Speed = value;
                OnPropertyChanged();
                RestartGameLoop(); // restart with updated speed
            }
        }
    }

    private void StartGameLoop()
    {
        Task.Run(async () =>
        {
            await foreach (var cellList in _game.Loop(_cts.Token))
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Cells.Clear();
                    foreach (var cell in cellList)
                        Cells.Add(cell);

                    UpdateScore();
                });
            }
        });
    }

    private void RestartGameLoop()
    {
        _cts.Cancel();
        StartGameLoop();
    }

    private void UpdateScore()
    {
        int green = Cells.Count(c => c.Player == 0);
        int blue = Cells.Count(c => c.Player == 1);
        Score = $"Green {green} | Blue {blue}";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
