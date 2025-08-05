using System;
using System.Linq;

// Verificador de cantidad específica de números en la contraseña
public class VCantNum : VEspecifico
{
    private int numeros;

    public VCantNum(int numeros, Verificador? vClass = null) : base(vClass)
    {
        this.numeros = numeros;
    }

    protected override bool VerificarEsp(string pass)
    {
        int count = pass.Count(char.IsDigit);
        return count == numeros;
    }
}
