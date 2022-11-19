using BDLUCY_CodeFirst_Crud.Models;
using BodegaLucy.Models;
using Microsoft.EntityFrameworkCore;

namespace BodegaLucyCF.Models
{
    public class BdLucyContext:DbContext
    {
        //Creamos un constructor para inicializar nuestro contexto

        public BdLucyContext(DbContextOptions<BdLucyContext>
            options) : base(options) { }

        //Establecer las entidades que van a ser migrdas
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Distribuidor> Distribuidores { get; set; }

        public DbSet<Compra> Compras { get; set; }

        public DbSet<Detalle_Compra> Detalle_Compras { get; set; }

        public DbSet<Paquete> Paquetes { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Detalle_Venta> Detalle_Ventas { get; set; }



    }
}
