using NegosudLibrary.DAO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NegosudLibrary.DTO;

public class LigneCommandeDTO
{

    public int Id { get; set; } = 0;

    public double Prix { get; set; } = double.NaN;

    public double Quantite { get; set; }

    public int ArticleId { get; set; }

    public Article? Article { get; set; } = new Article();

}
