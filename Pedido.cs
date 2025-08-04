using System;
using System.Collections.Generic;

// Clase Pedido (Context)
public class Pedido
{
    // Atributos según el diagrama
    private int nroRepartidor;
    private int nroCliente;
    private int nroTienda;
    private Estado estado;
    private TipoPedido tipo;
    private DateTime fecha;
    private List<PedidoProducto> productos;
    private float montoTotal;
    private bool pagado;
    private List<Pago> pagos;

    public int NroRepartidor { get => nroRepartidor; set => nroRepartidor = value; }
    public int NroCliente { get => nroCliente; set => nroCliente = value; }
    public int NroTienda { get => nroTienda; set => nroTienda = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
    public List<PedidoProducto> Productos { get => productos; set => productos = value; }
    public float MontoTotal { get => montoTotal; set => montoTotal = value; }
    public bool Pagado { get => pagado; set => pagado = value; }
    public List<Pago> Pagos { get => pagos; set => pagos = value; }
    public TipoPedido Tipo { get => tipo; set => tipo = value; }

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
    public Pedido(int nroRepartidor, int nroCliente, int nroTienda, TipoPedido tipo)
    {
        this.NroRepartidor = nroRepartidor;
        this.NroCliente = nroCliente;
        this.NroTienda = nroTienda;
        this.Tipo = tipo;
        this.Productos = new List<PedidoProducto>();
        this.Estado = Ingresado.GetInstance();
        this.Fecha = DateTime.Now;
        this.Pagado = false;
        this.MontoTotal = 0.0f;
    }

    public void ListarInfo()
    {
        Console.WriteLine($"Número de Repartidor: {NroRepartidor}");
        Console.WriteLine($"Número de Cliente: {NroCliente}");
        Console.WriteLine($"Número de Tienda: {NroTienda}");
        Console.WriteLine($"Estado: {Estado.GetNombre()}");
        Console.WriteLine($"Tipo: {Tipo}");
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

    public void AgregarPedido(string nombreProducto, string repartidor = null)
    {
        Estado.Asignar(this, nombreProducto, repartidor);
    }

    public void CancelarPedido()
    {
        Estado.Cancelar(this);
    }

    public void RechazarPedido()
    {
        Estado.Rechazar(this);
    }

    public void EntregarPedido()
    {
        Estado.Entregar(this);
    }

    // Métodos para manejar productos
    public void AgregarAPedidos(Producto nuevoProducto)
    {
        // Crear un producto simple para agregar
        PedidoProducto producto = new PedidoProducto(nuevoProducto, 1, nuevoProducto.Precio);
        Productos.Add(producto);
        CalcularMontoTotal();
    }

    public void RemoverDePedidos(Producto prod)
    {
        Productos.RemoveAll(p => p.Producto.Nombre == prod.Nombre);
        CalcularMontoTotal();
    }


    // Método para calcular monto total
    private void CalcularMontoTotal()
    {
        MontoTotal = 0.0f;
        foreach (PedidoProducto pprod in Productos)
        {
            MontoTotal += pprod.PrecioUnitario * pprod.Cantidad;
        }
    }
    
    public void AgregarPago(Pago pago)
    {
        if (!pagado)
        {
            if (pago.Procesar(GetMontoRestante()))
            {
                pagos.Add(pago);
                Console.WriteLine("El pago es correcto");

                if (GetMontoPagado() >= montoTotal)
                {
                    pagado = true;
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

    // GetMontoPagado con lista de pagos
    public float GetMontoPagado()
    {
        float totalPagado = 0.0f;
        foreach (Pago p in pagos)
        {
            totalPagado += p.GetMonto();
        }
        return totalPagado;
    }

    // GetMontoRestante sigue igual
    public float GetMontoRestante()
    {
        return montoTotal - GetMontoPagado();
    }

    // Getter para la lista de pagos
    public List<Pago> GetPagos()
    {
        return new List<Pago>(pagos);
    }


}