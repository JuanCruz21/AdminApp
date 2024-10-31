import 'package:administratorapp/domain/entities/Usuario.dart';

abstract class Usuariodatasource {
  Future<List<Usuario>> getUsuarios();
}
