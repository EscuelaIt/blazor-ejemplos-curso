using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Viewmodels;

public class WeatherForecast
{
    public DateTime Date { get; set; }
    [Range(-50, 50)]
    [IsEven(IsZeroValid = true)]
    public int Celsius { get; set; }
    public int Farenheit => 32 + (int)(Celsius / 0.556);
    [MinLength(3)]
    public string Summary { get; set; }

    public WeatherForecast()
    {
        Date = DateTime.Now;
        Celsius = 15;
        Summary = "new forecast";
    }
}
