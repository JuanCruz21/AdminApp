import 'package:app/features/auth/domain/entities/user.dart';

abstract class Authrepository {
  Future<Usuario> login(String email, String contrasena);
  Future<Usuario> register(String email, String contrasena, String nombre);
  Future<void> logout();
  Future<Usuario> getCurrentUser(String token);
}
