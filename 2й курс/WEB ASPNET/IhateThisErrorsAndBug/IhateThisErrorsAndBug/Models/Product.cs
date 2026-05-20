using IhateThisErrorsAndBug.validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IhateThisErrorsAndBug.Models;

public partial class Product
{
    public int ProductId { get; set; }


    [Required(ErrorMessage ="Имя - обязательный атребут")]
    [BanList]
    [Zakon]
    public string ProductName { get; set; } = null!;

    [Required(ErrorMessage ="Вы не можете не выставить цену!")]
    [Range(99.90, 1_000_000_000.99,ErrorMessage ="Минимальная цена с учетом коммисии сервиса - 100 рублей")]
    [GoodPrice]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }


    [Required(ErrorMessage = "это поле обязательно!")]
    public string? Discription { get; set; }

    public byte[]? ImageData { get; set; }
    
    public string? ImageMimeType { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }



}
