use NEBULOUS;
/* LEER */
/* Obtener todos los registros de una tabla */
exec dbo.getRegisters @tableName = 'OperationDetail';
/* Obtener un registro en específico */
exec dbo.getOneRegister @id = 2, @tableName = 'Operation';
/* Obtener sesión de usuario */
exec dbo.getSession @user_ = 'herreraalvaro042@gmail.com', @password_ = '123';

/* Filtro para optener detalle de operación */
select MovementType.movementType movementType, Operation.codeReference as codeReference, OperationDetail.idProduct, OperationDetail.unityPrice, OperationDetail.amount
from MovementType, Operation, OperationDetail
where MovementType.id = Operation.idMovementType and OperationDetail.codeReferenceOperation = Operation.codeReference and Operation.codeReference = 'cdb001';

/* ELIMINAR */
/* Eliminar un registro en específico */
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
/* Registrar Usuario y Credenciales de sesión del usuario */
exec dbo.iUser @firstName = 'Alvaro Damián', @lastName = 'Herrera Gutiérrez', @user_ = 'herreraalvaro042@gmail.com', @password_= '123';
/* Registrar Proveedores */
exec dbo.iSupplier @supplier = 'Coca-Cola', @details = 'Corporación multinacional estadounidense de bebidas.';
exec dbo.iSupplier @supplier = 'Pepsi', @details = 'Corporación multinacional estadounidense de bebidas.';
/* Registrar Marcas de productos de Proveedores */
exec dbo.iProductBrands @idSupplier = 1, @brand = 'Fanta';
exec dbo.iProductBrands @idSupplier = 1, @brand = 'Sprite';
exec dbo.iProductBrands @idSupplier = 1, @brand = 'Powerade';
/* Registrar Categoría de productos */
exec dbo.iProductCategory @category = 'Bebidas', @details = 'Bebidas ingeribles.';
/* Registrar SubCategoría de productos */
exec dbo.iProductSubCategory @idProductCategory = 1, @product = 'Gaseosa', @details = 'Bebida gaseosa.';
/* Registrar Producto */
exec dbo.iProduct @idProductSubCategory = 1, @idBrand = 1, @unity = 'Litros', @extent = 1, @idCategory = 1;
exec dbo.iProduct @idProductSubCategory = 1, @idBrand = 2, @unity = 'Litros', @extent = 2, @idCategory = 1;
exec dbo.iProduct @idProductSubCategory = 1, @idBrand = 3, @unity = 'Litros', @extent = 3, @idCategory = 1;
/* Registrar una Operación Compra */
exec dbo.iOperation @idMovementType = 1, @idSupplier = 1, @concept = 'Compra de bebidas.', @codeReference = 'cdb001';
/* Registrar items a Operación Compra (Detalle de operación)*/
exec dbo.iOperationDetail @idMovementType = 1, @codeReferenceOperation = 'cdb001', @idProduct = 1, @unityCost = 25, @unityPrice = 35, @amount = 10, @subTotal = 250;
/* Registrar una Operación Venta */
exec dbo.iOperation @idMovementType = 2, @idSupplier = 1, @concept = 'Venta de bebidas.', @codeReference = 'v0001';
/* Registrar items a Operación Venta (Detalle de operación)*/
exec dbo.iOperationDetail @idMovementType = 2, @codeReferenceOperation = 'v0001', @idProduct = 1, @unityCost = 25, @unityPrice = 35, @amount = 6, @subTotal = 350;

/* MODIFICAR */
/* Usuario y Credenciales de Sesión del Usuario */
exec dbo.mUser @id = 1, @firstName = 'Alvaro Damián', @lastName = 'Herrera Gutiérrez', @user_='herreraalvaro042@gmail.com', @password_ = '123';
/* Proveedor */
exec dbo.mSupplier @id = 1, @supplier = 'Coca-Cola', @details = 'Corporación multinacional estadounidense de bebidas.';
/* Marca de productos */
exec dbo.mProductBrands @id = 1, @idSupplier = 1, @brand = 'Fanta';
/* Categoría de producto */
exec dbo.mProductCategory @id = 1, @category = 'Bebidas', @details = 'Bebidas ingeribles';
/* Subcategoría de producto */
exec dbo.mProductSubCategory @id = 1, @idProductCategory = 1, @product = 'Gaseosa', @details = 'Bebida gaseosa.';
/* Producto */
exec dbo.mProduct @id = 1, @idProductSubCategory = 1, @idBrand = 1, @unity = 'Litros', @extent = 1, @idCategory = 1, @unityPrice = 35;
/* Operación */
exec dbo.mOperation @id = 1, @idSupplier = 1, @concept = 'Compra de bebidas.';
/* Detalle de operación */
/* Compra */
exec dbo.mOperationDetail @id = 1, @codeReferenceOperation = 'cdb001', @idProduct = 1, @unityCost = 20, @unityPrice = 30, @amount = 3, @subTotal = 60, @idMovementType = 1;
/* Venta */
exec dbo.mOperationDetail @id = 2, @codeReferenceOperation = 'v0001', @idProduct = 1, @unityCost = 20, @unityPrice = 30, @amount = 2, @subTotal = 180, @idMovementType = 2;
