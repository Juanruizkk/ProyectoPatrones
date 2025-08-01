using System;


public abstract class Pago
{
    protected float monto;

    public Pago(float monto)
    {
        this.monto = monto;
    }


    public bool Procesar(float restante)
    {
        Console.WriteLine($"Procesando pago de tipo {GetTipo()} por ${monto}");


        if (!ValidarDatos())
        {
            Console.WriteLine("Error: Datos inválidos para el pago");
            return false;
        }

        if (monto >= restante)
        {
            Console.WriteLine($"Pago procesado exitosamente: ${monto}");
            return true;
        }
        else
        {
            Console.WriteLine($"Error: Monto insuficiente. Se requiere ${restante}, se proporcionó ${monto}");
            return false;
        }
    }

    public abstract bool ValidarDatos();
    public abstract string GetTipo();

    public float GetMonto()
    {
        return monto;
    }

    public void SetMonto(float monto)
    {
        this.monto = monto;
    }
}