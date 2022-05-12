using System.ComponentModel;

namespace ViewModel
{
    public class TextOutput : INotifyPropertyChanged
    {
        // Textboxes
        private double _textBlock_Der_1rst_l;
        public double TextBlock_Der_1rst_l
        {
            get { return _textBlock_Der_1rst_l; }
            set
            {
                if (value != _textBlock_Der_1rst_l)
                {
                    _textBlock_Der_1rst_l = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBlock_Der_1rst_l)));
                }
            }
        }

        private double _textBlock_Der_1rst_r;
        public double TextBlock_Der_1rst_r
        {
            get { return _textBlock_Der_1rst_r; }
            set
            {
                if (value != _textBlock_Der_1rst_r)
                {
                    _textBlock_Der_1rst_r = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBlock_Der_1rst_r)));
                }
            }
        }

        private double _textBlock_Der_2nd_r;
        public double TextBlock_Der_2nd_r
        {
            get { return _textBlock_Der_2nd_r; }
            set
            {
                if (value != _textBlock_Der_2nd_r)
                {
                    _textBlock_Der_2nd_r = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBlock_Der_2nd_r)));
                }
            }
        }

        private double _textBlock_Der_2nd_l;
        public double TextBlock_Der_2nd_l
        {
            get { return _textBlock_Der_2nd_l; }
            set
            {
                if (value != _textBlock_Der_2nd_l)
                {
                    _textBlock_Der_2nd_l = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBlock_Der_2nd_l)));
                }
            }
        }

        private double _textBlock_Spl1;
        public double TextBlock_Spl1
        {
            get { return _textBlock_Spl1; }
            set
            {
                if (value != _textBlock_Spl1)
                {
                    _textBlock_Spl1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBlock_Spl1)));
                }
            }
        }

        private double _textBlock_Spl2;
        public double TextBlock_Spl2
        {
            get { return _textBlock_Spl2; }
            set
            {
                if (value != _textBlock_Spl2)
                {
                    _textBlock_Spl2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBlock_Spl2)));
                }
            }
        }

        private double _textBlock_Integ1;
        public double TextBlock_Integ1
        {
            get { return _textBlock_Integ1; }
            set
            {
                if (value != _textBlock_Integ1)
                {
                    _textBlock_Integ1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBlock_Integ1)));
                }
            }
        }

        private double _textBlock_Integ2;
        public double TextBlock_Integ2
        {
            get { return _textBlock_Integ2; }
            set
            {
                if (value != _textBlock_Integ2)
                {
                    _textBlock_Integ2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBlock_Integ2)));
                }
            }
        }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;

        // Methods
        public void SetDefaults()
        {
            TextBlock_Der_1rst_l = 0;
            TextBlock_Der_1rst_r = 0;
            TextBlock_Der_2nd_l = 0;
            TextBlock_Der_2nd_r = 0;
            TextBlock_Spl1 = 0;
            TextBlock_Spl2 = 0;
            TextBlock_Integ1 = 0;
            TextBlock_Integ2 = 0;
        }
    }
}
