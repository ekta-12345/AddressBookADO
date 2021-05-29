----Create table AddressBook----
Create table AddressBookSys
(FirstName varchar(50),
LastName varchar(50),
Address varchar(50),
City varchar(50),
State varchar(50),
Zip varchar(6),
PhoneNumber varchar(10),
EmailId varchar(50),
AddressBookType varchar(50),
AddressBookName varchar(50) );

----insert record for table----
insert into AddressBookSys values
('Ekta','Kumbhare','Aundh','Pune','Maharashtra','411008','7709283353','ektakumbhare3@gmail.com','Family','Ekta');
select * from AddressBookSys;

drop table AddressBookSys