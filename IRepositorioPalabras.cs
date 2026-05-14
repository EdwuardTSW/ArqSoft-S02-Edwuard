namespace Ahorcado
{
    public interface IRepositorioPalabras
    {
        List<string> ObtenerCategorias();
        string ObtenerPalabraAleatoria(string categoria);
    }
}