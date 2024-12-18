namespace NegosudLibrary.DTO;

public class CommandeDTO
{
    public int Id { get; set; } = 0;

    public DateTime DateCommande { get; set; }

    public string FullName { get; set; } = String.Empty;

    public int StatutCommande { get; set; } = 0;

    public int StatutPaiement { get; set; } = 0;

    public int Total { get; set; } = 0;

    public virtual ICollection<LigneCommandeDTO>? ProduitCollection { get; set; }

}
