using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegosudLibrary.DAO;

public class LigneCommande
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("prix")]
    public double Prix { get; set; }

    [Column("quantite")]
    public double Quantite { get; set; }

    [ForeignKey(nameof(Article))]
    [Column("articleid")]
    public int ArticleId { get; set; }

    public virtual Article? Article { get; set; } = null!;






}
