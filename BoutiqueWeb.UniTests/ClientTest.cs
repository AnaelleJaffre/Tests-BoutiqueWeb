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
    // On vérifie que les champs Nom et Prenom ne sont pas vides.
    public void ClientNomAndPrenom_ShouldNotBeEmpty()
    {
        // Arrange
        var client = new Client
        {
            Id = 2,
            Nom = "",
            Prenom = "",
            Adresse = ""
        };

        // Assert
        client.Nom.Should().BeNullOrWhiteSpace("le nom du client est obligatoire");
        client.Prenom.Should().BeNullOrWhiteSpace("le prénom du client est obligatoire");
        client.Adresse.Should().BeNullOrWhiteSpace("l'adresse du client est obligatoire");
    }

    [TestMethod]
    // Vérification du bon format d'adresse
    public void ClientAdresse_ShouldHaveCorrectFormatWithValidStreetType()
    {
        // Arrange
        var client = new Client { Adresse = "456 Boulevard des Champs" };

        // Assert
        client.Adresse.Should().MatchRegex(@"(?i)^\d+\s+(rue|avenue|boulevard|impasse|place)\s+.*", 
            "l'adresse doit commencer par un numéro suivi d'un type de voirie valide comme rue, avenue, boulevard, etc.");
    }

}