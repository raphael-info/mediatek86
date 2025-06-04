# MediaTek86

MediaTek86 est une application de bureau développée en C# selon l’architecture MVC, destinée à la gestion du personnel et des absences dans une médiathèque. 
Elle propose une interface simple et intuitive permettant de centraliser les informations relatives aux employés.

## Fonctionnalités principales

 Connexion sécurisée avec identifiants responsables
 Visualisation complète du personnel
 Ajout, modification et suppression de fiches personnel
 Enregistrement et gestion des absences par motif

## Technologies utilisées

 Langage : C#
 Framework : Windows Forms (.NET)
 Base de données : MySQL
 Modèle : Architecture MVC 

## Organisation du projet

 modele/ : contient les classes représentant les entités métier (Personnel, Absence, Motif, etc.)
 dal/ : assure la communication entre l’application et la base de données
 `bddmanager/ : gère la connexion à la base de données MySQL
 vue/ : regroupe toutes les interfaces graphiques

## Prérequis

 Visual Studio (idéalement version 2022)
 MySQL installé localement (port 3307 par défaut)
 Un utilisateur MySQL nommé `mediatek` avec le mot de passe `admin123`
 La base de données peut être générée à l’aide du script SQL fourni avec le projet

## À propos

Ce projet a été réalisé dans le cadre du BTS SIO option SLAM.

