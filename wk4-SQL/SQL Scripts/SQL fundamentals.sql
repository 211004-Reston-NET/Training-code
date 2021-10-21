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
		
insert into fingers(finger_length, finger_type, person_SSN)
	values(3, 'Pointy finger', 2),
		(1, 'Pinky finger', 1)

--Quick example of inner joins
select p.person_name, f.finger_type from person p
inner join fingers f on p.SSN = f.person_SSN 
		