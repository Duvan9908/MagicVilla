﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.Dto
{
    public class NumeroVillaCreateDto
    {
        [Required]
        public int VillaNo { get; set; }

        public int VillaId { get; set; }

        public string DetalleEspecial { get; set; }
    }
}
