use NEBULOUS;
go
/* FUNCIONES */
/* Obtener la fecha del día de hoy en formato ("DD/MM/YY") */
create function getTodaysDate()
returns varchar(10)
as
begin
declare @date varchar(10);
set @date = CONVERT(VARCHAR(10), GETDATE(), 3);
return @date;
end;
go
/* Obtener el id máximo de cualquier tabla */
create function getMaxId(@tableName varchar(30))
returns int
as
begin
declare @id int;
set @id = 0;

	if @tableName = 'User_'
begin
	set @id = (select isnull(max(id) + 1, 1) as id from User_);
end
	else if @tableName = 'UserSession'
begin
	set @id = (select isnull(max(id) + 1, 1) as id from UserSession);
end
	else if @tableName = 'UserType'
begin
	set @id = (select isnull(max(id) + 1, 1) as id from UserType);
end
	else if @tableName = 'Supplier'
begin
	set @id = (select isnull(max(id) + 1, 1) as id from Supplier);
end
	else if @tableName = 'Store'
begin
	set @id = (select isnull(max(id) + 1, 1) as id from Store);
end
	else if @tableName = 'ProductCategory'
begin
	set @id = (select isnull(max(id) + 1, 1) as id from ProductCategory);
end
	else if @tableName = 'ProductSubCategory'
begin
	set @id = (select isnull(max(id) + 1, 1) as id from ProductSubCategory);
end
	else if @tableName = 'ProductBrands'
begin
	set @id = (select isnull(max(id) + 1, 1) as id from ProductBrands);
end
	else if @tableName = 'Product'
begin
	set @id = (select isnull(max(id) + 1, 1) as id from Product);
end
	else if @tableName = 'OperationDetail'
begin
	set @id = (select isnull(max(id) + 1, 1) as id from OperationDetail);
end
	else if @tableName = 'Operation'
begin
	set @id = (select isnull(max(id) + 1, 1) as id from Operation);
end
	else /* MovementType */
begin
	set @id = (select isnull(max(id) + 1, 1) as id from MovementType);
end

return @id;
end;
go
/* Obtener las existencias (Unidades) de un producto en específico */
create function getProductStock(@idProduct int)
returns int
as
begin
declare @stock int;
	if exists(select * from Store where idProduct = @idProduct)
begin
	set @stock = (select stock from Store where idProduct = @idProduct);
	return @stock;
end
	else
begin
	set @stock = -1;
end
	return @stock;
end;
go
/* Obtener el monto total de una operación */
create function getTotalOfOperation(@codeReference varchar(30))
returns float
as
begin
declare @total float;
	if exists(select * from Operation where codeReference = @codeReference)
begin
	set @total = (select total from Operation where codeReference = @codeReference);
	return @total;
end
	else
begin
	set @total = -1;
end
return @total;
end;
go
/* ***************************************************************************************** */
/* PROCEDIMIENTOS DE ALMACENADO */
/* INSERTAR */
/* Procedimiento para crear UserSession */
create proc iUserSession
@idUser int,
@user_ varchar(70),
@password_ varchar(50)
as
begin
/* Variables */
declare @id int;
declare @date varchar(10);
	
	/* Validar si existe el usuario */
	if exists (select * from UserSession where lower(user_)= lower(@user_) and lower(password_) = lower(@password_))
		begin
			select 'Las credenciales del usuario ya existen.' as message;
		end
	else
		begin
			/* Id */
			set @id = (select dbo.getMaxId('UserSession') as max_id);

			/* Fecha */
			set @date = (select dbo.getTodaysDate() as date);

			/* Insertar valores */
			insert into UserSession(id, idUser, user_, password_, date) values (@id, @idUser, @user_, @password_, @date);
			
			/* Retorno de resultado*/
			select 'Las credenciales de sesión del usuario se creo correctamente.' as message;
		end
end;
go
/* Procedimiento para crear User_ */
create proc iUser
@firstName varchar(50),
@lastName varchar(50),
@user_ varchar(70),
@password_ varchar(50)
as
begin
/* Variables */
declare @id int;
declare @date varchar(10);
	
	/* Validar si existe el usuario */
	if exists (select * from User_ where lower(firstName)= lower(@firstName))
		begin
			select 'El usuario ya existe.' as message;
		end
	else
		begin
			if exists (select * from UserSession where user_ = @user_)
				begin
					select 'No es posible crear el usuario debido a que ya se encuentra en uso el correo electrónico.' as message;
				end
			else
				begin
					/* Id */
					set @id = (select dbo.getMaxId('User_') as max_id);

					/* Fecha */
					set @date = (select dbo.getTodaysDate() as date);

					/* Insertar valores en tabla User*/
					insert into User_ (id, firstName, lastName, date) values (@id, @firstName, @lastName, @date);

					/* Insertar valores en tabla UserSession*/
					exec dbo.iUserSession @idUser = @id, @user_ = @user_, @password_ = @password_;

					/* Retorno de resultado*/
					select 'El usuario se creo correctamente.' as message;
				end
		end
