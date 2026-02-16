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

    private async void BtnCalculateBMI_Clicked(object sender, EventArgs e)
    {
        double height = double.Parse(LblHeight.Text);
        double weight = double.Parse(LblWeight.Text);
        double bmi = (weight * 703) / (height * height);
        string bmiClass = HealthClassification(bmi);

        string recommendations = GetRecommendations(bmiClass);

        string message = $"Gender: {gender}\nBMI: {bmi:F1}\nClassification: {bmiClass}\n\nRecommendations:\n{recommendations}";

        await DisplayAlert("Your calculated BMI results are:", message, "OK");
    }

    private string GetRecommendations(string bmiClass)
    {
        return bmiClass switch
        {
            "Underweight" => string.Join(Environment.NewLine, new[]
            {
                "- Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains).",
                "- Incorporate strength training to build muscle mass",
                "- Consult a nutritionist if needed."
            }),
            "Normal Weight" => string.Join(Environment.NewLine, new[]
            {
                "- Maintain a balanced diet with proteins, healthy fats, and fiber",
                "- Stay physically active with at least 150 of exercise per week.",
                "- Keep regular check-ups to monitor overall health."
            }),
            "Overweight" => string.Join(Environment.NewLine, new[]
            {
                "- Reduce processed foods and focus on portion control.",
                "- Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training.",
                "- Drink plenty of water and track your progress."
            }),
            "Obese" => string.Join(Environment.NewLine, new[]
            {
                "- Consult a doctor for personalized guidance.",
                "- Start with low-impact exercises (e.g., walking, cycling).",
                "- Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes.",
                "- Avoid sugary drinks and maintain a consistent sleep schedule."
            }),
            _ => "Not enough data to provide recommendations. Please make sure you selected a gender and entered valid height and weight."
        };
    }
}