﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BodegaLucyCF.Models
{
    public class Detalle_Compra
    {

        [Key] //Atributo Clave
        public int Codigo_Detalle_Compra { get; set; }
        //----------------------------------------------
        public int Codigo_Compra { get; set; }          //ATRIBUTO RELACIONADO
        //----------------------------------------------
        public int Codigo_Paquete { get; set; }         //ATRIBUTO RELACIONADO
        //----------------------------------------------
        public int Cantidad { get; set; }
        //----------------------------------------------
        public float Precio_Unitario { get; set; }
        //----------------------------------------------
        public float Importe_Detalle_Compra { get; set; }
        //----------------------------------------------

        //ESTÁBLECEMOS LAS RELACIONES ENTRE CLASES
        //----------------------------------------------
        [ForeignKey("Codigo_Compra")]                  //ForeingKey
        public Compra? compra { get; set; }
        //----------------------------------------------
        [ForeignKey("Codigo_Paquete")]             //ForeingKey
        public Paquete? paquete { get; set; }
        //----------------------------------------------
    }
}
