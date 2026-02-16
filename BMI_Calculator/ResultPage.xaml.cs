namespace BMI_Calculator;

public partial class ResultPage : ContentPage
{
	string gender;
	double bmi;
	string bmiClass;
	public ResultPage(string gender, double bmi, string bmiClass)
	{
		InitializeComponent();
		this.gender = gender;
		this.bmi = bmi;
		this.bmiClass = bmiClass;

		LblGender.Text = gender;
		LblBMI.Text = bmi.ToString("F1");
		LblClass.Text = bmiClass.ToString();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new RecomPage(bmiClass));
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
		Navigation.PopToRootAsync();
    }
}