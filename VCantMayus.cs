using System;
using System.Linq;

// Verificador de cantidad específica de mayúsculas en la contraseña
public class VCantMayus : VEspecifico
{
    private int mayusculas;

    public VCantMayus(int mayusculas, Verificador? vClass = null) : base(vClass)
    {
        this.mayusculas = mayusculas;
    }

    protected override bool VerificarEsp(string pass)
    {
        int count = pass.Count(char.IsUpper);
        return count == mayusculas;
    }
}
