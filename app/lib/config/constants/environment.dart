import 'package:flutter_dotenv/flutter_dotenv.dart';

class Enviroment {
  static Future<void> initEnviroment() async {
    await dotenv.load(fileName: ".env");
  }

  static String baseUrl =
      dotenv.env['BASE_URL'] ?? 'no hay esta configurada la BASE_URL';
}
