﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodegaLucyCF.Models
{
    public class Distribuidor
    {

        [Key] //Atributo Clave
        public int Codigo_Distribuidor { get; set; }
        //----------------------------------------------
        [Column(TypeName = "nvarchar(50)")]
        public string Razon_Social_Distribuidor { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(11)")]
        public char RUC_Distribuidor { get; set; }
        //----------------------------------------------
        [Column(TypeName ="nvarchar(150)")]
        public string Direccion_Distribuidor { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(9)")]
        public string Telefono_Distribuidor { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(70)")]
        public string Nombre_Contacto { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(70)")]
        public string Telefono_Contacto { get; set; } = "";
        //----------------------------------------------
        public bool Estado_Distribuidor { get; set; }
        //----------------------------------------------

    }
}
