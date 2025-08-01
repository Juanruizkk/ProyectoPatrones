using System;

public class Ingresado : Estado
{
    private static Ingresado instance;

    private Ingresado() : base("Ingresado")
    {
    }

    public static Ingresado GetInstance()
    {
        if (instance == null)
        {
            instance = new Ingresado();
        }
        return instance;
    }

    public override void Asignar(Pedido pedido, string pedidoItem, string repartidor)
    {
        if (pedidoItem != null && repartidor != null)
        {
            pedido.AgregarAPedidos(pedidoItem);
            pedido.SetEstado(Asignado.GetInstance());
            Console.WriteLine($"Pedido '{pedidoItem}' asignado a repartidor '{repartidor}'");
        }
        else
        {
            Console.WriteLine("Se requiere pedido y repartidor para asignar");
        }
    }

    public override void Cancelar(Pedido pedido)
    {
        pedido.SetEstado(Cancelado.GetInstance());
        Console.WriteLine("Pedido cancelado desde estado Ingresado");
    }

    public override void Rechazar(Pedido pedido)
    {
        pedido.SetEstado(Cancelado.GetInstance());
        Console.WriteLine("Pedido rechazado desde estado Ingresado");
    }
}