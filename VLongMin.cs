using System;

// Verificador de longitud mínima de contraseña
public class VLongMin : VEspecifico
{
    private int min;

    public VLongMin(int min, Verificador? vClass = null) : base(vClass)
    {
        this.min = min;
    }

    protected override bool VerificarEsp(string pass)
    {
        return pass.Length >= min;
    }
}
