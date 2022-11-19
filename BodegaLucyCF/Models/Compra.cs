﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BodegaLucyCF.Models
{
    public partial class Compra
    {



        [Key] //Atributo Clave
        public int Codigo_Compra { get; set; }
        //----------------------------------------------
        public DateTime Fecha_Compra { get; set; } = DateTime.Now;
        //----------------------------------------------
        [Column(TypeName = "nvarchar(10)")]
        public string Tipo_Comprobante { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(4)")]
        public string Serie_Comprobante_Compra { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(8)")]
        public string Numero_Comprobante_Compra { get; set; } = "";
        //----------------------------------------------
        public int Codigo_Usuario { get; set; }         //ATRIBUTO RELACIONADO
        //----------------------------------------------
        public int Codigo_Distribuidor { get; set; }    //ATRIBUTO RELACIONADO
        //----------------------------------------------
        public float IGV_Compra { get; set; }
        //----------------------------------------------
        public float Subtotal_Compra { get; set; }
        //----------------------------------------------
        public float Total_Compra { get; set; }
        //----------------------------------------------

        //ESTÁBLECEMOS LAS RELACIONES ENTRE CLASES
        //----------------------------------------------
        [ForeignKey("Codigo_Usuario")]                  //ForeingKey
        public Usuario? usuario { get; set; }
        //----------------------------------------------
        [ForeignKey("Codigo_Distribuidor")]             //ForeingKey
        public Distribuidor? distribuidor { get; set; }

        //---------------------------- NUEVO -------------------------------------
        //---------------------------- NUEVO -------------------------------------
        //---------------------------- NUEVO -------------------------------------
        //public List<Detalle_Compra> Detalle_Compras { get; set; }
        //----------------------------------------------



    }
}
