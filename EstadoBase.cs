using System;

// Clase abstracta Estado
public abstract class Estado
{
    protected string nombre;

    protected Estado(string nombre)
    {
        this.nombre = nombre;
    }

    public string GetNombre()
    {
        return nombre;
    }

    public virtual void  Asignar(Pedido pedido, int repartidor)
    {
        Console.WriteLine($"No se puede pasar de '{GetNombre()}' a asignado");
    }

    public virtual void Cancelar(Pedido pedido)
    {
        Console.WriteLine($"No se puede pasar de '{GetNombre()}' a cancelado");
    }

    public virtual void Rechazar(Pedido pedido)
    {
        Console.WriteLine($"No se puede pasar de '{GetNombre()}' a rechazado");
    }

    public virtual void Entregar(Pedido pedido)
    {
        Console.WriteLine($"No se puede pasar de '{GetNombre()}' a entregado");
    }
}