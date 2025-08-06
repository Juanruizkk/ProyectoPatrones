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
        if (string.IsNullOrEmpty(comprobante) && comprobante.Trim().Length > 0)
        {

            return false;
        }
        else
        {

            Console.WriteLine($"Validación exitosa: Transferencia válida con comprobante {comprobante}");
            return true;
     
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

}