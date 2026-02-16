namespace BMI_Calculator;

public partial class RecomPage : ContentPage
{
	public RecomPage(string bmiClass)
	{
		InitializeComponent();
		LblRecs.Text = GetRecommendationText(bmiClass);
	}

    private string GetRecommendationText(string bmiClass)
    {
        return bmiClass switch
        {
            "Underweight" => string.Join(Environment.NewLine, new[]
            {
                "&#8226; Consider a nutrient-dense diet.",
                "&#8226; Increase calorie intake with healthy foods.",
                "&#8226; Consult a healthcare provider or dietitian to rule out underlying causes."
            }),
            "Normal Weight" => string.Join(Environment.NewLine, new[]
            {
                "&#8226; Maintain your weight with a balanced diet.",
                "&#8226; Keep regular physical activity.",
                "&#8226; Continue routine health check-ups."
            }),
            "Overweight" => string.Join(Environment.NewLine, new[]
            {
                "• Aim for gradual weight loss through healthy eating.",
                "• Increase physical activity.",
                "• Consult a healthcare provider for a personalized plan."
            }),
            "Obese" => string.Join(Environment.NewLine, new[]
            {
                "&#8226; Seek medical advice for a comprehensive weight-management plan.",
                "&#8226; Consider nutrition counseling and supervised exercise.",
                "&#8226; Discuss medical options with your provider if appropriate."
            }),
            _ => "Error: Not enough data"
        };
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        // Back to Home
        Navigation.PopToRootAsync();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        // Back to Results
        Navigation.PopAsync();
    }
}