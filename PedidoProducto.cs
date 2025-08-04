using System;
using System.Collections.Generic;

public class PedidoProducto
{
    private Producto producto;
    private int cantidad;
    private float precioUnitario;

    public Producto Producto { get => producto; set => producto = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }
    public float PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }

    public PedidoProducto(Producto prod, int cant, float precioU)
    {
        this.Producto = prod;
        this.Cantidad = cant;
        this.PrecioUnitario = precioU;
    }

    public void ListarInfo()
    {
        Console.WriteLine($"Producto: {Producto.Nombre}, Precio: {this.PrecioUnitario}, Cantidad: {this.Cantidad}");
    }

    public float GetTotal()
    {
        return this.PrecioUnitario * this.Cantidad;
    }
}