end;
go
/* Procedimiento para crear Supplier*/
create proc iSupplier
@supplier varchar(100),
@details varchar(150)
as
begin
declare @id int;
declare @date varchar(10);

	if exists(select * from Supplier where supplier = @supplier)
begin
	select 'El proveedor que intenta registrar ya existe en la base de datos' As message;
end
	else
begin
	set @id = (select dbo.getMaxId('Supplier') as max_id);
	set @date = (select dbo.getTodaysDate() as date);
	insert into Supplier (id, supplier, details, date) values (@id, @supplier, @details, @date);
end
end;
go
/* Procedimiento para crear Store*/
create proc iStore
@idProduct int,
@unityPrice float,
@stock int
as
begin
declare @id int;
declare @currentStock int;
	if exists(select * from Store where idProduct = @idProduct)
begin
	set @currentStock = (select dbo.getProductStock(@idProduct) as current_stock);
	update Store set unityPrice = @unityPrice, stock =  @currentStock + @stock where idProduct = @idProduct;
end
	else
begin
	set @id = (select dbo.getMaxId('Store') as max_id);
	insert into Store (id, idProduct, unityPrice, stock) values (@id, @idProduct, @unityPrice, @stock);
end
end;
go
/* Procedimiento para crear ProductCategory*/
create proc iProductCategory
@category varchar(70),
@details varchar(150)
as
begin
declare @id int;

	if exists(select * from ProductCategory where category = @category)
begin
	select 'La categoría de producto que desea registrar ya existe.' as message;
end
	else
begin
	set @id = (select dbo.getMaxId('ProductCategory') as max_id);
	insert into ProductCategory (id, category, details) values (@id, @category, @details);
end
end;
go
/* Procedimiento para crear ProductSubCategory*/
create proc iProductSubCategory
@idProductCategory int,
@product varchar(70),
@details varchar(150)
as
begin
declare @id int;

	if exists(select * from ProductSubCategory where product = @product)
begin
	select 'La subcategoría de producto que desea registrar ya existe.' as message;
end
	else
begin
	set @id = (select dbo.getMaxId('ProductSubCategory') as max_id);
	insert into ProductSubCategory (id, idProductCategory, product, details) values (@id, @idProductCategory, @product, @details);
end
end;
go
/* Procedimiento para crear ProductBrands*/
create proc iProductBrands
@idSupplier int,
@brand varchar(100)
as
begin
declare @id int;
	if exists(select * from ProductBrands where brand = @brand)
begin
	select 'La marca que desea registrar ya existe.' as message;
end
	else
begin
	set @id = (select dbo.getMaxId('ProductBrands') as max_id);
	insert into ProductBrands (id, idSupplier, brand) values (@id, @idSupplier, @brand);
end
end;
go
/* Procedimiento para crear Product */
create proc iProduct
@idProductSubCategory int,
@idBrand int,
@unity varchar(50),
@extent float,
@idCategory int
as
begin
declare @id int;
declare @date varchar(10);
	if exists(select * from Product where idBrand = @idBrand)
begin
	select 'El producto que desea registrar ya se encuentra existente.' as message;
end
	else
begin
	set @id = (select dbo.getMaxId('Product') as max_id);
	set @date = (select dbo.getTodaysDate() as date);
	insert into Product (id, idProductSubCategory, idBrand, unity, extent, idCategory, date) values (@id, @idProductSubCategory, @idBrand, @unity, @extent, @idCategory, @date);
end
end;
go
/* Procedimiento para crear Operation*/
create proc iOperation
@idMovementType int,
@idSupplier int,
@concept varchar(150),
@codeReference varchar(30)
as
begin
declare @id int;
declare @date varchar(10);
	if exists(select * from Supplier where id = @idSupplier)
begin
	set @id = (select dbo.getMaxId('Operation') as max_id);
	set @date = (select dbo.getTodaysDate() as date);
	insert into Operation (id, idMovementType, idSupplier, concept, date, codeReference) values (@id, @idMovementType, @idSupplier, @concept, @date, @codeReference);
end
	else
begin
	select 'El proveedor que seleccionó, no existe.' as message;
