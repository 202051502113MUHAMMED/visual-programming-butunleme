-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3306
-- Üretim Zamanı: 17 Oca 2023, 12:30:48
-- Sunucu sürümü: 10.4.27-MariaDB
-- PHP Sürümü: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `diliveri`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `dilivge`
--

CREATE TABLE `dilivge` (
  `id` int(11) NOT NULL,
  `dilivname` varchar(20) NOT NULL,
  `addres` varchar(200) NOT NULL,
  `pone` varchar(20) NOT NULL,
  `email` varchar(32) NOT NULL,
  `isActiv` enum(' yes','no') NOT NULL,
  `imege` varchar(300) NOT NULL,
  `Nods` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `dilivge`
--

INSERT INTO `dilivge` (`id`, `dilivname`, `addres`, `pone`, `email`, `isActiv`, `imege`, `Nods`) VALUES
(8, 'Ahmedaslan', 'bursa myrkez ', '05376495647', 'ahmed@gmail.com', '', 'C:\\Users\\muhma\\Downloads\\Gorsel-Butunleme\\Gorsel-Butunleme\\bin\\Debug\\fotograflar\\Dileviri\\Ahmed.jpg', 'reere'),
(9, 'sapıt', 'osmanıye', '64575', 'sapıt@gmail.com', ' yes', 'C:\\Users\\muhma\\Downloads\\Gorsel-Butunleme\\Gorsel-Butunleme\\bin\\Debug\\fotograflar\\Dileviri\\sapıt.jpg', 'ee');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `manavlar`
--

CREATE TABLE `manavlar` (
  `id` int(11) NOT NULL,
  `MaName` varchar(20) NOT NULL,
  `Code` varchar(50) NOT NULL,
  `Fiyat` varchar(50) NOT NULL,
  `not` varchar(100) NOT NULL,
  `imege` varchar(300) NOT NULL,
  `adet` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `manavlar`
--

INSERT INTO `manavlar` (`id`, `MaName`, `Code`, `Fiyat`, `not`, `imege`, `adet`) VALUES
(11, 'Muz', '1123233', '18Tl', '', 'C:\\Users\\muhma\\Downloads\\Gorsel-Butunleme\\Gorsel-Butunleme\\bin\\Debug\\fotograflar\\manav\\Muz.jpg', '11'),
(12, 'elma', '232323', '10t', '', 'C:\\Users\\muhma\\Downloads\\Gorsel-Butunleme\\Gorsel-Butunleme\\bin\\Debug\\fotograflar\\manav\\elma.jpg', '22'),
(13, 'bataates', '1111222', '8Tl', 'kg icin', 'C:\\Users\\muhma\\Downloads\\Gorsel-Butunleme\\Gorsel-Butunleme\\bin\\Debug\\fotograflar\\manav\\bataates.jpg', '33');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musterıler`
--

CREATE TABLE `musterıler` (
  `id` int(11) NOT NULL,
  `musname` varchar(20) NOT NULL,
  `addres` varchar(200) NOT NULL,
  `pone` varchar(20) NOT NULL,
  `email` varchar(32) NOT NULL,
  `isActiv` enum(' yes','no') NOT NULL,
  `imege` varchar(300) NOT NULL,
  `Nods` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `musterıler`
--

INSERT INTO `musterıler` (`id`, `musname`, `addres`, `pone`, `email`, `isActiv`, `imege`, `Nods`) VALUES
(9, 'muhammed', 'kutahya merkez osman gazi', '053189394', 'muhammed@gmail.com', ' yes', 'C:\\Users\\muhma\\Downloads\\Gorsel-Butunleme\\Gorsel-Butunleme\\bin\\Debug\\fotograflar\\Muşteriler\\muhammed.jpg', 'Hizli gelir'),
(11, 'musaplamas', 'ıstanpul', '0873572573', 'eme@gmail.com', '', 'C:\\Users\\muhma\\Downloads\\Gorsel-Butunleme\\Gorsel-Butunleme\\bin\\Debug\\fotograflar\\Muşteriler\\musaplamas.jpg', 'ww'),
(12, 'tamas', 'gfdgdfgf', '5465565', 'gdfgdf@sjvdk', '', 'C:\\Users\\muhma\\Downloads\\Gorsel-Butunleme\\Gorsel-Butunleme\\bin\\Debug\\fotograflar\\Muşteriler\\tamas.jpg', 'rdsg');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `Name` varchar(20) NOT NULL,
  `password` varchar(30) NOT NULL,
  `email` varchar(50) NOT NULL,
  `img` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `users`
--

INSERT INTO `users` (`id`, `Name`, `password`, `email`, `img`) VALUES
(23, 'aa', '11', 'aa@gmail.com', 'C:\\Users\\muhma\\Downloads\\Gorsel-Butunleme\\Gorsel-Butunleme\\bin\\Debug\\fotograflar\\user\\11.jpg'),
(26, 'rr', 'rr', 'ss@gemail.com', 'C:\\Users\\muhma\\Downloads\\Gorsel-Butunleme\\Gorsel-Butunleme\\bin\\Debug\\fotograflar\\Muşteriler\\rr.jpg');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `dilivge`
--
ALTER TABLE `dilivge`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `manavlar`
--
ALTER TABLE `manavlar`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `musterıler`
--
ALTER TABLE `musterıler`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `dilivge`
--
ALTER TABLE `dilivge`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Tablo için AUTO_INCREMENT değeri `manavlar`
--
ALTER TABLE `manavlar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Tablo için AUTO_INCREMENT değeri `musterıler`
--
ALTER TABLE `musterıler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
