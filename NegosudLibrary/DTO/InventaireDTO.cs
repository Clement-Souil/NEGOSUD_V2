using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegosudLibrary.DTO;

internal class InventaireDTO
{
    public virtual ICollection<ProduitDTO>? Produits { get; set; }

    public int QuantiteReel { get; set; } = 0; 

}
