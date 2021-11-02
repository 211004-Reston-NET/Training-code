
-------------------- Our initial setup of Database -------------------- 
CREATE TABLE role (
	role_id serial PRIMARY KEY,
	role_title varchar(50),
	role_salary integer
);


CREATE TABLE employee (
	employee_id serial PRIMARY KEY,
	first_name varchar(30),
	last_name varchar(30),
	role_id integer REFERENCES roles(roles_id) --FOREIGN KEY REFERENCES TO the roles TABLE specifically the roles_id column
);

INSERT INTO role(roles_title, roles_salary)
	VALUES ('CEO', 100000),
			('Scientist', 80000),
			('Fry Cook', 50000),
			('Cashier', 27000),
			('Interns', 10000);
			
INSERT INTO employee(first_name, last_name, role_id)
	VALUES ('Eugene', 'Krabs', 1),
			('Spongebob', 'Squarepant', 3),
			('Sandy', 'Cheeks', 2),
			('Squidward', 'Tentacles', 4),
			('Sheldon', 'Plankton', 2);

-------------------- End of Statement -------------------- 

-------------------- Set Operations -------------------- 

--Adding a Cashier first name in employee for duplicated value
insert into employee (first_name) values ('Cashier');

--Union
select first_name from employee
union
select role_title from role

--Union all
select first_name from employee
union all
select role_title from role

--Except
select first_name from employee
except
select role_title from role

--Intersect
select first_name from employee
intersect
select role_title from role 

-------------------- User-defined Functions -------------------- 

--Example of a Scalar Function
--A function that will reduce the employee's salary
create function reduceEmpSalary(
	@reduction int,
	@name varchar(30)
)
returns int
AS 
begin
	declare @newSalary int;
	
	set @newSalary = (select (r.role_salary - @reduction) from employee e 
	inner join role r on r.role_id = e.role_id
	where e.first_name = @name);

	return @newSalary;
end;

select dbo.reduceEmpSalary(100, 'Spongebob');

--Example of a Table function
--A function that will return the inner join table of employee and role
create function employeeWithSalary()
returns TABLE 
as
return
(
	select e.first_name, e.last_name, r.role_salary from employee e
	inner join role r on r.role_id = e.role_id
);

--Gets employees with salaries that is above the avg of employee's salary
select * from dbo.employeeWithSalary()
where role_salary > (select avg(role_salary) 
					from dbo.employeeWithSalary());

-------------------- Stored Procedure --------------------
				
--It will add employee or/and role in table
alter procedure proc_addData(
	@which varchar(30),
	@first_name varchar(30) = null, --Adding null will give this parameter a default value of null if not given data
	@last_name varchar(30) = null,
	@role_id varchar(30) = null,
	@role_title varchar(30) = null,
	@role_salary varchar(30) = null,
	@status bit output --Will return if procedure is successful or not
)
as
begin
	if(@which = 'employee')
	begin 
		insert into employee(first_name, last_name, role_id)
			values(@first_name, @last_name, @role_id);
		set @status = 1;
	end
	if(@which = 'role')
	begin
		insert into role(role_title, role_salary)
			values(@role_title, @role_salary);
		set @status = 1;
	end
	else
	begin
		set @status = 0;
	end
end;

declare @currentStatus bit;
exec proc_addData @which = 'fea', @role_title = 'Test', @role_salary = 10, @status = @currentStatus output;
select @currentStatus;


-------------------- Triggers -------------------- 

--Will add 10000 from everyone's salary when an employee is removed
create trigger employee_removed on employee
after DELETE 
as 
begin
	update role set role_salary = role_salary + 10000;
end;

delete from employee 
where first_name = 'Test';

--Will deduct 10000 from everyone's salary when an employee is added
create trigger employee_added on employee
after insert
as 
begin 
	update role set role_salary = role_salary - 10000;
end

insert into employee (first_name) values('Test');

-------------------- View -------------------- 
create view EmployeeDetails
as
select
	first_name as "First Name",
	last_name as "Last Name",
	role_salary as Salary
from dbo.employeeWithSalary()

select * from EmployeeDetails

--We cannot DML or DDL into virtual tables to protect from malicious intent
--insert into EmployeeDetails("First Name", "Last Name", Salary)
--	values ('Test' , 'Test', 57000)
--	
--alter table EmployeeDetails add active bit;

--If you really want user to change values into virtual tables you need to use triggers
--(I'll let you research how to implement that)




