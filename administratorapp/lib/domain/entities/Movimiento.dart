import 'package:administratorapp/domain/entities/Producto.dart';
import 'package:administratorapp/domain/entities/Usuario.dart';

enum TipoMovimiento {
  INGRESO,
  EGRESO,
}

class Movimiento {
  final int movimientoid;
  final TipoMovimiento tipoMovimiento;
  final int cantidad;
  final DateTime fecha;
  final Producto producto;
  final Usuario usuario;

  Movimiento({
    required this.movimientoid,
    required this.tipoMovimiento,
    required this.cantidad,
    required this.fecha,
    required this.producto,
    required this.usuario,
  });
}