end
end;
go
/* Procedimiento para crear OperationDetail*/
create proc iOperationDetail
@idMovementType int,
@codeReferenceOperation varchar(30),
@idProduct int,
@unityCost float,
@unityPrice float,
@amount float,
@subTotal float
as
begin
declare @id int;
declare @date varchar(10);
declare @total float;
declare @stock int;
	if exists (select * from Operation where codeReference = @codeReferenceOperation)
begin
	set @id = (select dbo.getMaxId('OperationDetail') as max_id);
	set @date = (select dbo.getTodaysDate() as date);
	set @stock = (select dbo.getProductStock(@idProduct) as stock);
	/* Registrar Detalle de operación */
	insert into OperationDetail (id, codeReferenceOperation, idProduct, unityCost, unityPrice, amount, subTotal, date) values (@id, @codeReferenceOperation, @idProduct, @unityCost, @unityPrice, @amount, @subTotal, @date);
	/* Actualizar monto total de operación */
	set @total = (select dbo.getTotalOfOperation(@codeReferenceOperation) as total);
	update Operation set total = @total + @subTotal where codeReference = @codeReferenceOperation;
	
	/* Verificar si el producto ya existe en el almacén, sino entonces crearlo */
		if exists(select * from Store where idProduct = @idProduct)
	begin
		/* Actualizar las unidades existentes en el almacén */
		if @idMovementType = 1
	begin
		/* Actualizar las existencias del producto */
		update Store set unityPrice = @unityPrice, stock = @stock + @amount where idProduct = @idProduct;
	end
		else
	begin
		update Store set unityPrice = @unityPrice, stock = @stock - @amount where idProduct = @idProduct;
	end
	end
		else
	begin
		set @id = (select dbo.getMaxId('Store') as max_id);
		set @stock = @amount;
		insert into Store(id, idProduct, unityPrice, stock) values (@id, @idProduct, @unityPrice, @stock);
	end
end
	else
begin
	select 'Error en la operación. No fue posible completar la operación realizada, por favor verifica las credenciales he inténtalo nuevamente.' as message;
end
end;
go
/* LEER */
create proc getRegisters
@tableName varchar(30)
as
begin
    declare @sql nvarchar(max);
	if @tableName = 'allUser´sData'
		begin
			set @sql = 'select * from User_, UserSession where User_.id = UserSession.id';
		end
	else
		begin
			set @sql = 'select * from' + quotename(@tableName);
		end
    exec sp_executesql @sql;
end;
go
create proc getOneRegister
@id int,
@tableName varchar(30)
as
begin
    declare @sql nvarchar(max);
	if @tableName = 'User_'
		begin
			set @sql = N'select * from User_, UserSession where User_.id = @id and UserSession.id = @id';
		end
	else
		begin
			set @sql = N'select * from' + quotename(@tableName) + ' where id = @id';
		end
    exec sp_executesql @sql, N'@id int', @id = @id;
end;
go
create proc getSession
@user_ varchar(70),
@password_ varchar(50)
as
begin
	select * from UserSession where user_ = @user_ and password_ = @password_;
end;
go
/* MODIFICAR */
create proc mSession
@id int,
@state varchar(10)
as
begin
	declare @date varchar(10);
	set @date = (select dbo.getTodaysDate() as date);
	update UserSession set state = @state, date = @date where id = @id;
end;
go
create proc mUser
@id int,
@firstName varchar(50),
@lastName varchar(50),
@user_ varchar(70),
@password_ varchar(50)
as
begin
declare @results int;
set @results = 0;
	if exists(select * from User_, UserSession where User_.id = @id and UserSession.id = @id)
		begin
			update User_ set firstName = @firstName, lastName = @lastName where id = @id;
			update UserSession set user_ = @user_, password_ = @password_ where id = @id;
			set @results = 1;
		end
	else
		begin
			select 'No se consiguió modificar el registro, por favor, verifica las credenciales.' as message;
		end
	return @results;
end;
go
create proc mSupplier
@id int,
@supplier varchar(100),
@details varchar(150)
as
begin
declare @results int;
set @results = 0;
	if exists(select * from Supplier where id = @id)
		begin
			update Supplier set supplier= @supplier, details = @details where id = @id;
			set @results = 1;
		end
	else
		begin
			select 'No se consiguió modificar el registro, por favor, verifica las credenciales.' as message;
		end
	return @results;
