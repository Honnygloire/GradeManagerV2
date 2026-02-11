# GradeManager  Version 2 

Cette version du projet **GradeManager** est une application console en C# permettant de gérer les notes d’une classe d’étudiants.  
Elle améliore largement la V1 en ajoutant une **sauvegarde persistante** et des **outils de gestion avancés**.

---

## 🚀 Fonctionnalités principales

### 🗂 Gestion des étudiants
- Ajouter un étudiant (**avec anti‑doublon**)
- Rechercher un étudiant par nom
- Modifier les notes d’un étudiant
- Supprimer un étudiant
- Afficher tous les bulletins
- Trier les étudiants :
  - par nom (A → Z)
  - par moyenne (du meilleur au moins bon)

### 📊 Calculs automatiques
Pour chaque étudiant :
- Somme des notes  
- Moyenne  
- Meilleure note  
- Pire note  
- Bulletin formaté

### 💾 Persistance des données
- Sauvegarde automatique dans un fichier `students.json`
- Chargement automatique au démarrage
- Export des bulletins dans un fichier `bulletins.txt`

---

## 📁 Structure du projet

```bash
GradeManagerV2/
│
├── Program.cs            # Menu principal et logique utilisateur
├── Student.cs            # Modèle étudiant + calculs
├── StudentManager.cs     # Gestion des étudiants (CRUD + tri)
├── FileService.cs        # Sauvegarde / chargement JSON
├── students.json         # Fichier généré automatiquement
└── README.md
```

---

## 📘 Exemple de bulletin

```bash
Bulletin de Sophia
------------------
Notes : 2, 3, 20, 11, 2, 13
Somme : 51
Moyenne : 8,5
Meilleure note : 20
Pire note : 2
```

---

## 🧠 Fonctionnalités avancées détaillées

### ✔ Anti‑doublon
Impossible d’ajouter deux étudiants avec le même nom.

### ✔ Recherche
Affiche uniquement le bulletin de l’étudiant demandé.

### ✔ Modification des notes
Permet de remplacer toutes les notes d’un étudiant.

### ✔ Suppression
Supprime un étudiant de la liste et du fichier JSON.

### ✔ Tri
- **Par nom** : ordre alphabétique  
- **Par moyenne** : du meilleur au moins bon  

---

## ▶️ Exécution

Dans le dossier du projet :

```bash
dotnet run
```

---

## 💾 Sauvegarde automatique

Les données sont enregistrées dans :

```bash
students.json
```

Ce fichier est généré automatiquement et ne doit pas être modifié manuellement.

---

## 📤 Export des bulletins

L’option du menu permet de générer :

```bash
bulletins.txt
```

contenant tous les bulletins formatés.

---

## 🎯 Objectifs pédagogiques

Cette V2 permet de pratiquer :

- la structuration d’un projet C#  
- la sérialisation JSON  
- les listes et collections  
- les méthodes CRUD  
- la séparation des responsabilités (architecture simple)  
- la manipulation de fichiers  
- la conception d’un menu console avancé  

---

## 👩‍💻 Auteur

Projet réalisé par **Honnygloire MBOMBOTO TO HOUNDA**  
Master ASI – ETNA  
