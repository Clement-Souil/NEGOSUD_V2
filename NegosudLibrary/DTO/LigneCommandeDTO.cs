namespace NegosudLibrary.DTO;

public class LigneCommandeDTO
{
    public ProduitDTO Produit { get; set; } = new ProduitDTO();

    public int Quantite { get; set; } = 0;
}
