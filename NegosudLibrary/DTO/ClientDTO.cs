namespace NegosudLibrary.DTO;

public class ClientDTO
{
    public string Nom {  get; set; } = string.Empty;

    public string Prenom { get; set; } = string.Empty;

    public string email { get; set; } = string.Empty;

    public string Telephone { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public int CodePostal = 0;

    public string Ville = string.Empty;
}
