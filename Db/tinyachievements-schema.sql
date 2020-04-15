DROP SCHEMA IF EXISTS tinyachievements;
CREATE SCHEMA tinyachievements;
USE tinyachievements;

CREATE TABLE Achievement (
  Id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  Name CHAR(64) NOT NULL,
  Description CHAR(128) NOT NULL,
  MetaData JSON NOT NULL,
  PRIMARY KEY  (Id)
);
