CREATE DATABASE ToDoListDB;

CREATE TABLE tasks (
	task_id INT PRIMARY KEY IDENTITY(1,1),
	title NVARCHAR(255) NOT NULL,
	description NVARCHAR(MAX),
	create_date DATETIME DEFAULT GETDATE(),
	due_date DATETIME,
	status BIT DEFAULT 0
);

CREATE TABLE category (
	category_id INT PRIMARY KEY IDENTITY(1,1),
	name NVARCHAR(255) NOT NULL
);

CREATE TABLE colors (
	color_id INT PRIMARY KEY IDENTITY(1,1),
	name NVARCHAR(255) NOT NULL
);


--CONSTRAINT - �� ������� �����, �� ����� �� ��������� ������ ��������� (constraint) �� �������.
--FK_tasks_category_id - ����� ���������, �� �� ���������.

ALTER TABLE category
ADD color_id INT,
CONSTRAINT FK_colors_color_id FOREIGN KEY (color_id) REFERENCES colors(color_id);

ALTER TABLE tasks
ADD category_id INT,
CONSTRAINT FK_tasks_category_id FOREIGN KEY (category_id) REFERENCES category(category_id);

EXEC sp_rename 'category', 'categories';
