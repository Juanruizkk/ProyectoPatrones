using System;


public class PagoEfectivo : Pago
{
    public PagoEfectivo(float monto) : base(monto)
    {
    }

    
    public override bool ValidarDatos()
    {
        return true;
    }

    public override string GetTipo()
    {
        return "Pago en Efectivo";
    }

    public string ListarInfo()
    {
        return $"Tipo: {GetTipo()}, Monto: ${this.monto}";
    }
}