# 📚 EduEvent - Gestion d'Événements  

Bienvenue dans **EduEvent** ! Une appli .NET pour gérer des événements avec deux types de rôles : **Prof** et **Élève**.  
- Les **Profs** : peuvent créer, modifier et supprimer des événements.  
- Les **Élèves** : peuvent s'inscrire aux événements existants.  
 

---

## 🛠️ Installation de l'application  

Avant de lancer l'appli, on doit préparer l'environnement. Voici les étapes :  

### 1️⃣ **Installer WAMP**  
 

1. **Télécharge WAMP** : [Lien officiel WAMPServer](https://www.wampserver.com/).  
2. **Installe-le** : Suis les étapes de l’installation classique.  
3. **Démarre WAMP** : Clique sur l’icône WAMP et assure-toi que l'icone dans la bare des taches est **vertes** .  

---

### 2️⃣ **Installer l'environnement .NET**  

On utilise **.NET 8** :  

1. **Télécharge .NET SDK** : [Télécharger ici](https://dotnet.microsoft.com/download).  
2. Vérifie que ça marche :  
   ```bash
   dotnet --version
   ````
🚀 Lancer le projet
Maintenant, on va lancer l'appli :

Étape 1 : Cloner le projet
Télécharge le projet ou clone-le avec Git, le projet se trouve dans /project/EduEvent(TP)

Étape 2 : Installer les outils EF Core
Pour gérer les migrations et la BDD, on installe l'outil Entity Framework Core :

````bash
dotnet tool install --global dotnet-ef
````

Étape 3 : Configurer et synchroniser la base de données
Crée la base de données et applique les migrations :

````bash
dotnet ef database update
````
Vérifie dans ton serveur MySQL (via PHp MyAdmin) que la base s’est bien créée. Elle devrait s’appeler EduEvent.

Étape 4 : Lancer le serveur
Pour lancer l’appli sur ton localhost :

````bash
dotnet run
````
Puis ouvre ton navigateur et va sur http://localhost:5129 (ou le port qui s'affiche dans le terminal).

🧰 Fonctionnalités de l'application
Connexion & Inscription :

Les profs peuvent s'inscrire via le rôle "Prof".
Les élèves peuvent s'inscrire via le rôle "Élève".
Gestion des événements :

Créer, modifier et supprimer des événements (uniquement pour les profs).
Voir la liste des événements pour la semaine.
Rechercher des événements par titre ou par date.
Inscription aux événements :

Les élèves peuvent s’inscrire aux événements existants.
