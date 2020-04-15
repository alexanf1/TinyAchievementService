# TinyAchievementService
A minimal and general-purpose .NET Core achievement web API

## Prerequisites

You need a MySQL database server (5.0+) and run the commands below through a 
user that has the following privileges:

    SELECT, INSERT, UPDATE, DELETE, 
    CREATE, DROP, RELOAD, REFERENCES, 
    INDEX, ALTER, SHOW DATABASES, 
    CREATE TEMPORARY TABLES, 
    LOCK TABLES, EXECUTE, CREATE VIEW
    
## Installation:

1. Download or clone this repository
2. Then run the following commands from the 'Db' directory <b>in order</b>

    mysql < tinyachievements-schema.sql
    
    mysql < tinyachievements-data.sql
    
    

