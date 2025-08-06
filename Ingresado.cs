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

    public override void Asignar(Pedido pedido, int repartidor)
    {
        pedido.SetRepartidor(repartidor);
        pedido.SetEstado(Asignado.GetInstance());
    }

    public override void Cancelar(Pedido pedido)
    {
        pedido.SetEstado(Cancelado.GetInstance());
    }
}