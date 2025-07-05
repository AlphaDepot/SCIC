using System.Windows;
using System.Windows.Controls;

namespace SCIC.UserControls;

public partial class LabeledComboBoxControl : UserControl
{
    public LabeledComboBoxControl()
    {
        InitializeComponent();
    }
    
    public static readonly DependencyProperty LabelContentProperty =
        DependencyProperty.Register(nameof(LabelContent), typeof(string), typeof(LabeledComboBoxControl));
    
    public static readonly DependencyProperty ItemsSourceBindingProperty =
        DependencyProperty.Register(nameof(ItemsSourceBinding), typeof(object), typeof(LabeledComboBoxControl));

    public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(LabeledComboBoxControl),
            new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



    public string LabelContent
    {
        get => (string)GetValue(LabelContentProperty);
        set => SetValue(LabelContentProperty, value);
    }
    
    public object ItemsSourceBinding
    {
        get => GetValue(ItemsSourceBindingProperty);
        set => SetValue(ItemsSourceBindingProperty, value);
    }

    public object SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

  
}