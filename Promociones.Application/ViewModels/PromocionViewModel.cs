using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Promociones.Application.ViewModels
{
    public class PromocionViewModel : IValidatableObject
    {
        public Guid Id { get; set; }
        public IEnumerable<string> MediosDePago { get; set; }
        public IEnumerable<string> Bancos { get; set; }
        public IEnumerable<string> CategoriasProductos { get; set; }
        public int? MaximaCantidadDeCuotas { get; set; }
        public decimal? ValorInteresCuotas { get; set; }

        [Range(5,80,ErrorMessage= "{0} en caso de tener valor, debe estar comprendido entre {1} y {2}.")]
        public decimal? PorcentajeDeDescuento { get; set; }

        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Cantidad de cuotas y porcentaje de descuento son nullables pero al
            //menos una debe tener valor
            if (!(MaximaCantidadDeCuotas.HasValue | PorcentajeDeDescuento.HasValue))
            {
                yield return new ValidationResult("Cantidad de cuotas y porcentaje de descuento son nullables pero al menos una debe tener valor.");
            }

            // La promoción puede tener porcentaje de descuento o cuotas.NO ambas
            if (MaximaCantidadDeCuotas.HasValue && PorcentajeDeDescuento.HasValue)
            {
                yield return new ValidationResult("La promoción puede tener porcentaje de descuento o cuotas. NO ambas.");
            }

            // Fecha fin no puede ser mayor que fecha inicio
            if (FechaFin < FechaInicio)
            {
                yield return new ValidationResult("Fecha fin no puede ser menor que fecha inicio.");
            }
            // Porcentaje interés cuota solo puede tener valor si cantidad de cuotas
            //tiene valor
            if (ValorInteresCuotas.HasValue & !MaximaCantidadDeCuotas.HasValue)
            {
                yield return new ValidationResult("Porcentaje interés cuota solo puede tener valor si cantidad de cuotas tiene valor.");
            }
        }
    }
}
