using System;
using System.Linq;

// Verificador de mayúsculas en la contraseña
public class VMayus : VEspecifico
{
    private bool mayusculas;

    public VMayus(bool mayusculas, Verificador? vClass = null) : base(vClass)
    {
        this.mayusculas = mayusculas;
    }

    protected override bool VerificarEsp(string pass)
    {
        int count = pass.Count(char.IsUpper);
        return mayusculas ? count > 0 : count == 0;
    }
}
