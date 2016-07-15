-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jul 02, 2016 at 12:46 PM
-- Server version: 10.1.10-MariaDB
-- PHP Version: 5.6.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `medicaldb`
--

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(128) NOT NULL,
  `Name` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`) VALUES
('1', 'Admin'),
('2', 'User');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(128) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `UserId` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(128) NOT NULL,
  `RoleId` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('29776cca-77f6-4370-8356-4cd6d87e462b', '1'),
('2aebd97e-f08b-4bf5-8d03-49f00a4b9ba2', '2');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(128) NOT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `UserName` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `Email`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEndDateUtc`, `LockoutEnabled`, `AccessFailedCount`, `UserName`) VALUES
('29776cca-77f6-4370-8356-4cd6d87e462b', 'admin@gmail.com', 0, 'ACqatywf2YAB5APMkSTYmCWZEm8kcruE+AwUY1LC01RjV6ns5+F9r4Z+TVUJZk00Kw==', '55c7a9a2-cc80-4d26-b81d-17417435a1e4', NULL, 0, 0, NULL, 1, 0, 'admin'),
('2aebd97e-f08b-4bf5-8d03-49f00a4b9ba2', 'test@gmail.com', 0, 'ALzY10b/cFWzZ9cWaKIUNF0LkrggoKatKKw+eiHHjbLCuu9EVtoQUP04H7zTfsFP5Q==', '669d429e-c37d-4899-bac3-f65bd4117c25', NULL, 0, 0, NULL, 1, 0, 'test');

-- --------------------------------------------------------

--
-- Table structure for table `entrymodels`
--

