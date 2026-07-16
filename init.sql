CREATE TABLE IF NOT EXISTS HealthChecks
(
    Id SERIAL PRIMARY KEY,
    Status VARCHAR(20) NOT NULL,
    ResponseTimeMs INT NOT NULL,
    CheckedAt TIMESTAMP NOT NULL
);

INSERT INTO HealthChecks (Status, ResponseTimeMs, CheckedAt)
VALUES ('Healthy', 12, NOW());