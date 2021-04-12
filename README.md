## Ejecutar la aplicación
$ cd Vector/App

$ dotnet run

## Ejecutar los tests
$ cd Vector/UnitTests

$dotnet test


## Settings: 
Se corresponden con el fichero "Vector/App/MyConfig.json" y configuran el path del fichero countries.json y el nombre del fichero donde se guarda el nombre del país creado.


## Acceptance test:
Comprueba los nombres de los ficheros con datos de paises y que la ruta es la correcta.


## Endpoints:
Para testear las rutas y obtener documentación sobre los endpoints, una vez lanzada la aplicación, dirigirse a esta ruta en el navegador: "https://localhost:5001/swagger/index.html"

* Get /Countries: Haciendo click sobre la ruta Get "/Countries" y pulsando ejecutar se obtiene una lista de todos los países.
* Get /CountryName: Haciendo click sobre la ruta Get "/CountryName" y rellenando en el campo "code" con un código de país, al pulsar ejecutar se obtiene el nombre del país con su código.
* Post /CreateCountry: Haciendo click sobre la ruta Post "/CreateCountry" y sustituyendo en el campo "Request body" ambos "string" por un nombre y un código, al pulsar ejecutar se crea en el servidor un fichero en la carpeta "data", llamado "contry.json" con los datos pasados en el cuerpo del post.


## Systema operativo y version de .Net
* Probado sobre Linux Mint 20 Ulyana
* dotnet --version: 5.0.202
* No ha sido probado sobre Windows
