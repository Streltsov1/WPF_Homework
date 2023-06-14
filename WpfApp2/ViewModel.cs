using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApp2
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private ColorVM selectedColor;
        public ColorVM SelectedColor
        {
            get => selectedColor;
            set
            {
                if (value == null)
                    selectedColor = new();
                else
                {
                    selectedColor = value;
                }

            }
        }
        public int? Index { get; set; }
        private ObservableCollection<ColorVM> colors = new ObservableCollection<ColorVM>();
        public IEnumerable<ColorVM> Colors => colors;
        private readonly RelayCommand addColor;
        private readonly RelayCommand removeColor;
        public ViewModel()
        {
            addColor = new((o) => Add(), (o) => !colors.Contains(SelectedColor));
            removeColor = new((o) => Delete(), (o) => Index != null);
            SelectedColor = new();
        }
        public ICommand AddCmd => addColor;
        public ICommand RemoveCmd => removeColor;
        public void Delete()
        {
            colors.Remove(SelectedColor);
            Index = null;
        }
        public void Add()
        {
            colors.Add((ColorVM)SelectedColor.Clone());
        }
    }
}
