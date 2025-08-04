 using System;
using System.Collections.Generic;

public class Producto
{
    private string nombre;
    private float precio;
    private int llenos;
    private int vacios;

    public string Nombre { get => nombre; set => nombre = value; }
    public float Precio { get => precio; set => precio = value; }
    public int Llenos { get => llenos; set => llenos = value; }
    public int Vacios { get => vacios; set => vacios = value; }

    public Producto(string nombre, float precio, int llenos, int vacios)
    {
        this.Nombre = nombre;
        this.Precio = precio;
        this.Llenos = llenos;
        this.Vacios = vacios;
    }

    public void ListarInfo()
    {
        Console.WriteLine($"Producto: {Nombre}, Precio: {Precio}, Llenos: {Llenos}, Vacios: {Vacios}");
    }


}