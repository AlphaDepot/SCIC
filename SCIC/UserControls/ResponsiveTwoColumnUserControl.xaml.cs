using System.Windows;
using System.Windows.Controls;

namespace SCIC.UserControls;

public partial class ResponsiveTwoColumnUserControl : UserControl
{
    public ResponsiveTwoColumnUserControl()
    {
        InitializeComponent();
    }
    public object ColumnOneContent
    {
        get => GetValue(ColumnOneContentProperty);
        set => SetValue(ColumnOneContentProperty, value);
    }

    public static readonly DependencyProperty ColumnOneContentProperty =
        DependencyProperty.Register("ColumnOneContent", typeof(object), typeof(ResponsiveTwoColumnUserControl), new PropertyMetadata(null));

    public object ColumnTwoContent
    {
        get => GetValue(ColumnTwoContentProperty);
        set => SetValue(ColumnTwoContentProperty, value);
    }

    public static readonly DependencyProperty ColumnTwoContentProperty =
        DependencyProperty.Register("ColumnTwoContent", typeof(object), typeof(ResponsiveTwoColumnUserControl), new PropertyMetadata(null));
}