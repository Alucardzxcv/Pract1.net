namespace frontend
{
    public class PokemonResponse
    {
        public PokemonResult[] Results { get; set; }
    }

    public class PokemonResult
    {
        public string Name { get; set; }
        public string Url { get; set; }
        // Puedes agregar aquí propiedades adicionales según sea necesario para mapear la respuesta JSON.
    }
}
