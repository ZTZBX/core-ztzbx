/*
CORE ZTZBX SQL SCRIPT
*/

CREATE TABLE players (
    game_id int NULL,
    username varchar(50) NOT NULL,
    password varchar(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    UNIQUE (game_id),
    PRIMARY KEY(username)
)ENGINE=InnoDB;