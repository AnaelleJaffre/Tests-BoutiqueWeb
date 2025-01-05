[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/lXJn8EVV)

Présentation
==

Ce repository contient le code d'une API se basant sur le diagramme de classe suivant : 

![Diagramme UML de l'API](https://github.com/user-attachments/assets/ce79e52a-ffb3-4beb-87ff-9e9f31d77ebb)

> Source : [Lien vers PlantUML](https://www.plantuml.com/plantuml/umla/hP2nIi0m48RtFCKHjqAhhjMXKfSkKj4NYEP80ybLBXUqYEzkZLXRSHB7_y_7VU7laXYM78FgvnWDMGHD6YxhkW9zhc7asMOlkzUpfgbsG1yyaYY5bECNVRyy8PmyJrxmOa9ZaTlWtIIESL7gCPYKO3juv4euBVH3o0Yl2W062oqC9EYGF_9jDYGhTsolJMdkX3qvzRQ9oWV_ehcPu_UzDO-CzAEwiemf_QRzdEAVlFxbI9I1s_tSgxX3iZc6Tm00)

Il est composé de trois classes principales permettant des interactions entre des clients et des produits. Chaque client peut effectuer un nombre indéfini de commandes, et chaque commande contient une quantité indéfinie d'un seul produit.

Il existe aussi une classe "type" qui a été créée pour définir un nouvel objet, plus précisément le type d'un produit.

Procédure d'installation
==
1. Clonez ce projet dans votre éditeur de code (par exemple, VSCode).
2. Ouvrez-y un terminal. Exécutez les commandes suivantes :
```
cd BoutiqueWeb
dotnet build
dotnet ef database update
dotnet run
```
3. L'API est alors fonctionnelle et disponible à l'adresse suivante : [Swagger](http://localhost:7044/swagger/index.html).
4. Des tests sont disponibles dans le dossier "BoutiqueWeb.UniTests". Si vous souhaitez les exécuter, vous pouvez taper les lignes de commande suivantes :
```
cd..
cd BoutiqueWeb.UnitTests
dotnet test
```

Annexes 
==

**Code PlantUML du diagramme de classe**
```
@startuml

Commande "n" <--* "1" Produit
Commande "0..*" <--* "1" Client

enum ProduitType #white;header:lightgrey

class Commande #white;header:white/lightblue {
   Id : Integer
   Quantite : Integer
   Date : DateOnly
}

class Client #white;header:white/lightblue {
   Id : Integer
   Nom : String
   Prenom : String
   Adresse : String
}

class Produit #white;header:white/lightblue {
   Id : Integer
   Nom : String
   Prix : Integer
   Type : ProduitType
}

@enduml
```
