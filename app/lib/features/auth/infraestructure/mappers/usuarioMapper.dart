import 'package:app/features/auth/domain/domain.dart';

class Usuariomapper {
  static Usuario userJsonToEntity(Map<String, dynamic> json) => Usuario(
        usuarioid: json["id"],
        nombre: json["name"],
        contrasena: json["username"],
        email: json["email"],
        token: json['token'],
      );
}
