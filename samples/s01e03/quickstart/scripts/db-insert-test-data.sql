use teamfu;
INSERT INTO [dbo].[lists](list_name, list_owner_id) 
SELECT 'My first list', 1;

INSERT INTO [dbo].[tasks](task_name, task_description, owner_id, percent_complete)
SELECT 'create a task', 'create an awesome task', 1, 0;
  