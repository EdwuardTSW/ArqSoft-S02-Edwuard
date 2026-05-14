namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly Dictionary<string, List<string>> _palabrasPorCategoria = new()
    {
        {
            "Programacion",
            new List<string>
            {
                "arquitectura",
                "interfaz",
                "polimorfismo",
                "encapsulamiento",
                "herencia"
            }
        },
        {
            "Animales",
            new List<string>
            {
                "perro",
                "gato",
                "caballo",
                "elefante",
                "jirafa"
            }
        },
        {
            "Paises",
            new List<string>
            {
                "argentina",
                "brasil",
                "chile",
                "uruguay",
                "peru"
            }
        },
        {
            "ParaBikersB",
            new List<string>    
            {
                "moto",
                "casco",
                "cilindrada",
                "embrague",
                "acelerador",
                "freno",
                "cadena",
                "llanta",
                "escape",
                "manubrio"
            }
}
    };
        public List<string> ObtenerCategorias()
        {
            return _palabrasPorCategoria.Keys.ToList();
        }
        public string ObtenerPalabraAleatoria(string categoria)
        {
            var palabras = _palabrasPorCategoria[categoria];
            var random = new Random();
            return palabras[random.Next(palabras.Count)];
        }
    }
}
