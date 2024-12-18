namespace NegosudLibrary.DTO;

public class ProduitDTO
{
    public string Nom {  get; set; } = string.Empty;

    public string Type {  get; set; } = string.Empty;

    public int Année {  get; set; } = 0;

    public int Volume { get; set; } = 0;

    public int Stock {  get; set; } = 0;

    public int Prix { get; set; } = 0;

    public string Region {  get; set; } = string.Empty;

    public double DegreAlcool {  get; set; } = 0;

    public string Description {  get; set; } = string.Empty;
}
