using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TecGurusModels
{
    public class ProductModel
    {
        public int ProductId { get; set; }


        //[Display(Name = "labelForName", ResourceType = typeof(Resources.Resources))]
        [Display(Name ="Nombre de Producto")]
        [Required(ErrorMessage ="*Requerido")]
        [StringLength(10, ErrorMessage ="Maximo diez caracteres")]
        public string ProductName { get; set; }


        [Display(Name = "Cantidad por Unidad")]
        [Required(ErrorMessage = "*Requerido")]
        [StringLength(30, ErrorMessage = "Maximo treinta caracteres")]
        public string? QuantityPerUnit { get; set; }


        [Display(Name = "Precion Unitario")]
        //Una expresion regular es una cadena de texto donde queremos definir como estara compuesto un campo para restirngir su valor o delimitar
        [RegularExpression(@"^\d*(\.|,|(\.\d{1,2})|(,\d{1,2}))?$", ErrorMessage = "Solo numero con dos decimales")]
        public decimal? UnitPrice { get; set; }


        [Display(Name = "Category")]
        [Required(ErrorMessage = "*Campo Requerido")]
        public int? CategoryId { get; set; }

        [ValidateNever] //->  nunca valida esta propiedad , siempre el string es requerido aunque tenga un is null
        public string CategoryName { get; set; } = null!;


        #region tabla3

        #endregion

    }
}
