namespace CRUD.ENTIDADES
{
    public class UsuarioDTO
    {
        
        public int IdUsuario { get; set;}
        public string? Correo { get; set;}
        public string? Contrasena { get; set;}
        public DateTime? FechaCreacion { get; set;}
        public int IdRol { get; set;}
        public string? NombreCompleto { get; set;}


    }
}
