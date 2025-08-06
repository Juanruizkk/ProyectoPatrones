using System;
using System.Linq;

// Verificador de cantidad específica de números en la contraseña
public class VNum : VEspecifico
{
    private bool numeros;

    public VNum(bool numeros, Verificador? vClass = null) : base(vClass)
    {
        this.numeros = numeros;
    }

    protected override bool VerificarEsp(string pass)
    {
        int count = pass.Count(char.IsDigit);
        return numeros ? count > 0 : count == 0;
    }
}
