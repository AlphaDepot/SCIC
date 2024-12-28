// InterestCalculator.cs

namespace SCIC;

public class InterestCalculator
{
    public double CalculateCompoundInterestWithPayment(double principal, double interestRate, double yearsOfGrowth, double compoundFrequency, double payment, double paymentFrequency)
    {
        var interestRatePercent = interestRate / 100;
        var rate = Math.Pow(1 + (interestRatePercent / compoundFrequency), compoundFrequency / paymentFrequency) - 1;
        var totalPaymentPeriods = paymentFrequency * yearsOfGrowth;
        var compoundFactor = Math.Pow(1 + rate, totalPaymentPeriods);
        var accumulatedInterestFactor = compoundFactor - 1;
        var paymentFactor = accumulatedInterestFactor / rate;
        return principal * compoundFactor + payment * paymentFactor;
    }
}