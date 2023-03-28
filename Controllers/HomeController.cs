using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace basic_mvc.Controllers
{
    public class HomeController : Controller
    {
        //index básico --> retornando string
        /*
        public string Index()
        {
            return "Saludos!";
        }
        */

        public IActionResult Index()
        {
            /*
             * este método llamará al método View del controlador y usará una plantilla de vista para generar una respuesta basada en HTML
             * .Net gestiona las vistas, entre otras opcinoes, con Razor: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-7.0
             * 
             * generalmente, el método index de un controlador retornará un IActionResult o un objeto de alguna clase derivada, no un tipo de dato primitivo
             * --> básicamente, retornará una vista.
             */
            return View();
        } 

        /*
         * los parámetros que se definen para los métodos se llenarán con los argumentos que se pasen desde la URL invocada
         * por ejemplo, la url localhost:<#port>/Home/Welcome invocará el método Welcome de la clase controladora HomeController.cs
         * adicionalmente, la url localhost:<#port>/Home/Welcome?name=Johnathan&age=30 invocará el mismo método pero le asignará los valores John y 30
         * a los parámetros del método. --> esto se hace a través de model biding (lo abordaremos después): https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-7.0
         * 
         * en el ejemplo anterior, la url contiene "?" y "&", el primero separa la clase de los argumentos y el segundo, separa parejas de parámetro=argumento
         * Como cualquier otro método, se pueden definir valores por defecto como en age.
         */
            public string Welcome(string name, int age=20)
        {
            //return $"Bienvenido {name} con edad {age}";

            //Html encoder protege, de manera básica, inyección maliciosa desde Javascript
            return HtmlEncoder.Default.Encode($"Bienvenido {name} con edad {age}");
        }

        /*
         * En el ruteo del controlador Home definimos un parámetro opcional "id" --> "{controller=Home}/{action=Index}/{id?}"
         * este patrón nos sirve para caracterizar la invocación a este controlador, así que si se hace match con este patrón, podremos incluir
         * un valor adicional por fuera de los parámetros invocados directamente desde la url. En este caso, c# acepta variaciones en minúsculas y 
         * mayúsculas del nombre. 
         * 
         * Por ejemplo, si accedemos a localhost:<#port>/Home/Welcome2/100?name=Johnathan&age=30, el parámetro ID del método recibirá lo que se guardó
         * en "id" del patrón del archivo de rutas, que en este ejemplo es 100. 
         */
        public string Welcome2(string name, int ID, int age = 20)
        {
            //return $"Bienvenido {name} con edad {age}";

            //Html encoder protege, de manera básica, inyección maliciosa desde Javascript
            return HtmlEncoder.Default.Encode($"Bienvenido {name} con id {ID} y edad {age}");
        }
        public IActionResult Welcome3(string name, int ID, int age = 20)
        {
            //return $"Bienvenido {name} con edad {age}";

            //Html encoder protege, de manera básica, inyección maliciosa desde Javascript
            return View();
        }
        public IActionResult Welcome4(string name, int ID, int age = 20)
        {
            //Definiendo datos para enviar a la vista --> todos en el diccionario ViewData de la vista
            ViewData["name"] = name;
            ViewData["id"] = ID;
            ViewData["age"] = age;
            ViewData["mensaje"] = ":O";


            /* En este flujo, los datos se traen desde el navegador, llegan al controlador y el controlador
             * los envía a la vista
             */
            return View();
        }
    }
}
