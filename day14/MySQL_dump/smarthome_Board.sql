-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: smarthome
-- ------------------------------------------------------
-- Server version	9.2.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Board`
--

DROP TABLE IF EXISTS `Board`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Board` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(125) NOT NULL,
  `Writer` varchar(50) DEFAULT NULL,
  `Title` varchar(250) NOT NULL,
  `Contents` longtext NOT NULL,
  `PostDate` datetime DEFAULT NULL,
  `ReadCount` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Board`
--

LOCK TABLES `Board` WRITE;
/*!40000 ALTER TABLE `Board` DISABLE KEYS */;
INSERT INTO `Board` VALUES (2,'dbqhrud5789@naver.com','작성자','첫번째 글','내용을 수정하였습니다','2025-06-05 08:04:57',5),(3,'user0001@example.com','작성자0001','게시글 제목 0001','게시글 내용입니다. 내용 번호: 0001','2015-08-22 04:00:26',0),(4,'user0002@example.com','작성자0002','게시글 제목 0002','게시글 내용입니다. 내용 번호: 0002','2022-01-13 10:38:18',0),(5,'user0003@example.com','작성자0003','게시글 제목 0003','게시글 내용입니다. 내용 번호: 0003','2019-01-06 03:03:08',1),(6,'user0004@example.com','작성자0004','게시글 제목 0004','게시글 내용입니다. 내용 번호: 0004','2023-11-21 15:14:20',2),(8,'user0006@example.com','작성자0006','게시글 제목 0006','게시글 내용입니다. 내용 번호: 0006','2019-05-02 21:57:07',0),(9,'user0007@example.com','작성자0007','게시글 제목 0007','게시글 내용입니다. 내용 번호: 0007','2023-07-22 10:33:16',0),(10,'user0008@example.com','작성자0008','게시글 제목 0008','게시글 내용입니다. 내용 번호: 0008','2024-08-14 07:57:31',1),(11,'user0009@example.com','작성자0009','게시글 제목 0009','게시글 내용입니다. 내용 번호: 0009','2016-11-01 13:12:48',0),(12,'user0010@example.com','작성자0010','게시글 제목 0010','게시글 내용입니다. 내용 번호: 0010','2019-04-03 16:25:12',1),(13,'user0011@example.com','작성자0011','게시글 제목 0011','게시글 내용입니다. 내용 번호: 0011','2025-04-25 06:02:55',2),(14,'user0012@example.com','작성자0012','게시글 제목 0012','게시글 내용입니다. 내용 번호: 0012','2018-09-26 20:08:03',0),(15,'user0013@example.com','작성자0013','게시글 제목 0013','게시글 내용입니다. 내용 번호: 0013','2019-02-18 21:06:09',0),(16,'user0014@example.com','작성자0014','게시글 제목 0014','게시글 내용입니다. 내용 번호: 0014','2015-12-04 08:43:50',0),(17,'user0015@example.com','작성자0015','게시글 제목 0015','게시글 내용입니다. 내용 번호: 0015','2021-05-01 04:56:54',0),(18,'user0016@example.com','작성자0016','게시글 제목 0016','게시글 내용입니다. 내용 번호: 0016','2022-12-25 20:26:10',0),(19,'user0017@example.com','작성자0017','게시글 제목 0017','게시글 내용입니다. 내용 번호: 0017','2015-10-04 12:44:22',0),(20,'user0018@example.com','작성자0018','게시글 제목 0018','게시글 내용입니다. 내용 번호: 0018','2023-06-24 15:07:01',0),(21,'user0019@example.com','작성자0019','게시글 제목 0019','게시글 내용입니다. 내용 번호: 0019','2025-05-06 09:33:38',0),(22,'user0020@example.com','작성자0020','게시글 제목 0020','게시글 내용입니다. 내용 번호: 0020','2021-04-27 02:35:25',0),(23,'user0021@example.com','작성자0021','게시글 제목 0021','게시글 내용입니다. 내용 번호: 0021','2017-12-07 16:09:30',0),(24,'user0022@example.com','작성자0022','게시글 제목 0022','게시글 내용입니다. 내용 번호: 0022','2019-10-31 00:41:22',0),(25,'user0023@example.com','작성자0023','게시글 제목 0023','게시글 내용입니다. 내용 번호: 0023','2016-05-14 16:39:59',0),(26,'user0024@example.com','작성자0024','게시글 제목 0024','게시글 내용입니다. 내용 번호: 0024','2023-06-22 03:26:56',0),(27,'user0025@example.com','작성자0025','게시글 제목 0025','게시글 내용입니다. 내용 번호: 0025','2019-09-08 16:31:24',0),(28,'user0026@example.com','작성자0026','게시글 제목 0026','게시글 내용입니다. 내용 번호: 0026','2023-10-20 23:53:42',0),(29,'user0027@example.com','작성자0027','게시글 제목 0027','게시글 내용입니다. 내용 번호: 0027','2016-02-05 22:17:04',0),(30,'user0028@example.com','작성자0028','게시글 제목 0028','게시글 내용입니다. 내용 번호: 0028','2022-07-29 21:20:27',0),(31,'user0029@example.com','작성자0029','게시글 제목 0029','게시글 내용입니다. 내용 번호: 0029','2025-02-03 17:54:19',0),(32,'user0030@example.com','작성자0030','게시글 제목 0030','게시글 내용입니다. 내용 번호: 0030','2024-09-07 09:07:33',0),(33,'user0031@example.com','작성자0031','게시글 제목 0031','게시글 내용입니다. 내용 번호: 0031','2024-03-15 17:13:57',3),(34,'user0032@example.com','작성자0032','게시글 제목 0032','게시글 내용입니다. 내용 번호: 0032','2018-10-05 10:16:32',0),(35,'user0033@example.com','작성자0033','게시글 제목 0033','게시글 내용입니다. 내용 번호: 0033','2019-08-06 21:08:06',0),(36,'user0034@example.com','작성자0034','게시글 제목 0034','게시글 내용입니다. 내용 번호: 0034','2024-06-20 02:04:30',0),(37,'user0035@example.com','작성자0035','게시글 제목 0035','게시글 내용입니다. 내용 번호: 0035','2019-07-23 22:12:11',0),(38,'user0036@example.com','작성자0036','게시글 제목 0036','게시글 내용입니다. 내용 번호: 0036','2022-05-12 00:10:31',0),(39,'user0037@example.com','작성자0037','게시글 제목 0037','게시글 내용입니다. 내용 번호: 0037','2019-11-04 00:29:35',0),(40,'user0038@example.com','작성자0038','게시글 제목 0038','게시글 내용입니다. 내용 번호: 0038','2016-09-27 12:46:48',0),(41,'user0039@example.com','작성자0039','게시글 제목 0039','게시글 내용입니다. 내용 번호: 0039','2020-06-14 03:22:29',0),(42,'user0040@example.com','작성자0040','게시글 제목 0040','게시글 내용입니다. 내용 번호: 0040','2018-11-29 02:05:34',0);
/*!40000 ALTER TABLE `Board` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-12 16:06:37
