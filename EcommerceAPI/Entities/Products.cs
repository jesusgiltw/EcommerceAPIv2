namespace EcommerceAPI.Entities;

public class Products
{
    public string ProductId { get; set; } = string.Empty; // Identificador único del producto
    public string? ProductCategoryName { get; set; } // Nombre de la categoría del producto
    public double? ProductNameLength { get; set; } // Longitud del nombre del producto
    public double? ProductDescriptionLength { get; set; } // Longitud de la descripción del producto
    public double? ProductPhotosQty { get; set; } // Cantidad de fotos del producto
    public double? ProductWeightG { get; set; } // Peso del producto en gramos
    public double? ProductLengthCm { get; set; } // Longitud del producto en cm
    public double? ProductHeightCm { get; set; } // Altura del producto en cm
    public double? ProductWidthCm { get; set; } // Ancho del producto en cm
}