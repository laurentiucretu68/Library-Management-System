--- DROP

--- STERGERE TABEL RECENZIE
ALTER TABLE RECENZIE
    DROP CONSTRAINT RECENZIE_id_carte_FK
    DROP CONSTRAINT RECENZIE_id_recenzor_FK;
DROP TABLE RECENZIE;

--- STERGERE TABEL IMPRUMUTA
ALTER TABLE IMPRUMUTA
    DROP CONSTRAINT IMPRUMUTA_id_carte_FK
    DROP CONSTRAINT IMPRUMUTA_id_cititor_FK;
DROP TABLE IMPRUMUTA;

--- STERGERE TABEL SCRIE
ALTER TABLE SCRIE
    DROP CONSTRAINT SCRIE_id_autor_FK
    DROP CONSTRAINT SCRIE_id_carte_FK;
DROP TABLE SCRIE;

--- STERGERE TABEL CARTI
ALTER TABLE CARTI
    DROP CONSTRAINT CARTI_id_categorie_FK
    DROP CONSTRAINT CARTI_id_editura_FK
    DROP CONSTRAINT CARTI_id_furnizor_FK;
DROP TABLE CARTI;

--- STERGERE TABEL CITITORI
DROP TABLE CITITORI;

--- STERGERE TABEL RECENZORI
DROP TABLE RECENZORI;

--- STERGERE TABEL FURNIZORI
DROP TABLE FURNIZORI;

--- STERGERE TABEL CATEGORII
DROP TABLE CATEGORII;

--- STERGERE TABEL EDITURI
DROP TABLE EDITURI;

--- STERGERE TABEL AUTORI
DROP TABLE AUTORI;


--- CREAREA TABELELOR

--- CREAREA TABELULUI AUTORI
CREATE TABLE AUTORI(
    id_autor NUMBER(5,0)
        CONSTRAINT AUTORI_id_autor_PK PRIMARY KEY,
    nume_autor VARCHAR2(30 CHAR)
        CONSTRAINT AUTORI_nume_NN NOT NULL,
    prenume_autor VARCHAR2(30 CHAR)
        CONSTRAINT AUTORI_prenume_NN NOT NULL,
    data_nasterii DATE
);


--- CREAREA TABELULUI EDITURI
CREATE TABLE EDITURI(
    id_editura NUMBER(5,0)
        CONSTRAINT EDITURI_id_editura_PK PRIMARY KEY,
    nume_editura VARCHAR2(30 CHAR)
        CONSTRAINT EDITURI_nume_NN NOT NULL,
    email_editura VARCHAR2(30 CHAR)
        CONSTRAINT EDITURI_email_NN NOT NULL
        CONSTRAINT EDITURI_email_U UNIQUE
);


--- CREAREA TABELULUI CATEGORII
CREATE TABLE CATEGORII(
    id_categorie NUMBER(5,0)
        CONSTRAINT CATEGORII_id_categorie_PK PRIMARY KEY,
    nume_categorie VARCHAR2(30 CHAR)
        CONSTRAINT CATEGORII_nume_NN NOT NULL,
    varsta_minima_recomandata NUMBER(2,0)
        CONSTRAINT CATEGORII_varsta_C CHECK (varsta_minima_recomandata >= 1)
);


--- CREAREA TABELULUI FURNIZORI
CREATE TABLE FURNIZORI(
    id_furnizor NUMBER(5,0)
        CONSTRAINT FURNIZORI_id_furnizor_PK PRIMARY KEY,
    nume_furnizor VARCHAR2(30 CHAR)
        CONSTRAINT FURNIZORI_nume_NN NOT NULL,
    telefon_furnizor VARCHAR2(10 CHAR)
        CONSTRAINT FURNIZORI_telefon_NN NOT NULL
        CONSTRAINT FURNIZORI_telefon_U UNIQUE,
    email_furnizor VARCHAR2(30 CHAR)
        CONSTRAINT FURNIZORI_email_NN NOT NULL
        CONSTRAINT FURNIZORI_email_U UNIQUE
);


--- CREAREA TABELULUI RECENZORI
CREATE TABLE RECENZORI(
    id_recenzor NUMBER(5,0)
        CONSTRAINT RECENZORI_id_recenzor_PK PRIMARY KEY,
    nume_recenzor VARCHAR2(30 CHAR)
        CONSTRAINT RECENZORI_nume_NN NOT NULL,
    prenume_recenzor VARCHAR2(30 CHAR)
        CONSTRAINT RECENZORI_prenume_NN NOT NULL,
    email_recenzor VARCHAR2(30 CHAR)
        CONSTRAINT RECENZORI_email_U UNIQUE
);


--- CREAREA TABELULUI CITITORI
CREATE TABLE CITITORI(
    id_cititor NUMBER(5,0)
        CONSTRAINT CITITORI_id_cititor_PK PRIMARY KEY,
    nume_cititor VARCHAR2(30 CHAR)
        CONSTRAINT CITITORI_nume_NN NOT NULL,
    prenume_cititor VARCHAR2(30 CHAR)
        CONSTRAINT CITITORI_prenume_NN NOT NULL,
    telefon_cititor VARCHAR2(10 CHAR)
        CONSTRAINT CITITORI_telefon_NN NOT NULL
        CONSTRAINT CITITORI_telefon_U UNIQUE,
    email_cititor VARCHAR2(30 CHAR)
        CONSTRAINT CITITORI_email_U UNIQUE,
    data_nasterii DATE
        CONSTRAINT CITITORI_data_nasterii_NN NOT NULL,
    data_inscrierii DATE
        CONSTRAINT CITITORI_data_inscrierii_NN NOT NULL
);


