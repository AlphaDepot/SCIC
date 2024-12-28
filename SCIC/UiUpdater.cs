// UiUpdater.cs

using System.Windows.Controls;
using System.Windows.Media;

namespace SCIC
{
    public class UiUpdater
    {
        public void UpdateUi(Label futureInterestLabel, Label futureInterestLabel2, TextBlock futureInterest, Label totalPaymentsLabel, Label totalPaymentsLabel2, TextBlock totalPayments, Label paymentInterestLabel, Label paymentInterestLabel2, TextBlock paymentInterest, Label futureValueLabel, Label futureValueLabel2, TextBlock futureValue, SolidColorBrush lightGreen, double accruedAmount, double principal, double totalPaymentAmount)
        {
            var totalInterest = accruedAmount - (principal + totalPaymentAmount);

            SetLabelBackground(futureInterestLabel, futureInterestLabel2, futureInterest, lightGreen);
            futureInterest.Text = totalInterest.ToString("0,000.00");

            SetLabelBackground(totalPaymentsLabel, totalPaymentsLabel2, totalPayments, lightGreen);
            totalPayments.Text = totalPaymentAmount.ToString("0,000.00");

            SetLabelBackground(paymentInterestLabel, paymentInterestLabel2, paymentInterest, lightGreen);
            paymentInterest.Text = (principal + totalPaymentAmount).ToString("0,000.00");

            SetLabelBackground(futureValueLabel, futureValueLabel2, futureValue, lightGreen);
            futureValue.Text = accruedAmount.ToString("0,000.00");
        }

        private void SetLabelBackground(Label label1, Label label2, TextBlock textBlock, SolidColorBrush color)
        {
            label1.Background = color;
            label2.Background = color;
            textBlock.Background = color;
        }
    }
}