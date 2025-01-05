using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoutiqueWeb.Models;
using FluentAssertions;

[TestClass]
public class CommandeTests
{

    [TestMethod]
    // Changement de la quantité de produits d'une commande
    public void Commande_ShouldBeUpdatedCorrectly()
    {
        // Arrange
        var produit = new Produit
        {
            Id = 2,
            Nom = "Smartphone",
            Prix = 800,
            Type = ProduitType.Electronique
        };

        var commande = new Commande
        {
            Id = 1,
            ClientId = 3,
            ProduitId = 2,
            Quantite = 4,
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-78)),
            Produit = produit
        };

        // Act
        decimal total = commande.CalculerPrixTotal();

        // Assert
        total.Should().Be(800*4);
    }


}