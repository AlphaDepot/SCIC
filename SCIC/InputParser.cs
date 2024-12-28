// InputParser.cs

using System.Windows;
using System.Windows.Controls;

namespace SCIC;

public class InputParser
{
    private readonly double _defaultPrincipal;
    private readonly double _defaultInterestRate;
    private readonly double _defaultYearsOfGrowth;
    private readonly double _defaultPayment;

    public InputParser(double defaultPrincipal, double defaultInterestRate, double defaultYearsOfGrowth, double defaultPayment)
    {
        _defaultPrincipal = defaultPrincipal;
        _defaultInterestRate = defaultInterestRate;
        _defaultYearsOfGrowth = defaultYearsOfGrowth;
        _defaultPayment = defaultPayment;
    }

    public bool TryParseInputs(string principalText, string interestRateText, string yearsOfGrowthText, object compoundFrequencyItem, string paymentText, object paymentFrequencyItem, out double principal, out double interestRate, out double yearsOfGrowth, out double compoundFrequency, out double payment, out double paymentFrequency)
    {
        principal = double.TryParse(principalText, out double p) ? p : _defaultPrincipal;
        interestRate = double.TryParse(interestRateText, out double ir) ? ir : _defaultInterestRate;
        yearsOfGrowth = double.TryParse(yearsOfGrowthText, out double yg) ? yg : _defaultYearsOfGrowth;
        compoundFrequency = double.TryParse(((ComboBoxItem)compoundFrequencyItem).Tag.ToString(), out double cf) ? cf : 0;
        payment = double.TryParse(paymentText, out double pay) ? pay : _defaultPayment;
        paymentFrequency = double.TryParse(((ComboBoxItem)paymentFrequencyItem).Tag.ToString(), out double pf) ? pf : 0;

        return principal > 0 && interestRate > 0 && yearsOfGrowth > 0 && compoundFrequency > 0 && payment > 0 && paymentFrequency > 0;
    }

    public void CheckForLetters(List<string> components)
    {
        var invalidComponents = components.Where(item => !double.TryParse(item, out _)).Select(item => $"{item} is not a number.").ToList();

        if (invalidComponents.Any())
        {
            invalidComponents.Add("These fields only support numbers.");
            MessageBox.Show(string.Join(Environment.NewLine, invalidComponents));
        }
    }
}