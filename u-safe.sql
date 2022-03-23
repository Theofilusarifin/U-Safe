-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 23, 2022 at 01:27 AM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 7.4.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `u-safe`
--

-- --------------------------------------------------------

--
-- Table structure for table `admins`
--

CREATE TABLE `admins` (
  `id` int(10) UNSIGNED NOT NULL,
  `username` mediumtext DEFAULT NULL,
  `email` mediumtext DEFAULT NULL,
  `phone_number` mediumtext DEFAULT NULL,
  `password` mediumtext DEFAULT NULL,
  `profile_photo` longblob DEFAULT NULL,
  `KTPnum` mediumtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `checkups`
--

CREATE TABLE `checkups` (
  `id` int(10) UNSIGNED NOT NULL,
  `price` int(11) DEFAULT NULL,
  `total_price` int(11) DEFAULT NULL,
  `finished` tinyint(4) DEFAULT NULL,
  `start_date` datetime DEFAULT NULL,
  `finisht_date` datetime DEFAULT NULL,
  `customer_id` int(10) UNSIGNED NOT NULL,
  `doctor_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `checkup_medicine`
--

CREATE TABLE `checkup_medicine` (
  `checkup_id` int(10) UNSIGNED NOT NULL,
  `medicine_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `id` int(10) UNSIGNED NOT NULL,
  `username` mediumtext DEFAULT NULL,
  `email` mediumtext DEFAULT NULL,
  `phone_number` mediumtext DEFAULT NULL,
  `password` mediumtext DEFAULT NULL,
  `balance` int(11) DEFAULT NULL,
  `profile_photo` longblob DEFAULT NULL,
  `KTPnum` mediumtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `doctors`
--

CREATE TABLE `doctors` (
  `id` int(10) UNSIGNED NOT NULL,
  `username` mediumtext DEFAULT NULL,
  `email` mediumtext DEFAULT NULL,
  `phone_number` mediumtext DEFAULT NULL,
  `password` mediumtext DEFAULT NULL,
  `profile_photo` longblob DEFAULT NULL,
  `KTPnum` mediumtext DEFAULT NULL,
  `balance` int(11) DEFAULT NULL,
  `availability` varchar(45) DEFAULT NULL,
  `bank_account` mediumtext DEFAULT NULL,
  `hospital_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `medicines`
--

CREATE TABLE `medicines` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `price` int(11) DEFAULT NULL,
  `stock` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `checkups`
--
ALTER TABLE `checkups`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_checkup_customers1_idx` (`customer_id`),
  ADD KEY `fk_checkup_doctors1_idx` (`doctor_id`);

--
-- Indexes for table `checkup_medicine`
--
ALTER TABLE `checkup_medicine`
  ADD PRIMARY KEY (`checkup_id`,`medicine_id`),
  ADD KEY `fk_checkup_has_medicines_medicines1_idx` (`medicine_id`),
  ADD KEY `fk_checkup_has_medicines_checkup1_idx` (`checkup_id`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `doctors`
--
ALTER TABLE `doctors`
  ADD PRIMARY KEY (`id`,`hospital_id`),
  ADD KEY `fk_doctors_hospitals_idx` (`hospital_id`);

--
-- Indexes for table `medicines`
--
ALTER TABLE `medicines`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admins`
--
ALTER TABLE `admins`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `checkups`
--
ALTER TABLE `checkups`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `doctors`
--
ALTER TABLE `doctors`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `medicines`
--
ALTER TABLE `medicines`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `checkups`
--
ALTER TABLE `checkups`
  ADD CONSTRAINT `fk_checkup_customers1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_checkup_doctors1` FOREIGN KEY (`doctor_id`) REFERENCES `doctors` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `checkup_medicine`
--
ALTER TABLE `checkup_medicine`
  ADD CONSTRAINT `fk_checkup_has_medicines_checkup1` FOREIGN KEY (`checkup_id`) REFERENCES `checkups` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_checkup_has_medicines_medicines1` FOREIGN KEY (`medicine_id`) REFERENCES `medicines` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `doctors`
--
ALTER TABLE `doctors`
  ADD CONSTRAINT `fk_doctors_hospitals` FOREIGN KEY (`hospital_id`) REFERENCES `hospitals` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
