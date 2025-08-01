using System;

public class Cancelado : Estado
{
    private static Cancelado instance;

    private Cancelado() : base("Cancelado")
    {
    }

    public static Cancelado GetInstance()
    {
        if (instance == null)
        {
            instance = new Cancelado();
        }
        return instance;
    }

    // En estado Cancelado no se pueden realizar más transiciones
    // Los métodos heredados mostrarán el mensaje de error por defecto
}