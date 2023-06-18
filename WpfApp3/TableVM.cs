
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace WpfApp3.ViewModels
{
    public class TableVM
    {
        private IList<CellVM> cells = new List<CellVM>();

        public IEnumerable<CellVM> Cells => cells;
        public int Size { get; }

        public const int EYE_NUMBER = 0;
        public int FirstNumber { get; } = 1;
        public int LastNumber { get; }

        public TableVM(int size)
        {
            Size = size;
            LastNumber = Size * Size - 1;

            GenerateCells();
        }

        private void GenerateCells()
        {
            for (int i = FirstNumber; i <= LastNumber; ++i)
            {
                cells.Add(new CellVM(i));
            }
            this.cells.Shuffle();

            cells.Insert(cells.Count / 2, new CellVM(EYE_NUMBER, CellColor.White));
        }

    }

    public enum CellColor
    {
        White, Green, Purple, Yellow, Blue, Red
    };
    public enum CellState
    {
        Current, Closed, Next
    }

    public class CellVM
    {
        private static Random rnd = new();
        public int Number { get; }
        public CellColor Color { get; set; }
        public CellState State { get; set; }
        public bool IsWrong { get; set; }

        public CellVM(int number) : this(number, GetRandomColor()) { }
        public CellVM(int number, CellColor color)
        {
            Number = number;
            Color = color;

            IsWrong = true;
        }
        private static CellColor GetRandomColor()
        {
            return (CellColor)rnd.Next(Enum.GetValues(typeof(CellColor)).Length);
        }
    }
}
