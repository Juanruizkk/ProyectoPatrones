using System;
using System.Collections.Generic;

public class Cliente
{
    private string nombre;
    private string apellido;
    private string direccion;
    private string ubicacionGPS;

    private List<Pedido> listaPedidos;

    // Constructor
    public Cliente(string nombre, string apellido, string direccion, string ubicacionGPS)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.direccion = direccion;
        this.ubicacionGPS = ubicacionGPS;
        this.listaPedidos = new List<Pedido>();
    }

    // Constructor alternativo sin parámetros
    public Cliente()
    {
        this.nombre = "";
        this.apellido = "";
        this.direccion = "";
        this.ubicacionGPS = "";
        this.listaPedidos = new List<Pedido>();
    }

    // Función para listar información del cliente
    public List<string> ListarInfo()
    {
        List<string> info = new List<string>();
        
        info.Add($"Nombre: {nombre} {apellido}");
        info.Add($"Dirección: {direccion}");
        info.Add($"Ubicación GPS: {ubicacionGPS}");
        info.Add($"Total de pedidos: {listaPedidos.Count}");
        
        // Agregar información de cada pedido
        for (int i = 0; i < listaPedidos.Count; i++)
        {
            info.Add($"Pedido {i + 1}:");
            info.Add($"  Estado: {listaPedidos[i].GetEstado().GetNombre()}");
            
            List<string> pedidoItems = listaPedidos[i].ListarInfo();
            if (pedidoItems.Count > 0)
            {
                info.Add($"  Items: {string.Join(", ", pedidoItems)}");
            }
            else
            {
                info.Add("  Items: Sin items");
            }
        }
        
        return info;
    }

    // Métodos adicionales útiles
    public void AgregarPedido(Pedido pedido)
    {
        listaPedidos.Add(pedido);
    }

    public void RemoverPedido(Pedido pedido)
    {
        listaPedidos.Remove(pedido);
    }

    // Getters y Setters
    public string GetNombre()
    {
        return nombre;
    }

    public void SetNombre(string nombre)
    {
        this.nombre = nombre;
    }

    public string GetApellido()
    {
        return apellido;
    }

    public void SetApellido(string apellido)
    {
        this.apellido = apellido;
    }

    public string GetDireccion()
    {
        return direccion;
    }

    public void SetDireccion(string direccion)
    {
        this.direccion = direccion;
    }

    public string GetUbicacionGPS()
    {
        return ubicacionGPS;
    }

    public void SetUbicacionGPS(string ubicacionGPS)
    {
        this.ubicacionGPS = ubicacionGPS;
    }

    public List<Pedido> GetListaPedidos()
    {
        return new List<Pedido>(listaPedidos);
    }
}