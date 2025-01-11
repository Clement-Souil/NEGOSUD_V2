using NegosudLibrary.DAO;

namespace NegosudLibrary.DTO;

public class CommandeDTO
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public int StatutCommandeId { get; set; }

    public int FournisseurId { get; set; }

    public string FournisseurNom { get; set; } = string.Empty;

    public int PrixTotal { get; set; } = 0;

    public virtual IEnumerable<LigneCommande>? LignesCommande { get; set; }

    //public virtual ICollection<LigneCommandeDTO>? ProduitCollection { get; set; }

}
