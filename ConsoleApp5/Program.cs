using ConsoleApp5.Data;
using ConsoleApp5.Model;
using ConsoleApp5.Service;
using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {
        Console.ResetColor();
        Console.WriteLine("Bienvenido al programa de consulta de tiempo y base de datos.");
       
        try
        {
            while (true)
            {
                MostrarMenu();

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear(); // Limpia la consola
                        await ConsultarTiempo();
                        break;

                    case "2":
                        Console.Clear(); // Limpia la consola
                        VerResultadosBaseDatos();
                        break;

                    case "0":
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, elige una opción válida.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {ex.Message}");
        }

        static void MostrarMenu()
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Consultar tiempo");
            Console.WriteLine("2. Ver resultados de la base de datos");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");
        }

        static void SaveDay1(Root weatherData)
        {
            using (var context = new DayDBContext())
            {
                context.Days.Add(new Day
                {
                    Date = weatherData.day1.date,
                    TemperatureMax = weatherData.day1.temperature_max,
                    TemperatureMin = weatherData.day1.temperature_min,
                    Icon = weatherData.day1.icon,
                    Text = weatherData.day1.text,
                    Humidity = weatherData.day1.humidity,
                    Wind = weatherData.day1.wind,
                    WindDirection = weatherData.day1.wind_direction,
                    Sunrise = weatherData.day1.sunrise,
                    Sunset = weatherData.day1.sunset,
                    Moonrise = weatherData.day1.moonrise,
                    Moonset = weatherData.day1.moonset,
                    MoonPhasesIcon = weatherData.day1.moon_phases_icon
                });
                context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Se registro correctamente");
                Console.ResetColor();
            }
        }

        static async Task ConsultarTiempo()
        {
            Console.WriteLine("Consultado a TuTiempo...");

            ApiService apiService = new ApiService();

            string apiResponse = await apiService.GetDataFromApiAsync();

            if (apiResponse != null)
            {
                Root weatherData = JsonConvert.DeserializeObject<Root>(apiResponse);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Fecha: {weatherData.day1.date}");
                Console.WriteLine($"Temperatura Máxima/Mínima: {weatherData.day1.temperature_max}{weatherData.information.temperature}/{weatherData.day1.temperature_min}{weatherData.information.temperature}");
                Console.WriteLine($"Descripción: {weatherData.day1.text}");
                Console.WriteLine($"Humedad: {weatherData.day1.humidity}{weatherData.information.humidity}");
                Console.WriteLine($"Viento: {weatherData.day1.wind} {weatherData.information.wind}");
                Console.WriteLine($"Dirección del Viento: {weatherData.day1.wind_direction}");
                Console.WriteLine($"Amanecer: {weatherData.day1.sunrise}");
                Console.WriteLine($"Atardecer: {weatherData.day1.sunset}");
                Console.WriteLine($"Luna Nace: {weatherData.day1.moonrise}");
                Console.WriteLine($"Luna Se Pone: {weatherData.day1.moonset}");
                Console.WriteLine(new string('-', Console.WindowWidth));
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine($"Fecha: {weatherData.day2.date}");
                Console.WriteLine($"Temperatura Máxima: {weatherData.day2.temperature_max}");
                Console.WriteLine($"Se espera una temperatura minima: {weatherData.day2.temperature_min}");
                Console.WriteLine();
                Console.WriteLine($"Fecha: {weatherData.day3.date}");
                Console.WriteLine($"Se espera una temperatura maxima: {weatherData.day3.temperature_max}");
                Console.WriteLine($"Se espera una temperatura minima: {weatherData.day3.temperature_min}");
                Console.WriteLine();
                Console.WriteLine($"Fecha: {weatherData.day3.date}");
                Console.WriteLine($"Se espera una temperatura maxima: {weatherData.day3.temperature_max}");
                Console.WriteLine($"Se espera una temperatura minima: {weatherData.day3.temperature_min}");
                Console.WriteLine();
                Console.WriteLine($"Fecha: {weatherData.day4.date}");
                Console.WriteLine($"Se espera una temperatura maxima: {weatherData.day4.temperature_max}");
                Console.WriteLine($"Se espera una temperatura minima: {weatherData.day4.temperature_min}");
                Console.WriteLine();
                Console.WriteLine($"Fecha: {weatherData.day5.date}");
                Console.WriteLine($"Se espera una temperatura maxima: {weatherData.day5.temperature_max}");
                Console.WriteLine($"Se espera una temperatura minima: {weatherData.day5.temperature_min}");
                Console.WriteLine();
                Console.WriteLine($"Fecha: {weatherData.day6.date}");
                Console.WriteLine($"Se espera una temperatura maxima: {weatherData.day3.temperature_max}");
                Console.WriteLine($"Se espera una temperatura minima: {weatherData.day3.temperature_min}");
                Console.WriteLine();
                Console.WriteLine($"Fecha: {weatherData.day7.date}");
                Console.WriteLine($"Se espera una temperatura maxima: {weatherData.day7.temperature_max}");
                Console.WriteLine($"Se espera una temperatura minima: {weatherData.day7.temperature_min}");
                SaveDay1(weatherData);
            }
        }

        static void VerResultadosBaseDatos()
        {

            Console.WriteLine("Mostrando resultados de la base de datos...");

            using (var dbContext = new DayDBContext())
            {
                // Consulta para obtener todos los registros de la tabla Day
                var resultados = dbContext.Days.ToList();

                if (resultados.Any())
                {
                    int totalRegistros = dbContext.Days.Count();
                    Console.WriteLine($" Se han encontrado registros {totalRegistros} | Resultados de la base de datos:");
                    foreach (var resultado in resultados)
                    {
                        Console.WriteLine($"Fecha: {resultado.Date}");
                        Console.WriteLine($"Temperatura Máxima: {resultado.TemperatureMax}");
                        Console.WriteLine($"Temperatura Mínima: {resultado.TemperatureMin}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No hay resultados en la base de datos.");
                }
            }

        }

    }

}
