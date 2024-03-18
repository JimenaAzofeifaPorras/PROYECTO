namespace FrontEnd.ApiModels
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public string? Nombre { get; set; }

        public string? Estado { get; set; }

        public byte[]? Imagen { get; set; }

        public string? Precio { get; set; }
    }
}
