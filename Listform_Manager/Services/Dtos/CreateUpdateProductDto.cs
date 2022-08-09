﻿using System.ComponentModel.DataAnnotations;

namespace Listform_Manager.Services.Dtos
{
    public class CreateUpdateProductDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }
}
