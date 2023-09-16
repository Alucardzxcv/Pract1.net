namespace frontend
{
    public class GiftenorResponse
    {
        public GiftenorResult[] Results { get; set; }
    }

    public class GiftenorResult
    {
        public string Id { get; set; }
        public string Content_Description { get; set; }
        // Puedes agregar aquí propiedades adicionales según sea necesario para mapear la respuesta JSON.
    }
}
