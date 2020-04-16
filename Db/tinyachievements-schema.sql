DROP SCHEMA IF EXISTS Tinyachievements;
CREATE SCHEMA Tinyachievements;

USE Tinyachievements;

CREATE TABLE IF NOT EXISTS Tinyachievements.Achievement (
  Id CHAR(36) NOT NULL UNIQUE PRIMARY KEY,
  ApiName CHAR(64) NOT NULL,
  DisplayName CHAR(64) NOT NULL,
  Description CHAR(128) NOT NULL,
  MetaData JSON NOT NULL
);

CREATE TABLE IF NOT EXISTS Tinyachievements.PlayerAchievement (
  PlayerId CHAR(36) NOT NULL REFERENCES Tinyachievements.Player(Id),
  AchievementId CHAR(36) NOT NULL REFERENCES Tinyachievements.Achievement(Id),
  Earned BOOL NOT NULL,
  PRIMARY KEY (PlayerId, AchievementId),
  UNIQUE (PlayerId, AchievementId)
);

CREATE TABLE IF NOT EXISTS Tinyachievements.Player (
  Id CHAR(36) NOT NULL UNIQUE PRIMARY KEY
);
