using System.Windows;
using System.Windows.Controls;

namespace SCIC.UserControls;

public partial class LabeledInputControl : UserControl
{
    public LabeledInputControl()
    {
        InitializeComponent();
    }
    
    public static readonly DependencyProperty LabelContentProperty =
        DependencyProperty.Register(nameof(LabelContent), typeof(string), typeof(LabeledInputControl));

    public static readonly DependencyProperty TextBoxBindingProperty =
        DependencyProperty.Register(nameof(TextBoxBinding), typeof(object), typeof(LabeledInputControl),
            new FrameworkPropertyMetadata(default(decimal), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        );

    public string LabelContent
    {
        get => (string)GetValue(LabelContentProperty);
        set => SetValue(LabelContentProperty, value);
    }

    public object TextBoxBinding
    {
        get => GetValue(TextBoxBindingProperty);
        set => SetValue(TextBoxBindingProperty, value);
    }
}