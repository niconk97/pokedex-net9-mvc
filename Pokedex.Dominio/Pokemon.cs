namespace Pokedex.Dominio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Pokemon
{
    public int Id { get; set; }
    
    [DisplayName("Número")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "El Nombre es requerido")]
    public string Nombre { get; set; }
    
    [DisplayName("Descripción")]
    public string Descripcion { get; set; }

    [DisplayName("Imagen")]
    public string UrlImagen { get; set; }
    public Elemento Tipo { get; set; }
    public Elemento Debilidad { get; set; }
    public bool Activo { get; set; }
}
