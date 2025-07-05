using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SCIC.Enums;
using SCIC.Extensions;
using SCIC.Services;

namespace SCIC.ViewModels;

/// <summary>
///  ViewModel for the MainWindow.
/// </summary>
public partial class MainWindowViewModel : ObservableObject
{
    /// <summary>
    /// Stores the principal amount for calculations.
    /// </summary>
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private decimal _principal = 1000;

    /// <summary>
    /// Represents the interest rate used in financial calculations. 10% by default.
    /// </summary>
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private decimal _interestRate = 10;

    /// <summary>
    /// Represents the number of years for which the investment will grow. Default is 30 years.
    /// </summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private int _yearsOfGrowth = 30;

    /// <summary>
    /// Represents the payment amount made at each compounding period. Default is 200.
    /// </summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private decimal _payment = 200;

    /// <summary>
    /// Represents the frequency at which interest is compounded, with a default
    /// value corresponding to the "Annual" frequency description.
    /// </summary>
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private string _compoundFrequency = FrequencyOptions.Annual.GetDescription();

    /// <summary>
    /// Represents the frequency at which payments are made, with a default
    /// value corresponding to the "Bi-Weekly" frequency description.
    /// </summary>
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private string _paymentFrequency = FrequencyOptions.BiWeekly.GetDescription();

    /// <summary>
    ///  Represents the total investment amount for the total period including initial principal and all payments made.
    /// </summary>
    [ObservableProperty]
    private string _investmentAmount = "0";
    /// <summary>
    ///  Represents the total interest accrued over the investment period.
    /// </summary>
    [ObservableProperty]
    private string _interestAccrued = "0";

    /// <summary>
    ///  Represents the future value of the investment after the specified number of years, including interest and payments.
    /// </summary>
    [ObservableProperty]
    private string _futureValue = "0";
    
    /// <summary>
    /// List of frequency options for the compound frequency dropdown
    /// </summary>
    public List<string> FrequencyOptionsList { get; } =  
        Enum.GetValues<FrequencyOptions>()
            .Select(option => option.GetDescription())
            .ToList();
    
    
    [RelayCommand]
    private void Calculate()
    {
     
        // Convert the selected frequency descriptions to their corresponding enum values
        var compoundFrequency =  FrequencyOptionsExtensions.FromDescription(CompoundFrequency).GetValue();
        var paymentFrequency = FrequencyOptionsExtensions.FromDescription(PaymentFrequency).GetValue();

        // Create an instance of the InterestCalculator and perform the calculation
        var interestCalculator = new InterestCalculator();
        var result = interestCalculator.CalculateCompoundInterestWithPayment(Principal, InterestRate, YearsOfGrowth, compoundFrequency, Payment, paymentFrequency);

        // Update the properties with the results
        InvestmentAmount = result.Investment.ToString("N2");
        InterestAccrued = result.InterestAccrued.ToString("N2");
        FutureValue = result.FutureValue.ToString("N2");
        
        
    }
}