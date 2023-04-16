CREATE DATABASE ToDoListDB;

CREATE TABLE tasks (
	id INT PRIMARY KEY IDENTITY(1,1),
	title NVARCHAR(255) NOT NULL,
	description NVARCHAR(MAX),
	create_date DATETIME DEFAULT GETDATE(),
	due_date DATETIME,
	status BIT DEFAULT 0
);

CREATE TABLE category (
	id INT PRIMARY KEY IDENTITY(1,1),
	name NVARCHAR(255) NOT NULL
);

CREATE TABLE colors (
	color_id INT PRIMARY KEY IDENTITY(1,1),
	name NVARCHAR(255) NOT NULL
);


--CONSTRAINT - це ключове слово, що вказує на створення нового обмеження (constraint) на таблиці.
--FK_tasks_category_id - назва обмеження, що ми створюємо.

ALTER TABLE category
ADD color_id INT,
CONSTRAINT FK_colors_color_id FOREIGN KEY (color_id) REFERENCES colors(color_id);

ALTER TABLE tasks
ADD category_id INT,
CONSTRAINT FK_tasks_category_id FOREIGN KEY (category_id) REFERENCES categories(id);

EXEC sp_rename 'category', 'categories';


ALTER TABLE categories
DROP  CONSTRAINT FK_colors_color_id;
DROP TABLE colors;

ALTER TABLE categories
DROP  COLUMN color_id;

EXEC sp_rename 'categories.category_id', 'id', 'COLUMN';

DROP DATABASE ToDoListDB


-- Inserting values into the "categories" table
INSERT INTO categories (name)
VALUES ('Work'), ('Personal'), ('Shopping'), ('Errands');

-- Inserting values into the "tasks" table
INSERT INTO tasks (title, description, due_date, category_id)
VALUES ('Finish project report', 'Write and format project report for presentation', '2023-04-15', 1),
       ('Buy groceries', 'Get milk, eggs, bread, and vegetables from the store', '2023-04-10', 3),
       ('Call plumber', 'Schedule appointment to fix leaky faucet in the bathroom', NULL, 4),
       ('Go for a run', 'Run for 30 minutes in the park', '2023-04-09', 2);



SELECT * FROM categories

SELECT tasks.title AS 'Task', categories.name AS 'Category'
FROM tasks
JOIN categories ON tasks.category_id = categories.id;

INSERT INTO tasks (title, description, create_date, due_date, status, category_id)
VALUES 
  ('Task 1', 'Description of task 1', GETDATE(), GETDATE()+7, 0, 1),
  ('Task 2', 'Description of task 2', GETDATE(), GETDATE()+14, 0, 2),
  ('Task 3', 'Description of task 3', GETDATE(), GETDATE()+21, 0, 3),
  ('Task 4', 'Description of task 4', GETDATE(), GETDATE()+28, 0, 1),
  ('Task 5', 'Description of task 5', GETDATE(), GETDATE()+35, 0, 2),
  ('Task 6', 'Description of task 6', GETDATE(), GETDATE()+42, 0, 3),
  ('Task 7', 'Description of task 7', GETDATE(), GETDATE()+49, 0, 1);


  --inner join
SELECT t.id, t.title, c.name
FROM tasks t
INNER JOIN categories c ON t.category_id = c.id;

--left
SELECT tasks.title, categories.name
FROM tasks
LEFT JOIN categories ON tasks.category_id = categories.id;

SELECT t.id as Id, title as Title, description as Description, 
create_date as CreatedDate, due_date as DueDate, status as Status, 
categories.name as Category FROM tasks t INNER JOIN categories ON t.category_id = categories.id

SELECT id as Id, title as Title, description as Description, create_date as CreatedDate, 
                due_date as DueDate, status as Status FROM tasks

SELECT id as Id, name as Name FROM categories

ALTER TABLE tasks DROP COLUMN description;
