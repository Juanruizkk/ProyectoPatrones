using System;
using System.Collections.Generic;

public class Pedido
{
    private int idRepartidor;
    private int idCliente;
    private int idRecepcionista;
    private Estado estado;
    private DateTime fecha;
    private List<PedidoProducto> productos;
    private float montoTotal;
    private bool pagado;
    private List<Pago> pagos;
    public int IdRepartidor { get => idRepartidor; set => idRepartidor = value; }
    public int IdCliente { get => idCliente; set => idCliente = value; }
    public int IdRecepcionista { get => idRecepcionista; set => idRecepcionista = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
    public List<PedidoProducto> Productos { get => productos; set => productos = value; }
    public float MontoTotal { get => montoTotal; set => montoTotal = value; }
    public bool Pagado { get => pagado; set => pagado = value; }
    public List<Pago> Pagos { get => pagos; set => pagos = value; }



    // Constructor
    public Pedido()
    {
        Productos = new List<PedidoProducto>();
        Pagos = new List<Pago>();
        Estado = Ingresado.GetInstance(); // Estado inicial
        Fecha = DateTime.Now;
        Pagado = false;
        MontoTotal = 0.0f;

    }

    // Constructor con parámetros
    public Pedido(int idRepartidor, int idCliente, int idRecepcionista)
    {
        this.IdRepartidor = idRepartidor;
        this.IdCliente = idCliente;
        this.IdRecepcionista = idRecepcionista;
        this.Productos = new List<PedidoProducto>();
        this.Pagos = new List<Pago>();
        this.Estado = Ingresado.GetInstance();
        this.Fecha = DateTime.Now;
        this.Pagado = false;
        this.MontoTotal = 0.0f;
    }

    public void ListarInfo()
    {
        Console.WriteLine($"ID de Repartidor: {IdRepartidor}");
        Console.WriteLine($"ID de Cliente: {IdCliente}");
        Console.WriteLine($"ID de Recepcionista: {IdRecepcionista}");
        Console.WriteLine($"Estado: {(this.estado.GetNombre())}");
        Console.WriteLine($"Fecha: {Fecha:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Monto Total: ${MontoTotal}");
        Console.WriteLine($"Pagado: {(Pagado ? "Sí" : "No")}");

        Console.WriteLine("Productos:");
        foreach (PedidoProducto producto in Productos)
        {
            Console.Write("  - ");
            producto.ListarInfo();
        }
    }

    // Método para cambiar estado (necesario para el patrón State)
    public void SetEstado(Estado nuevoEstado)
    {
        Estado = nuevoEstado;
    }
    public void SetRepartidor(int repartidor)
    {
        this.idRepartidor = repartidor;
        Console.WriteLine($"Repartidor {repartidor} asignado al pedido");
    } 
    public void Asignar(int repartidor)
    {
        estado.Asignar(this, repartidor);
    }

    public void CancelarPedido()
    {
        estado.Cancelar(this);
    }

    public void RechazarPedido()
    {
        estado.Rechazar(this);
    }

    public void EntregarPedido()
    {
        estado.Entregar(this);
    }

    public void AgregarPago(Pago pago)
    {
        if (!Pagado)
        {
            if (pago.Procesar(GetMontoRestante()))
            {
                Pagos.Add(pago);
                Console.WriteLine("El pago es correcto");

                if (GetMontoPagado() >= MontoTotal)
                {
                    Pagado = true;
                    Console.WriteLine("El pedido está completamente pagado");
                }
            }
            else
            {
                Console.WriteLine("No se pudo registrar el pago");
            }
        }
        else
        {
            Console.WriteLine("El pedido ya está pagado");
        }
    }

    public float GetMontoPagado()
    {
        float totalPagado = 0.0f;
        foreach (Pago p in Pagos)
        {
            totalPagado += p.GetMonto();
        }
        return totalPagado;
    }

    public float GetMontoRestante()
    {
        return MontoTotal - GetMontoPagado();
    }

    public List<Pago> GetPagos()
    {
        return new List<Pago>(Pagos);
    }


}