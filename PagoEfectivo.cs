using System;


public class PagoEfectivo : Pago
{
    public PagoEfectivo(float monto) : base(monto)
    {
    }

    
    public override bool ValidarDatos()
    {
        if (monto > 0)
        {
            Console.WriteLine("Validación exitosa: Monto de efectivo válido");
            return true;
        }
        else
        {
            Console.WriteLine("Error: El monto en efectivo debe ser mayor a 0");
            return false;
        }
    }

    public override string GetTipo()
    {
        return "Pago en Efectivo";
    }

    public string ListarInfo()
    {
        return $"Tipo: {GetTipo()}, Monto: ${monto}";
    }
}