--- CREAREA TABELULUI CARTI
CREATE TABLE CARTI(
    id_carte NUMBER(7,0)
        CONSTRAINT CARTI_id_carte_PK PRIMARY KEY,
    titlu VARCHAR2(50 CHAR)
        CONSTRAINT CARTI_titlu_NN NOT NULL,
    numar_pagini NUMBER(4,0),
    data_publicare DATE,
    id_editura NUMBER(5,0)
        CONSTRAINT CARTI_id_editura_FK REFERENCES EDITURI(id_editura)
        ON DELETE CASCADE
        CONSTRAINT CARTI_id_editura_NN NOT NULL,
    id_categorie NUMBER(5,0)
        CONSTRAINT CARTI_id_categorie_FK REFERENCES CATEGORII(id_categorie)
        ON DELETE CASCADE
        CONSTRAINT CARTI_id_categorie_NN NOT NULL,
    id_furnizor NUMBER(5,0)
        CONSTRAINT CARTI_id_furnizor_FK REFERENCES FURNIZORI(id_furnizor)
        ON DELETE SET NULL
);


--- CREAREA TABELULUI SCRIE
CREATE TABLE SCRIE(
    id_autor NUMBER(5,0)
        CONSTRAINT SCRIE_id_autor_FK REFERENCES AUTORI(id_autor)
        ON DELETE CASCADE,
    id_carte NUMBER(7,0)
        CONSTRAINT SCRIE_id_carte_FK REFERENCES CARTI(id_carte)
        ON DELETE CASCADE,
    CONSTRAINT SCRIE_PK PRIMARY KEY(id_autor, id_carte)
);


--- CREAREA TABELULUI IMPRUMUTA
CREATE TABLE IMPRUMUTA(
    id_imprumut NUMBER(10,0)
        CONSTRAINT IMPRUMUTA_id_imprumut_PK PRIMARY KEY,
    id_cititor NUMBER(5,0)
        CONSTRAINT IMPRUMUTA_id_cititor_FK REFERENCES CITITORI(id_cititor)
        ON DELETE CASCADE
        CONSTRAINT IMPRUMUTA_id_cititor_NN NOT NULL,
    id_carte NUMBER(7,0)
        CONSTRAINT IMPRUMUTA_id_carte_FK REFERENCES CARTI(id_carte)
        ON DELETE CASCADE
        CONSTRAINT IMPRUMUTA_id_carte_NN NOT NULL,
    data_imprumut DATE
        CONSTRAINT IMPRUMUTA_data_imprumut_NN NOT NULL,
    data_returnare DATE
);



--- CREAREA TABELULUI RECENZIE
CREATE TABLE RECENZIE(
    id_recenzie NUMBER(8,0)
        CONSTRAINT RECENZIE_id_recenzie_PK PRIMARY KEY,
    id_recenzor NUMBER(5,0)
        CONSTRAINT RECENZIE_id_recenzor_FK REFERENCES RECENZORI(id_recenzor)
        ON DELETE CASCADE
        CONSTRAINT RECENZIE_id_recenzor_NN NOT NULL,
    id_carte NUMBER(7,0)
        CONSTRAINT RECENZIE_id_carte_FK REFERENCES CARTI(id_carte)
        ON DELETE CASCADE
        CONSTRAINT RECENZIE_id_carte_NN NOT NULL,
    data DATE
        CONSTRAINT RECENZIE_data_NN NOT NULL,
    nota_recenzie NUMBER(4,2)
        CONSTRAINT RECENZIE_nota_recenzie_NN NOT NULL
        CONSTRAINT RECENZIE_nota_recenzie_C CHECK (nota_recenzie>=1 AND nota_recenzie <= 10)
);



----- POPULAREA TABELELOR

