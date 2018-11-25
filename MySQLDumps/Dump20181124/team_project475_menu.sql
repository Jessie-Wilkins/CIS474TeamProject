-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: team_project475
-- ------------------------------------------------------
-- Server version	8.0.13

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
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `menu` (
  `ItemID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ItemName` varchar(50) DEFAULT NULL,
  `BasePrice` float(5,2) DEFAULT NULL,
  `Description` varchar(300) DEFAULT NULL,
  UNIQUE KEY `ItemID` (`ItemID`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (1,'Single Hamburger',6.00,''),(2,'Double Hamburger',7.00,''),(4,'Triple Hamburger',8.00,''),(5,'Chili Bowl',4.75,''),(6,'Loaded Potato Bowl',4.75,''),(7,'Broccoli Cheese Bowl',4.75,''),(8,'Vegetable Soup Bowl',4.75,''),(9,'Soup of the Day Bowl',4.75,''),(10,'Chili Cup',2.75,''),(11,'Loaded Potato Cup',2.75,''),(12,'Broccoli Cheese Cup',2.75,''),(13,'Vegetable Soup Cup',2.75,''),(14,'Soup of the Day Cup',2.75,''),(15,'Fries',2.50,''),(16,'Fried Greenbeans',3.75,''),(17,'Fried Mushrooms',4.00,''),(18,'Side Salad',3.25,''),(19,'Fresh Seasonal Fruit',3.25,''),(20,'Ice Cream Sundae',3.50,''),(21,'Cake of the Day',2.50,''),(22,'Pie of the Day',2.50,'');
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-11-24 22:11:39
