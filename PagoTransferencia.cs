using System;

public class PagoTransferencia : Pago
{
    private string comprobante;

    public PagoTransferencia(float monto, string comprobante) : base(monto)
    {
        this.comprobante = comprobante;
    }

    public override bool ValidarDatos()
    {
        if (monto > 0 && !string.IsNullOrEmpty(comprobante) && comprobante.Trim().Length > 0)
        {
            Console.WriteLine($"Validación exitosa: Transferencia válida con comprobante {comprobante}");
            return true;
        }
        else
        {
            if (monto <= 0)
                Console.WriteLine("Error: El monto de transferencia debe ser mayor a 0");
            if (string.IsNullOrEmpty(comprobante) || comprobante.Trim().Length == 0)
                Console.WriteLine("Error: Se requiere un comprobante válido para la transferencia");
            return false;
        }
    }

    public override string GetTipo()
    {
        return "Pago por Transferencia";
    }

    public string ListarInfo()
    {
        return $"Tipo: {GetTipo()}, Monto: ${monto}, Comprobante: {comprobante}";
    }

    public string GetComprobante()
    {
        return comprobante;
    }

    public void SetComprobante(string comprobante)
    {
        this.comprobante = comprobante;
    }
}