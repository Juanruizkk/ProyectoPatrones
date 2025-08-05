using System;
using System.Collections.Generic;
using System.Linq;

// Clase Sistema - Fachada para manejar todo el sistema
public class Sistema
{
    // Listas para almacenar los datos del sistema
    private List<Usuario> usuarios;
    private List<Producto> productos;
    private List<Cliente> clientes;
    private List<Pedido> pedidos;

    // Properties
    public List<Usuario> Usuarios { get => usuarios; set => usuarios = value; }
    public List<Producto> Productos { get => productos; set => productos = value; }
    public List<Cliente> Clientes { get => clientes; set => clientes = value; }
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

    // Constructor
    public Sistema()
    {
        this.usuarios = new List<Usuario>();
        this.productos = new List<Producto>();
        this.clientes = new List<Cliente>();
        this.pedidos = new List<Pedido>();
    }

    // === MÉTODOS PARA USUARIOS ===
    public void CrearUsuario(string nombre, string apellido, string usuario, string contrasenia, string rol, string imagen)
    {
        int nuevoId = usuarios.Count > 0 ? usuarios.Max(u => u.IdUsuario) + 1 : 1;
        
        // Crear verificador básico para el usuario
        Verificador verificador = new VLongMin(6, new VCantNum(1));
        
        Usuario nuevoUsuario = new Usuario(nuevoId, nombre, apellido, usuario, contrasenia, imagen, rol, verificador);
        usuarios.Add(nuevoUsuario);
        
        Console.WriteLine($"Usuario creado: {nuevoUsuario.ListarInfo()}");
    }

