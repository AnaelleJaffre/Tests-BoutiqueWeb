using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoutiqueWeb.Models;
using FluentAssertions;

[TestClass]
public class ClientTests
{
    
    [TestMethod]
    // On vérifie que les informations du client ont été remplies correctement.
    public void Client_ShouldBeCorrectlyInitialized()
    {
        // Arrange
        var client = new Client
        {
            Id = 1,
            Nom = "De la Vérité",
            Prenom = "Ange",
            Adresse = "11 rue de la Vérité la Vraie"
        };

        // Assert
        client.Id.Should().Be(1);
        client.Nom.Should().Be("De la Vérité");
        client.Prenom.Should().Be("Ange");
        client.Adresse.Should().Be("11 rue de la Vérité la Vraie");
    }

    [TestMethod]
    // Test de mise à jour des données du client
    public void CLient_ShouldBeCorrectlyUpdated()
    {
        // Arrange
        var client = new Client
        {
            Id = 5,
            Nom = "Fraichit",
            Prenom = "Sarah",
            Adresse = "3 Avenue des Grands Glaciers"
        };

        // Act
        client.Adresse = "Quelque part au Pôle Sud";

        // Assert
        client.Adresse.Should().Be("Quelque part au Pôle Sud");
    }

    [TestMethod]
    // On tente de calculer combien un client a dépensé, en tout, sur la Boutique Web.
    public void Client_TotalSpentOnTheAppShouldCorrespond()
    {
        // Arrange
        var client = new Client
        {
            Id = 1,
            Nom = "Disoir",
            Prenom = "Alain"
        };

        var produit1 = new Produit { Id = 1, Nom = "Lampe Ionisee", Prix = 12 };
        var produit2 = new Produit { Id = 2, Nom = "Acer Nitro V 120Go 16GH", Prix = 1299 };

        var commande1 = new Commande
        {
            ClientId = client.Id,
            ProduitId = produit1.Id,
            Quantite = 3, // Ici on en prend 3
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-17)),
            Produit = produit1
        };

        var commande2 = new Commande
        {
            ClientId = client.Id,
            ProduitId = produit2.Id,
            Quantite = 1, // Et là 1 seul (les PC ça coûte cher)
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)),
            Produit = produit2
        };

        client.ListeCommandes.Add(commande1);
        client.ListeCommandes.Add(commande2);

        // Act
        decimal total = client.CalculerTotalDepense();

        // Assert
        total.Should().Be(3*12 + 1*1299);
    }

}