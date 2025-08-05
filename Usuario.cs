using System;

// Clase Usuario
public class Usuario
{
    private int idUsuario;
    private string nombre;
    private Verificador vPass;
    private string apellido;
    private string usuario;
    private string contrasenia;
    private string imagen;
    private string rol;

    // Properties
    public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public Verificador VPass { get => vPass; set => vPass = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public string UsuarioNombre { get => usuario; set => usuario = value; }
    public string Contrasenia { get => contrasenia; set => contrasenia = value; }
    public string Imagen { get => imagen; set => imagen = value; }
    public string Rol { get => rol; set => rol = value; }

    // Constructor sin parámetros
    public Usuario()
    {
        this.nombre = "";
        this.apellido = "";
        this.usuario = "";
        this.contrasenia = "";
        this.imagen = "";
        this.rol = "";
    }

    // Constructor con parámetros
    public Usuario(int idUsuario, string nombre, string apellido, string usuario, 
                   string contrasenia, string imagen, string rol, Verificador vPass)
    {
        this.idUsuario = idUsuario;
        this.nombre = nombre;
        this.apellido = apellido;
        this.usuario = usuario;
        this.contrasenia = contrasenia;
        this.imagen = imagen;
        this.rol = rol;
        this.vPass = vPass;
    }

    // Método ListarInfo
    public string ListarInfo()
    {
        return $"ID: {idUsuario}, Usuario: {usuario}, Nombre: {nombre} {apellido}, Rol: {rol}";
    }

    // Método CambiarContrasenia según el pseudocódigo del diagrama
    public void CambiarContrasenia(string pass)
    {
        if (vPass != null && vPass.Verificar(pass))
        {
            Console.WriteLine("La contraseña se cambió correctamente");
            contrasenia = pass;
        }
        else
        {
            Console.WriteLine("La contraseña ingresada no es válida");
        }
    }

    // Método EditarUsuario
    public void EditarUsuario(Usuario usuarioModificado)
    {
        this.nombre = usuarioModificado.nombre;
        this.apellido = usuarioModificado.apellido;
        this.usuario = usuarioModificado.usuario;
        this.imagen = usuarioModificado.imagen;
        this.rol = usuarioModificado.rol;
        
        Console.WriteLine("Usuario editado correctamente");
    }

}