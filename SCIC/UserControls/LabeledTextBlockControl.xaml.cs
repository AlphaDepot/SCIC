using System.Windows;
using System.Windows.Controls;

namespace SCIC.UserControls;

public partial class LabeledTextBlockControl : UserControl
{
    public LabeledTextBlockControl()
    {
        InitializeComponent();
    }
    
    public static readonly DependencyProperty LabelContentProperty =
        DependencyProperty.Register(nameof(LabelContent), typeof(string), typeof(LabeledTextBlockControl));
    public static readonly DependencyProperty TextBlockBindingProperty =
    DependencyProperty.Register(
        nameof(TextContent),
        typeof(string),
        typeof(LabeledTextBlockControl),
        new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


    public string LabelContent
    {
        get => (string)GetValue(LabelContentProperty);
        set => SetValue(LabelContentProperty, value);
    }
    
    public string TextContent
    {
        get => (string)GetValue(TextBlockBindingProperty);
        set => SetValue(TextBlockBindingProperty, value);
    }
}