using System;

// Clase abstracta para verificadores específicos con chain of responsibility
public abstract class VEspecifico : Verificador
{
    protected Verificador? vClass;

    protected VEspecifico(Verificador? vClass = null)
    {
        this.vClass = vClass;
    }

    public override bool Verificar(string pass)
    {
        bool estado = VerificarEsp(pass);
        if (!estado && vClass != null)
        {
            estado = vClass.Verificar(pass);
        }
        return estado;
    }

    protected abstract bool VerificarEsp(string pass);
}
