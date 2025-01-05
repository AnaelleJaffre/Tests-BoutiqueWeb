using BoutiqueWeb.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ProduitTests
{
    [TestMethod]
    // Mise à jour d'un produit
    public void Produit_DevraitSeMettreAJourCorrectement()
    {
        // Arrange
        var produit = new Produit
        {
            Id = 1,
            Nom = "Laser",
            Prix = 125,
            Type = ProduitType.Mobilier,
        };

        // Act
        produit.Nom = "Laser Pro";
        produit.Prix = 150;

        // Assert
        produit.Nom.Should().Be("Laser Pro");
        produit.Prix.Should().Be(150);
    }

    [TestMethod]
    public void Produit_CalculerNombreDeClientsQuiOntAcheteCeProduit()
    {
        // Arrange
        var produit = new Produit
        {
            Id = 1,
            Nom = "Lampe Ionisee",
            Prix = 12,
            Type = ProduitType.Bureautique,
        };

        var commandes = new List<Commande>
        {
            new Commande
            {
                ProduitId = 1,
                ClientId = 1,
                Quantite = 2,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-87)),
            },
            new Commande
            {
                ProduitId = 1,
                ClientId = 2,
                Quantite = 3,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-17)),
            },
            new Commande
            {
                ProduitId = 2,
                ClientId = 3,
                Quantite = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-457)),
            },
        };

        // Act
        int nombreClients = produit.CalculerNombreClients(commandes);

        // Assert
        nombreClients.Should().Be(2); // 2 clients ont acheté le produit n°1
    }
}
