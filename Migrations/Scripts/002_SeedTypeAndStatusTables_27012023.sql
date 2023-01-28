IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ProductStatus')
BEGIN	
	DELETE FROM ProductStatus
	DBCC CHECKIDENT (ProductStatus, RESEED, 0)

	INSERT INTO ProductStatus VALUES
	('Disponível'),
	('Em Espera'),
	('Esgotado'),
	('Vendido')
END
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ProductTypes')
BEGIN	
	DELETE FROM ProductTypes
	DBCC CHECKIDENT (ProductTypes, RESEED, 0)

	INSERT INTO ProductTypes VALUES
	('Pintura a Óleo'),
	('Outros')
END
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ProfileTypes')
BEGIN	
	DELETE FROM ProfileTypes
	DBCC CHECKIDENT (ProfileTypes, RESEED, 0)

	INSERT INTO ProfileTypes VALUES
	('Administrador'),
	('Visitante')
END
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SaleStatus')
BEGIN	
	DELETE FROM SaleStatus
	DBCC CHECKIDENT (SaleStatus, RESEED, 0)

	INSERT INTO SaleStatus VALUES
	('Pedido Realizado'),
	('Pagamento em Análise'),
	('Pagamento Confirmado'),
	('Pedido em Separação'),
	('Pedido Enviado'),
	('Pedido Entregue')
END
GO