CREATE TABLE `entrymodels` (
  `EntryId` int(11) NOT NULL,
  `Beneficiary_First_Name` longtext NOT NULL,
  `Beneficiary_Middle_Name` longtext,
  `Beneficiary_Last_Name` longtext NOT NULL,
  `Principal_First_Name` longtext NOT NULL,
  `Principal_Middle_Name` longtext,
  `Principal_Last_Name` longtext NOT NULL,
  `DOB` longtext NOT NULL,
  `maritalstatus_id` int(11) NOT NULL,
  `visacategory_id` int(11) NOT NULL,
  `Passport_Number` longtext NOT NULL,
  `Category` longtext NOT NULL,
  `Nationality` longtext NOT NULL,
  `gender_id` int(11) NOT NULL,
  `Rid` int(11) NOT NULL,
  `Sid` int(11) NOT NULL,
  `Emirates_ID` longtext NOT NULL,
  `City_of_Residence` longtext NOT NULL,
  `Company_Name` longtext NOT NULL,
  `UID_Number` longtext NOT NULL,
  `SubGroup_Name` longtext NOT NULL,
  `Emirates_Of_Visa` longtext NOT NULL,
  `Work_Location` longtext NOT NULL,
  `Entity_Id` longtext NOT NULL,
  `Entity_Type` longtext NOT NULL,
  `Establishment_Id` longtext NOT NULL,
  `insurance_companyname` longtext NOT NULL,
  `policy` longtext NOT NULL,
  `PhoneNumber` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `photo` longtext,
  `Visa` longtext,
  `passport_copy` longtext,
  `Emirates_id_copy` longtext,
  `medical_card` longtext,
  `other_documents` longtext,
  `other_field_1` varchar(250) NOT NULL,
  `other_field_2` varchar(250) NOT NULL,
  `other_field_3` varchar(250) NOT NULL,
  `Date_Time` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `entrymodels`
--

INSERT INTO `entrymodels` (`EntryId`, `Beneficiary_First_Name`, `Beneficiary_Middle_Name`, `Beneficiary_Last_Name`, `Principal_First_Name`, `Principal_Middle_Name`, `Principal_Last_Name`, `DOB`, `maritalstatus_id`, `visacategory_id`, `Passport_Number`, `Category`, `Nationality`, `gender_id`, `Rid`, `Sid`, `Emirates_ID`, `City_of_Residence`, `Company_Name`, `UID_Number`, `SubGroup_Name`, `Emirates_Of_Visa`, `Work_Location`, `Entity_Id`, `Entity_Type`, `Establishment_Id`, `insurance_companyname`, `policy`, `PhoneNumber`, `Email`, `photo`, `Visa`, `passport_copy`, `Emirates_id_copy`, `medical_card`, `other_documents`, `other_field_1`, `other_field_2`, `other_field_3`, `Date_Time`) VALUES
(24, 'bhargav', NULL, 'Konathala', 'bhargav', NULL, 'konathala', '01/02/1993', 2, 1, 'test', 'test', 'indian', 2, 1, 2, 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'bhargav@gmail.com', 'bhargav-Konathala_photo.jpg', 'bhargav-Konathala_visa.jpg', 'bhargav-Konathala_passport.jpg', NULL, NULL, NULL, 'test', 'test', 'test', '7/1/2016 8:25:27 PM'),
(25, 'Naidu', NULL, 'k', 'naidu', NULL, 'k', '13/03/1990', 2, 2, 'test', 'test', 'indian', 2, 2, 2, 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'naidu@gmail.com', NULL, NULL, 'Naidu-k_passport.jpg', 'Naidu-k_emiratesid.jpg', 'Naidu-k_medicalcard.jpg', 'Naidu-k_other.JPG', 'test', 'test', 'test', '7/1/2016 8:25:49 PM');

-- --------------------------------------------------------

--
-- Table structure for table `genders`
--

CREATE TABLE `genders` (
  `gender_id` int(11) NOT NULL,
  `Name` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `genders`
--

INSERT INTO `genders` (`gender_id`, `Name`) VALUES
(1, ' Female'),
(2, 'Male');

-- --------------------------------------------------------

--
-- Table structure for table `grosssalaries`
--

CREATE TABLE `grosssalaries` (
  `Sid` int(11) NOT NULL,
  `Value` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `grosssalaries`
--

INSERT INTO `grosssalaries` (`Sid`, `Value`) VALUES
(1, 'Above 4K'),
(2, 'Below 4K'),
(3, 'N/A ');

-- --------------------------------------------------------

--
-- Table structure for table `marital_status`
--

CREATE TABLE `marital_status` (
  `maritalstatus_id` int(11) NOT NULL,
  `Name` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `marital_status`
--

INSERT INTO `marital_status` (`maritalstatus_id`, `Name`) VALUES
(1, 'Married'),
(2, ' Single'),
(3, ' Divorced');

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_applications`
--

CREATE TABLE `my_aspnet_applications` (
  `id` int(11) NOT NULL,
  `name` varchar(256) DEFAULT NULL,
  `description` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_membership`
--

CREATE TABLE `my_aspnet_membership` (
  `userId` int(11) NOT NULL,
  `Email` varchar(128) DEFAULT NULL,
  `Comment` varchar(255) DEFAULT NULL,
  `Password` varchar(128) NOT NULL,
  `PasswordKey` char(32) DEFAULT NULL,
  `PasswordFormat` tinyint(4) DEFAULT NULL,
  `PasswordQuestion` varchar(255) DEFAULT NULL,
  `PasswordAnswer` varchar(255) DEFAULT NULL,
  `IsApproved` tinyint(1) DEFAULT NULL,
  `LastActivityDate` datetime DEFAULT NULL,
  `LastLoginDate` datetime DEFAULT NULL,
  `LastPasswordChangedDate` datetime DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `IsLockedOut` tinyint(1) DEFAULT NULL,
  `LastLockedOutDate` datetime DEFAULT NULL,
  `FailedPasswordAttemptCount` int(10) UNSIGNED DEFAULT NULL,
  `FailedPasswordAttemptWindowStart` datetime DEFAULT NULL,
  `FailedPasswordAnswerAttemptCount` int(10) UNSIGNED DEFAULT NULL,
  `FailedPasswordAnswerAttemptWindowStart` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='2';

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_paths`
--

CREATE TABLE `my_aspnet_paths` (
  `applicationId` int(11) NOT NULL,
  `pathId` varchar(36) NOT NULL,
  `path` varchar(256) NOT NULL,
  `loweredPath` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_personalizationallusers`
--

CREATE TABLE `my_aspnet_personalizationallusers` (
  `pathId` varchar(36) NOT NULL,
  `pageSettings` blob NOT NULL,
  `lastUpdatedDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_personalizationperuser`
--

CREATE TABLE `my_aspnet_personalizationperuser` (
  `id` int(11) NOT NULL,
  `applicationId` int(11) NOT NULL,
  `pathId` varchar(36) DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `pageSettings` blob NOT NULL,
  `lastUpdatedDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_profiles`
--

CREATE TABLE `my_aspnet_profiles` (
  `userId` int(11) NOT NULL,
  `valueindex` longtext,
  `stringdata` longtext,
  `binarydata` longblob,
  `lastUpdatedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_roles`
--

CREATE TABLE `my_aspnet_roles` (
  `id` int(11) NOT NULL,
  `applicationId` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_schemaversion`
--

CREATE TABLE `my_aspnet_schemaversion` (
  `version` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `my_aspnet_schemaversion`
--

INSERT INTO `my_aspnet_schemaversion` (`version`) VALUES
(10);

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_sessioncleanup`
--

CREATE TABLE `my_aspnet_sessioncleanup` (
  `LastRun` datetime NOT NULL,
  `IntervalMinutes` int(11) NOT NULL,
  `ApplicationId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_sessions`
--

CREATE TABLE `my_aspnet_sessions` (
  `SessionId` varchar(191) NOT NULL,
  `ApplicationId` int(11) NOT NULL,
  `Created` datetime NOT NULL,
  `Expires` datetime NOT NULL,
  `LockDate` datetime NOT NULL,
  `LockId` int(11) NOT NULL,
  `Timeout` int(11) NOT NULL,
  `Locked` tinyint(1) NOT NULL,
  `SessionItems` longblob,
  `Flags` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_sitemap`
--

CREATE TABLE `my_aspnet_sitemap` (
  `Id` int(11) NOT NULL,
  `Title` varchar(50) DEFAULT NULL,
  `Description` varchar(512) DEFAULT NULL,
  `Url` varchar(512) DEFAULT NULL,
  `Roles` varchar(1000) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_users`
--

CREATE TABLE `my_aspnet_users` (
  `id` int(11) NOT NULL,
  `applicationId` int(11) NOT NULL,
  `name` varchar(256) NOT NULL,
  `isAnonymous` tinyint(1) NOT NULL DEFAULT '1',
  `lastActivityDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_usersinroles`
--

CREATE TABLE `my_aspnet_usersinroles` (
  `userId` int(11) NOT NULL,
  `roleId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `relationships`
--

CREATE TABLE `relationships` (
  `Rid` int(11) NOT NULL,
  `RelationName` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `relationships`
--

INSERT INTO `relationships` (`Rid`, `RelationName`) VALUES
(1, 'Principal'),
(2, 'Spouse'),
(3, 'Child');

-- --------------------------------------------------------

--
-- Table structure for table `visa_category`
--

CREATE TABLE `visa_category` (
  `visacategory_id` int(11) NOT NULL,
  `Name` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `visa_category`
--

INSERT INTO `visa_category` (`visacategory_id`, `Name`) VALUES
(1, ' Employment Visa'),
(2, ' Dependant Visa');

-- --------------------------------------------------------

--
-- Table structure for table `__migrationhistory`
--

CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 NOT NULL,
  `ContextKey` varchar(300) CHARACTER SET utf8 NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `__migrationhistory`
--

INSERT INTO `__migrationhistory` (`MigrationId`, `ContextKey`, `Model`, `ProductVersion`) VALUES
('201607010713170_InitialCreate', 'WebApplication1.Migrations.Configuration', 0x1f8b0800000000000400dd5c5b6fe3b6127e3f40ff83a0c722b57269167b027b17a993f4046773c13adb73de16b4443bc24aa42a51698283feb23ef427f52f9ca144c9122fbad88aed140b2c2c72f8cd70382487c361fefae3cff1c7e730b09e709cf8944ceca3d1a16d61e252cf27cb899db2c50fefed8f1fbefbc7f8d20b9fad5f0aba134e072d4932b11f198bce1c27711f71889251e8bb314de8828d5c1a3ac8a3cef1e1e13f9da3230703840d589635fe9c12e68738fb80cf29252e8e588a821beae12011e55033cb50ad5b14e224422e9ed8ffc1f3f3280a7c173110e56894b7b0adf3c04720cd0c070bdb42845096119c7d49f08cc5942c671114a0e0e125c240b7404182451fce56e45dbb7378ccbbe3ac1a16506e9a301af6043c3a11fa71e4e66b69d92ef5071abc044db317deeb4c8b13fbdac359d1671a8002648667d320e6c413fba664719e44b7988d8a86a31cf22a06b8df68fc6d54453cb03ab73b28ede97874c8ff1d58d33460698c2704a72c46c181759fce61a8ff8d5f1ee8374c262747f3c5c9fbd377c83b79f7233e39adf614fa0a74b50228ba8f698463900d2fcafedb96536fe7c80dcb669536b956c096606ad8d60d7afe84c9923dc2a4397e6f5b57fe33f68a12615c5f880f33091ab13885cfdb3408d03cc065bdd3c893ffdfc0f5f8f4dd205c6fd193bfcc865ee20f13278679f51907596df2e847f9f4aa8df757417615d3907fd7ed2baffd3aa369ecf2ce5023c9038a9798d5a51b3b2be3ed64d21c6a78b32e50f7dfb4b9a4aa796b497987d69909058b6dcf8642ded7e5dbd9e22a5b10d74893c1e937ac9184706049742b133aea6a4204baf6775e112f43e407032c891db88047b2f0e31097bdfc89820122d25be67b9424b02278ff42c96383e8f07300d167d84d6330d4194361f4eadcee1f29c1b76938e7f6bf3d5e830dcdc36ff40ab98cc69784b7da18ef1375bfd1945d12ef0231fc85b90520ff7cf0c3ee00838873eeba3849aec098b137a5e0701780d7849d1cf786e38bd4ae5d926980fc50ef9348cbe9d78274e597e82914dfc440a6f34f9a44fd44973ee9266a416a1635a768155590f5159583759354509a05cd085ae5cca906f3f8b2111adee5cb60f7dfe7db6cf336ad051535ce6085c43f63826358c6bc7bc4188ec96a04baac1bbb7016b2e1e34c5f7d6fca38fd82827468566bcd866c11187e3664b0fb3f1b3231a1f8c9f7b857d2e1205410037c277afd19ab7dce49926d7b3ad4bab96de6db59034cd3e53c49a8eb67b340130213018cbafce0c359edd18cbc377244043a0686eef32d0f4aa06fb66c5477e402079861ebdccd43845394b8c853d5081df27a0856eca81ac1569191ba70df2b3cc1d271cc1b217e084a60a6fa84a9d3c227ae1fa1a0554b52cb8e5b18ef7bc943aeb9c011269c61ab26ba30d70742b800251f6950da3434762a16d76c8806afd534e66d2eec6adc95f8c4566cb2c57736d8a5f0df5ec5309b35b605e36c564917018c41bd5d18a838ab743500f9e0b26f062a9d980c062a5caaad18685d633b30d0ba4ade9c81e647d4aee32f9d57f7cd3ceb07e5ed6feb8deada816dd6f4b167a699fb9ed086410b1cabe67931e795f899690e6720a7389f25c2d5954d8483cf30ab876c56feaed60f759a4164236a025c195a0ba8b80e54809409d543b82296d7289df0227ac01671b74658b1f64bb0151b50b1abd7a21542f3e5a96c9c9d4e1f65cf4a6b508cbcd361a182a3310879f1aa77bc83524c715955315d7ce13ede70a56362301a14d4e2b91a94547466702d15a6d9ae259d43d6c725db484b92fb64d052d199c1b5246cb45d491aa7a0875bb0918aea5bf84093ad887494bb4d593776f28c295130760ca955e31b14453e595652ad448935cbf3aca63fccfa271f853986e3269a1ca452da9213a3315a62a9165883a4577e9cb00bc4d01cf138cfd40b1532edde6a58fe0b96d5ed531dc4621f28a8f9efbc85e112bfb6dfaa0e89c0b9825e86dcabc942e91a1bd037b778fa1b0a50ac89de4f699086c4ec64995be77778d5f679898a307624f915274ad198e2ead6d5df6970d48931e040957eccfa83658630a9bcf042ab4a3779a66694225055453105af7636782687a6f780c9fe62fff16a45789df9259254aa00a2a8274625cf4101abd47547ada7a25431eb35dd11a57c932aa454d543ca6a56494dc86ac55a78068dea29ba7350f348aae86a6d77644d4649155a53bd06b64666b9ae3baa26e9a40aaca9ee8ebdca409117d23ddec18ca7988db6b0fcb0bbd91e66c0789d5571982db072a75f05aa14f7c412b7f60a9828df4b8b329ef836b2a83cceb199451930cc2b50ed46bcbe00355ee39b316bd7dcb545bee99adf8cd7cf6e5fd53a94439f4c52722f0f7fd2216f2c0e5ced8f6c9413584e625b851a27f6cdcbecd760c4eb47d9cf69e063be9e17143788f80b9cb03cb7c33e1d9d4a6f74f6e7bd8c93245ea039b09a1ecdd4c76c0b595ae409c5ee238ad59c890dde94ac409570f435f1f0f3c4fe5fd6ea2c8b6cf05f59f181759d7c21feaf29543cc429b67e57734087c9b16f3e70ede98b88ee5abdfeefd7bce9817517c38439b30e255dae33c2f57712bda4c99b6e20cddaaf27deee84aa3d49d0a24a1362fd1708734a83419e1f041424cbeea1fa89a57d5db02e98e6f1c00050c328cdf430602d30e3ab000f3e59f62ae03ec6ae9f3fac3decdb79fd9b81b524353e18f009dbf8b940f795a868b9c3dd467334dac6aa94e9b935dd7aa3dccb5d6f4f4a56f6ba935e4dbaee86b4414ef51af6f0c6d29107db1635d9c68361efd2a05f3dc5785fb28a57f91ebb4d26de66fe70c3ddd0df2a6d780f12dd34893bbb4f0edeb6ad9982b87b9e61d92f0578cf8c4da473ed3ed177dbc6668aefeeb9b1f54ae7dd335bdbd5feb9634bebbc85ee3c3957cd33325cc6e882c06dc9b779c41c8ef9730a46907b94f99b497db65753a66a0bc3158999a939cd4c66ac4c1c85af42d1ccb65f5fc586dfd85941d3ccd6909cd9c45bacff8dbc054d336f43cae32ed286b54987ba54ee9675ac2913ea2da509d77ad29295dee6b336deacbfa5ace04194529b3d86cbe1b793043c884a869c3a3d927ed57b5ed83b2b7f7211f6efc45fae20f81f6024d8aded9a25cd3559d062f396242a48a408cd0d66c8832df53c66fe02b90caa7964397bf49d85ecf815c71c7bd7e42e6551caa0cb389c07b5801777029af86799cd7599c77711ff4a86e80288e9f300fd1df929f503af94fb4a1313324070ef42c471f958321ecf5dbe9448b794740412ea2b9da2071c460180257764869ef03ab281f97dc24be4beac22802690f681a8ab7d7ce1a3658cc24460acdac327d8b0173e7ff83f4cfc5bee79540000, '6.1.3-40302'),
('201607010721475_InitialCreate1', 'WebApplication1.Migrations.Configuration', 0x1f8b0800000000000400dd5d5b6fdcb8157e2fd0ff20cc6391f5c471b3d806f62e1c3b4e8dc6177892ddbe0d64891e0bd148b3ba646d14fd657de84fea5f2875e7ed88a42851e3c02f1e91fc7878f8f17ec8f3bffffcf7f897a76de87c43491ac4d1c9e2f0e0f5c2419117fb41b43959e4d9c30f3f2d7ef9f9cf7f3afee06f9f9c5f9b7847453c9c324a4f168f59b67bb75ca6de23dabae9c136f092388d1fb2032fde2e5d3f5ebe79fdfa6fcbc3c325c2100b8ce538c7777994055b54fec03fcfe2c843bb2c77c3abd847615a7fc721ab12d5b976b728ddb91e3a59fc86ee4f77bb30f0dc0c8b727850a55838a761e0626956287c58386e14c55919e1dd9714adb2248e36ab1dfee0869f9f7708c77b70c314d56578d745572dceeb374571965dc206cacbd32cde6a021e1ed5fa59b2c9076979d1ea0f6bf003d674f65c94bad4e2c9027f489e4bad2d1c36bb776761524485d47cd0257ee530515eb5f4c02c2afe5e39677998e5093a89509e252e4e729bdfe3f8ff40cf9fe3af283a89f2302485c5e2e230ea03fe749bc43b9464cf77e8812cc2a5bf709674e2259bba4dcb26ac0a791965476f16ce3516c3bd0f51cb0a4221ab2c4ed04714a1c4cd907feb66194a70a55efaa8d42b270293e17b9cf221f00237795e5f04499aad8bef4dfe9898b89d2d9c2bf7e9138a36d9e3c902ffbb702e8227e4375f6a99be44016e96385196e44820b3ba1c5781ef87682c41d4f3fde4ce56fc5b9c9117ecdc70d64ae8a4b059055dae3356c0f9cd7bfb996edd24c87044dc94f3741d489b7d3fdab720757157873631e6b229d8ad9ba6bb38c1d5916fef51625f37677549ece77c5d76ac6e58f69eb633dfa0c8478971f5dd9902ac4c013e6c8362444ad797e7339007d7dd3a7e58dfa134c003a137438772166f776ef43c5377f6e5f27cb696bbcaef3f2671be9ba9e82df16e1ed6bfe22ed1be04bfc5c9d7f5a7d8ab27c8d615504efcd6dd2cd27ad645b633648ec7513c7b4f1fb778ea3b4bf18328cd131777376baf6afdd12c2d6017e335cc0c63d7ed631ca1b97a9d0f5b370867d0f5639cc5934f9147eac7244569a67c5ebc1b833d8add74e0dbc9708bfcc0c38b0ccf4dc6e81afa338bb3473c8bf3632f2f3aa374f2fcceb12ad79f8329566bd7eeb760530e654c9e174188ce515636bb3b149651d2c76057ed711d74c16b7247e72289b7777148a52722ac3fbbc90665b818715fac559c279e86ac1fcb69b550ce2a0890910be4e4e363e8cab649e2344dddd02d163b22018bf055190e49298cc18b2a8ea62bef55b56a5dafca65ab50643a0a20351889131c8ea92b3b29ab5072f21320371085931a8aa72b73d1f9afbbe5b040682a0620351487131b8c2892fb78d96ddff66eea929d85f6a66e9778ce4ddd21fbb9dd2cf4635eaca835671745c1adecc17d78ca50948eb35c912e115476b8551b0749f6f106a186eafd8350d3720635886644d26e0c55c2391b02b147a5db1e94b7b7c63be198a6fd0c25a4e66c8325223c1f1946c26e463084895dea39e9b81a424485fdcdf128f8ab1be6fbc4c1a1134a8e8dfdf3ce4194646797daaca401e624267fbca3cb52dd03a2efb5d7345c4fb0bc95af3c0651975e5c6813974c3e276def863055e1c0693c72369ada2f921a2c1d5982ca969883e8c9ac23b5f949a59f93a0dc41b72e59354fcabfd75ed568db80a5ac747f6110671bc51679f451f6aa35373b4d77d7283b68121e5490170986fb234ebe1e9088af1ce5741dbddfa8d2fbe8f0fee1e8a7b73fbafed18f7f45476fedef39082876f8e6a7696c267a89fde6ed8fa3e40a32fd4b8a6b474872b2bed775b48ede7c28476c419451285d408d4feb0675ffa95d48cad35b3c23c1051ad2129a2c6cb78646de69f355661c314c171a1930f433082f7717d61e0764e7d1aa5da2422e6771f410245bd496f27d8c09e846838cfe708fe0ffdd4d1f27df085e212fc7cbb067bc08dbeea637321dd5364139afd1aae6f31ff185ebe1d9e787a848658cf729f6bec679f621f28ba3e32f99d700163fab8364458051c439f53c94a61798ccc83f8bf32833333e2c3aa9b9a72467a11b6cc57312a63b5d3751bb79893806373701a289e6277da27e8a3741a4266a131516b58a2115b58ea62b6a01a626691d1316b48c2095b38a35da8cafaca1f1a77c25ecfecff9cc06efe9d7e7734d18cbea1bc96a5221a729ce2306b586b21318bf3594b0fbdf1a4a31f1e76f417912acb0106a226378a5f8e23596bccd3192d96e0e54316d676ea70f809acb699ac65e50b602ce7286dca2a38b80a7718e923d435526da3202170e933d28863d2cd0c9e22f9c8664f0ad0951074fee26d2f0870b96b737d1390a51869c53afba917ae6a69eebf3358575e6d35f30d55152346ab75805a5b8a90651c6b78bfa82994a2198c4c266055cef2c246cf36243ced1ae38bb8f32958a3214a2cd8b519f4c5bc74b827efdace4ed1820caf41835747469ac6126a44a9f445a04e6dbc72016827a51a97cd004478b83a0228c45b0c140b1150358e9129306828ba4518c1d424aec776db2b2574d2abc1098e3e891b25719061258e0246ca70055bd82d14257fbac6d8c15722a98695be4a7545f2a049119e668f155aa9fb124b2c05fc88401e286d49ea163066d1c6385b952437d8bbc95684a852302bb1c2da24ad4612082056682b60a50e5cb0d17bada672c63ac90537e1fc3223b65ca52e186c42a478baa32e58c248f05de0acc0f2046f4d922745ca02d62ac50b5c70242205867d7300955612da990c270d10e6b42a9f7149a3158222270e604d5b9ec00aaab77cebac00a2725275f002febd3974988d9af310be4ec57898a00a049ce1c04ad4f1a5509c01e3bee1b4199f34e80a0f581881582d21a9b81a0b44a5e1c41ab0366d5fa674e9bf78d9ef431b7fd61bd575d337093d2c79e51b33a39c269329c02253c3dcfef8b40f494098e56b19cf5e96a5a1f54b11429c0572813d890774756828509776644e390e74d1c0e1928c1694e0a388c2640969edcdde541c8500912bb1bc781b1112478f40e098746074bb098152d07c684cb24ab4c6938147a2d2201613b923ec0aeb39180d606dd1c10d7a96a08d75863f54a57cf2435601bcba95ed87afc6760897e40d4a0a8ab1b44dcde3bf06c37a57a84dc16916ed25cb7a77a664ce0f5f4264b5a050aea115cb4e6552339c574fa4f0d052a117742129cc95501dcf715e843e14ccd5138b9126906ee595510a7d651cf0d535e4d8ac73c9a073d44d1fa470ecde399a95406de77e415a674aea075b24014aa6f60d43a0f984a51f03d3b5e536afbdc7a3bdd44b97ac77dbdfde9a9b425bab0c5eb49b6afaabab34af2a89a94f4e8a4672394c0114c748c9502598cf38a51d9e7d3d9e9230a5657468f8224bb7280929ac28caea566ca25d79268b34967bbc9484bccd610a0a5a630a36ba9e6a85c49820d0f8d2d0f2315d1db132335b6c606b35d49b761c7cbcaaf47fde17809380039be7277bb20da100e41ea2fceaaf20672f6c34adf45c6b6c2587a94b6d9757f9b531627ee0631a1c50bd43e2abd099cbb997bef1616a867fe968b26dc370096354d96dcd6005f93cd22a74952fc5f25937aee10ecb7d42817b8a0c5839a6599917804e2123b859796624209bd44761687f936925855c238900b0d12168a332c17ca3b03940d1569583e843f062817228a7a1e626f176416e218437200750544199207a027610475fcd2250589577e504fcfdb149160728b2318993b5a2781a5e7ee3d1a659d4e50da6403d571bb092f09084f836124ca3704094605a8e31146b4245a8f6d2d8c75c7a208ad75e0f42b36bdd08e124e4f797ca0fa543240a3d602ce8903557d7cb00636e59d8182a542d411498f0b241ef95da32e681f0a54add04103eaa7758c20aca436541d99717840c232411ad29683fb5a303e379fb5b1aa0b7602b42a40038ff334408172a1eac8800701121e88a29e47e31e80046dbe69f4d5e4857aaa9f260374d859ee23d394146e2df794ac7a8c9f2a58f5491d836f19baad8179479f92860e1ad076dbd7f2856db70dd5982550cfe25333042a441d917bfb9e04e50235e643dd1bf7d4aca8fbcc631d2f999503773acbad54b833747aeda3b432224e46465819c1680a2ba3bec490a6d91e4daf0feb1ead2631baaf1aacef5ea5a6e8de7dd61a03b4567b3331a73e401a8135622405c640096dcc6179de409c99ab7e8863ac312a098653a9a9bed4534df3ebc703a811b2fab43795c41c9f8d504ffd880a552503b0bf88dffba6469deb8d50877d780a35d89f7caa4539fdd42d054485ec4dadd1278c23545b2fa042bd49d2dbdee3daff66079cf268571c651da65f6ffdc9a799baee7de5f0c75d2356546b7537bcb2600870dfacb69ba5f6cc005b5a18a5b95a437590c0759bd92a0f3253d0ae30d6ba51bfbea408d3b4af313679d8272f3930224cefe8a17bfa923d77e84234b670e9f72da919371d34dfa69bf8a54a0078905ef9772b49743e541d59f08225092d081e802d90990d5347153c7249020b82358e1fda172fd98e748f4730d036c96808ab4cb3cdc63000639a5e719c21907843903acfea3e6b620916fae4f7bd641468c765c4a8ca2adf8c510006dc03512ff0d11d50efb3813026f5ac1e6da8d0f3ac208ca7c7db49d9c19972b151dadceb2fedefd694ab36a3a2ecbbca9217d65a6589d3daa48bb5abaaa22c9c468d278babe7d5efe141117e50fe7b1606a8e8cf9b18576e143ca034abde925cbc3d78bb704ec3c04d2bcbbbda62ec1d7b794bc984ecf0a8302143fe76c926d737442b50d2d4a78e0ef8173d21e32bb55730813d78f923956dc2ea2e4d502858fafeabe6639090dd56956518479bea9a9d012c657d04e3aa3cee0a1866190a2bb6c51a0d74c4f20b0dae0c052d8dae0c3120376e2565b91b9a97918f9e4e16ff2a13bf732effb966d3bf726e12dc8bbc735e3bffd61606707ea42a0b93dc4814cea4cb50cf9d4597211065cd6588c5b93c55d5749bd048c777fa19df1966b9d2cf72659825656266ca22deb0cc1491b2293304230dca0ca11853324334de82cc1090b11d3315afb31c1b07897caf7d3816672c660808988719a236f661a6a33eef85c5806e84839de105abecc3cce61d32b6ab6030a6616660bc4198191e6d0a6686c5598099c111e65f3a40caee0a20fb291b0e2f367931926a32ba33b432e450676565082458a7294c09ea641ad30275b7e7020b27b5fa048d9ae4d52a9e078ebd60d5aff941cee207a8ced44dfb24eaa23ca18cacaf3e939fb91d88bf34eec1c637767c5a4fa22f911beb91f5d663fc32afafe5974640d81ac5c64420fae626dea39bf07e680c34d481ca46e3a2d0c57fe5e757ce65fa250a7ecf71c067acd0625866fdea8d334cf71b95eca9975975ade2394e95949ee218d630ed7b564b9a2aa98134833dd2bedc0645ad4285a84c8318eed5f53e8ec3515cba0e9dc80b3db60edeab57db0a30f5b73a486990b3d54160a0a7551fffccca85eb6d82bca0f43fb778ad5b78b11fd64192824e58cbc1dad005ab7a4fd4a49c71b411987fd8e895269914edd7f0c479ba1cdae879479613cdf800e38defd2c5e368c3e22defc17134ec39093d95db4622ca0c5e14456f750e761639e8f967484500e9019b11679803c6efd0dde27cce15b5993caa3b458bce133529fb72dd25ceec1c713642f55ecd55dadf9e924f2fd7c9e1fc2e0de7a294f416b1fe11c09414fb0e9c12ceed82702ea649ee3a2b1d904c49ad97ea487076b78173114a760b5bfbe4684a76bd68d77ffbe2edaff3c12190c7a2933f9b7efd7a6e40ab9e17592297993bbf3d70402570a602f0cca2d33edb5c83ae2a6a9c63eebf6bbe3d235bed6207209b45077cb6c906dd62dc73b269b9d9db33aecd357ececc34e5217476a779fc1bf96cb5d6574ec95d60156f78d59dd093857f5f589757e7095db8dc199cb2bb3c51465db83c23a93f3d5106559802b8bab33d61366d8440e0d881cd4cdb1f9f28cb297df689f22363c8b3d374eb27ca50cff31fbdfee0f2a38345d99da6bb6b94893d734099759d2398611705ce147609c266cc0d145cbe5c8cfe6cf5ca5a4f707b0b5bc7e9cf1670a4d397773ddfe9cdbb8ed39f37e09ec6aeeb42be7b96f8a7a252f37daec4cde1feb825d47542a8ada8bd753b38c8c9a08de25bf62838d47fa00d5558f31438cc2fa00d15d8f40138d0e39f0d354cecdc4fe81a4ce44858b26213a0802e89f7d9991f5512894f64d9ee1ca013b123e47df6dd378a52a87913f0d8d3f84a99ca55df282a19b3e968b8e6e3df6d3a5edee55161595dfd3a4769b0e9208e3166843c6a7fa08d73193dc4cd360523511385b146bcc23343dfcddcd3240b1e5c2fc3c1851575106d164e699e5a98f3df23ff32bac9b35d9ee122a3ed7d4875c5c576475ffea5ff415ae6e39b5d39b68d51042c665018a3df44eff320f45bb92f04f68f0044b18f52db2c17759915b6cb9be716e93a8e14816af5b5db3f9fd176171657d96fa295fb0d0d910dd3ef13dab8de7367ed0a81c82b8256fbf179e06e12779bd6185d7afc1373d8df3efdfc7fdb51900fc5d60000, '6.1.3-40302');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id` (`Id`),
  ADD KEY `UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`,`UserId`),
  ADD KEY `ApplicationUser_Logins` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IdentityRole_Users` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `entrymodels`
--
ALTER TABLE `entrymodels`
  ADD PRIMARY KEY (`EntryId`),
  ADD KEY `IX_maritalstatus_id` (`maritalstatus_id`) USING HASH,
  ADD KEY `IX_visacategory_id` (`visacategory_id`) USING HASH,
  ADD KEY `IX_gender_id` (`gender_id`) USING HASH,
  ADD KEY `IX_Rid` (`Rid`) USING HASH,
  ADD KEY `IX_Sid` (`Sid`) USING HASH;

--
-- Indexes for table `genders`
--
ALTER TABLE `genders`
  ADD PRIMARY KEY (`gender_id`);

--
-- Indexes for table `grosssalaries`
--
ALTER TABLE `grosssalaries`
  ADD PRIMARY KEY (`Sid`);

--
-- Indexes for table `marital_status`
--
ALTER TABLE `marital_status`
  ADD PRIMARY KEY (`maritalstatus_id`);

--
-- Indexes for table `my_aspnet_applications`
--
ALTER TABLE `my_aspnet_applications`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `my_aspnet_membership`
--
ALTER TABLE `my_aspnet_membership`
  ADD PRIMARY KEY (`userId`);

--
-- Indexes for table `my_aspnet_paths`
--
ALTER TABLE `my_aspnet_paths`
  ADD PRIMARY KEY (`pathId`);

--
-- Indexes for table `my_aspnet_personalizationallusers`
--
ALTER TABLE `my_aspnet_personalizationallusers`
  ADD PRIMARY KEY (`pathId`);

--
-- Indexes for table `my_aspnet_personalizationperuser`
--
ALTER TABLE `my_aspnet_personalizationperuser`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `my_aspnet_profiles`
--
ALTER TABLE `my_aspnet_profiles`
  ADD PRIMARY KEY (`userId`);

--
-- Indexes for table `my_aspnet_roles`
--
ALTER TABLE `my_aspnet_roles`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `my_aspnet_sessioncleanup`
--
ALTER TABLE `my_aspnet_sessioncleanup`
  ADD PRIMARY KEY (`ApplicationId`);

--
-- Indexes for table `my_aspnet_sessions`
--
ALTER TABLE `my_aspnet_sessions`
  ADD PRIMARY KEY (`SessionId`,`ApplicationId`);

--
-- Indexes for table `my_aspnet_sitemap`
--
ALTER TABLE `my_aspnet_sitemap`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `my_aspnet_users`
--
ALTER TABLE `my_aspnet_users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `my_aspnet_usersinroles`
--
ALTER TABLE `my_aspnet_usersinroles`
  ADD PRIMARY KEY (`userId`,`roleId`);

--
-- Indexes for table `relationships`
--
ALTER TABLE `relationships`
  ADD PRIMARY KEY (`Rid`);

--
-- Indexes for table `visa_category`
--
ALTER TABLE `visa_category`
  ADD PRIMARY KEY (`visacategory_id`);

--
-- Indexes for table `__migrationhistory`
--
ALTER TABLE `__migrationhistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `entrymodels`
--
ALTER TABLE `entrymodels`
  MODIFY `EntryId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
--
-- AUTO_INCREMENT for table `genders`
--
ALTER TABLE `genders`
  MODIFY `gender_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `grosssalaries`
--
ALTER TABLE `grosssalaries`
  MODIFY `Sid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `marital_status`
--
ALTER TABLE `marital_status`
  MODIFY `maritalstatus_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `my_aspnet_applications`
--
ALTER TABLE `my_aspnet_applications`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `my_aspnet_personalizationperuser`
--
ALTER TABLE `my_aspnet_personalizationperuser`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `my_aspnet_roles`
--
ALTER TABLE `my_aspnet_roles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `my_aspnet_sitemap`
--
ALTER TABLE `my_aspnet_sitemap`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `my_aspnet_users`
--
ALTER TABLE `my_aspnet_users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `relationships`
--
ALTER TABLE `relationships`
  MODIFY `Rid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `visa_category`
--
ALTER TABLE `visa_category`
  MODIFY `visacategory_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `ApplicationUser_Claims` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `ApplicationUser_Logins` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `ApplicationUser_Roles` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  ADD CONSTRAINT `IdentityRole_Users` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Constraints for table `entrymodels`
--
ALTER TABLE `entrymodels`
  ADD CONSTRAINT `FK_EntryModels_Genders_gender_id` FOREIGN KEY (`gender_id`) REFERENCES `genders` (`gender_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_EntryModels_GrossSalaries_Sid` FOREIGN KEY (`Sid`) REFERENCES `grosssalaries` (`Sid`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_EntryModels_Marital_Status_maritalstatus_id` FOREIGN KEY (`maritalstatus_id`) REFERENCES `marital_status` (`maritalstatus_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_EntryModels_Relationships_Rid` FOREIGN KEY (`Rid`) REFERENCES `relationships` (`Rid`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_EntryModels_Visa_Category_visacategory_id` FOREIGN KEY (`visacategory_id`) REFERENCES `visa_category` (`visacategory_id`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
