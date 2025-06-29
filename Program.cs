using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Programa
{
    public string nombre { get; set; } = string.Empty;
    public string url { get; set; } = string.Empty;
    public string archivo { get; set; } = string.Empty;
    public string argumentos { get; set; } = string.Empty;
}

class Program
{
    private static readonly string jsonPath = Path.Combine("Resources", "software_list.json");
    private static readonly string installerPath = "Installers";

    static async Task Main()
    {
        Console.WriteLine("Cargando lista de programas...");
        if (!File.Exists(jsonPath))
        {
            Console.WriteLine("ERROR: No se encontró el archivo software_list.json");
            return;
        }

        var json = await File.ReadAllTextAsync(jsonPath);
        var programas = JsonSerializer.Deserialize<List<Programa>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Directory.CreateDirectory(installerPath);

        if (programas == null)
        {
            Console.WriteLine("No se pudo cargar la lista de programas.");
            return;
        }

        foreach (var programa in programas)
        {
            string ruta = Path.Combine(installerPath, programa.archivo);

            if (!File.Exists(ruta))
            {
                Console.WriteLine($"Descargando {programa.nombre}...");
                using var httpClient = new HttpClient();
                try
                {
                    var data = await httpClient.GetByteArrayAsync(programa.url);
                    await File.WriteAllBytesAsync(ruta, data);
                    Console.WriteLine($"Descarga de {programa.nombre} completada.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al descargar {programa.nombre}: {ex.Message}");
                    continue;
                }
            }
            else
            {
                Console.WriteLine($"{programa.nombre} ya está descargado.");
            }

            Console.WriteLine($"Instalando {programa.nombre}...");
            var proceso = new Process();
            proceso.StartInfo.FileName = ruta;
            proceso.StartInfo.Arguments = programa.argumentos;
            proceso.StartInfo.UseShellExecute = false;
            proceso.StartInfo.CreateNoWindow = true;

            try
            {
                proceso.Start();
                proceso.WaitForExit();
                Console.WriteLine($"{programa.nombre} instalado con código de salida {proceso.ExitCode}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al instalar {programa.nombre}: {ex.Message}");
            }
        }

        Console.WriteLine("Instalación finalizada. Presiona una tecla para salir.");
        Console.ReadKey();
    }
}
