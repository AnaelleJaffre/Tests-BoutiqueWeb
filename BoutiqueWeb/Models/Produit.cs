namespace BoutiqueWeb.Models;

public class Produit
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public int Prix { get; set; }
    public ProduitType Type { get; set; }
   
    public Produit() {}

    public Produit(ProduitDTO produitDTO) { 
        Id = produitDTO.Id;
        Nom = produitDTO.Nom;
        Prix = produitDTO.Prix;
        Type = (ProduitType) Enum.Parse(typeof(ProduitType), produitDTO.Type, true);    
    }
}