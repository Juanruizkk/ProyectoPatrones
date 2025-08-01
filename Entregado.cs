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

    // En estado Entregado no se pueden realizar más transiciones
    // Los métodos heredados mostrarán el mensaje de error por defecto
}