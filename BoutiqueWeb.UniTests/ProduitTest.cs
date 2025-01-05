using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoutiqueWeb.Models;
using FluentAssertions;

[TestClass]
public class ProduitTests
{

    [TestMethod]
    // Mise à jour d'un produit
    public void Produit_ShouldBeUpdatedCorrectly()
    {
        // Arrange
        var produit = new Produit
        {
            Id = 1,
            Nom = "Laser",
            Prix = 125,
            Type = ProduitType.Mobilier
        };

        // Act
        produit.Nom = "Laser Pro";
        produit.Prix = 150;

        // Assert
        produit.Nom.Should().Be("Laser Pro");
        produit.Prix.Should().Be(150);
    }


}