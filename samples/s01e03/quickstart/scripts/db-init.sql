/*
* Create a table or two
*/

USE teamfu;
IF (OBJECT_ID(N'[dbo].[lists]','U') IS NULL)
BEGIN
  CREATE TABLE [dbo].[lists]
  (
    list_id INT NOT NULL IDENTITY PRIMARY KEY,
    list_name VARCHAR(255),
    list_owner_id INT
  );
END

IF (OBJECT_ID(N'[dbo].[tasks]','U') IS NULL)
BEGIN
  CREATE TABLE [dbo].[tasks]
  (
    task_id INT NOT NULL IDENTITY PRIMARY KEY,
    task_name VARCHAR(255),
    task_description VARCHAR(255),
    owner_id INT,
    percent_complete TINYINT,
  );
END
