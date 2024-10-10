use NEBULOUS;
/* LEER */
/* Obtener todos los registros de una tabla */
exec dbo.getRegisters @tableName = 'OperationDetail';
/* Obtener un registro en espec�fico */
exec dbo.getOneRegister @id = 2, @tableName = 'Operation';
/* Obtener sesi�n de usuario */
exec dbo.getSession @user_ = 'herreraalvaro042@gmail.com', @password_ = '123';

/* Filtro para optener detalle de operaci�n */
select MovementType.movementType movementType, Operation.codeReference as codeReference, OperationDetail.idProduct, OperationDetail.unityPrice, OperationDetail.amount
from MovementType, Operation, OperationDetail
where MovementType.id = Operation.idMovementType and OperationDetail.codeReferenceOperation = Operation.codeReference and Operation.codeReference = 'cdb001';

/* ELIMINAR */
/* Eliminar un registro en espec�fico */
exec dbo.dataDelete @id = 2, @codeReferenceOp = '', @tableName = 'User_';
/* Eliminar todos los registros */
delete from User_;
delete from UserSession;
delete from Supplier;
delete from ProductBrands;
delete from Store;
delete from ProductCategory;
delete from ProductSubCategory; 
delete from Product;
delete from OperationDetail;
delete from Operation;

/* INSERTAR */
/* Registrar Usuario y Credenciales de sesi�n del usuario */
exec dbo.iUser @firstName = 'Alvaro Dami�n', @lastName = 'Herrera Guti�rrez', @user_ = 'herreraalvaro042@gmail.com', @password_= '123';
/* Registrar Proveedores */
exec dbo.iSupplier @supplier = 'Coca-Cola', @details = 'Corporaci�n multinacional estadounidense de bebidas.';
exec dbo.iSupplier @supplier = 'Pepsi', @details = 'Corporaci�n multinacional estadounidense de bebidas.';
/* Registrar Marcas de productos de Proveedores */
exec dbo.iProductBrands @idSupplier = 1, @brand = 'Fanta';
exec dbo.iProductBrands @idSupplier = 1, @brand = 'Sprite';
exec dbo.iProductBrands @idSupplier = 1, @brand = 'Powerade';
/* Registrar Categor�a de productos */
exec dbo.iProductCategory @category = 'Bebidas', @details = 'Bebidas ingeribles.';
/* Registrar SubCategor�a de productos */
exec dbo.iProductSubCategory @idProductCategory = 1, @product = 'Gaseosa', @details = 'Bebida gaseosa.';
/* Registrar Producto */
exec dbo.iProduct @idProductSubCategory = 1, @idBrand = 1, @unity = 'Litros', @extent = 1, @idCategory = 1;
exec dbo.iProduct @idProductSubCategory = 1, @idBrand = 2, @unity = 'Litros', @extent = 2, @idCategory = 1;
exec dbo.iProduct @idProductSubCategory = 1, @idBrand = 3, @unity = 'Litros', @extent = 3, @idCategory = 1;
/* Registrar una Operaci�n Compra */
exec dbo.iOperation @idMovementType = 1, @idSupplier = 1, @concept = 'Compra de bebidas.', @codeReference = 'cdb001';
/* Registrar items a Operaci�n Compra (Detalle de operaci�n)*/
exec dbo.iOperationDetail @idMovementType = 1, @codeReferenceOperation = 'cdb001', @idProduct = 1, @unityCost = 25, @unityPrice = 35, @amount = 10, @subTotal = 250;
/* Registrar una Operaci�n Venta */
exec dbo.iOperation @idMovementType = 2, @idSupplier = 1, @concept = 'Venta de bebidas.', @codeReference = 'v0001';
/* Registrar items a Operaci�n Venta (Detalle de operaci�n)*/
exec dbo.iOperationDetail @idMovementType = 2, @codeReferenceOperation = 'v0001', @idProduct = 1, @unityCost = 25, @unityPrice = 35, @amount = 6, @subTotal = 350;

/* MODIFICAR */
/* Usuario y Credenciales de Sesi�n del Usuario */
exec dbo.mUser @id = 1, @firstName = 'Alvaro Dami�n', @lastName = 'Herrera Guti�rrez', @user_='herreraalvaro042@gmail.com', @password_ = '123';
/* Proveedor */
exec dbo.mSupplier @id = 1, @supplier = 'Coca-Cola', @details = 'Corporaci�n multinacional estadounidense de bebidas.';
/* Marca de productos */
exec dbo.mProductBrands @id = 1, @idSupplier = 1, @brand = 'Fanta';
/* Categor�a de producto */
exec dbo.mProductCategory @id = 1, @category = 'Bebidas', @details = 'Bebidas ingeribles';
/* Subcategor�a de producto */
exec dbo.mProductSubCategory @id = 1, @idProductCategory = 1, @product = 'Gaseosa', @details = 'Bebida gaseosa.';
/* Producto */
exec dbo.mProduct @id = 1, @idProductSubCategory = 1, @idBrand = 1, @unity = 'Litros', @extent = 1, @idCategory = 1, @unityPrice = 35;
/* Operaci�n */
exec dbo.mOperation @id = 1, @idSupplier = 1, @concept = 'Compra de bebidas.';
/* Detalle de operaci�n */
/* Compra */
exec dbo.mOperationDetail @id = 1, @codeReferenceOperation = 'cdb001', @idProduct = 1, @unityCost = 20, @unityPrice = 30, @amount = 3, @subTotal = 60, @idMovementType = 1;
/* Venta */
exec dbo.mOperationDetail @id = 2, @codeReferenceOperation = 'v0001', @idProduct = 1, @unityCost = 20, @unityPrice = 30, @amount = 2, @subTotal = 180, @idMovementType = 2;
