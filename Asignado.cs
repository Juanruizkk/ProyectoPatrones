using System;

public class Asignado : Estado
{
    private static Asignado instance;

    private Asignado() : base("Asignado")
    {
    }

    public static Asignado GetInstance()
    {
        if (instance == null)
        {
            instance = new Asignado();
        }
        return instance;
    }

    public override void Cancelar(Pedido pedido)
    {
        pedido.SetEstado(Cancelado.GetInstance());
        Console.WriteLine("Pedido cancelado desde estado Asignado");
    }

    public override void Rechazar(Pedido pedido)
    {
        pedido.SetEstado(Cancelado.GetInstance());
        Console.WriteLine("Pedido rechazado desde estado Asignado");
    }

    public override void Entregar(Pedido pedido)
    {
        pedido.SetEstado(Entregado.GetInstance());
        Console.WriteLine("Pedido entregado exitosamente");
    }
}