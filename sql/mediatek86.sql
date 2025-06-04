DROP DATABASE IF EXISTS mediatek86;
CREATE DATABASE mediatek86;
USE mediatek86;

DROP TABLE IF EXISTS absence;
DROP TABLE IF EXISTS personnel;
DROP TABLE IF EXISTS responsable;
DROP TABLE IF EXISTS motif;
DROP TABLE IF EXISTS service;

CREATE TABLE responsable (
    login VARCHAR(64) NOT NULL PRIMARY KEY,
    pwd VARCHAR(64) NOT NULL
);

INSERT INTO responsable VALUES ('admin', SHA2('admin123', 256));

CREATE TABLE service (
    idservice INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(100) NOT NULL
);

INSERT INTO service(nom) VALUES ('administratif'), ('ressources humaines'), ('prêt');

CREATE TABLE motif (
    idmotif INT AUTO_INCREMENT PRIMARY KEY,
    libelle VARCHAR(100) NOT NULL
);

INSERT INTO motif(libelle) VALUES ('vacances'), ('maladie'), ('motif familial'), ('congé parental');

CREATE TABLE personnel (
    idpersonnel INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(100) NOT NULL,
    prenom VARCHAR(100) NOT NULL,
    tel VARCHAR(20),
    mail VARCHAR(100),
    idservice INT NOT NULL,
    FOREIGN KEY (idservice) REFERENCES service(idservice)
);

CREATE TABLE absence (
    idpersonnel INT NOT NULL,
    datedebut DATE NOT NULL,
    datefin DATE NOT NULL,
    idmotif INT NOT NULL,
    PRIMARY KEY (idpersonnel, datedebut),
    FOREIGN KEY (idpersonnel) REFERENCES personnel(idpersonnel),
    FOREIGN KEY (idmotif) REFERENCES motif(idmotif)
);
