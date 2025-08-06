using System;

// Estado Entregado - Singleton Perezoso
public class Entregado : Estado
{
    private static Entregado instance;

    private Entregado() : base("Entregado")
    {
    }

    public static Entregado GetInstance()
    {
        if (instance == null)
        {
            instance = new Entregado();
        }
        return instance;
    }

}