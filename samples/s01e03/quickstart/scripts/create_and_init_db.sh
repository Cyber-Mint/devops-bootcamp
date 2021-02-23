/* Drop the database if it exists and recreate it. 
*  (be careful using this as it will erase any data in an existing database)
*/
USE master
IF EXISTS(select * from sys.databases where name='teamfu')
DROP DATABASE teamfu

CREATE DATABASE teamfu
ON   
( NAME = teamfu_dat,  
    FILENAME = '/var/opt/mssql/data/teamfu_data.mdf',  
    SIZE = 10,  
    MAXSIZE = 50,  
    FILEGROWTH = 5 )  
LOG ON  
( NAME = teamfu_log,
    FILENAME = '/var/opt/mssql/data/teamfu_log.ldf',  
    SIZE = 5MB,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB ) ;  
GO