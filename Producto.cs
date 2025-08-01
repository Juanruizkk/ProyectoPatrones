 using System;
using System.Collections.Generic;

public class Producto
{
    private string nombre;
    private float precio;
    private int llenos;
    private int vacios;

    public Producto(string nombre, float precio, int llenos, int vacios)
    {
        this.nombre = nombre;
        this.precio = precio;
        this.llenos = llenos;
        this.vacios = vacios;
    }

    public void listarInfo()
    {
        Console.WriteLine($"Producto: {nombre}, Precio: {precio}, Llenos: {llenos}, Vacios: {vacios}");
    }

    public void setLlenos(int cantidad)
    {
        llenos = cantidad;
    }

    public void setVacios(int cantidad)
    {
        vacios = cantidad;
    }
    public float getPrecio()
    {
        return precio;
    }

    public string getNombre()
    {
        return nombre;
    } 

}