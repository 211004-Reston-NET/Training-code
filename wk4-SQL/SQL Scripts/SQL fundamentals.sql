------------- DDL or Data Definition Language -------------

--Will create a new table if you use create statement
create table avenger(
	avenger_name varchar(50),
	avenger_power varchar(50),
	real_name varchar(50),
	power_level int
);


--Alter will change the table either add column, constraints or remove them
alter table avenger add dead bit;

alter table avenger drop column dead;

--Dropping the table from the database (basically means deleting out of existence)
drop table avenger;

------------- DML or Data Manipulation Language -------------

--Insert will add data to a table
insert into avenger(avenger_name, avenger_power,real_name , power_level)
	values('Capt. America', 'Drugs', 'Steve Rogers', 200)

--Select will display data from a table
select * from avenger

select avenger_name, power_level from avenger

--Delete will remove data from the table
delete from avenger
where avenger_name = 'Capt. America'

insert into avenger(avenger_name, avenger_power,real_name , power_level)
	values('Capt. America', 'Drugs', 'Steve Rogers', 200),
		('Ironman', 'Money', 'Tony Stark', 9999)
		
------------- Multiplicity -------------

--One to One Relationship	
create table heart(
	heart_size int,
	heart_healthy bit,
	person_SSN int unique foreign key references person(SSN) --This will automatically fill in some auto generate named for the foreign key
)

insert into heart(heart_size, heart_healthy)
	values (1000, 1) --Cannot add another heart to Colin which has an SSN of 2

--One to Many Relationship
create table person
(
	SSN int,
	person_name varchar(50),
	person_age int,
	
	--constraint keyword tells SQL an upcoming constraint is about to added
	--primary key constraint is what we are adding in
	--(column) this is what specifies what column it is adding the constraint
	constraint primary_key_SSN primary key (SSN)
)

create table fingers(
	finger_length int,
	finger_type varchar(30),
	person_SSN int,
	
	--references will reference the table and column this foreign key constraint is going to point
	constraint foreign_key_SSN foreign key (person_SSN) references person(SSN)
)

insert into person(SSN, person_name, person_age)
	values(1, 'Adam', 24),
		(2, 'Colin', 26)
		
insert into person(SSN, person_name, person_age)
	values(5, 'Pinky', 10)
		
insert into fingers(finger_length, finger_type, person_SSN)
	values(3, 'Pinky', 2)


--Many to Many relationship
create table class(
	class_id int primary key,
	class_name varchar(30)
)

insert into class(class_id, class_name)
	values (1, '.NET course'),
			(2, 'Intro to Psychology'),
			(3, 'Home economics')

-- Join table of person and class
create table person_class(
	person_SSN int foreign key references person(SSN),
	class_id int foreign key references class(class_id)
)

--We inserted value that will always refernce to another row in both person and class table
insert into person_class (person_SSN, class_id)
	values (2, 1), -- 2 SSN which is Colin will have 1 class id which is the .NET course
			(1, 1), -- Since Adam will also point to 1 class id which is .NET, both Colin and Adam will have the .NET course
			(1, 2), -- 1 SSN which is Adam will have multiple class id to indicate that person will have multiple classes
			(1, 3)

-- This inner join will point to how many students are currently taking the .NET course
select p.person_name, c.class_name from person p
inner join person_class pc on p.SSN = pc.person_SSN 
inner join class c on c.class_id = pc.class_id 
where c.class_id = 1 -- Just change the where clause to limit what type of data you are looking for

-- This inner join will poin to how many courses Adam is currently taking 
select p.person_name, c.class_name from person p
inner join person_class pc on p.SSN = pc.person_SSN 
inner join class c on c.class_id = pc.class_id 
where p.SSN = 1 -- In this case, I'm looking for a person_SSN instead

-- Overall these inner joins just select data from the many to many relationship into one to many relationship that SQL understands


--------------------- Joins ---------------------

--Example of inner join
select * from person p
inner join heart h on p.SSN = h.person_SSN 

--Example of left join
select * from person p 
left join heart h on p.SSN = h.person_SSN 

--Example of right join
select * from person p 
right join heart h on p.SSN = h.person_SSN 

--Example of full join
select * from person p 
full join heart h on p.SSN = h.person_SSN

--Example of cross join
select * from person p 
cross join heart h

----------------- Subquery ---------------------

--Old way
select avg(p.person_age) from person p 

--How do we select every person that is above the average when using the aggregate function avg()
select * from person
where person_age > 24

--Subquery way
select * from person
where person_age > (
	select avg(person_age) from person
)

--------------------- Union ---------------------

--Two query statements must have the same # of columns and same datatypes
--Example of Union
select p.person_name from person p
union
select f.finger_type from fingers f 

--Example of Union All
select p.person_name from person p
union all
select f.finger_type from fingers f 

--Example of Except
select f.finger_type from fingers f
except
select p.person_name from person p 

--Example of Intersect
select f.finger_type from fingers f
intersect
select p.person_name from person p 

