/*
CORE ZTZBX SQL SCRIPT
*/

CREATE TABLE players (
    username varchar(50) NOT NULL,
    email varchar(150) NOT NULL,
    `password` varchar(255) NOT NULL,
    token varchar(255) NULL,
    `group` varchar(100) NOT NULL, 
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY(username)
)ENGINE=InnoDB;