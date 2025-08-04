using System;
using System.Collections.Generic;

public class Cliente
{
    private int idCliente;
    private string nombre;
    private string apellido;
    private string direccion;
    private string ubicacionGPS;

    private List<Pedido> listaPedidos;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string UbicacionGPS { get => ubicacionGPS; set => ubicacionGPS = value; }
    public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
    public int IdCliente { get => idCliente; set => idCliente = value; }

    // Constructor
    public Cliente(string nombre, string apellido, string direccion, string ubicacionGPS)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Direccion = direccion;
        this.UbicacionGPS = ubicacionGPS;
        this.ListaPedidos = new List<Pedido>();
    }

    // Constructor alternativo sin parámetros
    public Cliente()
    {
        this.Nombre = "";
        this.Apellido = "";
        this.Direccion = "";
        this.UbicacionGPS = "";
        this.ListaPedidos = new List<Pedido>();
    }

    // Función para listar información del cliente
   public void ListarInfo()
{
    Console.WriteLine($"Nombre: {Nombre} {Apellido}");
    Console.WriteLine($"Dirección: {Direccion}");
    Console.WriteLine($"Ubicación GPS: {UbicacionGPS}");
    Console.WriteLine($"Total de pedidos: {ListaPedidos.Count}");

    // Agregar información de cada pedido
    foreach (Pedido pedido in ListaPedidos)
    {
        Console.Write("  - ");
        pedido.ListarInfo();
    }
}


    // Métodos adicionales útiles
    public void AgregarPedido(Pedido pedido)
    {
        ListaPedidos.Add(pedido);
    }

    public void RemoverPedido(Pedido pedido)
    {
        ListaPedidos.Remove(pedido);
    }

   
}