using System.Text;

namespace BMI_Calculator;

public partial class BMI_Page : ContentPage
{
    public BMI_Page()
    {
        InitializeComponent();
    }
    string gender = string.Empty;
    private void TapMale_Tapped(object sender, TappedEventArgs e)
    {
        gender = "Male";
        FrameMale.BorderColor = Color.FromArgb("#0a0e29");
        FrameFemale.BorderColor = Color.FromArgb("#fdfdfd");
    }

    private void TapFemale_Tapped(object sender, TappedEventArgs e)
    {
        gender = "Female";
        FrameFemale.BorderColor = Color.FromArgb("#0a0e29");
        FrameMale.BorderColor = Color.FromArgb("#fdfdfd");
    }

    private string HealthClassification(double bmi)
    {
        string bmi_class = string.Empty;
        if (gender == "Male")
        {
            if (bmi < 18.5)
                bmi_class = "Underweight";
            else if (bmi < 25)
                bmi_class = "Normal Weight";
            else if (bmi < 30)
                bmi_class = "Overweight";
            else
                bmi_class = "Obese";
        }
        else if (gender == "Female")
        {
            if (bmi < 18)
                bmi_class = "Underweight";
            else if (bmi < 24)
                bmi_class = "Normal Weight";
            else if (bmi < 29)
                bmi_class = "Overweight";
            else
                bmi_class = "Obese";
        }
        else
        {
            bmi_class = "Not enough data";
        }

        return bmi_class;
    }

    private void BtnCalculateBMI_Clicked(object sender, EventArgs e)
    {
        double height = double.Parse(LblHeight.Text);
        double weight = double.Parse(LblWeight.Text);
        double bmi = (weight * 703) / (height * height);
        string bmiClass = HealthClassification(bmi);

        //await DisplayAlert("Your calculated BMI results are:", message, "OK");
        Navigation.PushAsync(new ResultPage(gender, bmi, bmiClass));
    }}