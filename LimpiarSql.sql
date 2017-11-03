USE GD2C2017;
GO

DROP SEQUENCE SUBSELECT.REDENCION_SEQ; 
DROP SEQUENCE SUBSELECT.ITEM_FORMA_PAGO_SEQ;
DROP SEQUENCE SUBSELECT.ITEM_PAGO_SEQ;
DROP SEQUENCE SUBSELECT.ITEM_FACTURA_SEQ;
DROP SEQUENCE SUBSELECT.FACTURA_SEQ;
DROP SEQUENCE SUBSELECT.SUCURSAL_SEQ; 
DROP SEQUENCE SUBSELECT.PERSONA_SEQ;
DROP SEQUENCE SUBSELECT.EMPRESA_SEQ;
DROP SEQUENCE SUBSELECT.RUBRO_SEQ;
DROP SEQUENCE SUBSELECT.DEVOLUION_SEQ; 

DROP TRIGGER  SUBSELECT.TG_ALTA_CLIENTE;
DROP TRIGGER SUBSELECT.TG_QUITAR_ROL_INACTIVO_USUARIOS;


DROP PROCEDURE SUBSELECT.LOGIN_USUARIO;
DROP PROCEDURE SUBSELECT.GET_ROLES_POR_USUARIO; 
DROP PROCEDURE SUBSELECT.GET_SUCURSALES_POR_USUARIO; 
DROP PROCEDURE SUBSELECT.SP_ABM_ROL_ACTIVAR_DESACTIVAR;
DROP PROCEDURE SUBSELECT.SP_ABM_ROL_MODIFICAR_NOMBRE;
DROP PROCEDURE SUBSELECT.SP_ABM_ROL_QUITAR_FUNCIONALIDAD;
DROP PROCEDURE SUBSELECT.SP_ABM_ROL_AGREGAR_FUNCIONALIDAD;
DROP PROCEDURE SUBSELECT.GET_ALL_FUNCIONALIDADES; 
DROP PROCEDURE SUBSELECT.GET_ROLES_POR_DESCRIPCION;
DROP PROCEDURE SUBSELECT.SP_ABM_ROL_ALTA;
DROP PROCEDURE SUBSELECT.GET_FUNCIONALIDADES_POR_ROL; 
DROP PROCEDURE SUBSELECT.SP_MIGRACION_REDENCION;
DROP PROCEDURE SUBSELECT.SP_MIGRACION_PAGO;
DROP PROCEDURE SUBSELECT.SP_MIGRACION_FACTURA;
DROP PROCEDURE SUBSELECT.SP_MIGRACION_SUCURSAL;
DROP PROCEDURE SUBSELECT.SP_MIGRACION_EMPRESA;;
DROP PROCEDURE SUBSELECT.SP_MIGRACION_CLIENTES;
DROP PROCEDURE SUBSELECT.SP_MIGRACION_INSERT_DATOS_FIJOS;
DROP PROCEDURE SUBSELECT.SP_ABM_CLIENTE_ALTA;
DROP PROCEDURE SUBSELECT.SP_ABM_CLIENTE_MODIFICAR;
DROP PROCEDURE SUBSELECT.SP_ABM_CLIENTE_ACTIVAR_DESACTIVAR;
DROP PROCEDURE SUBSELECT.GET_CLIENTES;
DROP PROCEDURE SUBSELECT.GET_CLIENTES_ACTIVOS;
DROP PROCEDURE SUBSELECT.GET_RUBROS;
DROP PROCEDURE SUBSELECT.SP_ABM_EMPRESA_ALTA;
DROP PROCEDURE SUBSELECT.SP_ABM_EMPRESA_MODIFICAR;
DROP PROCEDURE SUBSELECT.SP_ABM_EMPRESA_ACTIVAR_DESACTIVAR;
DROP PROCEDURE SUBSELECT.GET_EMPRESAS;
DROP PROCEDURE SUBSELECT.GET_EMPRESAS_ACTIVAS;
DROP PROCEDURE SUBSELECT.SP_ABM_SUCURSAL_ALTA;
DROP PROCEDURE SUBSELECT.SP_ABM_SUCURSAL_MODIFICAR;
DROP PROCEDURE SUBSELECT.SP_ABM_SUCURSAL_ACTIVAR_DESACTIVAR;
DROP PROCEDURE SUBSELECT.GET_SUCURSALES;
DROP PROCEDURE SUBSELECT.GET_SUCURSALES_ACTIVAS;
DROP PROCEDURE SUBSELECT.SP_ABM_FACTURACION_ALTA;
DROP PROCEDURE SUBSELECT.SP_ABM_ITEM_FACTURA_ALTA;
DROP PROCEDURE SUBSELECT.SP_ABM_FACTURACION_MODIFICACION;
DROP PROCEDURE SUBSELECT.SP_ABM_ITEM_FACTURACION_MODIFICACION;
DROP PROCEDURE SUBSELECT.SP_ABM_PAGO_ALTA;
DROP PROCEDURE SUBSELECT.GET_FACTURA;
DROP PROCEDURE SUBSELECT.GET_FACTURA_NO_VENCIDAS;
DROP PROCEDURE SUBSELECT.GET_ITEMS;
DROP PROCEDURE SUBSELECT.GET_PAGO;
DROP PROCEDURE SUBSELECT.GET_FORMAS_PAGO;
DROP PROCEDURE SUBSELECT.SP_ABM_PAGO_FACTURA_ALTA;
DROP PROCEDURE SUBSELECT.SP_ABM_RENDICION_ALTA;
DROP PROCEDURE SUBSELECT.DEVOLUCION_FACTURAS_PAGADAS;
DROP PROCEDURE SUBSELECT.DEVOLUCION_RENDICION;
DROP PROCEDURE SUBSELECT.GET_LISTADO_1;
DROP PROCEDURE SUBSELECT.GET_LISTADO_2;
DROP PROCEDURE SUBSELECT.GET_LISTADO_3;
DROP PROCEDURE SUBSELECT.GET_LISTADO_4;


DROP FUNCTION SUBSELECT.TRIM;
DROP FUNCTION SUBSELECT.PASSWORD_HASH;

DROP TABLE SUBSELECT.USUARIO_SUCURSAL;
DROP TABLE SUBSELECT.ROL_FUNCIONALIDAD;
DROP TABLE SUBSELECT. USUARIO_ROL;
DROP TABLE SUBSELECT.USUARIO;
DROP TABLE SUBSELECT.ROL;
DROP TABLE SUBSELECT.FUNCIONALIDAD;
DROP TABLE SUBSELECT.DEVOLUCION_REDENCION;
DROP TABLE SUBSELECT.DEVOLUCION_FACTURA;
DROP TABLE SUBSELECT.DEVOLUCION;
DROP TABLE SUBSELECT.REDENCION_FACTURA;
DROP TABLE SUBSELECT.REDENCION;
DROP TABLE SUBSELECT.PAGO_FACTURAS;
DROP TABLE SUBSELECT.PAGO;
DROP TABLE SUBSELECT.FORMA_PAGO;
DROP TABLE SUBSELECT.ITEM;
DROP TABLE SUBSELECT.FACTURA;
DROP TABLE SUBSELECT.EMPRESA;
DROP TABLE SUBSELECT.RUBRO;
DROP TABLE SUBSELECT.CLIENTE;
DROP TABLE SUBSELECT.SUCURSAL;


DROP SCHEMA SUBSELECT;

GO
