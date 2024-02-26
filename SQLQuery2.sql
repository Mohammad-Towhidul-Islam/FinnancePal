CREATE TABLE UserRegistration (
   
    first_name VARCHAR(500) NOT NULL,
    last_name VARCHAR(500) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    contact_number BIGINT NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL
);

select *from UserRegistration;