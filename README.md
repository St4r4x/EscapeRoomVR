Projet Unity 2D — Escape Room VR

## Objectif

Utiliser un template Unity pour créer un projet VR.
Se familiariser avec le simulateur VR et l'asset store d'Unity.
Construire des mécaniques pour ouvrir des portes, faire tirer le personnage et
déclencher des choses si les cibles sont touchées. Créer un ennemi.

## Liste des TP pour les bases du jeu

1. Créer le projet et mettre sur Github
2. Tester le simulateur et commencer à faire du level design avec l'Asset Store
3. Animer une porte
4. Faire tirer des balles au personnage
5. Coder une cible qui réagit aux tirs
6. Faire un ennemi simple

## Fonctionnalités intégrées

- **Cible (Assets/Scripts/Cible.cs):** Le script détruit désormais uniquement l'objet colliseur et affiche "Cible touchée" dans la console si le colliseur a le tag `Projectile` (utilise `Debug.Log`).
- **Comportement:** Empêche la destruction d'autres objets non liés aux projectiles.
- **Porte (Assets/Scenes/ & Assets/):** La porte est animée et réagit aux interactions (ouverture via animation déclenchée).
- **Projectiles (Assets/Projectile.prefab & Assets/Scripts):** Le tir du personnage instancie des projectiles (préfab) qui collident avec les cibles et sont détruits quand ils touchent une `Cible`.
- **Tremblement de la cible :** Intégré — paramètres exposés dans `Assets/Scripts/Cible.cs`.
  - `shakeFrequency` = 20f (fréquence)
