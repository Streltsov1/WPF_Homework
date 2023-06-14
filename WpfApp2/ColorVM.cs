using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PropertyChanged;

namespace WpfApp2
{
    [AddINotifyPropertyChangedInterface]
    public class ColorVM
    {
        [DependsOn("Alpha", "Red", "Green", "Blue")]
        public Color Color => Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue);
        public int Alpha { get; set; }
        public int Red { get; set; }

        public int Blue { get; set; }
        public int Green { get; set; }
        [DependsOn("Color", "Alpha", "Red", "Green", "Blue")]
        public string ShortInfo => ToString();
        public ColorVM()
        {

        }
        public object Clone()
        {
            var copy = (ColorVM)this.MemberwiseClone();

            copy.Alpha = (int)this.Alpha;
            copy.Red = (int)this.Red;
            copy.Blue = (int)this.Blue;
            copy.Green = (int)this.Green;

            return copy;
        }
        public override string ToString()
        {
            return Color.ToString();
        }
    }
}
