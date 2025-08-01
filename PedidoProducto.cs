using System;
using System.Collections.Generic;

public class PedidoProducto()
{
    private Producto producto;
    private int cantidad;
    private float precioUnitario;

    public PedidoProducto(PedidoProducto prod, int cant, int precioU)
    {
        this.producto = prod;
        this.cantidad = cant;
        this.precioUnitario = precioU;
    }

    public void listarInfo()
    {
        Console.WriteLine($"Producto: {producto.getNombre()}, Precio: {this.precioUnitario}, Cantidad: {this.cantidad}");
    }

    public float getTotal()
    {
        return this.precioUnitario * this.cantidad;
    }
}