CREATE TABLE person (
    Enroll INT PRIMARY KEY,
    name VARCHAR(100),
    branch VARCHAR(50)
);

INSERT INTO person (Enroll, name, branch)
VALUES (01, 'shruti', 'IT');

INSERT INTO person (Enroll, name, branch) VALUES
(2, 'vruti', 'CSE'),
(3, 'Neha', 'ECE'),
(4, 'stuti', 'ME'),
(5, 'Priya', 'IT');


SELECT * FROM person;

SELECT * FROM person WHERE branch = 'IT';

update person 
set name='dabhi shruti'
where branch='IT';

update person
set name='priya'
where branch='IT' and Enroll=5;


SELECT branch, COUNT(*) as total_students
FROM person
GROUP BY branch;

SELECT * FROM person
ORDER BY name ASC;


