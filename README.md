Présentation
==

Ce repository contient le code d'une API se basant sur le diagramme de classe suivant : 

![Diagramme UML de l'API](https://github.com/user-attachments/assets/13c77bf5-f28e-45f2-b82e-299d632870c1)

> Source : [Lien vers PlantUML](https://www.plantuml.com/plantuml/umla/hP2nIi0m48RtFCKHjqAhhjMXKfSkKj4NYEP80ybLBXUqYEzkZLXRSHB7_y_7VU7laXYM78FgvnWDMGHD6YxhkW9zhc7asMOlkzUpfgbsG1yyaYY5bECNVRyy8PmyJrxmOa9ZaTlWtIIESL7gCPYKO3juv4euBVH3o0Yl2W062oqC9EYGF_9jDYGhTsolJMdkX3qvzRQ9oWV_ehcPu_UzDO-CzAEwiemf_QRzdEAVlFxbI9I1s_tSgxX3iZc6Tm00)

Il est composé de trois classes principales permettant des interactions entre des clients et des produits. Chaque client peut effectuer un nombre indéfini de commandes, et chaque commande contient une quantité indéfinie d'un seul produit.

Il existe aussi une classe "type" qui a été créée pour définir un nouvel objet, plus précisément le type d'un produit.



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
   Date : String
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
