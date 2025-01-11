using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NegosudLibrary.DTO;

public class FournisseurDTO
{
    public int Id { get; set; } = 0;
    public string NomDomaine { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;

}
