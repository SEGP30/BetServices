create table Clients(
    
    Id       bigint primary key,
    Names    varchar(50),
    Surnames varchar(50),
    Gender   int,
    Credit   bigint,
    CreationDate datetime,
    UpdateTime datetime,
    EntityState int
    
);
