using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FIO_Group
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly SolidColorBrush _red = new SolidColorBrush(Color.FromRgb(243, 21, 21));
        readonly SolidColorBrush _orange = new SolidColorBrush(Color.FromRgb(243, 163, 21));
        readonly SolidColorBrush _green = new SolidColorBrush(Color.FromRgb(21, 243, 202));

        List<Label> _labels = new List<Label>();

        readonly int _currentYear = DateTime.Now.Year % 10;

        public MainWindow()
        {
            InitializeComponent();
            _labels.Add(Second_Name_L);
            _labels.Add(First_Name_L);
            _labels.Add(Patronomic_L);
            _labels.Add(Group_L);
            _labels.Add(LVL_L);
            _labels.Add(Course_L);
            Set_Default();
        }

        private void Set_Default()
        {
            if (_labels == null) { return; }
            foreach (var label in _labels)
            {
                label.Content = "Ошибка";
                label.Foreground = _orange;
            }
        }
        private void Update()
        {
            if (_labels.Count == 0) { return; }
            Set_Default();
            var inputs = Main_TB.Text.Split(' ');
            if (!(inputs.Length == 1 && inputs[0] == ""))
            {
                for (int i = 0; i < inputs.Length && i < 3; i++)
                {
                    char[] temp = inputs[i].Trim().ToLower().ToCharArray();
                    if (temp.Length <= 0) { continue; }
                    temp[0] = char.ToUpper(temp[0]);
                    _labels[i].Content = new string(temp);
                    _labels[i].Foreground = _green;
                }
            }
            string group = Group_TB.Text.ToUpper();
            int course = 0;
            if (group[3] != '_')
            {
                int addm_year = int.Parse(group[3].ToString());
                course = _currentYear - addm_year + 1;
            }
            if (group[0] == 'Б')
            {
                _labels[4].Content = "Бакалавриат";
                _labels[4].Foreground = _green;
                if (course <= 4 && course > 0)
                {
                    _labels[5].Content = course;
                    _labels[5].Foreground = _green;
                }
                else course = 0;
            }
            else if (group[0] == 'М')
            {
                _labels[4].Content = "Магистратура";
                _labels[4].Foreground = _green;
                if (course <= 2 && course > 0)
                {
                    _labels[5].Content = course;
                    _labels[5].Foreground = _green;
                }
                else course = 0;
            }
            else if (group[0] == 'К')
            {
                _labels[4].Content = "Колледж";
                _labels[4].Foreground = _green;
                if (course <= 4 && course > 0)
                {
                    _labels[5].Content = course;
                    _labels[5].Foreground = _green;
                }
                else course = 0;
            }
            else if (group[0] == '_')
            {
                _labels[4].Content = "Ошибка";
                _labels[4].Foreground = _orange;
            }
            else
            {
                _labels[4].Content = "Ошибка";
                _labels[4].Foreground = _red;
            }
            if (course <= 0)
            {
                _labels[5].Content = "Ошибка";
                _labels[5].Foreground = _red;
                course = 0;
            }
            if (group[3] == '_')
            {
                _labels[5].Content = "Ошибка";
                _labels[5].Foreground = _orange;
                course = 0;
            }
            if (_labels[4].Content != "Ошибка" && _labels[5].Content != "Ошибка")
            {
                _labels[3].Content = group;
                _labels[3].Foreground = _green;
            }
            else
            {
                _labels[3].Content = "Ошибка";
                _labels[3].Foreground = _orange;
            }
        }

        private void Main_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void Group_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
