-- Criar o banco de dados AgroVA se não existir
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'AgroVA')
BEGIN
    CREATE DATABASE AgroVA;
END
GO

-- Usar o banco de dados AgroVA
USE AgroVA;
GO

-- Criar um usuário de banco de dados (Opcional, se não quiser usar `sa`)
IF NOT EXISTS (SELECT * FROM sys.syslogins WHERE name = 'agrova_user')
BEGIN
    CREATE LOGIN agrova_user WITH PASSWORD = 'YourStrong!Passw0rd';
    CREATE USER agrova_user FOR LOGIN agrova_user;
    ALTER ROLE db_owner ADD MEMBER agrova_user;
END
GO
