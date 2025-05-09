using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;

namespace Wpf.DarkWindow.Controls
{
    [TemplatePart(Name = PART_MaxButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_MinButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_RestoreButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_CloseButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_LeftItems, Type = typeof(StackPanel))]
    public class DarkWindow : System.Windows.Window
    {
        #region PARTS
        protected const string PART_MaxButton = "PART_MaxButton";
        protected const string PART_MinButton = "PART_MinButton";
        protected const string PART_RestoreButton = "PART_RestoreButton";
        protected const string PART_CloseButton = "PART_CloseButton";
        protected const string PART_BackgroundImage = "PART_BackgroundImage";
        protected const string PART_LeftItems = "PART_LeftItems";
        protected const string PART_RightItems = "PART_RightItems";
        protected const string PART_BackgroundBlur = "PART_BackgroundBlur";
        protected const string PART_WindowBackground = "PART_WindowBackground";
        #endregion

        protected Button? btnMax;
        protected Button? btnMin;
        protected Button? btnRestore;
        protected Button? btnClose;
        protected IntPtr _HANDLE = IntPtr.Zero;

        protected Border? _PART_WindowBackground;
        protected StackPanel? LItems;
        protected StackPanel? RItems;


        public IntPtr HANDLE
        {
            get
            {
                if (_HANDLE == IntPtr.Zero)
                    _HANDLE = new WindowInteropHelper(this).Handle;
                return _HANDLE;
            }
        }
        static DarkWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkWindow), new FrameworkPropertyMetadata(typeof(DarkWindow)));

        }
        public static readonly DependencyProperty ButtonBrushProperty = DependencyProperty.Register(
           nameof(ButtonBrush),
           typeof(Brush),
           typeof(DarkWindow), new PropertyMetadata(Brushes.White)
        );
        public Brush ButtonBrush
        {
            get => (Brush)GetValue(ButtonBrushProperty);
            set => SetValue(ButtonBrushProperty, value);
        }

        public static readonly DependencyProperty CloseButtonBrushProperty = DependencyProperty.Register(
           nameof(CloseButtonBrush),
           typeof(Brush),
           typeof(DarkWindow), new PropertyMetadata(Brushes.Red)
        );
        public Brush CloseButtonBrush
        {
            get => (Brush)GetValue(CloseButtonBrushProperty);
            set => SetValue(CloseButtonBrushProperty, value);
        }









        public DarkWindow()
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.btnMax = this.GetTemplateChild(PART_MaxButton) as Button;
            this.btnMin = this.GetTemplateChild(PART_MinButton) as Button;
            this.btnRestore = this.GetTemplateChild(PART_RestoreButton) as Button;
            this.btnClose = this.GetTemplateChild(PART_CloseButton) as Button;

            this.LItems = this.GetTemplateChild(PART_LeftItems) as StackPanel;
            this.RItems = this.GetTemplateChild(PART_RightItems) as StackPanel;

            this._PART_WindowBackground = this.GetTemplateChild(PART_WindowBackground) as Border;

            if (this.btnMax != null)
            {
                this.btnMax.Click += btnMax_Click;
            }
            if (this.btnMin != null)
            {
                this.btnMin.Click += btnMin_Click;
            }
            if (this.btnRestore != null)
            {
                this.btnRestore.Click += btnRestore_Click;
            }
            if (this.btnClose != null)
            {
                this.btnClose.Click += btnClose_Click;
            }


        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Normal;
        }
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }


    }
}
