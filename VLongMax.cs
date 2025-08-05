using System;

// Verificador de longitud máxima de contraseña
public class VLongMax : VEspecifico
{
    private int max;

    public VLongMax(int max, Verificador? vClass = null) : base(vClass)
    {
        this.max = max;
    }

    protected override bool VerificarEsp(string pass)
    {
        return pass.Length <= max;
    }
}
