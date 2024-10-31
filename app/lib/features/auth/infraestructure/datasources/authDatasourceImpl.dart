import 'package:app/config/constants/environment.dart';
import 'package:app/features/auth/domain/domain.dart';
import 'package:app/features/auth/infraestructure/errors/AuthErrors.dart';
import 'package:app/features/auth/infraestructure/mappers/usuarioMapper.dart';
import 'package:dio/dio.dart';

class Authdatasourceimpl extends Authdatasources {
  final dio = Dio(BaseOptions(baseUrl: Enviroment.baseUrl));

  @override
  Future<Usuario> getCurrentUser(String token) {
    // TODO: implement getCurrentUser
    throw UnimplementedError();
  }

  @override
  Future<Usuario> login(String email, String contrasena) async {
    try {
      final response = await dio.post('/api/Usuarios/login', data: {
        'email': email,
        'contrasena': contrasena,
      });
      print(response.data);
      final user = Usuariomapper.userJsonToEntity(response.data);
      return user;
    } catch (e) {
      throw Exception('Failed to login $e');
    }
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
