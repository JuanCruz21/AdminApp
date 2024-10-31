import 'package:administratorapp/config/constants/enviroment.dart';
import 'package:administratorapp/domain/datasource/usuarioDataSource.dart';
import 'package:administratorapp/domain/entities/Usuario.dart';
import 'package:dio/dio.dart';

class AdmindbDatasource extends Usuariodatasource {
  final dio = Dio(BaseOptions(baseUrl: Enviroment.baseUrl));
  @override
  Future<List<Usuario>> getUsuarios() async {
    final response = await dio.get('/usuarios');
    if (response.statusCode == 200) {
      final List<dynamic> usuariosMap = response.data;
      List<Usuario> usuarios =
          usuariosMap.map((usuario) => Usuario.fromMap(usuario)).toList();
      return usuarios;
    } else {
      throw Exception('Failed to load usuarios');
    }
  }
}