end;
go
create proc mProductBrands
@id int,
@idSupplier int,
@brand varchar(100)
as
begin
declare @results int;
set @results = 0;
	if exists(select * from ProductBrands where id = @id)
		begin
			update ProductBrands set idSupplier = @idSupplier, brand = @brand where id = @id;
			set @results = 1;
		end
	else
		begin
			select 'No se consiguió modificar el registro, por favor, verifica las credenciales.' as message;
		end
	return @results;
end;
go
create proc mProductCategory
@id int,
@category varchar(70),
@details varchar(150)
as
begin
declare @results int;
set @results = 0;
	if exists(select * from ProductCategory where id = @id)
		begin
			update ProductCategory set category= @category, details = @details where id = @id;
			set @results = 1;
		end
	else
		begin
			select 'No se consiguió modificar el registro, por favor, verifica las credenciales.' as message;
		end
	return @results;
end;
go
create proc mProductSubCategory
@id int,
@idProductCategory varchar(70),
@product varchar(70),
@details varchar(150)
as
begin
declare @results int;
set @results = 0;
	if exists(select * from ProductCategory where id = @id)
		begin
			update ProductSubCategory set idProductCategory= @idProductCategory, product = @product, details = @details where id = @id;
			set @results = 1;
		end
	else
		begin
			select 'No se consiguió modificar el registro, por favor, verifica las credenciales.' as message;
		end
	return @results;
end;
go
create proc mProduct
@id int,
@idProductSubCategory int,
@idBrand int,
@unity varchar(50),
@extent float,
@idCategory int,
@unityPrice float
as
begin
declare @results int;
set @results = 0;
	if exists(select * from Product where id = @id)
		begin
			update Product set idProductSubCategory= @idProductSubCategory, idBrand = @idBrand, unity = @unity,  extent = @extent, idCategory = @idCategory where id = @id;
			/* Modificar datos del producto en almacén */
			if exists(select * from Store where idProduct = @id)
				begin
					update Store set unityPrice = @unityPrice where idProduct = @id;
				end
			else
				begin
					select 'No se consiguió modificar el registro del almacén, por favor, verifica las credenciales.' as message;
				end
			set @results = 1;
		end
	else
		begin
			select 'No se consiguió modificar el registro, por favor, verifica las credenciales.' as message;
		end
	return @results;
end;
go
create proc mOperation
@id int,
@idSupplier int,
@concept varchar(150)
as
begin
declare @results int;
set @results = 0;
	if exists(select * from Operation where id = @id)
		begin
			update Operation set idSupplier= @idSupplier, concept = @concept where id = @id;
			set @results = 1;
		end
	else
		begin
			select 'No se consiguió modificar el registro, por favor, verifica las credenciales.' as message;
		end
	return @results;
end;
go
create proc mOperationDetail
@id int,
@codeReferenceOperation varchar(30),
@idProduct int,
@unityCost float,
@unityPrice float,
@amount float,
@subTotal float,
@idMovementType int
as
begin
declare @results int;
declare @date varchar(10);
declare @stock int;
declare @oldAmount float;
declare @oldSubTotal float;
declare @oldTotal float;

set @results = 0;
	if exists(select * from OperationDetail where id = @id and codeReferenceOperation = @codeReferenceOperation)
		begin
			set @stock = (select dbo.getProductStock(@idProduct) as stock);
			set @oldAmount = (select amount from OperationDetail where id = @id);
			/* Actualizar el almacén */
				if exists(select * from Store where idProduct = @idProduct)
					begin
						if @idMovementType = 1 /* Compra */
							begin
								if @oldAmount < @amount
									begin
										update Store set unityPrice = @unityPrice, stock = @stock + (@amount - @oldAmount) where idProduct = @idProduct;
									end
								else if @oldAmount > @amount
									begin
										update Store set unityPrice = @unityPrice, stock = @stock - (@oldAmount - @amount) where idProduct = @idProduct;
									end
								else /* Es el mismo monto de compra*/
									begin
										update Store set unityPrice = @unityPrice where idProduct = @idProduct;
									end
							end
						else /* Venta */
							begin
								if @oldAmount < @amount
									begin
										update Store set unityPrice = @unityPrice, stock = @stock - (@amount - @oldAmount) where idProduct = @idProduct;
									end
								else if @oldAmount > @amount
									begin
										update Store set unityPrice = @unityPrice, stock = @stock + (@oldAmount - @amount) where idProduct = @idProduct;
									end
								else /* Es el mismo monto de compra*/
									begin
										update Store set unityPrice = @unityPrice where idProduct = @idProduct;
									end
							end
					end
				else
					begin
						select 'No se consiguió modificar el registro, por favor, verifica las credenciales.' as message;
					end
			/* Actualizar monto total de operación */
			set @oldTotal = (select dbo.getTotalOfOperation(@codeReferenceOperation) as oldTotal);
			set @oldSubTotal = (select subTotal from OperationDetail where id = @id and idProduct = @idProduct and codeReferenceOperation = @codeReferenceOperation);
				if @oldSubTotal > @subTotal
					begin
						update Operation set total = @oldTotal - (@oldSubTotal - @subTotal) where codeReference = @codeReferenceOperation;
					end
				else if @oldSubTotal < @subTotal
					begin
						update Operation set total = @oldTotal + (@subTotal - @oldSubTotal) where codeReference = @codeReferenceOperation;
					end
				else /* El subtotal es el mismo */
					begin
						update Operation set total = @oldTotal + @subTotal where codeReference = @codeReferenceOperation;
					end
			/* Actualizar el detalle de la operación */
			update OperationDetail set idProduct = @idProduct, unityCost = @unityCost, unityPrice = @unityPrice, amount = @amount, subTotal = @subTotal where id = @id;
			set @results = 1;
		end
	else
		begin
			select 'No se consiguió modificar el registro, por favor, verifica las credenciales.' as message;
		end
	return @results;
