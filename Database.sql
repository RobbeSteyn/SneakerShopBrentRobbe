CREATE DATABASE  IF NOT EXISTS `dbsneakers` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `dbsneakers`;
-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: dbsneakers
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblklanten`
--

DROP TABLE IF EXISTS `tblklanten`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblklanten` (
  `KlantID` int(11) NOT NULL AUTO_INCREMENT,
  `Naam` varchar(45) DEFAULT NULL,
  `Voornaam` varchar(45) DEFAULT NULL,
  `Adres` varchar(45) DEFAULT NULL,
  `Postcode` int(11) DEFAULT NULL,
  `Gemeente` varchar(45) DEFAULT NULL,
  `Mail` varchar(45) DEFAULT NULL,
  `Gebruikersnaam` varchar(45) DEFAULT NULL,
  `Wachtwoord` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`KlantID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblklanten`
--

LOCK TABLES `tblklanten` WRITE;
/*!40000 ALTER TABLE `tblklanten` DISABLE KEYS */;
INSERT INTO `tblklanten` VALUES (1,'Nooyens','Brent','Bergstraat 31',3404,'Landen','bnooyens@gmail.com','BrentNooyens','Test123'),(2,'Steynen','Robbe','Vrijheersstraat ',3891,'Gingelom','robbe.steynen@gmail.com','RobbeSteynen','Test123'),(3,'Slawisky','Lisa','Ridderstraat 21',3890,'Montenaken','Lisaslawisky5@icloud.com','LisaSlawisky','Test123'),(4,'Bollens','Inte','Bevingen-Centrum 32 ',3800,'Sint-Truiden','inte1977.bollens@gmail.com','InteBollen','Test123');
/*!40000 ALTER TABLE `tblklanten` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblorder`
--

DROP TABLE IF EXISTS `tblorder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblorder` (
  `OrderID` int(11) NOT NULL AUTO_INCREMENT,
  `Orderdatum` varchar(45) DEFAULT NULL,
  `KlantID` int(11) DEFAULT NULL,
  PRIMARY KEY (`OrderID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblorder`
--

LOCK TABLES `tblorder` WRITE;
/*!40000 ALTER TABLE `tblorder` DISABLE KEYS */;
INSERT INTO `tblorder` VALUES (1,'2019-05-14',1),(2,'2019-05-19 02:41:37',2),(3,'2019-05-19 04:38:27',2),(4,'2019-05-19 08:47:39',2),(5,'2019-05-19 09:14:04',2),(6,'2019-05-19 09:24:08',2),(7,'2019-05-19 09:27:10',2);
/*!40000 ALTER TABLE `tblorder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblorderlijn`
--

DROP TABLE IF EXISTS `tblorderlijn`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblorderlijn` (
  `OrderID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `Aantal` int(11) DEFAULT NULL,
  `Prijs` double DEFAULT NULL,
  PRIMARY KEY (`OrderID`,`ProductID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblorderlijn`
--

LOCK TABLES `tblorderlijn` WRITE;
/*!40000 ALTER TABLE `tblorderlijn` DISABLE KEYS */;
INSERT INTO `tblorderlijn` VALUES (2,2,5,180),(3,2,5,180),(4,4,1,160),(4,5,5,85),(5,10,5,112),(6,10,5,112),(7,10,5,112);
/*!40000 ALTER TABLE `tblorderlijn` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblproducten`
--

DROP TABLE IF EXISTS `tblproducten`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblproducten` (
  `ProductID` int(11) NOT NULL AUTO_INCREMENT,
  `Naam` varchar(45) DEFAULT NULL,
  `Voorraad` varchar(45) DEFAULT NULL,
  `Prijs` double DEFAULT NULL,
  `Foto` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ProductID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblproducten`
--

LOCK TABLES `tblproducten` WRITE;
/*!40000 ALTER TABLE `tblproducten` DISABLE KEYS */;
INSERT INTO `tblproducten` VALUES (1,'Nike Air Max 98 oa gs','50',200,'Nike98.jpg'),(2,'Nike Air Max Deluxe','50',180,'NikeDeluxe.jpg'),(3,'Nike Air Max2 Light','50',105,'NikeMax2.jpg'),(4,'Nike x Atmos Air Max2 Light qs','50',160,'NikeAtmos.jpg'),(5,'Nike Zoom 2k ','50',85,'NikeZoom.jpg'),(6,'Nike Air Max 270','50',150,'NikeAirMax270.jpg'),(7,'Nike M2K Tekno','50',100,'NikeM2KTekno.jpg'),(8,'Nike Kobe IV Protro','50',175,'NikeKobeIVProtro.jpg'),(9,'Nike Air Max 720','50',170,'NikeAirMax720.jpg'),(10,'Nike Air Max 97','50',112,'NikeAirMax97.jpg');
/*!40000 ALTER TABLE `tblproducten` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblwinkelmand`
--

DROP TABLE IF EXISTS `tblwinkelmand`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblwinkelmand` (
  `KlantID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `Aantal` int(11) DEFAULT NULL,
  PRIMARY KEY (`KlantID`,`ProductID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblwinkelmand`
--

LOCK TABLES `tblwinkelmand` WRITE;
/*!40000 ALTER TABLE `tblwinkelmand` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblwinkelmand` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-19 23:48:32
