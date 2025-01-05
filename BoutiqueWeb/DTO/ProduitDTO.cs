namespace BoutiqueWeb.Models;

public class ProduitDTO
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public int Prix { get; set; }
    public string Type { get; set; } = null!;

    public ProduitDTO() { }

    public ProduitDTO(Produit produit)
    {
        Id = produit.Id;
        Nom = produit.Nom;
        Prix = produit.Prix;
        Type = produit.Type.ToString();
    }
}
