
using System.Windows;
using System.Windows.Media;


namespace SCIC;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private const double DefaultPrincipal = 1000;
    private const double DefaultInterestRate = 10;
    private const double DefaultYearsOfGrowth = 30;
    private const double DefaultPayment = 200;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Calculate(object sender, RoutedEventArgs e)
    {
        var lightGreen = new SolidColorBrush(Color.FromRgb(152, 251, 152));
        var components = new List<string> { Principal.Text, InterestRateResult.Text, YearsOfGrouth.Text, Payment.Text };

        var inputParser = new InputParser(DefaultPrincipal, DefaultInterestRate, DefaultYearsOfGrowth, DefaultPayment);
        if (!inputParser.TryParseInputs(Principal.Text, InterestRateResult.Text, YearsOfGrouth.Text, CompoundFrequency.SelectedItem, Payment.Text, PaymentFrequency.SelectedItem, out double principal, out double interestRate, out double yearsOfGrowth, out double compoundFrequency, out double payment, out double paymentFrequency))
        {
            inputParser.CheckForLetters(components);
            return;
        }

        var interestCalculator = new InterestCalculator();
        var accruedAmount = interestCalculator.CalculateCompoundInterestWithPayment(principal, interestRate, yearsOfGrowth, compoundFrequency, payment, paymentFrequency);
        var totalPaymentAmount = payment * paymentFrequency * yearsOfGrowth;

        var uiUpdater = new UiUpdater();
        uiUpdater.UpdateUi(FutureInterestLabel, FutureInterestLabel2, FutureInterest, TotalPaymentsLabel, TotalPaymentsLabel2, TotalPayments, PaymentInterestLabel, PaymentInterestLabel2, PaymentInterest, FutureValueLabel, FutureValueLabel2, FutureValue, lightGreen, accruedAmount, principal, totalPaymentAmount);

    }
}