end;
go
/* ELIMINAR */
create proc dataDelete
@id int,
@codeReferenceOp varchar(30) null,
@tableName varchar(30)
as
begin
declare @results int;
set @results = 0;

	if @tableName = 'User_'
begin
		if exists(select * from User_ where id = (select id from UserSession where id = @id))
			begin
				delete from User_ where id = @id;
				delete from UserSession where id = @id;
				set @results = 1;
			end
		else
			begin
				select 'No fue posible eliminar el registro debido a que ya no se encuentra existente.' as message;
			end
end
	else if @tableName = 'Supplier'
begin
		if exists(select * from Supplier where id = @id)
			begin
				delete from Supplier where id = @id;
				set @results = 1;
			end
		else
			begin
				select 'No fue posible eliminar el registro debido a que ya no se encuentra existente.' as message;
			end
end
	else if @tableName = 'ProductCategory'
begin
		if exists(select * from ProductCategory where id = @id)
			begin
				if exists(select * from ProductSubCategory where idProductCategory = @id)
					begin
						select 'No fue posible eliminar el registro debido a que hay registros que dependen del que intenta eliminar.' as message;
					end
				else
					begin
						delete from ProductCategory where id = @id;
						set @results = 1;
					end
			end
		else
			begin
				select 'No fue posible eliminar el registro debido a que ya no se encuentra existente.' as message;
			end
end
	else if @tableName = 'ProductSubCategory'
begin
		if exists(select * from ProductSubCategory where id = @id)
			begin
				delete from ProductSubCategory where id = @id;
				set @results = 1;
			end
		else
			begin
				select 'No fue posible eliminar el registro debido a que ya no se encuentra existente.' as message;
			end
end
	else if @tableName = 'ProductBrands'
begin
		if exists(select * from ProductBrands where id = @id)
			begin
				delete from ProductBrands where id = @id;
				set @results = 1;
			end
		else
			begin
				select 'No fue posible eliminar el registro debido a que ya no se encuentra existente.' as message;
			end
end
	else if @tableName = 'Product'
begin
		if exists(select * from Product where id = @id)
			begin
				delete from Product where id = @id;
				set @results = 1;
			end
		else
			begin
				select 'No fue posible eliminar el registro debido a que ya no se encuentra existente.' as message;
			end
end
	else if @tableName = 'OperationDetail'
begin
		if exists(select * from OperationDetail where id = @id and codeReferenceOperation = @codeReferenceOp)
			begin
				delete from OperationDetail where id = @id and codeReferenceOperation = @codeReferenceOp;
				set @results = 1;
			end
		else
			begin
				select 'No fue posible eliminar el registro debido a que ya no se encuentra existente.' as message;
			end
end
	else if @tableName = 'Operation'
begin
		if exists(select * from Operation where id = @id and codeReference = @codeReferenceOp)
			begin
				if exists(select * from OperationDetail where codeReferenceOperation = @codeReferenceOp)
					begin
						select 'No fue posible eliminar el registro debido a que hay registros que dependen del que intenta eliminar.' as message;
					end
				else
					begin
						delete from Operation where id = @id and codeReference = @codeReferenceOp;
						set @results = 1;
					end
			end
		else
			begin
				select 'No fue posible eliminar el registro debido a que ya no se encuentra existente.' as message;
			end
end
	else
begin
	select 'Por favor, ingresa valores válidos.' as message;
end

return @results;
end;
go
