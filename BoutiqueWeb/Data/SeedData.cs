using BoutiqueWeb.Models;

namespace BoutiqueWeb.Data;

public static class SeedData
{
    public static void Init()
    {
        var context = new BoutiqueWebContext();

        // Vérification : si la DB contient déjà des données, on quitte.
        if (context.Clients.Any() || context.Produits.Any() || context.Commandes.Any())
        {
            return; // La base est déjà remplie
        }

        // Clients
        var clients = new[]
        {
            new Client
            {
                Nom = "Dupont",
                Prenom = "Jean",
                Adresse = "123 Rue Principale, Paris",
            },
            new Client
            {
                Nom = "Martin",
                Prenom = "Marie",
                Adresse = "45 Boulevard Haussmann, Lyon",
            },
            new Client
            {
                Nom = "Durand",
                Prenom = "Luc",
                Adresse = "78 Avenue des Champs, Marseille",
            },
            new Client
            {
                Nom = "Chaplin",
                Prenom = "Emma",
                Adresse = "2 Rue des Mirabelles, Gap",
            },
        };

        context.Clients.AddRange(clients);

        // Produits
        var produits = new[]
        {
            new Produit
            {
                Nom = "Ordinateur Portable",
                Prix = 1200,
                Type = ProduitType.Electronique,
            },
            new Produit
            {
                Nom = "Smartphone",
                Prix = 800,
                Type = ProduitType.Electronique,
            },
            new Produit
            {
                Nom = "Bureau en bois",
                Prix = 300,
                Type = ProduitType.Mobilier,
            },
            new Produit
            {
                Nom = "Chaise ergonomique",
                Prix = 150,
                Type = ProduitType.Mobilier,
            },
            new Produit
            {
                Nom = "Imprimante Laser",
                Prix = 200,
                Type = ProduitType.Bureautique,
            },
            new Produit
            {
                Nom = "Scanner",
                Prix = 180,
                Type = ProduitType.Bureautique,
            },
            new Produit
            {
                Nom = "Laser MegaJoule de poche",
                Prix = 21000,
                Type = ProduitType.Electronique,
            },
        };

        context.Produits.AddRange(produits);

        // Commandes
        var commandes = new[]
        {
            new Commande
            {
                Client = clients[0], // Jean Dupont
                Produit = produits[0], // Ordinateur Portable
                Quantite = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-15)),
            },
            new Commande
            {
                Client = clients[1], // Marie Martin
                Produit = produits[3], // Chaise ergonomique
                Quantite = 2,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-17)),
            },
            new Commande
            {
                Client = clients[2], // Luc Durand
                Produit = produits[5], // Scanner
                Quantite = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)),
            },
            new Commande
            {
                Client = clients[2], // Luc Durand
                Produit = produits[6], // Laser MegaJoule
                Quantite = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-14)),
            },
        };

        context.Commandes.AddRange(commandes);

        // Sauvegarde dans la base
        context.SaveChanges();
    }
}