--- AUTORI
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(1, 'ONCIU', 'ADRIAN', to_date('17-07-1968','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(2, 'CHRISTIE', 'AGATHA', to_date('15-09-1890','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(3, 'MARTIN-LUGAND', 'AGNES', to_date('22-07-1979','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(4, 'QUICK', 'AMANDA', to_date('28-03-1948','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(5, 'HOWARD', 'LINDA', to_date('07-12-1947','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(6, 'COX', 'ZARA', to_date('03-08-1950','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(7, 'GRAHAM', 'WINSTON', to_date('30-06-1908','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(8, 'EMINESCU', 'MIHAI', to_date('15-01-1950','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(9, 'CREANGA', 'ION', to_date('01-03-1837','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(10, 'ALECSANDRI', 'VASILE', to_date('21-07-1821','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(11, 'SLAVICI', 'IOAN', to_date('18-01-1848','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(12, 'SADOVEANU', 'MIHAIL', to_date('05-11-1880','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(13, 'BOWMAN', 'VALERIE', to_date('07-04-1964','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(14, 'DARE', 'TESSA', to_date('21-03-1974','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(15, 'LISA', 'SMITH', to_date('4-09-1950','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(16, 'HOAG', 'TAMI', to_date('20-01-1959','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(17, 'KING', 'STEPHEN', to_date('21-09-1947','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(18, 'STEEL', 'DANIELLE', to_date('14-08-1947','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(19, 'CINDEA', 'CORINA', to_date('30-11-1979','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(20, 'HOYT', 'ELIZABETH', to_date('21-11-1970','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(21, 'DANIELS', 'ELLE', to_date('07-01-1975','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(22, 'BARTON', 'FIONA', to_date('29-03-1957','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(23, 'WATT', 'ERIN', to_date('27-07-1975','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(24, 'FLYNN', 'GILLIAN', to_date('24-02-1971','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(25, 'HOWELL', 'HANNAH', to_date('03-10-1950','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(26, 'ALLENDE', 'ISABEL', to_date('02-08-1942','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(27, 'CLAVELL', 'JAMES', to_date('10-10-1921','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(28, 'WILDER', 'JASINDA', to_date('17-02-1969','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(29, 'FREDERICK', 'JEN', to_date('25-04-1970','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(30, 'BURTON', 'JESSIE', to_date('09-10-1982','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(31, 'GREEN', 'JOHN', to_date('24-08-1977','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(32, 'MOYES', 'JOJO', to_date('04-08-1969','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(33, 'SOBANET', 'JULIETTE', to_date('02-06-1979','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(34, 'ROSE', 'KAREN', to_date('06-04-1964','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(35, 'FOLLETT', 'KEN', to_date('05-06-1949','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(36, 'CASS', 'KIERA', to_date('19-05-1981','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(37, 'TAYLOR', 'LAINI', to_date('11-12-1971','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(38, 'BLAKELY', 'LAUREN', to_date('31-01-1969','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(39, 'DURRELL', 'LAWRENCE', to_date('27-02-1912','dd-mm-yyyy'));
INSERT INTO AUTORI(id_autor, nume_autor, prenume_autor, data_nasterii) VALUES(40, 'CHILD', 'LEE', to_date('29-10-1954','dd-mm-yyyy'));


--- EDITURI
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(1, 'Act si Politon', 'act.politon@gmail.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(2, 'Ad Libri', 'contact@adlibri.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(3, 'ALL Educational', 'all@educational.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(4, 'Aramis', 'aramis@gmail.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(5, 'ART', 'contact@art.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(6, 'Booklet', 'booklet@yahoo.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(7, 'Business Tech', 'business_tech@gmail.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(8, 'Cartex', 'contact@cartex.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(9, 'Casa Povestilor', 'casa_povestilor@yahoo.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(10, 'Crux Publishing', 'publishing@crux.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(11, 'Didactica si Pedagogica', 'didactica.pedagogica@yahoo.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(12, 'Economica', 'contact_economica@gmail.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(13, 'Erc Press', 'erc.press@gmail.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(14, 'Galaxia Copiilor', 'galaxia_copiilor@gmail.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(15, 'Humanitas Educational', 'contact@humanitas.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(16, 'Hyperliteratura', 'hyperliteratura@yahoo.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(17, 'Leda', 'contact@leda.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(18, 'Librex', 'librex.contact@gmail.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(19, 'Milena Press', 'contact@milenapress.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(20, 'Minerva', 'minerva_contact@yahoo.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(21, 'Nemira', 'contact@nemira.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(22, 'Orizonturi', 'orizonturi@yahoo.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(23, 'Polirom', 'contact@polirom.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(24, 'Praralela 45', 'paralela45@yahoo.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(25, 'Preda Publishing', 'contact@preda.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(26, 'Radical', 'radical.contact@yahoo.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(27, 'Sigma', 'contact@sigma.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(28, 'Steaua Nordului', 'steaua_nordului@gmail.com');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(29, 'Unicorn', 'contact@unicorn.ro');
INSERT INTO EDITURI(id_editura, nume_editura, email_editura) VALUES(30, 'Victoria Books', 'contact@vicbooks.ro');





--- CATEGORII
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(1, 'LINGVISTICA', 7);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(2, 'DICTIONARE', 7);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(3, 'BIOGRAFII, MEMORII, JURNALE', 10);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(4, 'LIMBI STRAINE',5);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(5, 'FICTIUNE', 5);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(6, 'POEZIE', 7);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(7, 'TEATRU', 12);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(8, 'ATLASE', 10);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(9, 'ENCICLOPEDII', 7);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(10, 'ISTORIE', 12);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(11, 'RELIGIE', 7);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(12, 'FILOSOFIE', 15);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(13, 'INFORMATICA', 14);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(14, 'PSIHOLOGIE', 17);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(15, 'POLITICA', 16);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(16, 'MARKETING SI COMUNICARE', 18);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(17, 'BUSINESS SI ECONOMIE', 18);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(18, 'DREPT', 15);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(19, 'MEDICINA', 15);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(20, 'STIINTE EXACTE', 9);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(21, 'NATURA SI MEDIU', 5);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(22, 'TEHNICA SI TEHNOLOGIE', 14);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(23, 'COMPUTERE', 14);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(24, 'SANATATE', 7);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(25, 'DEZVOLTARE PERSONALA', 12);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(26, 'CULINARE', 14);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(27, 'ROMANE', 10);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(28, 'ADOLESCENTI', 14);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(29, 'POVESTI PENTRU COPII', 3);
INSERT INTO CATEGORII(id_categorie, nume_categorie, varsta_minima_recomandata) VALUES(30, 'STIINTE SOCIALE', 16);



--- FURNIZORI
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(1, 'Atlas Group', '0702008610', 'contact@atlasgroup.ro');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(2, 'Astro Impex', '0704892400', 'contact@astro.ro');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(3, 'Nicol Cart', '0702094430', 'nicol_cart@gmail.com');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(4, 'Larry Cart', '0785027339', 'larry.cart@gmail.com');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(5, 'Rolcris Impex', '0702099361', 'contactrolcris@yahoo.com');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(6, 'Maricom 94', '0702049559', 'contact@maricom.ro');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(7, 'Bibliostar', '0713030996', 'contact@bibliostar.ro');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(8, 'Abstract Media', '0705568082', 'abstract_media@yahoo.com');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(9, 'Arcadia 2000', '0702022958', 'arcadia2000@gmail.com');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(10, 'Contexp Consult', '0702046894', 'contact@contexp.ro');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(11, 'ING Press', '0702078880', 'ingpress.contact@yahoo.com');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(12, 'Libricom', '0702003352', 'contact@libricom.ro');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(13, 'Miraclas', '0702017044', 'contact@miraclas.ro');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(14, 'Novus', '0788023375', 'novus_contact@gmail.com');
INSERT INTO FURNIZORI(id_furnizor, nume_furnizor, telefon_furnizor, email_furnizor) VALUES(15, 'Universalia', '0712753924', 'universalia.contact@yahoo.com');




--- RECENZORI
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(1, 'WALL', 'FELICIA', 'felicia.wall@gmail.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(2, 'EWING', 'DANTE', null);
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(3, 'BAUER', 'SIDRA', 'sidrabauer21@yahoo.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(4, 'FOSTER', 'NEHA', 'nehafoster@gmail.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(5, 'TERRELL', 'LUCIANO', null);
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(6, 'ORTEGA', 'MAI', null);
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(7, 'IONESCU', 'ADRIAN', null);
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(8, 'BARR', 'CHRISTIANA', 'christiana53@gmail.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(9, 'RAMSAY', 'ARCHER', 'archer.ramsay@yahoo.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(10, 'VASILE', 'ALINA', 'alina_vasile@gmail.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(11, 'BURNS', 'LORETTA', 'loretta23@yahoo.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(12, 'STEVENS', 'STEPHAN', null);
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(13, 'POPESCU', 'FELICIA', 'feliciapopescu55@yahoo.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(14, 'HANSEN', 'JUNAID', null);
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(15, 'WARDLE', 'HEENA', 'heenawardle1@gmail.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(16, 'FRITZ', 'SOFIJA', 'sofija.fritz@gmail.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(17, 'GILMORE', 'ANABELLE', 'anagilmore@yahoo.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(18, 'RYDER', 'DUSTIN', 'dustin.ryder@gmail.com');
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(19, 'IVASCU', 'ADRIAN', null);
INSERT INTO RECENZORI(id_recenzor, nume_recenzor, prenume_recenzor, email_recenzor) VALUES(20, 'KNOX', 'ZYAN', null);




--- CITITORI
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(1, 'Ionescu', 'Alin', '0701506075', 'alin.ionescu@gmail.com', to_date('15-05-2003','dd-mm-yyyy'), to_date('17-03-2019','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(2, 'Popescu', 'Lucian', '0712610752', 'popesculucian54@yahoo.com', to_date('01-10-2001','dd-mm-yyyy'), to_date('19-10-2018','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(3, 'Antonescu', 'Andreea', '0711185737', 'andreea_anto45@gmail.com', to_date('23-06-1993','dd-mm-yyyy'), to_date('21-05-2008','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(4, 'Nehita', 'Florin', '0702039611', 'florinnechitta12@yahoo.com', to_date('06-04-1997','dd-mm-yyyy'), to_date('03-05-2013','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(5, 'Ionel', 'Iustin', '0759904562', null, to_date('06-09-2001','dd-mm-yyyy'), to_date('10-04-2012','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(6, 'Horea', 'Eduard', '0702018213', 'edy_horea@yahoo.com', to_date('30-12-1996','dd-mm-yyyy'), to_date('30-04-2009','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(7, 'Ailenei', 'Ioan', '0702003534', 'ioanailenei12@gmail.com', to_date('17-02-1987','dd-mm-yyyy'), to_date('21-05-1999','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(8, 'Tofan', 'Andrei', '0708161350', 'andrei12tofan@gmail.com', to_date('13-05-1993','dd-mm-yyyy'), to_date('20-06-2008','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(9, 'Cretu', 'Cristina', '0702049214', 'cretucristina33@yahoo.com', to_date('24-03-2005','dd-mm-yyyy'), to_date('10-03-2018','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(10, 'Ignat', 'Andreea', '0702089482', 'andreea.ignat68@gmail.com', to_date('16-01-2004','dd-mm-yyyy'), to_date('21-10-2012','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(11, 'Iacob', 'Larisa', '0710949096', 'larisaa21@yahoo.com', to_date('24-04-1976','dd-mm-yyyy'), to_date('10-03-1995','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(12, 'Rusu', 'Bogdan', '0711220801', 'bogdan.rusu4@yahoo.com', to_date('20-11-2000','dd-mm-yyyy'), to_date('05-07-2014','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(13, 'Paslaru', 'Alexandra', '0702055431', 'alexandrapis33@gmail.com', to_date('24-04-1994','dd-mm-yyyy'), to_date('04-08-2020','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(14, 'Vieru', 'Manuela', '0708053370', 'manuvieru7@gmail.com', to_date('12-12-1984','dd-mm-yyyy'), to_date('19-06-2019','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(15, 'Vasiliu', 'Delia', '0709224671', null, to_date('03-01-2002','dd-mm-yyyy'), to_date('26-03-2011','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(16, 'Nemtanu', 'Eduard', '0702066176', 'nemtanuedy@gmail.com', to_date('31-12-2009','dd-mm-yyyy'), to_date('03-03-2020','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(17, 'Dochita', 'Adrian', '0713160666', 'adriandochita665@yahoo.com', to_date('17-07-2012','dd-mm-yyyy'), to_date('08-03-2020','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(18, 'Cucos', 'Iustin', '0799279691', 'cucos.iustin98@gmail.com', to_date('02-06-2004','dd-mm-yyyy'), to_date('14-12-2017','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(19, 'Boroianu', 'Eduard', '0708549948', 'eduardboroianu45@yahoo.com', to_date('09-01-1997','dd-mm-yyyy'), to_date('17-04-2012','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(20, 'Nistor', 'David', '0790778200', null, to_date('04-05-1979','dd-mm-yyyy'), to_date('12-05-1993','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(21, 'Bratu', 'Bianca', '0711123258', 'biancabratu.32@gmail.com', to_date('29-03-1980','dd-mm-yyyy'), to_date('23-09-2003','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(22, 'Catana', 'Sabina', '0740656899', 'sabinaa61@yahoo.com', to_date('05-04-2012','dd-mm-yyyy'), to_date('28-03-2020','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(23, 'Cucu', 'Stefan', '0713954834', null, to_date('12-11-2000','dd-mm-yyyy'), to_date('18-03-2010','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(24, 'Ciotirca', 'Adrian', '0712384444', 'cva.adrian@yahoo.com', to_date('03-08-2002','dd-mm-yyyy'), to_date('09-04-2019','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(25, 'Cosofret', 'Leonard', '0783050899', 'cosofret.le0@yahoo.com', to_date('18-08-1991','dd-mm-yyyy'), to_date('20-01-2003','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(26, 'Gusavan', 'Andrei', '0781324528', 'andrei_gusavan12@yahoo.com', to_date('06-02-1994','dd-mm-yyyy'), to_date('04-12-2008','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(27, 'Nechita', 'Madalina', '0726788543', 'madalina.necchita2@gmail.com', to_date('02-12-1984','dd-mm-yyyy'), to_date('03-09-1998','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(28, 'Antonescu', 'Cezar', '0707151052', 'cezaranto54@gmail.com', to_date('13-04-2005','dd-mm-yyyy'), to_date('19-06-2016','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(29, 'Balanici', 'Andrei', '0713240847', 'andrei_balanici78@yahoo.com', to_date('02-10-1994','dd-mm-yyyy'), to_date('11-10-2006','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(30, 'Balanici', 'Andreea', '0702039078', null, to_date('04-04-1998','dd-mm-yyyy'), to_date('30-01-2019','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(31, 'Cojocaru', 'Florin', '0740215222', 'florincojo4@gmail.com', to_date('01-07-1995','dd-mm-yyyy'), to_date('15-02-2003','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(32, 'Tanasuc', 'Stefan', '0711408867', 'tanasucstef44@gmail.com', to_date('19-12-1992','dd-mm-yyyy'), to_date('07-02-2009','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(33, 'Cojocaru', 'Denisa', '0779178261', 'denisacojocaru999@yahoo.com', to_date('09-04-2003','dd-mm-yyyy'), to_date('03-01-2012','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(34, 'Daraban', 'Delia', '0799611288', 'delia.daraban3@gmail.com', to_date('07-08-2001','dd-mm-yyyy'), to_date('08-12-2014','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(35, 'Olariu', 'Vasile', '0708520053', null, to_date('05-08-2010','dd-mm-yyyy'), to_date('29-05-2019','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(36, 'Chirila', 'Stefan', '0724543702', 'stef.chirilaa@gmail.com', to_date('12-12-2012','dd-mm-yyyy'), to_date('14-08-2020','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(37, 'Gorcea', 'Adrian', '0713447996', 'adygorcea9@yahoo.com', to_date('09-05-2004','dd-mm-yyyy'), to_date('01-04-2019','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(38, 'Pruna', 'Bogdan', '0711445624', 'bogdan.pruna4@yahoo.com', to_date('12-06-1984','dd-mm-yyyy'), to_date('12-10-2000','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(39, 'Motfai', 'Larisa', '0713479672', 'motfai.lariss@gmail.com', to_date('02-04-1995','dd-mm-yyyy'), to_date('26-01-2019','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(40, 'Florean', 'Emanuela', '0702003656', 'florean.ema@yahoo.com', to_date('25-04-1974','dd-mm-yyyy'), to_date('29-08-1998','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(41, 'Tugui', 'Alexandra', '0774901338', null, to_date('23-06-2002','dd-mm-yyyy'), to_date('30-10-2015','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(42, 'Mintoiu', 'Marius', '0783475328', null, to_date('19-12-1990','dd-mm-yyyy'), to_date('06-09-2004','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(43, 'Ursu', 'Maria', '0758334733', 'mariaursu45@yahoo.com', to_date('03-06-2003','dd-mm-yyyy'), to_date('17-04-2012','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(44, 'Preda', 'Catalin', '0703773986', 'catalinpreda100@gmail.com', to_date('07-03-1968','dd-mm-yyyy'), to_date('19-05-1997','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(45, 'Voda', 'Lucian', '0790209990', 'lucianvoda3@gmail.com', to_date('06-03-1987','dd-mm-yyyy'), to_date('28-01-1998','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(46, 'Tampau', 'Andrei', '0703933332', 'andreeey21@yahoo.com', to_date('30-03-2001','dd-mm-yyyy'), to_date('08-01-2019','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(47, 'Hutanu', 'Marcela', '0758867436', 'marcela_hutanu853@yahoo.com', to_date('07-03-2009','dd-mm-yyyy'), to_date('18-01-2020','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(48, 'Baetu', 'Denisa', '0787583227', null, to_date('31-12-2000','dd-mm-yyyy'), to_date('12-09-2010','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(49, 'Rotaru', 'Andrei', '0746475126', 'andrei.roty48@yahoo.com', to_date('08-02-2004','dd-mm-yyyy'), to_date('29-11-2017','dd-mm-yyyy'));
INSERT INTO CITITORI(id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii) VALUES(50, 'Popescu', 'Mihnea', '0774928471', 'mihnea.pop3scu@yahoo.com', to_date('01-03-2003','dd-mm-yyyy'), to_date('09-04-2013','dd-mm-yyyy'));




--- CARTI
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(1, 'Lumea se destrama', 345, to_date('12-05-1998','dd-mm-yyyy'), 2, 5, 4);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(2, 'Povesti si povestiri', 213, to_date('13-05-2003','dd-mm-yyyy'), 9, 29, 12);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(3, 'Teoria grafurilor', 543, to_date('10-03-2003','dd-mm-yyyy'), 23, 13, 1);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(4, 'Matematici speciale', 693, to_date('21-10-1992','dd-mm-yyyy'), 6, 20, 3);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(5, 'La rascruce de vanturi', 356, to_date('10-02-1974','dd-mm-yyyy'), 17, 5, null);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(6, 'Divina comedie', 420, to_date('10-02-1969','dd-mm-yyyy'), 30, 5, 14);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(7, 'Suflete moarte', 290, to_date('19-03-2013','dd-mm-yyyy'), 21, 28, 15);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(8, 'Drept constitutional', 890, to_date('17-10-2018','dd-mm-yyyy'), 18, 25, 11);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(9, 'Moby Dick', 389, to_date('20-08-1997','dd-mm-yyyy'), 18, 5, 6);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(10, 'Antichitatea', 549, to_date('10-02-2009','dd-mm-yyyy'), 13, 10, 9);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(11, 'Povesti complete', 268, to_date('19-03-1994','dd-mm-yyyy'), 28, 29, 8);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(12, 'Memoriile lui Hadrian', 403, to_date('12-12-2002','dd-mm-yyyy'), 16, 3, 10);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(13, 'Strainul', 320, to_date('10-03-2015','dd-mm-yyyy'), 10, 27, null);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(14, 'In cautarea timpului pierdut', 410, to_date('10-02-1985','dd-mm-yyyy'), 16, 27, 4);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(15, 'Jurnalul Annei Frank', 290, to_date('01-07-1987','dd-mm-yyyy'), 28, 3, 7);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(16, 'Minunata lume noua', 343, to_date('30-09-2001','dd-mm-yyyy'), 1, 27, 9);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(17, 'Ulise', 279, to_date('04-01-2005','dd-mm-yyyy'), 16, 5, 10);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(18, 'Retele neuronale adanci', 480, to_date('09-12-2017','dd-mm-yyyy'), 13, 22, 15);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(19, 'Istoria religiilor', 850, to_date('12-03-1986','dd-mm-yyyy'), 22, 11, 7);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(20, 'Marele Gatsby', 310, to_date('06-12-1985','dd-mm-yyyy'), 19, 27, 5);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(21, 'Baze de date', 354, to_date('12-04-2007','dd-mm-yyyy'), 24, 13, 14);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(22, 'Tehnici de comunicare', 236, to_date('19-03-2019','dd-mm-yyyy'), 7, 16, 2);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(23, 'Teoria sistemelor de control automat', 420, to_date('21-06-2012','dd-mm-yyyy'), 18, 22, 3);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(24, 'Gandire critica', 265, to_date('12-09-2009','dd-mm-yyyy'), 22, 12, 6);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(25, 'Somnul de veci', 302, to_date('03-03-2001','dd-mm-yyyy'), 1, 27, 7);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(26, 'Anatomia corpului uman', 755, to_date('19-02-2008','dd-mm-yyyy'), 3, 19, 8);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(27, 'Europa', 100, to_date('26-12-2013','dd-mm-yyyy'), 23, 8, 12);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(28, 'Romania', 56, to_date('10-03-2012','dd-mm-yyyy'), 23, 8, 15);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(29, 'Teatru', 430, to_date('12-09-1965','dd-mm-yyyy'), 19, 7, 13);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(30, 'Gramatica practica a limbii romane', 532, to_date('12-07-2009','dd-mm-yyyy'), 11, 1, 14);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(31, 'Omul fara insusiri', 289, to_date('20-03-1979','dd-mm-yyyy'), 16, 27, 2);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(32, 'Atitudinea este totul', 254, to_date('31-01-2015','dd-mm-yyyy'), 13, 25, 12);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(33, 'Secretele succesului', 343, to_date('15-09-2018','dd-mm-yyyy'), 10, 25, 1);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(34, 'Excelenta in afaceri', 423, to_date('08-03-2017','dd-mm-yyyy'), 3, 17, 8);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(35, 'Psihologia manipularii', 290, to_date('12-10-2013','dd-mm-yyyy'), 4, 14, null);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(36, 'Despre libertate', 451, to_date('01-04-2008','dd-mm-yyyy'), 18, 30, 3);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(37, 'Exceptionalii', 378, to_date('03-11-2012','dd-mm-yyyy'), 18, 30, 3);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(38, 'Introducere in stiinta politica', 450, to_date('10-02-2019','dd-mm-yyyy'), 12, 15, 1);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(39, 'Ciocnirea civilizatiilor', 390, to_date('15-08-2013','dd-mm-yyyy'), 13, 25, 2);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(40, 'Dieta castigatoare', 230, to_date('23-01-2019','dd-mm-yyyy'), 16, 24, 9);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(41, 'Studiul China', 332, to_date('12-12-2007','dd-mm-yyyy'), 2, 24, 5);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(42, 'Microsoft Windows 10', 540, to_date('12-01-2010','dd-mm-yyyy'), 10, 23, 3);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(43, 'Ion', 430, to_date('30-06-2001','dd-mm-yyyy'), 20, 27, null);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(44, 'Pamantul nelocuibil', 420, to_date('28-02-2018','dd-mm-yyyy'), 25, 21, 10);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(45, 'Walden', 320, to_date('25-07-2014','dd-mm-yyyy'), 25, 21, 11);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(46, 'Semiologie medicala', 539, to_date('12-07-2009','dd-mm-yyyy'), 15, 19, 12);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(47, 'Scurta istorie a omenirii', 653, to_date('03-08-2012','dd-mm-yyyy'), 3, 10, 13);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(48, 'Jurnalele vampirilor 1', 320, to_date('19-03-2004','dd-mm-yyyy'), 17, 28, 14);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(49, 'Dincolo de bine si rau', 365, to_date('10-02-2009','dd-mm-yyyy'), 21, 12, 15);
INSERT INTO CARTI(id_carte, titlu, numar_pagini, data_publicare, id_editura, id_categorie, id_furnizor) VALUES(50, 'Ecce homo', 290, to_date('24-05-2015','dd-mm-yyyy'), 22, 12, 7);




--- SCRIE
INSERT INTO SCRIE(id_autor, id_carte) VALUES(3,1);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(9,2);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(20,3);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(35,3);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(14,4);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(18,4);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(1,5);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(40,6);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(36,7);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(27,8);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(32,9);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(20,10);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(5,10);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(9,11);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(11,11);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(39,12);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(6,13);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(19,14);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(16,15);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(28,16);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(29,17);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(23,18);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(26,19);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(37,20);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(3,21);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(40,22);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(15,23);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(19,24);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(4,25);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(35,26);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(36,27);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(1,28);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(13,29);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(19,30);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(2,31);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(22,32);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(3,33);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(23,34);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(23,35);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(38,36);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(13,37);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(14,38);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(20,39);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(26,40);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(26,41);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(38,42);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(12,43);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(23,44);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(17,45);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(6,46);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(15,46);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(5,47);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(36,48);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(39,49);
INSERT INTO SCRIE(id_autor, id_carte) VALUES(40,50);




--- IMPRUMUTA
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(1, 1, 10, to_date('17-06-2020','dd-mm-yyyy'), to_date('30-07-2020','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(2, 1, 21, to_date('30-03-2020','dd-mm-yyyy'), to_date('19-04-2020','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(3, 2, 1, to_date('18-02-2019','dd-mm-yyyy'), to_date('30-03-2019','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(4, 4, 41, to_date('20-03-2015','dd-mm-yyyy'), to_date('17-04-2015','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(5, 4, 19, to_date('14-02-2019','dd-mm-yyyy'), to_date('27-03-2019','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(6, 5, 3, to_date('30-11-2018','dd-mm-yyyy'), to_date('17-12-2018','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(7, 6, 43, to_date('04-10-2014','dd-mm-yyyy'), to_date('07-11-2014','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(8, 6, 27, to_date('10-06-2015','dd-mm-yyyy'), to_date('23-07-2015','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(9, 6, 49, to_date('19-12-2021','dd-mm-yyyy'), null);
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(10, 7, 15, to_date('03-10-2005','dd-mm-yyyy'), to_date('30-11-2005','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(11, 7, 38, to_date('30-03-2020','dd-mm-yyyy'), to_date('02-05-2020','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(12, 8, 21, to_date('10-09-2013','dd-mm-yyyy'), to_date('14-11-2013','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(13, 10, 25, to_date('19-12-2018','dd-mm-yyyy'), to_date('10-01-2019','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(14, 10, 42, to_date('20-07-2020','dd-mm-yyyy'), to_date('03-09-2020','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(15, 10, 45, to_date('12-12-2021','dd-mm-yyyy'), null);
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(16, 11, 11, to_date('07-03-1998','dd-mm-yyyy'), to_date('10-05-1998','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(17, 11, 15, to_date('19-10-1999','dd-mm-yyyy'), to_date('20-11-1999','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(18, 11, 32, to_date('16-12-2016','dd-mm-yyyy'), to_date('19-01-2017','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(19, 12, 17, to_date('05-09-2017','dd-mm-yyyy'), to_date('16-10-2017','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(20, 12, 32, to_date('10-04-2018','dd-mm-yyyy'), to_date('20-05-2018','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(21, 14, 2, to_date('19-05-2020','dd-mm-yyyy'), to_date('25-06-2020','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(22, 14, 17, to_date('14-09-2021','dd-mm-yyyy'), to_date('15-10-2021','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(23, 15, 7, to_date('09-03-2014','dd-mm-yyyy'), to_date('07-05-2014','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(24, 15, 29, to_date('08-12-2014','dd-mm-yyyy'), to_date('19-01-2014','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(25, 16, 44, to_date('16-03-2020','dd-mm-yyyy'), to_date('15-04-2020','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(26, 17, 13, to_date('19-06-2021','dd-mm-yyyy'), to_date('30-07-2021','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(27, 17, 29, to_date('23-08-2021','dd-mm-yyyy'), to_date('04-10-2021','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(28, 18, 6, to_date('19-12-2017','dd-mm-yyyy'), to_date('14-01-2018','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(29, 18, 25, to_date('19-01-2018','dd-mm-yyyy'), to_date('03-03-2018','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(30, 18, 33, to_date('09-05-2019','dd-mm-yyyy'), to_date('19-06-2019','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(31, 19, 20, to_date('08-07-2012','dd-mm-yyyy'), to_date('19-08-2012','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(32, 20, 31, to_date('09-05-1997','dd-mm-yyyy'), to_date('10-07-1997','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(33, 20, 43, to_date('10-09-2002','dd-mm-yyyy'), to_date('07-10-2002','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(34, 21, 14, to_date('18-02-2004','dd-mm-yyyy'), to_date('30-03-2004','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(35, 21, 48, to_date('20-05-2005','dd-mm-yyyy'), to_date('09-06-2005','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(36, 24, 3, to_date('10-08-2019','dd-mm-yyyy'), to_date('21-09-2019','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(37, 24, 34, to_date('12-10-2020','dd-mm-yyyy'), to_date('04-12-2020','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(38, 25, 25, to_date('20-02-2003','dd-mm-yyyy'), to_date('12-03-2003','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(39, 27, 15, to_date('13-10-1998','dd-mm-yyyy'), to_date('11-11-1998','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(40, 27, 31, to_date('19-03-2000','dd-mm-yyyy'), to_date('21-05-2000','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(41, 28, 23, to_date('20-08-2020','dd-mm-yyyy'), to_date('20-09-2020','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(42, 28, 45, to_date('19-12-2021','dd-mm-yyyy'), null);
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(43, 30, 26, to_date('02-02-2019','dd-mm-yyyy'), to_date('06-04-2019','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(44, 31, 12, to_date('09-11-2003','dd-mm-yyyy'), to_date('10-12-2003','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(45, 31, 43, to_date('04-06-2004','dd-mm-yyyy'), to_date('08-07-2004','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(46, 35, 13, to_date('30-05-2019','dd-mm-yyyy'), to_date('03-06-2019','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(47, 35, 31, to_date('14-09-2020','dd-mm-yyyy'), to_date('15-10-2020','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(48, 35, 48, to_date('09-12-2021','dd-mm-yyyy'), null);
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(49, 39, 5, to_date('30-01-2019','dd-mm-yyyy'), to_date('14-02-2019','dd-mm-yyyy'));
INSERT INTO IMPRUMUTA(id_imprumut, id_cititor, id_carte, data_imprumut, data_returnare) VALUES(50, 39, 47, to_date('14-09-2019','dd-mm-yyyy'), to_date('03-11-2019','dd-mm-yyyy'));




--- RECENZIE
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(1, 1, 9, to_date('14-03-1998','dd-mm-yyyy'), 10);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(2, 1, 20, to_date('18-09-1987','dd-mm-yyyy'), 9.8);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(3, 2, 1, to_date('30-01-2000','dd-mm-yyyy'), 8.4);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(4, 3, 45, to_date('23-06-2015','dd-mm-yyyy'), 10);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(5, 4, 7, to_date('19-06-2013','dd-mm-yyyy'), 7.9);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(6, 5, 12, to_date('07-05-2003','dd-mm-yyyy'), 9.3);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(7, 5, 25, to_date('03-08-2001','dd-mm-yyyy'), 8.2);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(8, 6, 13, to_date('05-04-2015','dd-mm-yyyy'), 7.8);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(9, 7, 43, to_date('19-05-2002','dd-mm-yyyy'), 8.5);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(10, 8, 23, to_date('08-04-2013','dd-mm-yyyy'), 9.2);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(11, 9, 44, to_date('25-03-2018','dd-mm-yyyy'), 8);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(12, 10, 2, to_date('21-06-2003','dd-mm-yyyy'), 9.6);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(13, 10, 49, to_date('29-03-2009','dd-mm-yyyy'), 8.3);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(14, 11, 20, to_date('15-04-1986','dd-mm-yyyy'), 10);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(15, 12, 37, to_date('02-04-2013','dd-mm-yyyy'), 7.9);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(16, 13, 47, to_date('08-10-2012','dd-mm-yyyy'), 9.6);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(17, 14, 20, to_date('09-04-2003','dd-mm-yyyy'), 9.4);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(18, 15, 5, to_date('12-09-1991','dd-mm-yyyy'), 8.4);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(19, 15, 9, to_date('10-03-1998','dd-mm-yyyy'), 9.3);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(20, 16, 14, to_date('06-10-1987','dd-mm-yyyy'), 10);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(21, 16, 25, to_date('17-01-2003','dd-mm-yyyy'), 7.2);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(22, 17, 15, to_date('14-09-1990','dd-mm-yyyy'), 8.9);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(23, 17, 17, to_date('23-05-2005','dd-mm-yyyy'), 6.8);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(24, 17, 44, to_date('18-04-2018','dd-mm-yyyy'), 9.4);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(25, 18, 47, to_date('08-10-2012','dd-mm-yyyy'), 8.6);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(26, 18, 49, to_date('06-04-2009','dd-mm-yyyy'), 9.4);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(27, 19, 45, to_date('10-02-2015','dd-mm-yyyy'), 8.5);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(28, 19, 50, to_date('30-06-2015','dd-mm-yyyy'), 6.7);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(29, 20, 25, to_date('30-04-2001','dd-mm-yyyy'), 9.4);
INSERT INTO RECENZIE(id_recenzie, id_recenzor, id_carte, data, nota_recenzie) VALUES(30, 20, 49, to_date('19-05-2010','dd-mm-yyyy'), 8.9);


COMMIT;