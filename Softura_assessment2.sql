--Softura Assessment 2

use pubs

--1) Print the city name and the count of authors from every city
select * from authors
select city,count(au_fname) countOfAuthors from authors  group by city

--2) Print the authors who are not from the city in which the publisher 'New Moon Books' is from.
select * from authors
select * from publishers
select * from titleauthor
select * from titles

select au_lname,au_fname from authors where city != (select city from publishers where pub_name='New Moon Books')

--3) Create a procudure that will take the author first name and last name and new price 
--The procedure should update the price of the books written by the author with the give name
select * from authors
select * from titles
create proc proc_UpdatePriceOfTheBookAuthor(@au_fname varchar(50),@au_lname varchar(50),@new_price float)
as
begin
   update titles set price=@new_price 
   where title_id =(select title_id from titleauthor where au_id =(select au_id from authors where au_fname=@au_fname and au_lname=@au_lname))
end
exec proc_UpdatePriceOfTheBookAuthor 'Johnson','White',20.99


--4) Create a function that will calculate tax for the sale of every book
--If quantity <10 tax is 2%
--10 -20 tax is 5%
--20 - 50 tax is 6%
--above 30 tax is 7.5%
--The fuction should take quantity and return tax

select * from sales
create function fn_CalculateTaxSalesBook(@qty int)
returns float
as
begin
declare
	@tax float
	if(@qty<10)
		set @tax=2
	else if(@qty>=10 and @qty<=20)
		set @tax=5
	else if(@qty>20 and @qty<=50)
		set @tax=6
	else
		set @tax=7.5
	return @tax

end
select qty,dbo. fn_CalculateTaxSalesBook(qty) 'Tax' from sales
