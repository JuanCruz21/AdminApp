import 'package:app/features/auth/domain/domain.dart';
import 'package:app/features/auth/infraestructure/datasources/authDatasourceImpl.dart';

class Authrepositoryimpl extends Authrepository {
  final Authdatasources datasource;
  Authrepositoryimpl({
    Authdatasources? datasoource,
  }) : datasource = datasoource ?? Authdatasourceimpl();
  @override
  Future<Usuario> getCurrentUser(String token) {
    // TODO: implement getCurrentUser
    throw UnimplementedError();
  }

  @override
  Future<Usuario> login(String email, String contrasena) {
    return datasource.login(email, contrasena);
  }

  @override
  Future<void> logout() {
    // TODO: implement logout
    throw UnimplementedError();
  }

  @override
  Future<Usuario> register(String email, String contrasena, String nombre) {
    // TODO: implement register
    throw UnimplementedError();
  }
}
