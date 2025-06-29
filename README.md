# AppInstallerConsole.

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![C#](https://img.shields.io/badge/Language-C%23-green)
![Platform](https://img.shields.io/badge/Platform-Windows-yellow)

## Descripción.

**AppInstallerConsole** es una aplicación de consola desarrollada en C# que automatiza la descarga e instalación silenciosa de una lista predefinida de programas en sistemas Windows.  

El proyecto permite distribuir un instalador portátil y desatendido que, al ejecutarse, se encarga de gestionar las descargas y ejecuciones de los instaladores sin intervención manual, ideal para entornos donde se necesita desplegar software rápidamente en múltiples equipos.

---

## Características principales.

- Lectura dinámica de una lista de software desde un archivo JSON.
- Descarga automática de instaladores desde URLs oficiales.
- Instalación silenciosa con argumentos personalizados para cada programa.
- Evita re-descargar instaladores ya presentes.
- Ejecución desatendida sin mostrar ventanas de instalación.
- Proyecto portable, fácil de modificar y ampliar.

---

## Estructura del proyecto.

AutoInstallerConsole/
├── Program.cs                      # Código principal de la app consola
├── Resources/
│ └── software_list.json            # Archivo JSON con la lista de programas
├── Installers/                     # Carpeta donde se descargan los instaladores
├── AutoInstallerConsole.csproj     # Archivo de proyecto .NET
└── README.md                       # Este archivo de documentación

---

## Requisitos.

- Windows 10 o superior.
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado.
- Conexión a internet para descargar los instaladores.

---

## Uso.

1. Clona o descarga el repositorio.
2. Edita `Resources/software_list.json` para agregar o modificar la lista de programas a instalar.
3. Abre una terminal y navega a la carpeta del proyecto.
4. Ejecuta el programa con:

```bash
dotnet run
```

El programa descargará los instaladores necesarios y ejecutará la instalación de cada programa en modo silencioso.

---

## Agregar nuevos programas.

Edita el archivo `software_list.json` con el siguiente formato:

[
  {
    "nombre": "Nombre del programa",
    "url": "URL directa al instalador",
    "archivo": "nombre_local_del_instalador.exe",
    "argumentos": "argumentos_silenciosos_para_instalacion"
  }
]

---

## Contribuciones.

¡Las contribuciones son bienvenidas!
Si quieres mejorar el proyecto, por favor abre un issue o un pull request.

---

## Licencia.

Este proyecto está bajo licencia MIT.
Consulta el archivo LICENSE para más detalles.

---

## Contacto.

Desarrollado por JaviCanales17
GitHubLink

---