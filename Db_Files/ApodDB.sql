CREATE TABLE apod (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    copyright VARCHAR(1000),
    date DATE,
    explanation VARCHAR(1000),
    hdurl VARCHAR(1000),
    media_type VARCHAR(1000),
    service_version VARCHAR(1000),
    title VARCHAR(1000),
    url VARCHAR(1000)
);

SELECT * FROM apod

INSERT INTO apod 
    (copyright, date, explanation, hdurl, media_type, service_version, title, url) 
VALUES 
    ('Teste banco', '2026-04-21', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste')



    