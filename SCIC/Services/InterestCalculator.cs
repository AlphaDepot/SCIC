// InterestCalculator.cs

using SCIC.Models;

namespace SCIC.Services;
/// <summary>
///  InterestCalculator is a service that calculates compound interest with regular payments.
/// </summary>
public class InterestCalculator
{
    public InterestCalculatorResult CalculateCompoundInterestWithPayment(decimal principal, decimal interestRate, decimal yearsOfGrowth, decimal compoundFrequency, decimal payment, decimal paymentFrequency)
    {
        var totalPaymentPeriods = paymentFrequency * yearsOfGrowth;
        var initialInvestment = principal + (payment * totalPaymentPeriods); // Total payments made over the period
    
        var value = CalculateFutureValue(principal, interestRate, yearsOfGrowth, compoundFrequency, payment, paymentFrequency);
        var futureInterest = value - principal - initialInvestment; // Interest accrued over the period
    
        return new InterestCalculatorResult(
            Investment: initialInvestment, // Total payments made
            InterestAccrued: futureInterest, // Interest accrued
            FutureValue: value // Future value of the investment
        );
    }

    /// <summary>
    /// Calculates the future value of an investment, considering compound interest, principal,
    /// periodic payments, and specified time and frequency parameters.
    /// </summary>
    /// <param name="principal">The initial amount of money that is invested or loaned, in monetary units.</param>
    /// <param name="interestRate">The annual interest rate expressed as a percentage (e.g., 5 for 5%).</param>
    /// <param name="yearsOfGrowth">The total number of years over which the investment accrues interest.</param>
    /// <param name="compoundFrequency">The number of times the interest is compounded annually.</param>
    /// <param name="payment">The regular periodic payment amount made in addition to the principal.</param>
    /// <param name="paymentFrequency">The number of payments made each year.</param>
    /// <returns>The future value of the investment, including principal, compounded interest, and periodic payments.</returns>
    private decimal CalculateFutureValue(decimal principal, decimal interestRate, decimal yearsOfGrowth,
        decimal compoundFrequency, decimal payment, decimal paymentFrequency)
    {
        var interestRatePercent = interestRate / 100;
        var rate = Pow(1 + (interestRatePercent / compoundFrequency), compoundFrequency / paymentFrequency) - 1;
        var totalPaymentPeriods = paymentFrequency * yearsOfGrowth;
        var compoundFactor = Pow(1 + rate, totalPaymentPeriods);
        var accumulatedInterestFactor = compoundFactor - 1;
        var paymentFactor = accumulatedInterestFactor / rate;
        return principal * compoundFactor + payment * paymentFactor;
    }

    /// <summary>
    /// Raises a specified base value to a given exponent.
    /// </summary>
    /// <param name="baseValue">The base value to be raised to a power.</param>
    /// <param name="exponent">The exponent value to which the base is raised.</param>
    /// <returns>The result of raising the base value to the specified exponent.</returns>
    private decimal Pow(decimal baseValue, decimal exponent)
    {
        return (decimal)Math.Pow((double)baseValue, (double)exponent);
    }
}