    public void EliminarUsuario(int id)
    {
        Usuario usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);
        if (usuario != null)
        {
            usuarios.Remove(usuario);
            Console.WriteLine($"Usuario eliminado: {usuario.Nombre} {usuario.Apellido}");
        }
        else
        {
            Console.WriteLine($"Usuario con ID {id} no encontrado");
        }
    }

    public void EditarUsuario(int id, Usuario usuarioModificado)
    {
        Usuario usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);
        if (usuario != null)
        {
            usuario.EditarUsuario(usuarioModificado);
            Console.WriteLine($"Usuario editado correctamente");
        }
        else
        {
            Console.WriteLine($"Usuario con ID {id} no encontrado");
        }
    }

    public List<Usuario> GetUsuarios()
    {
        return new List<Usuario>(usuarios);
    }

    public Usuario GetUsuario(int id)
    {
        return usuarios.FirstOrDefault(u => u.IdUsuario == id);
    }

    // === MÉTODOS PARA CLIENTES ===
    public void CrearCliente(string nombre, string apellido, string direccion, string ubicacionGPS)
    {
        int nuevoId = clientes.Count > 0 ? clientes.Max(c => c.IdCliente) + 1 : 1;
        
        Cliente nuevoCliente = new Cliente(nombre, apellido, direccion, ubicacionGPS);
        nuevoCliente.IdCliente = nuevoId;
        clientes.Add(nuevoCliente);
        
        Console.WriteLine($"Cliente creado: {nuevoCliente.Nombre} {nuevoCliente.Apellido}");
    }

    public void EditarCliente(int id, Cliente cliente)
    {
        Cliente clienteExistente = clientes.FirstOrDefault(c => c.IdCliente == id);
        if (clienteExistente != null)
        {
            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Apellido = cliente.Apellido;
            clienteExistente.Direccion = cliente.Direccion;
            clienteExistente.UbicacionGPS = cliente.UbicacionGPS;
            
            Console.WriteLine($"Cliente editado correctamente");
        }
        else
        {
            Console.WriteLine($"Cliente con ID {id} no encontrado");
        }
    }

    public void EliminarCliente(int id)
    {
        Cliente cliente = clientes.FirstOrDefault(c => c.IdCliente == id);
        if (cliente != null)
        {
            clientes.Remove(cliente);
            Console.WriteLine($"Cliente eliminado: {cliente.Nombre} {cliente.Apellido}");
        }
        else
        {
            Console.WriteLine($"Cliente con ID {id} no encontrado");
        }
    }

    public Cliente GetCliente(int id)
    {
        return clientes.FirstOrDefault(c => c.IdCliente == id);
    }

    public List<Cliente> GetClientes()
    {
        return new List<Cliente>(clientes);
    }

    // === MÉTODOS PARA PRODUCTOS ===
    public void CrearProducto(string nombre, float precio, int vacios, int llenos)
    {
        Producto nuevoProducto = new Producto(nombre, precio, llenos, vacios);
        productos.Add(nuevoProducto);
        
        Console.WriteLine($"Producto creado: {nuevoProducto.Nombre} - ${nuevoProducto.Precio}");
    }

    public void EditarProducto(int id, Producto producto)
    {
        if (id >= 0 && id < productos.Count)
        {
            productos[id] = producto;
            Console.WriteLine($"Producto editado correctamente");
        }
        else
        {
            Console.WriteLine($"Producto con índice {id} no encontrado");
        }
    }

    public void EliminarProducto(int id)
    {
        if (id >= 0 && id < productos.Count)
        {
            Producto producto = productos[id];
            productos.RemoveAt(id);
            Console.WriteLine($"Producto eliminado: {producto.Nombre}");
        }
        else
        {
            Console.WriteLine($"Producto con índice {id} no encontrado");
        }
    }

    public List<Producto> GetProductos()
    {
        return new List<Producto>(productos);
    }

    public Producto GetProducto(int id)
    {
        if (id >= 0 && id < productos.Count)
        {
            return productos[id];
        }
        return null;
    }

    // === MÉTODOS PARA PEDIDOS ===
    public Pedido CrearPedido()
    {
        Pedido nuevoPedido = new Pedido();
        pedidos.Add(nuevoPedido);
        
        Console.WriteLine($"Pedido creado en estado: {nuevoPedido.Estado.GetNombre()}");
        return nuevoPedido;
    }

    public void AsignarPedido(int idPedido, int idRepartidor)
    {
        if (idPedido >= 0 && idPedido < pedidos.Count)
        {
            Pedido pedido = pedidos[idPedido];
            pedido.NroRepartidor = idRepartidor;
            // Aquí podrías agregar lógica adicional para asignar
            Console.WriteLine($"Pedido asignado al repartidor {idRepartidor}");
        }
        else
        {
            Console.WriteLine($"Pedido con ID {idPedido} no encontrado");
        }
    }

    public void RechazarPedido(int idPedido)
    {
        if (idPedido >= 0 && idPedido < pedidos.Count)
        {
            Pedido pedido = pedidos[idPedido];
            pedido.RechazarPedido();
        }
        else
        {
            Console.WriteLine($"Pedido con ID {idPedido} no encontrado");
        }
    }

    public void CancelarPedido(int idPedido)
    {
        if (idPedido >= 0 && idPedido < pedidos.Count)
        {
            Pedido pedido = pedidos[idPedido];
            pedido.CancelarPedido();
        }
        else
        {
            Console.WriteLine($"Pedido con ID {idPedido} no encontrado");
        }
    }

    // === MÉTODOS AUXILIARES ===
    public void MostrarEstadisticas()
    {
        Console.WriteLine("=== ESTADÍSTICAS DEL SISTEMA ===");
        Console.WriteLine($"Total de usuarios: {usuarios.Count}");
        Console.WriteLine($"Total de clientes: {clientes.Count}");
        Console.WriteLine($"Total de productos: {productos.Count}");
        Console.WriteLine($"Total de pedidos: {pedidos.Count}");
        
        // Estadísticas de pedidos por estado
        var estadosPedidos = pedidos.GroupBy(p => p.Estado.GetNombre())
                                   .Select(g => new { Estado = g.Key, Cantidad = g.Count() });
        
        Console.WriteLine("\nPedidos por estado:");
        foreach (var grupo in estadosPedidos)
        {
            Console.WriteLine($"  {grupo.Estado}: {grupo.Cantidad}");
        }
    }

    public void ListarTodos()
    {
        Console.WriteLine("\n=== LISTADO COMPLETO DEL SISTEMA ===");
        
        Console.WriteLine("\n--- USUARIOS ---");
        foreach (Usuario usuario in usuarios)
        {
            Console.WriteLine(usuario.ListarInfo());
        }
        
        Console.WriteLine("\n--- CLIENTES ---");
        foreach (Cliente cliente in clientes)
        {
            cliente.ListarInfo();
            Console.WriteLine("---");
        }
        
        Console.WriteLine("\n--- PRODUCTOS ---");
        foreach (Producto producto in productos)
        {
            producto.ListarInfo();
        }
       
        
        Console.WriteLine("\n--- PEDIDOS ---");
        for (int i = 0; i < pedidos.Count; i++)
        {
            Console.WriteLine($"[{i}] Estado: {pedidos[i].Estado.GetNombre()}");
        }
    }
}