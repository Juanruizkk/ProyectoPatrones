using System;


public abstract class Pago
{
    private float monto;

    protected float Monto { get => monto; set => monto = value; }

    public Pago(float monto)
    {
        this.Monto = monto;
    }


    public bool Procesar(float restante)
    {
        Console.WriteLine($"Procesando pago de tipo {GetTipo()} por ${Monto}");


        if (!ValidarDatos())
        {
            Console.WriteLine("Error: Datos inválidos para el pago");
            return false;
        }

        if (Monto >= restante)
        {
            Console.WriteLine($"Pago procesado exitosamente: ${Monto}");
            return true;
        }
        else
        {
            Console.WriteLine($"Error: Monto insuficiente. Se requiere ${restante}, se proporcionó ${Monto}");
            return false;
        }
    }

    public abstract bool ValidarDatos();
    public abstract string GetTipo();

    public float GetMonto()
    {
        return Monto;
    }

    public void SetMonto(float monto)
    {
        this.Monto = monto;
    }
}